using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static MGS1_MC_Cheat_Trainer.Constants;
using System.Threading.Tasks;
using static MGS1_MC_Cheat_Trainer.MemoryManager;
using MGS1_MC_Cheat_Trainer;

namespace MGS1_MC_Cheat_Trainer
{
    public class MemoryManager
    {
        private static MemoryManager _instance;

        public static MemoryManager Instance => _instance ?? (_instance = new MemoryManager());

        public static class NativeMethods
        {
            // Declare OpenProcess
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

            // Declare WriteProcessMemory with short
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, ref short lpBuffer, uint nSize, out int lpNumberOfBytesWritten);
            // and with bytes
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

            // Declare ReadProcessMemory
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, out short lpBuffer, uint size, out int lpNumberOfBytesRead);
            // and with bytes
            [DllImport("kernel32.dll")]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesRead);

            // Declare CloseHandle
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

        public static string ReadMemoryValueAsString(IntPtr processHandle, IntPtr address, int bytesToRead)
        {
            Process process = GetMGS1Process();
            if (process == null || process.MainModule == null)
            {
                return "Process not found or has exited.";
            }

            byte[] buffer = ReadMemoryBytes(processHandle, address, bytesToRead);
            string addressHex = $"0x{address.ToInt64():X}";

            if (buffer == null || buffer.Length != bytesToRead)
                return $"Failed to read memory from: (Address: {addressHex}).";

            return FormatMemoryRead(buffer, bytesToRead, addressHex, "0x");
        }

        private static string FormatMemoryRead(byte[] buffer, int bytesToRead, string addressHex, string moduleOffset)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"Address: {addressHex}\n");

            switch (bytesToRead)
            {
                case 1:  // Byte
                    result.Append($"Int8/Byte\nValue in Decimal: {buffer[0]}\nValue in Hex: {buffer[0]:X2}");
                    break;

                case 2:  // Short
                    short shortVal = BitConverter.ToInt16(buffer, 0);
                    result.Append($"Int16/Short\nValue in Decimal: {shortVal}\nValue in Hex: {shortVal:X4}");
                    break;

                case 4:  // Int, UInt, and Float
                    int intVal = BitConverter.ToInt32(buffer, 0);
                    uint uintVal = BitConverter.ToUInt32(buffer, 0);
                    float floatVal = BitConverter.ToSingle(buffer, 0);
                    result.Append($"Int32/Integer\nValue in Decimal: {intVal}\nValue in Hex: {intVal:X8}\n");
                    result.Append($"UInt32/Unsigned Integer\nValue in Decimal: {uintVal}\nValue in Hex: {uintVal:X8}\n");
                    result.Append($"Float\nValue: {floatVal}");
                    break;

                case 6:
                    result.Append("Byte Array (6 bytes)\nValue in Decimal: ");
                    foreach (byte b in buffer)
                        result.Append($"{b} ");
                    result.AppendLine();
                    result.Append("Value in Hex: ");
                    result.Append(BitConverter.ToString(buffer).Replace("-", " "));
                    break;

                case 8:  // Long and Double
                    long longVal = BitConverter.ToInt64(buffer, 0);
                    double doubleVal = BitConverter.ToDouble(buffer, 0);
                    result.Append($"Int64/Long\nValue in Decimal: {longVal}\nValue in Hex: {longVal:X16}\n");
                    result.Append($"Double\nValue: {doubleVal}");
                    break;

                default:  // Arbitrary Byte Array
                    result.Append("Byte Array\nValue in Hex: ");
                    foreach (byte b in buffer)
                        result.Append($"{b:X2} ");
                    break;
            }

            return result.ToString().Trim();  // Trim to remove any trailing spaces
        }

        public static bool WriteMemory<T>(IntPtr processHandle, IntPtr address, T value) where T : struct
        {
            byte[] buffer = GetBytes(value);
            return NativeMethods.WriteProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out _);
        }

        private static byte[] GetBytes<T>(T value) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(value, ptr, true);
                Marshal.Copy(ptr, arr, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
            return arr;
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