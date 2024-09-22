namespace MGS1_MC_Cheat_Trainer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bool aobFound = AobManager.Instance.FindAndStoreMainAOB();
            if (!aobFound)
            {
                MessageBox.Show(
                    "Failed to hook to the game process. Please try again if this persists please reach out to us at our Support Discord",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (aobFound)
            {
                LoggingManager.Instance.Log("Successfully hooked to the game process!");

            }
        }

        private void SetAmmoSocom_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadSocomAmmo();
                LoggingManager.Instance.Log($"Socom Ammo before editing: {AobManager.Instance.ReadSocomAmmo()}");

                AobManager.Instance.ReadSocomMaxAmmo();
                LoggingManager.Instance.Log($"Socom Max Ammo before editing: {AobManager.Instance.ReadSocomMaxAmmo()}");

                short SocomAmmo = Convert.ToInt16(SocomAmmoNumericBox.Text);
                short SocomMaxAmmo = Convert.ToInt16(SocomMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteSocomAmmo(SocomAmmo);
                AobManager.Instance.WriteSocomMaxAmmo(SocomMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadSocomAmmo();
                LoggingManager.Instance.Log($"Socom Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadSocomMaxAmmo();
                LoggingManager.Instance.Log($"Socom Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoFamas_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadFamasAmmo();
                LoggingManager.Instance.Log($"\nFamas Ammo before editing: {AobManager.Instance.ReadFamasAmmo()}");

                AobManager.Instance.ReadFamasMaxAmmo();
                LoggingManager.Instance.Log($"\nFamas Max Ammo before editing: {AobManager.Instance.ReadFamasMaxAmmo()}");

                short FamasAmmo = Convert.ToInt16(FamasAmmoNumericBox.Text);
                short FamasMaxAmmo = Convert.ToInt16(FamasMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteFamasAmmo(FamasAmmo);
                AobManager.Instance.WriteFamasMaxAmmo(FamasMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadFamasAmmo();
                LoggingManager.Instance.Log($"\nFamas Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadFamasMaxAmmo();
                LoggingManager.Instance.Log($"\nFamas Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoGrenade_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadGrenadeAmmo();
                LoggingManager.Instance.Log($"\nGrenade Ammo before editing: {AobManager.Instance.ReadGrenadeAmmo()}");

                AobManager.Instance.ReadGrenadeMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nGrenade Max Ammo before editing: {AobManager.Instance.ReadGrenadeMaxAmmo()}");

                short GrenadeAmmo = Convert.ToInt16(GrenadeAmmoNumericBox.Text);
                short GrenadeMaxAmmo = Convert.ToInt16(GrenadeMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteGrenadeAmmo(GrenadeAmmo);
                AobManager.Instance.WriteGrenadeMaxAmmo(GrenadeMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadGrenadeAmmo();
                LoggingManager.Instance.Log($"\nGrenade Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadGrenadeMaxAmmo();
                LoggingManager.Instance.Log($"\nGrenade Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoNikita_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadNikitaAmmo();
                LoggingManager.Instance.Log($"\nNikita Ammo before editing: {AobManager.Instance.ReadNikitaAmmo()}");

                AobManager.Instance.ReadNikitaMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nNikita Max Ammo before editing: {AobManager.Instance.ReadNikitaMaxAmmo()}");

                short NikitaAmmo = Convert.ToInt16(NikitaAmmoNumericBox.Text);
                short NikitaMaxAmmo = Convert.ToInt16(NikitaMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteNikitaAmmo(NikitaAmmo);
                AobManager.Instance.WriteNikitaMaxAmmo(NikitaMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadNikitaAmmo();
                LoggingManager.Instance.Log($"\nNikita Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadNikitaMaxAmmo();
                LoggingManager.Instance.Log($"\nNikita Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoStinger_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadStingerAmmo();
                LoggingManager.Instance.Log($"\nStinger Ammo before editing: {AobManager.Instance.ReadStingerAmmo()}");

                AobManager.Instance.ReadStingerMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nStinger Max Ammo before editing: {AobManager.Instance.ReadStingerMaxAmmo()}");

                short StingerAmmo = Convert.ToInt16(StingerAmmoNumericBox.Text);
                short StingerMaxAmmo = Convert.ToInt16(StingerMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteStingerAmmo(StingerAmmo);
                AobManager.Instance.WriteStingerMaxAmmo(StingerMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadStingerAmmo();
                LoggingManager.Instance.Log($"\nStinger Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadStingerMaxAmmo();
                LoggingManager.Instance.Log($"\nStinger Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoClaymore_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadClaymoreAmmo();
                LoggingManager.Instance.Log(
                    $"\nClaymore Ammo before editing: {AobManager.Instance.ReadClaymoreAmmo()}");

                AobManager.Instance.ReadClaymoreMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nClaymore Max Ammo before editing: {AobManager.Instance.ReadClaymoreMaxAmmo()}");

                short ClaymoreAmmo = Convert.ToInt16(ClaymoreAmmoNumericBox.Text);
                short ClaymoreMaxAmmo = Convert.ToInt16(ClaymoreMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteClaymoreAmmo(ClaymoreAmmo);
                AobManager.Instance.WriteClaymoreMaxAmmo(ClaymoreMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadClaymoreAmmo();
                LoggingManager.Instance.Log($"\nClaymore Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadClaymoreMaxAmmo();
                LoggingManager.Instance.Log($"\nClaymore Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoC4_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadC4Ammo();
                LoggingManager.Instance.Log($"\nC4 Ammo before editing: {AobManager.Instance.ReadC4Ammo()}");

                AobManager.Instance.ReadC4MaxAmmo();
                LoggingManager.Instance.Log($"\nC4 Max Ammo before editing: {AobManager.Instance.ReadC4MaxAmmo()}");

                short C4Ammo = Convert.ToInt16(C4AmmoNumericBox.Text);
                short C4MaxAmmo = Convert.ToInt16(C4MaxAmmoNumericBox.Text);

                AobManager.Instance.WriteC4Ammo(C4Ammo);
                AobManager.Instance.WriteC4MaxAmmo(C4MaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadC4Ammo();
                LoggingManager.Instance.Log($"\nC4 Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadC4MaxAmmo();
                LoggingManager.Instance.Log($"\nC4 Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoStunGrenade_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadStunGrenadeAmmo();
                LoggingManager.Instance.Log(
                    $"\nStun Grenade Ammo before editing: {AobManager.Instance.ReadStunGrenadeAmmo()}");

                AobManager.Instance.ReadStunGrenadeMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nStun Grenade Max Ammo before editing: {AobManager.Instance.ReadStunGrenadeMaxAmmo()}");

                short StunGrenadeAmmo = Convert.ToInt16(StunGrenadeAmmoNumericBox.Text);
                short StunGrenadeMaxAmmo = Convert.ToInt16(StunGrenadeMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteStunGrenadeAmmo(StunGrenadeAmmo);
                AobManager.Instance.WriteStunGrenadeMaxAmmo(StunGrenadeMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadStunGrenadeAmmo();
                LoggingManager.Instance.Log($"\nStun Grenade Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadStunGrenadeMaxAmmo();
                LoggingManager.Instance.Log($"\nStun Grenade Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoChaffGrenade_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadChaffGrenadeAmmo();
                LoggingManager.Instance.Log(
                    $"\nChaff Grenade Ammo before editing: {AobManager.Instance.ReadChaffGrenadeAmmo()}");

                AobManager.Instance.ReadChaffGrenadeMaxAmmo();
                LoggingManager.Instance.Log(
                    $"\nChaff Grenade Max Ammo before editing: {AobManager.Instance.ReadChaffGrenadeMaxAmmo()}");

                short ChaffGrenadeAmmo = Convert.ToInt16(ChaffGrenadeAmmoNumericBox.Text);
                short ChaffGrenadeMaxAmmo = Convert.ToInt16(ChaffGrenadeMaxAmmoNumericBox.Text);

                AobManager.Instance.WriteChaffGrenadeAmmo(ChaffGrenadeAmmo);
                AobManager.Instance.WriteChaffGrenadeMaxAmmo(ChaffGrenadeMaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadChaffGrenadeAmmo();
                LoggingManager.Instance.Log($"\nChaff Grenade Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadChaffGrenadeMaxAmmo();
                LoggingManager.Instance.Log($"\nChaff Grenade Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetAmmoPSG1_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadPSG1Ammo();
                LoggingManager.Instance.Log($"\nPSG1 Ammo before editing: {AobManager.Instance.ReadPSG1Ammo()}");

                AobManager.Instance.ReadPSG1MaxAmmo();
                LoggingManager.Instance.Log($"\nPSG1 Max Ammo before editing: {AobManager.Instance.ReadPSG1MaxAmmo()}");

                short PSG1Ammo = Convert.ToInt16(PSG1AmmoNumericBox.Text);
                short PSG1MaxAmmo = Convert.ToInt16(PSG1MaxAmmoNumericBox.Text);

                AobManager.Instance.WritePSG1Ammo(PSG1Ammo);
                AobManager.Instance.WritePSG1MaxAmmo(PSG1MaxAmmo);

                string CurrentAmmo = AobManager.Instance.ReadPSG1Ammo();
                LoggingManager.Instance.Log($"\nPSG1 Ammo after editing: {CurrentAmmo}");

                String CurrentMaxAmmo = AobManager.Instance.ReadPSG1MaxAmmo();
                LoggingManager.Instance.Log($"\nPSG1 Max Ammo after editing: {CurrentMaxAmmo}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void EnableBandana_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBandanaStatus();
                LoggingManager.Instance.Log(
                    $"Bandana status before editing: {AobManager.Instance.ReadBandanaStatus()}");

                AobManager.Instance.EnableBandana();

                string CurrentBandanaStatus = AobManager.Instance.ReadBandanaStatus();
                LoggingManager.Instance.Log($"Bandana status after editing: {CurrentBandanaStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableBandana_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBandanaStatus();
                LoggingManager.Instance.Log(
                    $"Bandana status before editing: {AobManager.Instance.ReadBandanaStatus()}");

                AobManager.Instance.DisableBandana();

                string CurrentBandanaStatus = AobManager.Instance.ReadBandanaStatus();
                LoggingManager.Instance.Log($"Bandana status after editing: {CurrentBandanaStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableStealthCamo_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadStealthStatus();
                LoggingManager.Instance.Log(
                    $"Stealth Camo status before editing: {AobManager.Instance.ReadStealthStatus()}");

                AobManager.Instance.EnableStealth();

                string CurrentStealthStatus = AobManager.Instance.ReadStealthStatus();
                LoggingManager.Instance.Log($"Stealth Camo status after editing: {CurrentStealthStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableStealthCamo_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadStealthStatus();
                LoggingManager.Instance.Log(
                    $"Stealth Camo status before editing: {AobManager.Instance.ReadStealthStatus()}");

                AobManager.Instance.DisableStealth();

                string CurrentStealthStatus = AobManager.Instance.ReadStealthStatus();
                LoggingManager.Instance.Log($"Stealth Camo status after editing: {CurrentStealthStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void SetRationcount_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadRationCount();
                LoggingManager.Instance.Log($"Ration Count before editing: {AobManager.Instance.ReadRationCount()}");

                AobManager.Instance.ReadMaxRationCount();
                LoggingManager.Instance.Log(
                    $"Max Ration Count before editing: {AobManager.Instance.ReadMaxRationCount()}");

                short RationCount = Convert.ToInt16(RationCountNumericBox.Text);
                short MaxRationCount = Convert.ToInt16(RationMaxCountNumericBox.Text);

                AobManager.Instance.WriteRationCount(RationCount);
                AobManager.Instance.WriteMaxRationCount(MaxRationCount);

                string CurrentRationCount = AobManager.Instance.ReadRationCount();
                LoggingManager.Instance.Log($"Ration Count after editing: {CurrentRationCount}");

                String CurrentMaxRationCount = AobManager.Instance.ReadMaxRationCount();
                LoggingManager.Instance.Log($"Max Ration Count after editing: {CurrentMaxRationCount}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void SetMedicineCount_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadMedicineCount();
                LoggingManager.Instance.Log(
                    $"Medicine Count before editing: {AobManager.Instance.ReadMedicineCount()}");

                AobManager.Instance.ReadMaxMedicineCount();
                LoggingManager.Instance.Log(
                    $"Max Medicine Count before editing: {AobManager.Instance.ReadMaxMedicineCount()}");

                short MedicineCount = Convert.ToInt16(MedicineCountNumericBox.Text);
                short MaxMedicineCount = Convert.ToInt16(MedicineMaxCountNumericBox.Text);

                AobManager.Instance.WriteMedicineCount(MedicineCount);
                AobManager.Instance.WriteMaxMedicineCount(MaxMedicineCount);

                string CurrentMedicineCount = AobManager.Instance.ReadMedicineCount();
                LoggingManager.Instance.Log($"Medicine Count after editing: {CurrentMedicineCount}");

                String CurrentMaxMedicineCount = AobManager.Instance.ReadMaxMedicineCount();
                LoggingManager.Instance.Log($"Max Medicine Count after editing: {CurrentMaxMedicineCount}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void SetDiazapamCount_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadDiazapamCount();
                LoggingManager.Instance.Log(
                    $"Diazapam Count before editing: {AobManager.Instance.ReadDiazapamCount()}");

                AobManager.Instance.ReadMaxDiazapamCount();
                LoggingManager.Instance.Log(
                    $"Max Diazapam Count before editing: {AobManager.Instance.ReadMaxDiazapamCount()}");

                short DiazapamCount = Convert.ToInt16(DiazapamCountNumericBox.Text);
                short MaxDiazapamCount = Convert.ToInt16(DiazapamMaxCountNumericBox.Text);

                AobManager.Instance.WriteDiazapamCount(DiazapamCount);
                AobManager.Instance.WriteMaxDiazapamCount(MaxDiazapamCount);

                string CurrentDiazapamCount = AobManager.Instance.ReadDiazapamCount();
                LoggingManager.Instance.Log($"Diazapam Count after editing: {CurrentDiazapamCount}");

                String CurrentMaxDiazapamCount = AobManager.Instance.ReadMaxDiazapamCount();
                LoggingManager.Instance.Log($"Max Diazapam Count after editing: {CurrentMaxDiazapamCount}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableBoxA_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxAStatus();
                LoggingManager.Instance.Log(
                    $"Box A status before editing: {AobManager.Instance.ReadBoxAStatus()}");

                AobManager.Instance.EnableBoxA();

                string CurrentBoxAStatus = AobManager.Instance.ReadBoxAStatus();
                LoggingManager.Instance.Log($"Box A status after editing: {CurrentBoxAStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableBoxA_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxAStatus();
                LoggingManager.Instance.Log(
                    $"Box A status before editing: {AobManager.Instance.ReadBoxAStatus()}");

                AobManager.Instance.DisableBoxA();

                string CurrentBoxAStatus = AobManager.Instance.ReadBoxAStatus();
                LoggingManager.Instance.Log($"Box A status after editing: {CurrentBoxAStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableBoxB_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxBStatus();
                LoggingManager.Instance.Log(
                    $"Box B status before editing: {AobManager.Instance.ReadBoxBStatus()}");

                AobManager.Instance.EnableBoxB();

                string CurrentBoxBStatus = AobManager.Instance.ReadBoxBStatus();
                LoggingManager.Instance.Log($"Box B status after editing: {CurrentBoxBStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableBoxB_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxBStatus();
                LoggingManager.Instance.Log(
                    $"Box B status before editing: {AobManager.Instance.ReadBoxBStatus()}");

                AobManager.Instance.DisableBoxB();

                string CurrentBoxBStatus = AobManager.Instance.ReadBoxBStatus();
                LoggingManager.Instance.Log($"Box B status after editing: {CurrentBoxBStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableBoxC_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxCStatus();
                LoggingManager.Instance.Log(
                    $"Box C status before editing: {AobManager.Instance.ReadBoxCStatus()}");

                AobManager.Instance.EnableBoxC();

                string CurrentBoxCStatus = AobManager.Instance.ReadBoxCStatus();
                LoggingManager.Instance.Log($"Box C status after editing: {CurrentBoxCStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableBoxC_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBoxCStatus();
                LoggingManager.Instance.Log(
                    $"Box C status before editing: {AobManager.Instance.ReadBoxCStatus()}");

                AobManager.Instance.DisableBoxC();

                string CurrentBoxCStatus = AobManager.Instance.ReadBoxCStatus();
                LoggingManager.Instance.Log($"Box C status after editing: {CurrentBoxCStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableBodyArmor_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBodyArmorStatus();
                LoggingManager.Instance.Log(
                    $"Body Armor status before editing: {AobManager.Instance.ReadBodyArmorStatus()}");

                AobManager.Instance.EnableBodyArmor();

                string CurrentBodyArmorStatus = AobManager.Instance.ReadBodyArmorStatus();
                LoggingManager.Instance.Log($"Body Armor status after editing: {CurrentBodyArmorStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableBodyArmor_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadBodyArmorStatus();
                LoggingManager.Instance.Log(
                    $"Body Armor status before editing: {AobManager.Instance.ReadBodyArmorStatus()}");

                AobManager.Instance.DisableBodyArmor();

                string CurrentBodyArmorStatus = AobManager.Instance.ReadBodyArmorStatus();
                LoggingManager.Instance.Log($"Body Armor status after editing: {CurrentBodyArmorStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableMineD_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadMineDetectorStatus();
                LoggingManager.Instance.Log(
                    $"Mine D status before editing: {AobManager.Instance.ReadMineDetectorStatus()}");

                AobManager.Instance.EnableMineDetector();

                string CurrentMineDStatus = AobManager.Instance.ReadMineDetectorStatus();
                LoggingManager.Instance.Log($"Mine D status after editing: {CurrentMineDStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableMineD_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadMineDetectorStatus();
                LoggingManager.Instance.Log(
                    $"Mine D status before editing: {AobManager.Instance.ReadMineDetectorStatus()}");

                AobManager.Instance.DisableMineDetector();

                string CurrentMineDStatus = AobManager.Instance.ReadMineDetectorStatus();
                LoggingManager.Instance.Log($"Mine D status after editing: {CurrentMineDStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableGasmask_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadGasMaskStatus();
                LoggingManager.Instance.Log(
                    $"Gas Mask status before editing: {AobManager.Instance.ReadGasMaskStatus()}");

                AobManager.Instance.EnableGasMask();

                string CurrentGasMaskStatus = AobManager.Instance.ReadGasMaskStatus();
                LoggingManager.Instance.Log($"Gas Mask status after editing: {CurrentGasMaskStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableGasmask_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadGasMaskStatus();
                LoggingManager.Instance.Log(
                    $"Gas Mask status before editing: {AobManager.Instance.ReadGasMaskStatus()}");

                AobManager.Instance.DisableGasMask();

                string CurrentGasMaskStatus = AobManager.Instance.ReadGasMaskStatus();
                LoggingManager.Instance.Log($"Gas Mask status after editing: {CurrentGasMaskStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableNvg_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadNightVisionStatus();
                LoggingManager.Instance.Log(
                    $"NVG status before editing: {AobManager.Instance.ReadNightVisionStatus()}");

                AobManager.Instance.EnableNightVision();

                string CurrentNvgStatus = AobManager.Instance.ReadNightVisionStatus();
                LoggingManager.Instance.Log($"NVG status after editing: {CurrentNvgStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableNvg_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadNightVisionStatus();
                LoggingManager.Instance.Log(
                    $"NVG status before editing: {AobManager.Instance.ReadNightVisionStatus()}");

                AobManager.Instance.DisableNightVision();

                string CurrentNvgStatus = AobManager.Instance.ReadNightVisionStatus();
                LoggingManager.Instance.Log($"NVG status after editing: {CurrentNvgStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableThermal_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadThermalGogglesStatus();
                LoggingManager.Instance.Log(
                    $"Thermal status before editing: {AobManager.Instance.ReadThermalGogglesStatus()}");

                AobManager.Instance.EnableThermalGoggles();

                string CurrentThermalStatus = AobManager.Instance.ReadThermalGogglesStatus();
                LoggingManager.Instance.Log($"Thermal status after editing: {CurrentThermalStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableThermal_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadThermalGogglesStatus();
                LoggingManager.Instance.Log(
                    $"Thermal status before editing: {AobManager.Instance.ReadThermalGogglesStatus()}");

                AobManager.Instance.DisableThermalGoggles();

                string CurrentThermalStatus = AobManager.Instance.ReadThermalGogglesStatus();
                LoggingManager.Instance.Log($"Thermal status after editing: {CurrentThermalStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableScope_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadScopeStatus();
                LoggingManager.Instance.Log(
                    $"Scope status before editing: {AobManager.Instance.ReadScopeStatus()}");

                AobManager.Instance.EnableScope();

                string CurrentScopeStatus = AobManager.Instance.ReadScopeStatus();
                LoggingManager.Instance.Log($"Scope status after editing: {CurrentScopeStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableScope_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadScopeStatus();
                LoggingManager.Instance.Log(
                    $"Scope status before editing: {AobManager.Instance.ReadScopeStatus()}");

                AobManager.Instance.DisableScope();

                string CurrentScopeStatus = AobManager.Instance.ReadScopeStatus();
                LoggingManager.Instance.Log($"Scope status after editing: {CurrentScopeStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableCigs_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadCigarettesStatus();
                LoggingManager.Instance.Log(
                    $"Cigs status before editing: {AobManager.Instance.ReadCigarettesStatus()}");

                AobManager.Instance.EnableCigarettes();

                string CurrentCigsStatus = AobManager.Instance.ReadCigarettesStatus();
                LoggingManager.Instance.Log($"Cigs status after editing: {CurrentCigsStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableCigs_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadCigarettesStatus();
                LoggingManager.Instance.Log(
                    $"Cigs status before editing: {AobManager.Instance.ReadCigarettesStatus()}");

                AobManager.Instance.DisableCigarettes();

                string CurrentCigsStatus = AobManager.Instance.ReadCigarettesStatus();
                LoggingManager.Instance.Log($"Cigs status after editing: {CurrentCigsStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableKetchup_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKetchupStatus();
                LoggingManager.Instance.Log(
                    $"Ketchup status before editing: {AobManager.Instance.ReadKetchupStatus()}");

                AobManager.Instance.EnableKetchup();

                string CurrentKetchupStatus = AobManager.Instance.ReadKetchupStatus();
                LoggingManager.Instance.Log($"Ketchup status after editing: {CurrentKetchupStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableKetchup_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKetchupStatus();
                LoggingManager.Instance.Log(
                    $"Ketchup status before editing: {AobManager.Instance.ReadKetchupStatus()}");

                AobManager.Instance.DisableKetchup();

                string CurrentKetchupStatus = AobManager.Instance.ReadKetchupStatus();
                LoggingManager.Instance.Log($"Ketchup status after editing: {CurrentKetchupStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableRope_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadRopeStatus();
                LoggingManager.Instance.Log(
                    $"Rope status before editing: {AobManager.Instance.ReadRopeStatus()}");

                AobManager.Instance.EnableRope();

                string CurrentRopeStatus = AobManager.Instance.ReadRopeStatus();
                LoggingManager.Instance.Log($"Rope status after editing: {CurrentRopeStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableRope_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadRopeStatus();
                LoggingManager.Instance.Log(
                    $"Rope status before editing: {AobManager.Instance.ReadRopeStatus()}");

                AobManager.Instance.DisableRope();

                string CurrentRopeStatus = AobManager.Instance.ReadRopeStatus();
                LoggingManager.Instance.Log($"Rope status after editing: {CurrentRopeStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableHandkerchief_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadHandkerchiefStatus();
                LoggingManager.Instance.Log(
                    $"Handkerchief status before editing: {AobManager.Instance.ReadHandkerchiefStatus()}");

                AobManager.Instance.EnableHandkerchief();

                string CurrentHandkerchiefStatus = AobManager.Instance.ReadHandkerchiefStatus();
                LoggingManager.Instance.Log($"Handkerchief status after editing: {CurrentHandkerchiefStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableHandkerchief_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadHandkerchiefStatus();
                LoggingManager.Instance.Log(
                    $"Handkerchief status before editing: {AobManager.Instance.ReadHandkerchiefStatus()}");

                AobManager.Instance.DisableHandkerchief();

                string CurrentHandkerchiefStatus = AobManager.Instance.ReadHandkerchiefStatus();
                LoggingManager.Instance.Log($"Handkerchief status after editing: {CurrentHandkerchiefStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }



        private void EnableKeycard_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log(
                    $"Keycard status before editing: {AobManager.Instance.ReadKeycardStatus()}");

                AobManager.Instance.EnableKeycard();

                string CurrentKeycardStatus = AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log($"Keycard status after editing: {CurrentKeycardStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableKeycard_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log(
                    $"Keycard status before editing: {AobManager.Instance.ReadKeycardStatus()}");

                AobManager.Instance.DisableKeycard();

                string CurrentKeycardStatus = AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log($"Keycard status after editing: {CurrentKeycardStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void IncrementKeycardLevelByOne_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log(
                    $"Keycard status before editing: {AobManager.Instance.ReadKeycardStatus()}");

                AobManager.Instance.IncrementKeycard();

                string CurrentKeycardStatus = AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log($"Keycard status after editing: {CurrentKeycardStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DecrementKeycardLevelByOne_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log(
                    $"Keycard status before editing: {AobManager.Instance.ReadKeycardStatus()}");

                AobManager.Instance.DecrementKeycard();

                string CurrentKeycardStatus = AobManager.Instance.ReadKeycardStatus();
                LoggingManager.Instance.Log($"Keycard status after editing: {CurrentKeycardStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void SetBombTimer_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadTimeBombStatus();
                LoggingManager.Instance.Log(
                    $"Time Bomb status before editing: {AobManager.Instance.ReadTimeBombStatus()}");

                short TimeBombValue = Convert.ToInt16(TimeBombNumerical.Text);

                AobManager.Instance.SetTimeBomb(TimeBombValue);

                string CurrentTimeBombStatus = AobManager.Instance.ReadTimeBombStatus();
                LoggingManager.Instance.Log($"Time Bomb status after editing: {CurrentTimeBombStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableMoDisc_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadMoDiscStatus();
                LoggingManager.Instance.Log(
                    $"Mo Disc status before editing: {AobManager.Instance.ReadMoDiscStatus()}");

                AobManager.Instance.EnableMoDisc();

                string CurrentMoDiscStatus = AobManager.Instance.ReadMoDiscStatus();
                LoggingManager.Instance.Log($"Mo Disc status after editing: {CurrentMoDiscStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableMoDisc_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadMoDiscStatus();
                LoggingManager.Instance.Log(
                    $"Mo Disc status before editing: {AobManager.Instance.ReadMoDiscStatus()}");

                AobManager.Instance.DisableMoDisc();

                string CurrentMoDiscStatus = AobManager.Instance.ReadMoDiscStatus();
                LoggingManager.Instance.Log($"Mo Disc status after editing: {CurrentMoDiscStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void EnableCamera_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadCameraStatus();
                LoggingManager.Instance.Log(
                    $"Camera status before editing: {AobManager.Instance.ReadCameraStatus()}");

                AobManager.Instance.EnableCamera();

                string CurrentCameraStatus = AobManager.Instance.ReadCameraStatus();
                LoggingManager.Instance.Log($"Camera status after editing: {CurrentCameraStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisableCamera_Click(object sender, EventArgs e)
        {
            try
            {
                AobManager.Instance.ReadCameraStatus();
                LoggingManager.Instance.Log(
                    $"Camera status before editing: {AobManager.Instance.ReadCameraStatus()}");

                AobManager.Instance.DisableCamera();

                string CurrentCameraStatus = AobManager.Instance.ReadCameraStatus();
                LoggingManager.Instance.Log($"Camera status after editing: {CurrentCameraStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void ChangePalKeyToNormalTemp_Click(object sender, EventArgs e)
        {
            // Same as a normal enable I presume temp changes might be elsewhere in the
            // code or a byte combo I'm unaware of or haven't tested I would assume
            // if 0100 is normal then 0200 and 0300 are hot and cold but needs testing
            try
            {
                palKeyNormalPicturebox.Visible = true;
                palKeyColdPictureBox.Visible = false;
                palKeyHotPictureBox.Visible = false;
                AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log(
                    $"Pal Key status before editing: {AobManager.Instance.ReadPalKeyStatus()}");

                AobManager.Instance.EnablePalKey();
                AobManager.Instance.SetPalKeyToNormal();

                string CurrentPalKeyStatus = AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log($"Pal Key status after editing: {CurrentPalKeyStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void DisablePalKey_Click(object sender, EventArgs e)
        {
            try
            {
                palKeyNormalPicturebox.Visible = true;
                palKeyColdPictureBox.Visible = false;
                palKeyHotPictureBox.Visible = false;
                AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log(
                    $"Pal Key status before editing: {AobManager.Instance.ReadPalKeyStatus()}");

                AobManager.Instance.ReadPalKeyTempStatus();
                LoggingManager.Instance.Log(
                                       $"Pal Key Temp status before editing: {AobManager.Instance.ReadPalKeyTempStatus()}");
                AobManager.Instance.DisablePalKey();

                string CurrentPalKeyStatus = AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log($"Pal Key status after editing: {CurrentPalKeyStatus}");

                string CurrentPalKeyTempStatus = AobManager.Instance.ReadPalKeyTempStatus();
                LoggingManager.Instance.Log($"Pal Key Temp status after editing: {CurrentPalKeyTempStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }

        }

        private void ChangePalKeyToColdTemp_Click(object sender, EventArgs e)
        {

            try
            {
                palKeyNormalPicturebox.Visible = false;
                palKeyColdPictureBox.Visible = true;
                palKeyHotPictureBox.Visible = false;
                AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log(
                    $"Pal Key status before editing: {AobManager.Instance.ReadPalKeyStatus()}");

                AobManager.Instance.SetPalKeyToCold();

                string CurrentPalKeyStatus = AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log($"Pal Key status after editing: {CurrentPalKeyStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }

        private void ChangePalKeyToHotTemp_Click(object sender, EventArgs e)
        {
            try
            {
                palKeyNormalPicturebox.Visible = false;
                palKeyColdPictureBox.Visible = false;
                palKeyHotPictureBox.Visible = true;
                AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log(
                    $"Pal Key status before editing: {AobManager.Instance.ReadPalKeyStatus()} \nTemp Range: {AobManager.Instance.ReadPalKeyTempRange()}");

                AobManager.Instance.SetPalKeyToHot();

                string CurrentPalKeyStatus = AobManager.Instance.ReadPalKeyStatus();
                LoggingManager.Instance.Log($"Pal Key status after editing: {CurrentPalKeyStatus}");
            }
            catch (Exception ex)
            {
                LoggingManager.Instance.Log($"Error: {ex.Message}");
            }
        }
    }
}