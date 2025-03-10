using AsciiToBin.Models.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiToBin.Utilities
{
    public static class BinaryConverter
    {

        public static class WorkBinaryConverter
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
            public struct NativeStruct
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
                public string? num_lav;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
                public string? stato_lav;
            }
        }

        public static class BarBinaryConverter
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
            public struct NativeStruct
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16 + 1)]
                public string? cod_prof;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8 + 1)]
                public string? col;

                public short? n_barra_ass;

                 public float? lung_standard;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7 + 1)]
                public string? rif1;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7 + 1)]
                public string? rif2;

                public short? slats_ass;

                public float? spess;
            }
        }

        public static class PieceBinaryConverter
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
            public struct NativeStruct
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

        public static class LeftPieceBinaryConverter
        {
            [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
            public struct NativeStruct
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

        


        public static byte[] Convert(WorkDataRecord record)
        {
            WorkBinaryConverter.NativeStruct native = new WorkBinaryConverter.NativeStruct
            {
                num_lav = record.num_lav,
                stato_lav = record.stato_lav
            };
            return StructureToByteArray(native);
        }

        public static byte[] Convert(BarDataRecord record)
        {
            BarBinaryConverter.NativeStruct native = new BarBinaryConverter.NativeStruct
            {
                cod_prof = record.cod_prof,
                col = record.col,
                n_barra_ass = record.nbarra_ass,
                lung_standard = record.lung_standard,
                rif1 = record.rif1,
                rif2 = record.rif2,
                slats_ass = record.slats_ass,
                spess = record.spess

            };
            return StructureToByteArray(native);
        }

        public static byte[] Convert(PieceDataRecord record)
        {
            PieceBinaryConverter.NativeStruct native = new PieceBinaryConverter.NativeStruct
            {
                l_ext = record.l_ext,
                l_int = record.l_int,
                angt_sx = record.angt_sx,
                angp_sx = record.angp_sx,   
                angt_dx = record.angt_dx,
                angp_dx = record.angp_dx,
                num_pezzo = record.num_pezzo,
                n_carrello = record.n_carrello,
                n_slot = record.n_slot, 
                n_unico_pezzo = record.n_unico_pezzo,
                id = record.id,
                tag_speciale = record.tag_speciale,
                ordine = record.ordine,
                cliente = record.cliente,
                pian_trav1 = record.pian_trav1,
                pian_trav2 = record.pian_trav2,
                pian_trav3 = record.pian_trav3,
                rinf = record.rinf,
                fissaggio = record.fissaggio,
                cod_tip = record.cod_tip,
                f_acqua1 = record.f_acqua1,
                f_acqua2 = record.f_acqua2,
                f_acqua3 = record.f_acqua3,
                note = record.note,
                q1 = record.q1,
                q2 = record.q2,
                q3 = record.q3,
                q4 = record.q4,
                info1 = record.info1,
                info2 = record.info2,
                info3 = record.info3,
                info4 = record.info4,
                info5 = record.info5
            };
            return StructureToByteArray(native);
        }

        public static byte[] Convert(LeftPieceDataRecord record)
        {
            LeftPieceBinaryConverter.NativeStruct native = new LeftPieceBinaryConverter.NativeStruct
            {
                n_barra = record.n_barra,
                l_ext = record.l_ext,
                l_int = record.l_int,
                ang_sx = record.ang_sx,
                ang_dx = record.ang_dx,
                rif = record.rif
            };
            return StructureToByteArray(native);
        }

        private static byte[] StructureToByteArray(object obj)
        {
            int size = Marshal.SizeOf(obj);
            IntPtr ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, ptr, false);
            byte[] bytes = new byte[size];
            Marshal.Copy(ptr, bytes, 0, size);
            Marshal.FreeHGlobal(ptr);
            return bytes;
        }

    }
}
