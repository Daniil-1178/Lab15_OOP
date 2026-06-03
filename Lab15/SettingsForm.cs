using System;
using System.IO;
using System.Windows.Forms;

namespace Lab15
{
    public partial class SettingsForm : Form
    {
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ftp_settings.txt");

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine(tbHost.Text.Trim());
                    sw.WriteLine(tbUser.Text.Trim());
                    sw.WriteLine(tbPass.Text.Trim());
                }
                MessageBox.Show("Налаштування збережено у файл!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка запису налаштувань: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    if (lines.Length >= 3)
                    {
                        tbHost.Text = lines[0];
                        tbUser.Text = lines[1];
                        tbPass.Text = lines[2];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не вдалося прочитати файл конфігурації: {ex.Message}");
                }
            }
        }
    }
}