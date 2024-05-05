using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using DataType = MGS1_MC_Cheat_Trainer.Constants.DataType;

namespace MGS1_MC_Cheat_Trainer
{
    public class MemoryManager
    {
        private static MemoryManager _instance;

        public static MemoryManager Instance => _instance ?? (_instance = new MemoryManager());

        public static class NativeMethods
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesRead);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool CloseHandle(IntPtr hObject);

        }

        public static IntPtr PROCESS_BASE_ADDRESS = IntPtr.Zero;

        public static Process GetMGS1Process()
        {
            Process? process = Process.GetProcessesByName(Constants.PROCESS_NAME).FirstOrDefault();
            if (process == null)
            {
               
            }
            return process;
        }

        public static IntPtr OpenGameProcess(Process process)
        {
            if (process == null)
            {
                return IntPtr.Zero;
            }

            IntPtr processHandle = NativeMethods.OpenProcess(0x1F0FFF, false, process.Id);
            if (processHandle == IntPtr.Zero)
            {
            }

            return processHandle;
        }

        public static bool ReadProcessMemory(IntPtr processHandle, IntPtr address, byte[] buffer, uint size, out int bytesRead)
        {
            return NativeMethods.ReadProcessMemory(processHandle, address, buffer, size, out bytesRead);
        }

        public static byte[] ReadMemoryBytes(IntPtr processHandle, IntPtr address, int bytesToRead)
        {
            byte[] buffer = new byte[bytesToRead];
            if (NativeMethods.ReadProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out _))
            {
                return buffer;
            }
            return null;
        }

        public static string ReadMemoryValueAsString(IntPtr processHandle, IntPtr address, int bytesToRead, DataType dataType)
        {
            Process process = GetMGS1Process();
            if (process == null || process.MainModule == null)
            {
                return "Process not found or has exited.";
            }

            byte[] buffer = ReadMemoryBytes(processHandle, address, bytesToRead);
            string addressHex = $"0x{address.ToInt64():X}";
            string moduleOffset = $"METAL GEAR SOLID.exe+{(address.ToInt64() - process.MainModule.BaseAddress.ToInt64()):X}";

            if (buffer == null || buffer.Length != bytesToRead)
                return $"Failed to read memory from: {moduleOffset} (Address: {addressHex}).";

            return FormatMemoryRead(buffer, bytesToRead, addressHex, moduleOffset, dataType);
        }

        private static string FormatMemoryRead(byte[] buffer, int bytesToRead, string addressHex, string moduleOffset, DataType dataType)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Address: {addressHex}\n");

            switch (dataType)
            {
                case DataType.UInt8:
                    result.Append($"UInt8/Byte\nValue in Decimal: {buffer[0]}\nValue in Hex: {buffer[0]:X2}\n");
                    break;
                case DataType.Int8:
                    sbyte sbyteVal = (sbyte)buffer[0];
                    result.Append($"Int8/Signed Byte\nValue in Decimal: {sbyteVal}\nValue in Hex: {sbyteVal:X2}\n");
                    break;
                case DataType.Int16:
                    short shortVal = BitConverter.ToInt16(buffer, 0);
                    result.Append($"Int16\nValue in Decimal: {shortVal}\nValue in Hex: {shortVal:X4}\n");
                    break;
                case DataType.UInt16:
                    ushort ushortVal = BitConverter.ToUInt16(buffer, 0);
                    result.Append($"UInt16\nValue in Decimal: {ushortVal}\nValue in Hex: {ushortVal:X4}\n");
                    break;
                case DataType.Int32:
                    int intVal = BitConverter.ToInt32(buffer, 0);
                    result.Append($"Int32\nValue in Decimal: {intVal}\nValue in Hex: {intVal:X8}\n");
                    break;
                case DataType.UInt32:
                    uint uintVal = BitConverter.ToUInt32(buffer, 0);
                    result.Append($"UInt32\nValue in Decimal: {uintVal}\nValue in Hex: {uintVal:X8}\n");
                    break;
                case DataType.Int64:
                    long longVal = BitConverter.ToInt64(buffer, 0);
                    result.Append($"Int64\nValue in Decimal: {longVal}\nValue in Hex: {longVal:X16}\n");
                    break;
                case DataType.UInt64:
                    ulong ulongVal = BitConverter.ToUInt64(buffer, 0);
                    result.Append($"UInt64\nValue in Decimal: {ulongVal}\nValue in Hex: {ulongVal:X16}\n");
                    break;
                case DataType.Float:
                    float floatVal = BitConverter.ToSingle(buffer, 0);
                    result.Append($"Float\nValue in Decimal: {floatVal}\nValue in Hex: {BitConverter.ToInt32(buffer, 0):X8}\n");
                    break;
                case DataType.Double:
                    double doubleVal = BitConverter.ToDouble(buffer, 0);
                    result.Append($"Double\nValue in Decimal: {doubleVal}\nValue in Hex: {BitConverter.ToInt64(buffer, 0):X16}\n");
                    break;
                case DataType.ByteArray:
                    result.Append("Byte Array\nValues in Decimal: ");
                    for (int i = 0; i < bytesToRead; i++)
                    {
                        result.Append($"{buffer[i]} ");
                    }
                    result.Append("\nValues in Hex: ");
                    for (int i = 0; i < bytesToRead; i++)
                    {
                        result.Append($"{buffer[i]:X2} ");
                    }
                    break;
                default:
                    throw new InvalidOperationException("Unsupported data type.");
            }

            return result.ToString().Trim();
        }

        public static bool WriteMemory<T>(IntPtr processHandle, IntPtr address, T value)
        {
            byte[] buffer;

            if (typeof(T) == typeof(byte[]))
            {
                buffer = value as byte[];
            }
            else
            {
                int size = Marshal.SizeOf(typeof(T));
                buffer = new byte[size];
                IntPtr ptr = Marshal.AllocHGlobal(size);
                try
                {
                    Marshal.StructureToPtr(value, ptr, false);
                    Marshal.Copy(ptr, buffer, 0, size);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }

            return NativeMethods.WriteProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out _);
        }

        public IntPtr ScanMemory(IntPtr processHandle, IntPtr startAddress, long size, byte[] pattern, string mask)
        {
            // 64 KB buffer
            int bufferSize = 65536;
            byte[] buffer = new byte[bufferSize];
            int bytesRead;

            long endAddress = startAddress.ToInt64() + size;
            for (long address = startAddress.ToInt64(); address < endAddress; address += bufferSize)
            {
                int effectiveSize = (int)Math.Min(bufferSize, endAddress - address);
                bool success = ReadProcessMemory(processHandle, new IntPtr(address), buffer, (uint)effectiveSize, out bytesRead);
                if (!success || bytesRead == 0)
                {
                    continue;
                }

                for (int i = 0; i < bytesRead - pattern.Length; i++)
                {
                    if (IsMatch(buffer, i, pattern, mask))
                    {
                        return new IntPtr(address + i);
                    }
                }
            }

            return IntPtr.Zero;
        }

        public IntPtr FindDynamicAob(string key)
        {
            if (!AobManager.AOBs.TryGetValue(key, out var aobData))
            {
                return IntPtr.Zero;
            }

            var process = GetMGS1Process();
            if (process == null || process.MainModule == null)
            {

                return IntPtr.Zero;
            }

            IntPtr processHandle = OpenGameProcess(process);
            if (processHandle == IntPtr.Zero)
            {

                return IntPtr.Zero;
            }

            if (!aobData.StartOffset.HasValue || !aobData.EndOffset.HasValue)
            {

                NativeMethods.CloseHandle(processHandle);
                return IntPtr.Zero;
            }

            IntPtr startAddress = aobData.StartOffset.Value;
            long size = aobData.EndOffset.Value.ToInt64() - startAddress.ToInt64();

            IntPtr foundAddress = ScanMemory(processHandle, startAddress, size, aobData.Pattern, aobData.Mask);

            NativeMethods.CloseHandle(processHandle);

            if (foundAddress == IntPtr.Zero)
            {

            }

            return foundAddress;
        }

        public bool IsMatch(byte[] buffer, int position, byte[] pattern, string mask)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                if (mask[i] == '?' || buffer[position + i] == pattern[i])
                {
                    continue;
                }
                return false;
            }
            return true;
        }

    }
}