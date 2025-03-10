using AsciiToBin.Models.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Services
{
    class BinaryWriterService
    {
        public void WriteRecords(List<CMP265Record> records, string outputPath)
        {
            var writers = new Dictionary<char, Action<CMP265Record, BinaryWriter>> {
            { 'L', (r, w) => w.Write(r.ToBinary()) },
            { 'B', (r, w) => w.Write(r.ToBinary()) },
            { 'P', (r, w) => w.Write(r.ToBinary()) },
            { 'R', (r, w) => w.Write(r.ToBinary()) }
        };

            using (var fs = new FileStream(outputPath, FileMode.Create))
            using (var bw = new BinaryWriter(fs))
            {
                foreach (var record in records)
                {
                    writers[record.RecordType](record, bw);
                }
            }
        }
    }
}
