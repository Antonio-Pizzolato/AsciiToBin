using AsciiToBin.Models.Records;
using AsciiToBin.Utilities;
using System.Formats.Tar;
using System.IO;
using System.Text;


class Program
{

    static void Main()
    {

        try
        {

            //string prova = "quattro";
            //byte[] byteArray = Encoding.ASCII.GetBytes(prova);
            //// Conversione in binario
            //string binaryString = StringToBinary(prova);
            //Console.WriteLine("Stringa in binario: " + binaryString);
            //Console.WriteLine(string.Join("",byteArray));
            //static string StringToBinary(string input)
            //{
            //    StringBuilder binary = new StringBuilder();
            //    foreach (char c in input)
            //    {
            //        binary.Append(Convert.ToString(c, 2).PadLeft(8, '0') + " ");
            //    }
            //    return binary.ToString();
            //}

            // 1. Definisci se sovrascrivere i file (true) o aggiungere record (false)
            bool overwriteFiles = true; // Cambia in true per sovrascrivere

            //Lettura file in ingresso
            Console.WriteLine("Enter the file path to save the data: ");
            string filePath = Console.ReadLine();
            string outputDirectory = Path.GetDirectoryName(filePath); // Directory del file di input

            // Se il file di input non ha una directory, usa la cartella "Data" del progetto
            if (string.IsNullOrEmpty(outputDirectory))
            {
                outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            }

            // 3. Inizializza i writer per i file binari
            var writers = new Dictionary<char, (string Extension, Action<CMP265Record, BinaryWriter> WriteAction)>
            {
                { 'L', (".lav", (record, bw) => bw.Write(((WorkDataRecord)record).ToBinary())) },
                { 'B', (".bar", (record, bw) => bw.Write(((BarDataRecord)record).ToBinary())) },
                { 'P', (".pez", (record, bw) => bw.Write(((PieceDataRecord)record).ToBinary())) },
                { 'R', (".pezrim", (record, bw) => bw.Write(((LeftPieceDataRecord)record).ToBinary())) }
            };


            // 2. Parsing del file
            var parser = new ParseHelper();
            List<CMP265Record> records = parser.ParseFile(filePath);



            // 4. Processa ogni record e raccogli i percorsi
            var exportedPaths = new Dictionary<string, string>(); // Tipo file -> Percorso
                                                                  // Scrittura file aggregato
            string allRecordsPath = Path.Combine(outputDirectory, "all.bin");
            using (var fs = new FileStream(allRecordsPath, overwriteFiles ? FileMode.Create : FileMode.Append))
            using (var bw = new BinaryWriter(fs))
            {
                foreach (var record in records)
                {
                    if (writers.TryGetValue(record.RecordType, out var writer))
                    {
                        writer.WriteAction(record, bw);
                    }
                }
            }
            exportedPaths["all.bin"] = allRecordsPath;

            // Scrittura file separati
            foreach (var writer in writers)
            {
                string fileTypePath = Path.Combine(outputDirectory, $"output{writer.Value.Extension}");
                using (var fs = new FileStream(fileTypePath, overwriteFiles ? FileMode.Create : FileMode.Append))
                using (var bw = new BinaryWriter(fs))
                {
                    foreach (var record in records.Where(r => r.RecordType == writer.Key))
                    {
                        writer.Value.WriteAction(record, bw);
                    }
                }
                exportedPaths[writer.Value.Extension] = fileTypePath;
            }


            // 5. Stampa i percorsi dei file esportati
            Console.WriteLine("\nFile esportati:");
            foreach (var kvp in exportedPaths)
            {
                Console.WriteLine($"- {kvp.Key.ToUpper()}: {kvp.Value}");
            }

            // 6. Verifica completamento
            if (exportedPaths.Count > 0)
            {
                Console.WriteLine("\nEsportazione completata con successo!");
            }
            else
            {
                Console.WriteLine("\nNessun file esportato. Verifica i dati di input.");
            }



        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }

    }

}