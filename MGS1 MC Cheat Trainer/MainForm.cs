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
                ReadAmmoValues();
                LoggingManager.Instance.Log("Successfully hooked to the game process!");
                
            }
        }

        private void ReadAmmoValues()
        {
            
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
    }
}