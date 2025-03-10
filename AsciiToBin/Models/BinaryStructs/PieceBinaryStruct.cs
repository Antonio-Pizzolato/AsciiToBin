using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.BinaryStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct PieceBinaryStruct
    {
        public float? l_ext;
        public float? l_int;
        public float? angt_sx;
        public float? angp_sx;
        public float? angt_dx;
        public float? angp_dx;

        public short? num_pezzo;
        public short? n_carrello;
        public short? n_slot;

        public long? n_unico_pezzo;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40 + 1)]
        public string? id;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4 + 1)]
        public string? tag_speciale;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7 + 1)]
        public string? ordine;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30 + 1)]
        public string? cliente;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6 + 1)]
        public string? pian_trav1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6 + 1)]
        public string? pian_trav2;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6 + 1)]
        public string? pian_trav3;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5 + 1)]
        public string? rinf;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 25 + 1)]
        public string? fissaggio;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15 + 1)]
        public string? cod_tip;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4 + 1)]
        public string? f_acqua1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4 + 1)]
        public string? f_acqua2;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4 + 1)]
        public string? f_acqua3;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30 + 1)]
        public string? note;

        public float? q1;
        public float? q2;
        public float? q3;
        public float? q4;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60 + 1)]
        public string? info1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60 + 1)]
        public string? info2;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60 + 1)]
        public string? info3;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60 + 1)]
        public string? info4;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60 + 1)]
        public string? info5;
    }
}
