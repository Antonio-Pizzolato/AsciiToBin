using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.Records
{
    public class LeftPieceDataRecord : CMP265Record
    {

        private float? _l_ext; // Campo di backing per la proprietà
        public float? l_ext
        {
            get => _l_ext;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo l_ext non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo l_ext non può avere più di 5 cifre");
                    }
                }

                _l_ext = value;
            }
        }

        private float? _l_int; // Campo di backing per la proprietà
        public float? l_int
        {
            get => _l_int;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo l_int non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo l_int non può avere più di 5 cifre");
                    }
                }

                _l_int = value;
            }
        }

        private float? _ang_sx; // Campo di backing per la proprietà
        public float? ang_sx
        {
            get => _ang_sx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0450)
                {
                    throw new ArgumentException("Il campo angs_sx non può essere maggiore di 45°");
                }
                _ang_sx = value;
            }
        }

        private float? _ang_dx; // Campo di backing per la proprietà
        public float? ang_dx
        {
            get => _ang_dx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0450)
                {
                    throw new ArgumentException("Il campo angs_dx non può essere maggiore di 45°");
                }
                _ang_dx = value;
            }
        }

        private string? _rif; // Campo di backing per la proprietà
        public string? rif
        {
            get => _rif;

            set
            {
                if (value.Length > 7)
                {
                    throw new ArgumentException("Il campo rif non può avere più di 7 caratteri");
                }
                _rif = value;
            }
        }

        public override byte[] ToBinary()
        {
            return Utilities.BinaryConverter.Convert(this);
        }
    }
}
