using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.Records
{
    public class PieceDataRecord : CMP265Record
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

                _l_ext = value; // Assegnazione al campo di backing
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

                _l_int = value; // Assegnazione al campo di backing
            }
        }

        private float? _angt_sx; // Campo di backing per la proprietà
        public float? angt_sx
        {
            get => _angt_sx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0450)
                {
                    throw new ArgumentException("Il campo angt_sx non può essere maggiore di 45°");
                }
                _angt_sx = value;
            }
        }

        private float? _angp_sx; // Campo di backing per la proprietà
        public float? angp_sx
        {
            get => _angp_sx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0900)
                {
                    throw new ArgumentException("Il campo angp_sx non può essere maggiore di 90°");
                }
                _angp_sx = value;
            }
        }

        private float? _angt_dx; // Campo di backing per la proprietà
        public float? angt_dx
        {
            get => _angt_dx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0450)
                {
                    throw new ArgumentException("Il campo angt_dx non può essere maggiore di 45°");
                }
                _angt_dx = value;
            }
        }

        private float? _angp_dx; // Campo di backing per la proprietà
        public float? angp_dx
        {
            get => _angp_dx;

            set
            {
                if (/*(*/value < 0 /*|| value.ToString("R").Replace("-", "").Replace(".", "").Replace(",", "").Length > 4)*/ && value > 0900)
                {
                    throw new ArgumentException("Il campo angp_dx non può essere maggiore di 90°");
                }
                _angp_dx = value;
            }
        }

        private short? _num_pezzo;
        public short? num_pezzo
        {
            get => _num_pezzo;

            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Il campo num_pezzo non può avere più di 2 cifre");
                }
                _num_pezzo = value;
            }
        }

        private short? _n_carrello;
        public short? n_carrello
        {
            get => _n_carrello;

            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Il campo n_carrello non può avere più di 2 cifre");
                }
                _n_carrello = value;
            }
        }

        private short? _n_slot;
        public short? n_slot
        {
            get => _n_slot;

            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("Il campo n_slot non può avere più di 2 cifre");
                }
                _n_slot = value;
            }
        }

        private long? _n_unico_pezzo;
        public long? n_unico_pezzo
        {
            get => _n_unico_pezzo;
            set
            {
                if (value < 0 || value > 9999999999)
                {
                    throw new ArgumentException("Il campo n_unico_pezzo non può avere più di 10 cifre");
                }
                _n_unico_pezzo = value;
            }
        }

        private string? _id;
        public string? id
        {
            get => _id;
            set
            {
                if (value.Length > 40 && value is not null)
                {
                    throw new ArgumentException("Il campo id non può superare 40 caratteri");
                }
                _id = value;
            }
        }

        private string? _tag_speciale;
        public string? tag_speciale
        {
            get => _tag_speciale;

            set
            {
                if (value.Length > 4 && value is not null)
                {
                    throw new ArgumentException("Il campo tag_speciale non può superare 4 caratteri");
                }
                _tag_speciale = value;
            }
        }

        private string? _ordine;
        public string? ordine
        {
            get => _ordine;

            set
            {
                if (value.Length > 7 && value is not null)
                {
                    throw new ArgumentException("Il campo ordine non può superare 7 caratteri");
                }
                _ordine = value;
            }
        }

        private string? _cliente;
        public string? cliente
        {
            get => _cliente;
            set
            {
                if (value.Length > 30 && value is not null)
                {
                    throw new ArgumentException("Il campo cliente non può superare 30 caratteri");
                }
                _cliente = value;
            }
        }

        private string? _pian_trav1;
        public string? pian_trav1
        {
            get => _pian_trav1;
            set
            {
                if (value.Length > 6 && value is not null)
                {
                    throw new ArgumentException("Il campo pian_trav1 non può superare 6 caratteri");
                }
                _pian_trav1 = value;
            }
        }

        private string? _pian_trav2;
        public string? pian_trav2
        {
            get => _pian_trav2;
            set
            {
                if (value.Length > 6 && value is not null)
                {
                    throw new ArgumentException("Il campo pian_trav2 non può superare 6 caratteri");
                }
                _pian_trav2 = value;
            }
        }

        private string? _pian_trav3;
        public string? pian_trav3
        {
            get => _pian_trav3;
            set
            {
                if (value.Length > 6 && value is not null)
                {
                    throw new ArgumentException("Il campo pian_trav3 non può superare 6 caratteri");
                }
                _pian_trav3 = value;
            }
        }

        private string? _rinf;
        public string? rinf
        {
            get => _rinf;

            set
            {
                if (value.Length > 5 && value is not null)
                {
                    throw new ArgumentException("Il campo rinf non può superare 5 caratteri");
                }
                _rinf = value;
            }
        }

        private string? _fissaggio;
        public string? fissaggio
        {
            get => _fissaggio;

            set
            {
                if (value.Length > 25 && value is not null)
                {
                    throw new ArgumentException("Il campo fissaggio non può superare 25 caratteri");
                }
                _fissaggio = value;
            }
        }

        private string? _cod_tip;
        public string? cod_tip
        {
            get => _cod_tip;

            set
            {
                if (value.Length > 15 && value is not null)
                {
                    throw new ArgumentException("Il campo cod_tip non può superare 15 caratteri");
                }
                _cod_tip = value;
            }
        }

        private string? _f_acqua1;
        public string? f_acqua1
        {
            get => _f_acqua1;

            set
            {
                if (value.Length > 4 && value is not null)
                {
                    throw new ArgumentException("Il campo f_acqua1 non può superare 4 caratteri");
                }
                _f_acqua1 = value;
            }
        }

        private string? _f_acqua2;
        public string? f_acqua2
        {
            get => _f_acqua2;

            set
            {
                if (value.Length > 4 && value is not null)
                {
                    throw new ArgumentException("Il campo f_acqua2 non può superare 4 caratteri");
                }
                _f_acqua2 = value;
            }
        }

        private string? _f_acqua3;
        public string? f_acqua3
        {
            get => _f_acqua3;

            set
            {
                if (value.Length > 4 && value is not null)
                {
                    throw new ArgumentException("Il campo f_acqua1 non può superare 4 caratteri");
                }
                _f_acqua3 = value;
            }
        }

        private string? _note;
        public string? note
        {
            get => _note;
            set
            {
                if (value.Length > 30 && value is not null)
                {
                    throw new ArgumentException("Il campo note non può superare 30 caratteri");
                }
                _note = value;
            }
        }

        private float? _q1; // Campo di backing per la proprietà
        public float? q1
        {
            get => _q1;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo q1 non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo q1 non può avere più di 5 cifre");
                    }
                }

                _q1 = value;
            }
        }

        private float? _q2; // Campo di backing per la proprietà
        public float? q2
        {
            get => _q2;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo q2 non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo q2 non può avere più di 5 cifre");
                    }
                }

                _q2 = value;
            }
        }
        private float? _q3; // Campo di backing per la proprietà
        public float? q3
        {
            get => _q3;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo q3 non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo q3 non può avere più di 5 cifre");
                    }
                }

                _q3 = value;
            }
        }
        private float? _q4; // Campo di backing per la proprietà
        public float? q4
        {
            get => _q4;
            set
            {
                if (value.HasValue)
                {
                    float val = value.Value;

                    if (val < 0)
                    {
                        throw new ArgumentException("Il campo q4 non può essere negativo");
                    }

                    // Formattazione con cultura invariante per evitare problemi con virgole/punti
                    string stringRepresentation = val.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
                    string cleaned = stringRepresentation.Replace("-", "").Replace(".", "").Replace(",", "");

                    if (cleaned.Length > 5)
                    {
                        throw new ArgumentException("Il campo q4 non può avere più di 5 cifre");
                    }
                }

                _q4 = value;
            }
        }

        private string? _info1;
        public string? info1
        {
            get => _info1;

            set
            {
                if (value.Length > 60 && value is not null)
                {
                    throw new ArgumentException("Il campo info2 non può superare 60 caratteri");
                }
                else if (value is null or "")
                {
                    _info1 = "";
                }
                else
                {
                    _info1 = value;
                }
            }
        }

        private string? _info2;
        public string? info2
        {
            get => _info2;

            set
            {
                if (value.Length > 60 && value is not null)
                {
                    throw new ArgumentException("Il campo info2 non può superare 60 caratteri");
                }
                else if (value is null or "")
                {
                    _info2 = "";
                }
                else
                {
                    _info2 = value;
                }
            }
        }

        private string? _info3;
        public string? info3
        {
            get => _info3;

            set
            {
                if (value.Length > 60 && value is not null)
                {
                    throw new ArgumentException("Il campo info2 non può superare 60 caratteri");
                }
                else if (value is null or "")
                {
                    _info3 = "";
                }
                else
                {
                    _info3 = value;
                }
            }
        }

        private string? _info4;
        public string? info4
        {
            get => _info4;

            set
            {
                if (value.Length > 60 && value is not null)
                {
                    throw new ArgumentException("Il campo info2 non può superare 60 caratteri");
                }
                else if (value is null or "")
                {
                    _info4 = "";
                }
                else
                {
                    _info4 = value;
                }
            }
        }

        private string? _info5;
        public string? info5
        {
            get => _info5;

            set
            {
                if (value.Length > 60 && value is not null)
                {
                    throw new ArgumentException("Il campo info2 non può superare 60 caratteri");
                }
                else if (value is null or "")
                {
                    _info5 = "";
                }
                else
                {
                    _info5 = value;
                }
            }
        }

        public override byte[] ToBinary()
        {
            return Utilities.BinaryConverter.Convert(this);
        }

    }
}
