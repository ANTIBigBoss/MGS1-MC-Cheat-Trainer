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

        #region Reading Weapon Adresses

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

        #region Writing Weapon Addresses

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

        #region Reading Item Addresses

        public string ReadRationCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Ration Count address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Rations);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadMaxRationCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Max Ration Count address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.RationMax);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadMedicineCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Medicine Count address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.ColdMedicine);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadMaxMedicineCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Max Cold Medicine address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MedicineMax);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadDiazapamCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Diazepam Count address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Diazepam);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadMaxDiazapamCount()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Max Diazepam address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.DiazepamMax);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        #endregion

        public void WriteRationCount(short rationCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Ration Count address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Rations);
            MemoryManager.WriteMemory(processHandle, targetAddress, rationCount);
        }

        public void WriteMaxRationCount(short maxRationCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Max Ration Count address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.RationMax);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxRationCount);
        }

        public void WriteMedicineCount(short medicineCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Medicine Count address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.ColdMedicine);
            MemoryManager.WriteMemory(processHandle, targetAddress, medicineCount);
        }

        public void WriteMaxMedicineCount(short maxMedicineCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Max Cold Medicine address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MedicineMax);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxMedicineCount);
        }

        public void WriteDiazapamCount(short diazepamCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Diazepam Count address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Diazepam);
            MemoryManager.WriteMemory(processHandle, targetAddress, diazepamCount);
        }

        public void WriteMaxDiazapamCount(short maxDiazepamCount)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Max Diazepam address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.DiazepamMax);
            MemoryManager.WriteMemory(processHandle, targetAddress, maxDiazepamCount);
        }

        #region Boolean Item Toggles

        public string ReadStealthStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Stealth address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.StealthCamo);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableStealth()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stealth address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.StealthCamo);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
            
        }

        public void DisableStealth()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Stealth address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.StealthCamo);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Bandana

        public string ReadBandanaStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Bandana address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Bandana);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableBandana()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Bandana address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Bandana);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableBandana()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Bandana address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Bandana);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Box A

        public string ReadBoxAStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Box A address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxA);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableBoxA()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box A address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxA);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableBoxA()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box A address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxA);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Box B

        public string ReadBoxBStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Box B address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxB);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableBoxB()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box B address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxB);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableBoxB()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box B address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxB);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Box C

        public string ReadBoxCStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Box C address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxC);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableBoxC()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box C address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxC);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableBoxC()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Box C address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CBoxC);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Body Armor

        public string ReadBodyArmorStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Body Armor address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.BodyArmor);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableBodyArmor()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Body Armor address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.BodyArmor);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableBodyArmor()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Body Armor address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.BodyArmor);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Mine Detector

        public string ReadMineDetectorStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Mine Detector address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MineDetector);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableMineDetector()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Mine Detector address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MineDetector);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableMineDetector()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Mine Detector address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MineDetector);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Camera

        public string ReadCameraStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Camera address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Camera);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableCamera()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Camera address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Camera);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableCamera()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Camera address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Camera);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Night Vision Goggles

        public string ReadNightVisionStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Night Vision Goggles address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.NightVisionGoggles);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableNightVision()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Night Vision Goggles address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.NightVisionGoggles);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableNightVision()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Night Vision Goggles address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.NightVisionGoggles);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Thermal Goggles

        public string ReadThermalGogglesStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Thermal Goggles address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.ThermalGoggles);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableThermalGoggles()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Thermal Goggles address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.ThermalGoggles);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableThermalGoggles()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Thermal Goggles address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.ThermalGoggles);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Gas Mask

        public string ReadGasMaskStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Gas Mask address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.GasMask);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableGasMask()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Gas Mask address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.GasMask);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableGasMask()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Gas Mask address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.GasMask);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Cigarettes

        public string ReadCigarettesStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Cigarettes address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Cigs);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableCigarettes()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Cigarettes address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Cigs);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableCigarettes()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Cigarettes address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Cigs);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Scope

        public string ReadScopeStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Scope address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Scope);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableScope()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Scope address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Scope);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableScope()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Scope address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Scope);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Ketchup

        public string ReadKetchupStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Ketchup address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Ketchup);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableKetchup()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Ketchup address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Ketchup);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableKetchup()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Ketchup address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Ketchup);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Rope

        public string ReadRopeStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Rope address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Rope);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableRope()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Rope address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Rope);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableRope()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Rope address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Rope);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Handkerchief

        public string ReadHandkerchiefStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Handkerchief address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Handkerchief);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableHandkerchief()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Handkerchief address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Handkerchief);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableHandkerchief()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Handkerchief address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.Handkerchief);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Pal Key
        public string ReadPalKeyStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Pal Key address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadPalKeyTempStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Pal Key Temp address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKeyTemp);           
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        // This can go from -9000 to 9000 we will need to change the temp range and status at the same time
        public string ReadPalKeyTempRange() 
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Pal Key Temp range address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKeyTempStatus);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        // This makes the Pal Key's temperature to normal for hot and cold it looks like this:
        // x01 x00 = Normal
        // x01 x01 = Hot
        // x01 x02 = Cold

        public void SetPalKeyToNormal()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Pal Key address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            IntPtr targetAddressTemp = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKeyTemp);
            IntPtr targetAddressTempRange = IntPtr.Subtract(FoundMainAOBAddress, (short)Items.PalKeyTempStatus);


            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
            MemoryManager.WriteMemory(processHandle, targetAddressTemp, (short)0);
            MemoryManager.WriteMemory(processHandle, targetAddressTempRange, (short)0);
        }

        public void SetPalKeyToHot()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Pal Key address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            IntPtr targetAddressTemp = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKeyTemp);
            IntPtr targetAddressTempRange = IntPtr.Subtract(FoundMainAOBAddress, (short)Items.PalKeyTempStatus);

            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
            MemoryManager.WriteMemory(processHandle, targetAddressTemp, (short)1);
            MemoryManager.WriteMemory(processHandle, targetAddressTempRange, (short)9100);

        }

        public void SetPalKeyToCold()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Pal Key address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            IntPtr targetAddressTemp = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKeyTemp);
            IntPtr targetAddressTempRange = IntPtr.Subtract(FoundMainAOBAddress, (short)Items.PalKeyTempStatus);

            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
            MemoryManager.WriteMemory(processHandle, targetAddressTemp, (short)2);
            MemoryManager.WriteMemory(processHandle, targetAddressTempRange, (short)-9100);
        }

        public void EnablePalKey()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Pal Key address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisablePalKey()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Pal Key address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.PalKey);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Mo Disc

        public string ReadMoDiscStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Mo Disc address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MoDisc);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void EnableMoDisc()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Mo Disc address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MoDisc);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableMoDisc()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Mo Disc address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.MoDisc);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        public string ReadKeycardStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Keycard address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CardKey);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }


        public void EnableKeycard()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Keycard address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CardKey);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)1);
        }

        public void DisableKeycard()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Keycard address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CardKey);
            MemoryManager.WriteMemory(processHandle, targetAddress, (short)0);
        }

        // Do not allow to increment past 69 i.e. 70 or greater should prompt a message box error
        public void IncrementKeycard()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Keycard address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CardKey);
            byte[] keycardValue = MemoryManager.ReadMemoryBytes(processHandle, targetAddress, 2);
            short keycardValueShort = BitConverter.ToInt16(keycardValue, 0);
            if (keycardValueShort < 69)
            {
                MemoryManager.WriteMemory(processHandle, targetAddress, (short)(keycardValueShort + 1));
            }
            else
            {
                MessageBox.Show("Keycard value can't be higher than 69.");
            }
            
        }

        // Do not allow the keycard to go below 0
        public void DecrementKeycard()
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Keycard address.");
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.CardKey);
            byte[] keycardValue = MemoryManager.ReadMemoryBytes(processHandle, targetAddress, 2);
            short keycardValueShort = BitConverter.ToInt16(keycardValue, 0);
            if (keycardValueShort > 0)
            {
                MemoryManager.WriteMemory(processHandle, targetAddress, (short)(keycardValueShort - 1));
            }
            else
            {
                MessageBox.Show("Keycard value can't be lower than 0.");
            }
            
        }

        // Time Bomb

        public string ReadTimeBombStatus()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Time Bomb address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.TimeBomb);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public void SetTimeBomb(short timeBombValue)
        {
            if (!FindAndStoreMainAOB())
            {
                MessageBox.Show("Failed to find Time Bomb address.");
                return;
            }

            if (timeBombValue < 1)
            {
                MessageBox.Show("Time Bomb value can't be lower than 1.");
                return;
            }

            if (timeBombValue > short.MaxValue)
            {
                MessageBox.Show("Time Bomb value can't be higher than " + short.MaxValue);
                return;
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)Items.TimeBomb);
            MemoryManager.WriteMemory(processHandle, targetAddress, timeBombValue);
        }
        #endregion

        #region Game Stats

        public string ReadPlayTime()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Game Time address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.PlayTime);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadAlertsTriggered()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Alert Mode address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.AlertsTriggered);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadContinuesUsed()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Continues address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.ContinuesUsed);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadRationsUsed()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Rations Used address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.RationsUsed);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadEnemiesKilled()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Enemies Killed address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.EnemiesKilled);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }

        public string ReadSavesUsed()
        {
            if (!FindAndStoreMainAOB())
            {
                return "Failed to find Saves Used address.";
            }

            IntPtr processHandle = MemoryManager.OpenGameProcess(MemoryManager.GetMGS1Process());
            IntPtr targetAddress = IntPtr.Subtract(FoundMainAOBAddress, (int)GameStats.TimesSaved);
            return MemoryManager.ReadMemoryValueAsString(processHandle, targetAddress, 2, DataType.UInt16);
        }


        #endregion
    }
}