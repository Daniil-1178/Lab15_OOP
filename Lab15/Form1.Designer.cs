namespace Lab15
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvFtpServer = new System.Windows.Forms.TreeView();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSize = new System.Windows.Forms.Button();
            this.btnCreateDir = new System.Windows.Forms.Button();
            this.btnDeleteDir = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.tbCatalog = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkFullView = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tvFtpServer
            // 
            this.tvFtpServer.Location = new System.Drawing.Point(371, 12);
            this.tvFtpServer.Name = "tvFtpServer";
            this.tvFtpServer.Size = new System.Drawing.Size(338, 189);
            this.tvFtpServer.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 86);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Підключитися та отримати список файлів та каталогів";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSize
            // 
            this.btnSize.Location = new System.Drawing.Point(12, 117);
            this.btnSize.Name = "btnSize";
            this.btnSize.Size = new System.Drawing.Size(106, 24);
            this.btnSize.TabIndex = 2;
            this.btnSize.Text = "Розмір файлу";
            this.btnSize.UseVisualStyleBackColor = true;
            this.btnSize.Click += new System.EventHandler(this.btnSize_Click);
            // 
            // btnCreateDir
            // 
            this.btnCreateDir.Location = new System.Drawing.Point(12, 147);
            this.btnCreateDir.Name = "btnCreateDir";
            this.btnCreateDir.Size = new System.Drawing.Size(110, 24);
            this.btnCreateDir.TabIndex = 3;
            this.btnCreateDir.Text = "Створити каталог";
            this.btnCreateDir.UseVisualStyleBackColor = true;
            this.btnCreateDir.Click += new System.EventHandler(this.btnCreateDir_Click);
            // 
            // btnDeleteDir
            // 
            this.btnDeleteDir.Location = new System.Drawing.Point(12, 177);
            this.btnDeleteDir.Name = "btnDeleteDir";
            this.btnDeleteDir.Size = new System.Drawing.Size(116, 24);
            this.btnDeleteDir.TabIndex = 4;
            this.btnDeleteDir.Text = "Видалити каталог";
            this.btnDeleteDir.UseVisualStyleBackColor = true;
            this.btnDeleteDir.Click += new System.EventHandler(this.btnDeleteDir_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(12, 207);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(116, 24);
            this.btnDeleteFile.TabIndex = 5;
            this.btnDeleteFile.Text = "Видалити файл";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(12, 237);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(136, 24);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Завантажити на FTP";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(12, 267);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(106, 24);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Налаштування";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(12, 297);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(102, 24);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Перейменувати";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(144, 12);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(108, 86);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Скачування файлів з сервера";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(371, 239);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(174, 20);
            this.tbFile.TabIndex = 10;
            // 
            // tbCatalog
            // 
            this.tbCatalog.Location = new System.Drawing.Point(371, 265);
            this.tbCatalog.Name = "tbCatalog";
            this.tbCatalog.Size = new System.Drawing.Size(174, 20);
            this.tbCatalog.TabIndex = 11;
            // 
            // tbPath
            // 
            this.tbPath.Location = new System.Drawing.Point(371, 291);
            this.tbPath.Name = "tbPath";
            this.tbPath.Size = new System.Drawing.Size(174, 20);
            this.tbPath.TabIndex = 12;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkFullView
            // 
            this.chkFullView.AutoSize = true;
            this.chkFullView.Location = new System.Drawing.Point(12, 371);
            this.chkFullView.Name = "chkFullView";
            this.chkFullView.Size = new System.Drawing.Size(80, 17);
            this.chkFullView.TabIndex = 13;
            this.chkFullView.Text = "checkBox1";
            this.chkFullView.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkFullView);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.tbCatalog);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnDeleteDir);
            this.Controls.Add(this.btnCreateDir);
            this.Controls.Add(this.btnSize);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tvFtpServer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFtpServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSize;
        private System.Windows.Forms.Button btnCreateDir;
        private System.Windows.Forms.Button btnDeleteDir;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.TextBox tbCatalog;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chkFullView;
    }
}

