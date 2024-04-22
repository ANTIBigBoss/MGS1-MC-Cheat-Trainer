using static MGS1_MC_Cheat_Trainer.Constants;

namespace MGS1_MC_Cheat_Trainer
{
    public class AobManager
    {
        private static AobManager instance;
        private static readonly object lockObj = new object();

        private AobManager() { }

        public static AobManager Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new AobManager();
                    }
                    return instance;
                }
            }
        }

        #region AOB Definitions and Functions
        public static readonly Dictionary<string, (byte[] Pattern, string Mask, IntPtr? StartOffset, IntPtr? EndOffset)> AOBs =
            new Dictionary<string, (byte[] Pattern, string Mask, IntPtr? StartOffset, IntPtr? EndOffset)>
            {
                {
                    "MainAOB", // 87 56 43 12 06
                    (new byte[] { 0x87, 0x56, 0x43, 0x12, 0x06 },
                    "87 56 43 12 06",
                    new IntPtr(0x00000000),
                    new IntPtr(0x80000000))
                },
            };

        public IntPtr FoundMainAOBAddress { get; private set; } = IntPtr.Zero;

        public bool FindAndStoreMainAOB()
        {
            if (FoundMainAOBAddress != IntPtr.Zero)
            {
                return true; // Already found, no need to search again
            }
            IntPtr foundAddress = MemoryManager.Instance.FindDynamicAob("MainAOB");
            if (foundAddress != IntPtr.Zero)
            {
                FoundMainAOBAddress = foundAddress;
                return true;
            }
            return false;
        }
        #endregion

        #region Reading Adresses

        #region Current Ammo Read
        public string ReadSocomAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find SOCOM Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.SocomAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2);
        }

        public string ReadFamasAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find FAMAS Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.FamasAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2);
        }


        #endregion

        #region Max Ammo Read
        public string ReadSocomMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find SOCOM Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponMaxAmmo.SocomMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2);
        }

        public string ReadFamasMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find FAMAS Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponMaxAmmo.FamasMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2);
        }

        #endregion

        #endregion


        #region Writing Addresses

        #region Current Ammo Write
        public void WriteSocomAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find SOCOM Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.SocomAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteFamasAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find FAMAS Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.FamasAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }
        #endregion
        
        #region Max Ammo Write

        public void WriteSocomMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find SOCOM Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponMaxAmmo.SocomMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteFamasMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find FAMAS Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponMaxAmmo.FamasMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        #endregion

        #endregion
    }
}
