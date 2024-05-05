using System.ComponentModel.DataAnnotations;
using static MGS1_MC_Cheat_Trainer.Constants;
using DataType = MGS1_MC_Cheat_Trainer.Constants.DataType;

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
                return true;
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
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }


        public string ReadFamasAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find FAMAS Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.FamasAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadGrenadeAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Grenade Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.GrenadeAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadNikitaAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Nikita Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.NikitaAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadStingerAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Stinger Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StingerAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadClaymoreAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Claymore Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ClaymoreAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadC4Ammo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find C4 Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.C4Ammo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadStunGrenadeAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Stun Grenade Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StunGrenadeAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadChaffGrenadeAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Chaff Grenade Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ChaffGrenadeAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadPSG1Ammo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find PSG1 Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.PSG1Ammo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
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
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.SocomMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadFamasMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find FAMAS Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.FamasMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadGrenadeMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Grenade Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.GrenadeMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadNikitaMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Nikita Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.NikitaMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadStingerMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Stinger Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StingerMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadClaymoreMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Claymore Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ClaymoreMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadC4MaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find C4 Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.C4MaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadStunGrenadeMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Stun Grenade Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StunGrenadeMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadChaffGrenadeMaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Chaff Grenade Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ChaffGrenadeMaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadPSG1MaxAmmo()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find PSG1 Max Ammo address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.PSG1MaxAmmo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
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

        public void WriteGrenadeAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Grenade Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.GrenadeAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteNikitaAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Nikita Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.NikitaAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteStingerAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stinger Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StingerAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteClaymoreAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Claymore Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ClaymoreAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteC4Ammo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find C4 Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.C4Ammo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteStunGrenadeAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stun Grenade Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StunGrenadeAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WriteChaffGrenadeAmmo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Chaff Grenade Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ChaffGrenadeAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, ammoValue);
        }

        public void WritePSG1Ammo(short ammoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find PSG1 Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.PSG1Ammo);
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
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.SocomMaxAmmo);
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
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.FamasMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteGrenadeMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Grenade Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.GrenadeMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteNikitaMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Nikita Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.NikitaMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteStingerMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stinger Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StingerMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteClaymoreMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Claymore Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ClaymoreMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteC4MaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find C4 Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.C4MaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteStunGrenadeMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stun Grenade Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.StunGrenadeMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WriteChaffGrenadeMaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Chaff Grenade Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.ChaffGrenadeMaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        public void WritePSG1MaxAmmo(short maxAmmoValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find PSG1 Max Ammo address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)WeaponAmmo.PSG1MaxAmmo);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxAmmoValue);
        }

        #endregion

        #endregion
    }
}