using System;
using System.Diagnostics;

namespace MGS1_MC_Cheat_Trainer
{
    public class Constants
    {
        public const string PROCESS_NAME = "METAL GEAR SOLID";

        // For reading different memory types and their values
        public enum DataType
        {
            // UInt = Unsigned Integer (No negative values)
            // Int = Signed Integer (Negative and positive values)
            UInt8, // Unsigned Byte
            Int8,  // Signed Byte
            Int16, // Signed Short
            UInt16,// Unsigned Short
            Int32, // Signed 4 byte integer
            UInt32, // Unsigned 4 byte integer
            Float, // 4 byte floating point number
            Int64, // Signed 8 byte integer
            UInt64, // Unsigned 8 byte integer
            Double, // 8 byte floating point number
            ByteArray, // For anything in between or larger than 8 bytes
        }

        public enum LifeStates
        {
            CurrentLife = 1038,
            MaxLife = 1036
        }

        public enum WeaponAmmo
        {
          SocomAmmo = 1026,
          FamasAmmo = 1024,
          GrenadeAmmo = 1022,
          NikitaAmmo = 1020,
          StingerAmmo = 1018,
          ClaymoreAmmo = 1016,
          C4Ammo = 1014,
          StunGrenadeAmmo = 1012,
          ChaffGrenadeAmmo = 1010,
          PSG1Ammo = 1008,
          // Max amounts
          SocomMaxAmmo = 1006,
          FamasMaxAmmo = 1004,
          GrenadeMaxAmmo = 1002,
          NikitaMaxAmmo = 1000,
          StingerMaxAmmo = 998,
          ClaymoreMaxAmmo = 996,
          C4MaxAmmo = 994,
          StunGrenadeMaxAmmo = 992,
          ChaffGrenadeMaxAmmo = 990,
          PSG1MaxAmmo = 988,
        }

        public enum Items
        {
            Cigs = 984,
            Scope = 982,
            CBoxA = 980,
            CBoxB = 978,
            CBoxC = 976,
            NightVisionGoggles = 974,
            ThermalGoggles = 972,
            GasMask = 970,
            BodyArmor = 968,
            Ketchup = 966,
            StealthCamo = 964,
            Bandana = 962,
            Camera = 960,
            Rations = 958,
            ColdMedicine = 956,
            Diazepam = 954,
            PalKey = 952,
            CardKey = 950,
            TimeBomb = 948,
            MineDetector = 946,
            MoDisc = 944,
            Rope = 942,
            Handkerchief = 940,
            SocomSuppressor = 938,
            // Max amounts
            RationMax = 936,
            MedicineMax = 934,
            DiazepamMax = 932,
        }

        public enum GameStats
        {
            AlertsTriggered = 930,
            EnemiesKilled = 928,
            RationsUsed = 926,
            ContinuesUsed = 924,
            PlayTime = 922,
            TimesSaved = 920,
        }

    }
}