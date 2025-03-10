using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.Records
{
    public class BarDataRecord : CMP265Record
    {

        private string? _cod_prof;

        public string? cod_prof
        {
            get => _cod_prof;

            set
            {
                if (value.Length > 16 && value is not null)
                {
                    throw new ArgumentException("Il campo num_barra non può superare 16 caratteri");
                }
                _cod_prof = value;
            }
        }

        private string? _col;
        public string? col
        {
            get => _col;
            set
            {
                if (value.Length > 8 && value is not null)
                {
                    throw new ArgumentException("Il campo col non può superare 8 caratteri");
                }
                _col = value;
            }
        }

        private short? _nbarra_ass;
        public short? nbarra_ass
        {
            get => _nbarra_ass;

            set
            {
                if (value <0 || value > 2)
                {
                    throw new ArgumentException("Il campo nbarra_ass non può superare il valore 2");
                }
                _nbarra_ass = value;
            }
        }

        private float? _lung_standard;
        public float? lung_standard
        {
            get => _lung_standard;

            set
            {
                if (value < 0 || value > 99999)
                {
                    throw new ArgumentException("Il campo lungh_standard non può avere più di 5 caratteri");
                }
                _lung_standard = value;
            }
        }

        private string? _rif1;
        public string? rif1
        {
            get => _rif1;

            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentException("Il campo rif1 non può avere più di 7 caratteri");
                }
                _rif1 = value;
            }
        } 
        
        private string? _rif2;
        public string? rif2
        {
            get => _rif2;

            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentException("Il campo rif2 non può avere più di 7 caratteri");
                }
                _rif2 = value;
            }
        }

        private short? _slats_ass;
        public short? slats_ass
        {
            get => _slats_ass;

            set
            {
                if (value < 0 || value >4)
                {
                    throw new ArgumentException("Il campo slats_ass non può superare il valore 4");
                }
                _slats_ass = value;
            }
        }

        private float? _spess; // Campo di backing per la proprietà
        public float? spess
        {
            get => _spess;

            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo spess non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo spess non può avere più di 5 cifre");
                    }
                }

                _spess = value; // Assegnazione al campo di backing
            }
        }

        public override byte[] ToBinary()
        {
            return Utilities.BinaryConverter.Convert(this);
        }

    }

}
