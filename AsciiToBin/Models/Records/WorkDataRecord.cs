using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.Records
{
    public class WorkDataRecord : CMP265Record
    {

        // Campi privati per memorizzare i valori
        private string? _num_lav;
        private string? _stato_lav;

        public string? num_lav 
        { 
            get => _num_lav;

            set
            {
                if (value.Length > 8 && value is not null)
                {
                    throw new ArgumentException("Il campo num_lav non può superare gli 8 caratteri");
                }
                _num_lav = value; 
            } 
        }

        public string? stato_lav
        {
            get => _stato_lav;

            set
            {
                if (value.Length > 8 && value is not null)
                {
                    throw new ArgumentException("Il campo stato_lav non può superare gli 8 caratteri");
                }
                _stato_lav = value;
            }
        }

        public override byte[] ToBinary()
        {
            return Utilities.BinaryConverter.Convert(this);
        }
    }
}
