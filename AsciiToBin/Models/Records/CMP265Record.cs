using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.Records
{
    public abstract class CMP265Record
    {
        public required char RecordType {get; set;}
        public abstract byte[] ToBinary();
    }
}
