using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.BinaryStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct BarBinaryStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16 + 1)]
        public string? cod_prof;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
        public string? col;

        public short? n_barra_ass;

        float? lung_standard;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7 + 1)]
        public string? rif1;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7 + 1)]
        public string? rif2;

        public short? slats_ass;

        public float? spess;
    }
}
