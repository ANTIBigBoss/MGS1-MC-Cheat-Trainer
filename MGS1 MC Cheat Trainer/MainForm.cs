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

                short SocomAmmo = Convert.ToInt16(SocomAmmoTextBox.Text);
                short SocomMaxAmmo = Convert.ToInt16(SocomMaxAmmoTextBox.Text);

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

                short FamasAmmo = Convert.ToInt16(FamasAmmoTextBox.Text);
                short FamasMaxAmmo = Convert.ToInt16(FamasMaxAmmoTextBox.Text);

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
    }
}