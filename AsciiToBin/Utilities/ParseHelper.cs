using AsciiToBin.Models;
using AsciiToBin.Models.Records;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Utilities
{
    class ParseHelper
    {
        public List<CMP265Record> ParseFile(string filePath)
        {
            var records = new List<CMP265Record>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var fields = ParseLine(line);
                    var record = CreateRecord(fields);
                    if (record != null)
                    {
                        records.Add(record);
                    }
                }
                return records;
            }
        }

        private string[] ParseLine(string line)
        {

            return line.Split(new[] { ',' }, StringSplitOptions.None);

        }

        private CMP265Record? CreateRecord(string[] fields)
        {
            if (fields.Length == 0) return null;

            return fields[0].ToUpper() switch
            {
                "L" => new WorkDataRecord
                {
                    RecordType = 'L',
                    num_lav = SafeGet(fields, 1),
                    stato_lav = SafeGet(fields, 2)
                },
                "B" => new BarDataRecord
                {
                    RecordType = 'B',
                    cod_prof = SafeGet(fields, 1),
                    col = SafeGet(fields, 2),
                    nbarra_ass = SafeParseShort(fields, 3),
                    lung_standard = SafeParseFloat(fields, 4),
                    rif1 = SafeGet(fields, 5),
                    rif2 = SafeGet(fields, 6),
                    slats_ass = SafeParseShort(fields, 7),
                    spess = SafeParseFloat(fields, 8),
                },
                "P" => new PieceDataRecord
                {
                    RecordType = 'P',
                    l_ext = SafeParseFloat(fields, 1),
                    l_int = SafeParseFloat(fields, 2),
                    angt_sx = SafeParseFloat(fields, 3),
                    angp_sx = SafeParseFloat(fields, 4),
                    angt_dx = SafeParseFloat(fields, 5),
                    angp_dx = SafeParseFloat(fields, 6),
                    num_pezzo = SafeParseShort(fields, 7),
                    n_carrello = SafeParseShort(fields, 8),
                    n_slot = SafeParseShort(fields, 9),
                    n_unico_pezzo = SafeParseLong(fields, 10),
                    id = SafeGet(fields, 11),
                    tag_speciale = SafeGet(fields, 12),
                    ordine = SafeGet(fields, 13),
                    cliente = SafeGet(fields, 14),
                    pian_trav1 = SafeGet(fields, 15),
                    pian_trav2 = SafeGet(fields, 16),
                    pian_trav3 = SafeGet(fields, 17),
                    rinf = SafeGet(fields, 18),
                    fissaggio = SafeGet(fields, 19),
                    cod_tip = SafeGet(fields, 20),
                    f_acqua1 = SafeGet(fields, 21),
                    f_acqua2 = SafeGet(fields, 22),
                    f_acqua3 = SafeGet(fields, 23),
                    note = SafeGet(fields, 24),
                    q1 = SafeParseFloat(fields, 25),
                    q2 = SafeParseFloat(fields, 26),
                    q3 = SafeParseFloat(fields, 27),
                    q4 = SafeParseFloat(fields, 28),
                    info1 = SafeGet(fields, 29),
                    info2 = SafeGet(fields, 30),
                    info3 = SafeGet(fields, 31),
                    info4 = SafeGet(fields, 32),
                    info5 = SafeGet(fields, 33),
                },
                "R" => new LeftPieceDataRecord
                {
                    RecordType = 'R',
                    n_barra = SafeParseShort(fields, 1),
                    l_ext = SafeParseFloat(fields, 2),
                    l_int = SafeParseFloat(fields, 3),
                    ang_sx = SafeParseFloat(fields, 4),
                    ang_dx = SafeParseFloat(fields, 5),
                    rif = SafeGet(fields, 6),
                },
                _ => null
            };
        }

        // Metodi helper per la sicurezza
        private static string SafeGet(string[] fields, int index)
        {
            return fields.Length > index ? fields[index] : string.Empty;
        }

        private static int SafeParseInt(string[] fields, int index, int defaultValue = 0)
        {
            string rawValue = SafeGet(fields, index).Trim();
            return int.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out int result)
                ? result
                : defaultValue;
        }


        private static double? SafeParseDouble(string[] fields, int index, double? defaultValue = null)
        {
            string rawValue = SafeGet(fields, index).Trim();

            if (string.IsNullOrWhiteSpace(rawValue))
                return null;

            if (!double.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                Console.WriteLine($"Valore non valido '{rawValue}' nel campo {index}. Usato default: {defaultValue}");
            }
            return result;
        }

        private static float? SafeParseFloat(string[] fields, int index, float? defaultValue = null)
        {
            string rawValue = SafeGet(fields, index).Trim();
            return float.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out float result)
                ? result
                : defaultValue;

        }

        private static short SafeParseShort(string[] fields, int index, short defaultValue = 0)
        {
            string rawValue = SafeGet(fields, index).Trim();
            return short.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out short result)
                ? result
                : defaultValue;
        }

        private static long SafeParseLong(string[] fields, int index, long defaultValue = 0)
        {
            string rawValue = SafeGet(fields, index).Trim();
            return long.TryParse(rawValue, NumberStyles.Any, CultureInfo.InvariantCulture, out long result)
                ? result
                : defaultValue;
        }
    }
}
