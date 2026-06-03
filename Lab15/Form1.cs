using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Lab15
{
    public partial class Form1 : Form
    {
        private string ftpHost = "";
        private string ftpUser = "";
        private string ftpPass = "";
        private string settingsFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ftp_settings.txt");

        public Form1()
        {
            InitializeComponent();
            LoadFtpCredentials();
        }

        private void LoadFtpCredentials()
        {
            if (File.Exists(settingsFile))
            {
                string[] lines = File.ReadAllLines(settingsFile);
                if (lines.Length >= 3)
                {
                    ftpHost = lines[0];
                    ftpUser = lines[1];
                    ftpPass = lines[2];
                }
            }
        }

        private FtpWebRequest CreateRequest(string targetUrl, string method)
        {
            LoadFtpCredentials();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetUrl);
            request.Credentials = new NetworkCredential(ftpUser, ftpPass);
            request.Method = method;
            request.UseBinary = true;
            return request;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tvFtpServer.Nodes.Clear();
            if (string.IsNullOrEmpty(ftpHost))
            {
                MessageBox.Show("Заповніть налаштування на окремій формі!");
                return;
            }

            TreeNode root = new TreeNode(ftpHost);
            tvFtpServer.Nodes.Add(root);

            try
            {
                string currentMethod = chkFullView.Checked ?
                    WebRequestMethods.Ftp.ListDirectoryDetails : WebRequestMethods.Ftp.ListDirectory;

                FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text, currentMethod);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        root.Nodes.Add(new TreeNode(line));
                    }
                    MessageBox.Show(response.WelcomeMessage, "Сервер підключено");
                }
                root.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка підключення LIST/NLIST: {ex.Message}");
            }
        }

        private void btnCreateDir_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text, WebRequestMethods.Ftp.MakeDirectory);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show($"Каталог {tbCatalog.Text} створено успішно! (Команда MKD)");
                }
                btnConnect_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteDir_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text, WebRequestMethods.Ftp.RemoveDirectory);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Каталог видалено (команда RMD)");
                }
                btnConnect_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text + tbFile.Text, WebRequestMethods.Ftp.DeleteFile);
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show("Файл видалено з сервера (команда DELE)");
                }
                btnConnect_Click(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            try
            {
                string targetFileUrl = ftpHost + tbCatalog.Text + tbFile.Text;

                FtpWebRequest sizeRequest = CreateRequest(targetFileUrl, WebRequestMethods.Ftp.GetFileSize);
                long fileSize = 0;
                using (FtpWebResponse res = (FtpWebResponse)sizeRequest.GetResponse()) { fileSize = res.ContentLength; }

                FtpWebRequest dateRequest = CreateRequest(targetFileUrl, WebRequestMethods.Ftp.GetDateTimestamp);
                DateTime fileDate;
                using (FtpWebResponse res = (FtpWebResponse)dateRequest.GetResponse()) { fileDate = res.LastModified; }

                MessageBox.Show($"Файл: {tbFile.Text}\nРозмір (SIZE): {fileSize} байт\nМодифіковано (MDTM): {fileDate}", "Інформація про об'єкт");
            }
            catch (Exception ex) { MessageBox.Show($"Помилка SIZE/MDTM: {ex.Message}"); }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string localPath in openFileDialog1.FileNames)
                    {
                        tbPath.Text = localPath;
                        string safeName = Path.GetFileName(localPath);
                        string remoteUrl = ftpHost + tbCatalog.Text + safeName;

                        string uploadMethod = WebRequestMethods.Ftp.UploadFile;

                        FtpWebRequest request = CreateRequest(remoteUrl, uploadMethod);
                        byte[] fileBytes = File.ReadAllBytes(localPath);
                        request.ContentLength = fileBytes.Length;

                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(fileBytes, 0, fileBytes.Length);
                        }
                    }
                    MessageBox.Show("Усі файли успішно імпортовано (STOR/STOU/APPE)!");
                    btnConnect_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show($"Помилка завантаження: {ex.Message}"); }
            }
        }

        private void btnUploadFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string localDirPath = fbd.SelectedPath;
                        string dirName = Path.GetFileName(localDirPath);
                        string remoteDirUrl = $"{ftpHost.TrimEnd('/')}/{dirName}";

                        FtpWebRequest mkdirReq = CreateRequest(remoteDirUrl, WebRequestMethods.Ftp.MakeDirectory);
                        using (FtpWebResponse res = (FtpWebResponse)mkdirReq.SetResponsePropertyEmpty()) { }

                        string[] localFiles = Directory.GetFiles(localDirPath);
                        foreach (string file in localFiles)
                        {
                            string fileName = Path.GetFileName(file);
                            FtpWebRequest uploadReq = CreateRequest($"{remoteDirUrl}/{fileName}", WebRequestMethods.Ftp.UploadFile);
                            byte[] bytes = File.ReadAllBytes(file);
                            uploadReq.ContentLength = bytes.Length;
                            using (Stream os = uploadReq.GetRequestStream()) { os.Write(bytes, 0, bytes.Length); }
                        }

                        MessageBox.Show($"Локальний каталог '{dirName}' перенесено на FTP сервер!");
                        btnConnect_Click(null, null);
                    }
                    catch (Exception ex) { MessageBox.Show($"Помилка завантаження каталогу: {ex.Message}"); }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFile.Text)) return;

            using (SaveFileDialog sfd = new SaveFileDialog { FileName = tbFile.Text })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text + tbFile.Text, WebRequestMethods.Ftp.DownloadFile);
                        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                        using (Stream responseStream = response.GetResponseStream())
                        using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            responseStream.CopyTo(fs);
                        }
                        MessageBox.Show("Файл успішно збережено локально! (Команда RETR)");
                    }
                    catch (Exception ex) { MessageBox.Show($"Помилка RETR: {ex.Message}"); }
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            string newName = "renamed_file.txt";
            if (InputBox("Перейменування об'єкта", "Введіть нове ім'я для файлу на FTP:", ref newName) == DialogResult.OK)
            {
                try
                {
                    FtpWebRequest request = CreateRequest(ftpHost + tbCatalog.Text + tbFile.Text, WebRequestMethods.Ftp.Rename);
                    request.RenameTo = newName;

                    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) { }
                    MessageBox.Show("Об'єкт перейменовано (команда RENAME)!");
                    btnConnect_Click(null, null);
                }
                catch (Exception ex) { MessageBox.Show($"Помилка RENAME: {ex.Message}"); }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            LoadFtpCredentials();
        }

        private static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form(); Label label = new Label(); TextBox textBox = new TextBox(); Button buttonOk = new Button();
            form.Text = title; label.Text = promptText; textBox.Text = value; buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK; label.SetBounds(9, 20, 372, 13); textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(309, 72, 75, 23); form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk }); form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen; DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text; return dialogResult;
        }
    }

    public static class FtpExtensions
    {
        public static WebResponse SetResponsePropertyEmpty(this FtpWebRequest req) => req.GetResponse();
    }
}