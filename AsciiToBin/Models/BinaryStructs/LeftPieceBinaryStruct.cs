using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AsciiToBin.Models.BinaryStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct LeftPieceBinaryStruct
    {
        public short? n_barra;
        public short? dummy2;
        public float? l_ext;
        public float? l_int;
        public float? ang_sx;
        public float? ang_dx;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]? dummy;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string? rif;
    }
}
