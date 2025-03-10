using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Models.BinaryStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
    public struct WorkBinaryStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
        public string? num_lav;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
        public string? stato_lav;
    }
}
