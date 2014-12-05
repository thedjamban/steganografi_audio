namespace Revisi_Stegano_Audio.UI
{
    partial class FrmExtraction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExtraction));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblLoading = new System.Windows.Forms.Label();
            this.btnExtraction = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpenMessage = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStopSteganoMP3 = new System.Windows.Forms.Button();
            this.btnPausedSteganoMP3 = new System.Windows.Forms.Button();
            this.btnPlaySteganoMP3 = new System.Windows.Forms.Button();
            this.btnOpenSteganofile = new System.Windows.Forms.Button();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtSteganofile = new System.Windows.Forms.TextBox();
            this.txtDestinaion = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cbIsImage = new System.Windows.Forms.CheckBox();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cryptographySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aESAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnExtraction, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.21978F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.78022F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 279);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Controls.Add(this.btnRestart);
            this.flowLayoutPanel1.Controls.Add(this.progressBar1);
            this.flowLayoutPanel1.Controls.Add(this.lblLoading);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 246);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(837, 30);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(759, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(678, 3);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(104, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(568, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoading.Location = new System.Drawing.Point(28, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(70, 29);
            this.lblLoading.TabIndex = 3;
            this.lblLoading.Text = "Loading: 0%";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExtraction
            // 
            this.btnExtraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExtraction.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtraction.Location = new System.Drawing.Point(3, 153);
            this.btnExtraction.Name = "btnExtraction";
            this.btnExtraction.Size = new System.Drawing.Size(837, 31);
            this.btnExtraction.TabIndex = 2;
            this.btnExtraction.Text = "E X T R A C T I O N   D A T A";
            this.btnExtraction.UseVisualStyleBackColor = true;
            this.btnExtraction.Click += new System.EventHandler(this.btnExtraction_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(837, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[Output Message]";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.23174F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.76826F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.Controls.Add(this.txtMessage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOpenMessage, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(831, 29);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(113, 3);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(656, 22);
            this.txtMessage.TabIndex = 11;
            this.txtMessage.DoubleClick += new System.EventHandler(this.txtMessage_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Message Path";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenMessage
            // 
            this.btnOpenMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenMessage.Image = global::Revisi_Stegano_Audio.Properties.Resources._1302061910_surveys;
            this.btnOpenMessage.Location = new System.Drawing.Point(775, 3);
            this.btnOpenMessage.Name = "btnOpenMessage";
            this.btnOpenMessage.Size = new System.Drawing.Size(53, 23);
            this.btnOpenMessage.TabIndex = 8;
            this.btnOpenMessage.UseVisualStyleBackColor = true;
            this.btnOpenMessage.Click += new System.EventHandler(this.btnOpenMessage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(837, 144);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[Source and Destination]";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.11111F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.88889F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 535F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnOpenSteganofile, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBrowseDestination, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtSteganofile, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtDestinaion, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtPassword, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.cbIsImage, 2, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(831, 123);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steganofile Path";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination Path";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnStopSteganoMP3);
            this.panel1.Controls.Add(this.btnPausedSteganoMP3);
            this.panel1.Controls.Add(this.btnPlaySteganoMP3);
            this.panel1.Location = new System.Drawing.Point(100, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 22);
            this.panel1.TabIndex = 4;
            // 
            // btnStopSteganoMP3
            // 
            this.btnStopSteganoMP3.Enabled = false;
            this.btnStopSteganoMP3.Image = global::Revisi_Stegano_Audio.Properties.Resources.Stop;
            this.btnStopSteganoMP3.Location = new System.Drawing.Point(81, 0);
            this.btnStopSteganoMP3.Name = "btnStopSteganoMP3";
            this.btnStopSteganoMP3.Size = new System.Drawing.Size(33, 23);
            this.btnStopSteganoMP3.TabIndex = 6;
            this.btnStopSteganoMP3.UseVisualStyleBackColor = true;
            this.btnStopSteganoMP3.Click += new System.EventHandler(this.btnStopSteganoMP3_Click);
            // 
            // btnPausedSteganoMP3
            // 
            this.btnPausedSteganoMP3.Enabled = false;
            this.btnPausedSteganoMP3.Image = global::Revisi_Stegano_Audio.Properties.Resources.Pause;
            this.btnPausedSteganoMP3.Location = new System.Drawing.Point(42, 0);
            this.btnPausedSteganoMP3.Name = "btnPausedSteganoMP3";
            this.btnPausedSteganoMP3.Size = new System.Drawing.Size(33, 23);
            this.btnPausedSteganoMP3.TabIndex = 5;
            this.btnPausedSteganoMP3.UseVisualStyleBackColor = true;
            this.btnPausedSteganoMP3.Click += new System.EventHandler(this.btnPausedSteganoMP3_Click);
            // 
            // btnPlaySteganoMP3
            // 
            this.btnPlaySteganoMP3.Image = global::Revisi_Stegano_Audio.Properties.Resources.Play;
            this.btnPlaySteganoMP3.Location = new System.Drawing.Point(3, 0);
            this.btnPlaySteganoMP3.Name = "btnPlaySteganoMP3";
            this.btnPlaySteganoMP3.Size = new System.Drawing.Size(33, 23);
            this.btnPlaySteganoMP3.TabIndex = 4;
            this.btnPlaySteganoMP3.UseVisualStyleBackColor = true;
            this.btnPlaySteganoMP3.Click += new System.EventHandler(this.btnPlaySteganoMP3_Click);
            // 
            // btnOpenSteganofile
            // 
            this.btnOpenSteganofile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenSteganofile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSteganofile.Image")));
            this.btnOpenSteganofile.Location = new System.Drawing.Point(775, 3);
            this.btnOpenSteganofile.Name = "btnOpenSteganofile";
            this.btnOpenSteganofile.Size = new System.Drawing.Size(53, 24);
            this.btnOpenSteganofile.TabIndex = 5;
            this.btnOpenSteganofile.UseVisualStyleBackColor = true;
            this.btnOpenSteganofile.Click += new System.EventHandler(this.btnOpenSteganofile_Click);
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowseDestination.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowseDestination.Image")));
            this.btnBrowseDestination.Location = new System.Drawing.Point(775, 63);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(53, 24);
            this.btnBrowseDestination.TabIndex = 6;
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtSteganofile
            // 
            this.txtSteganofile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel3.SetColumnSpan(this.txtSteganofile, 2);
            this.txtSteganofile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSteganofile.Location = new System.Drawing.Point(100, 3);
            this.txtSteganofile.Name = "txtSteganofile";
            this.txtSteganofile.ReadOnly = true;
            this.txtSteganofile.Size = new System.Drawing.Size(669, 22);
            this.txtSteganofile.TabIndex = 8;
            this.txtSteganofile.TextChanged += new System.EventHandler(this.txtSteganofile_TextChanged);
            this.txtSteganofile.DoubleClick += new System.EventHandler(this.txtSteganofile_DoubleClick);
            // 
            // txtDestinaion
            // 
            this.txtDestinaion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tableLayoutPanel3.SetColumnSpan(this.txtDestinaion, 2);
            this.txtDestinaion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinaion.Location = new System.Drawing.Point(100, 63);
            this.txtDestinaion.Name = "txtDestinaion";
            this.txtDestinaion.ReadOnly = true;
            this.txtDestinaion.Size = new System.Drawing.Size(669, 22);
            this.txtDestinaion.TabIndex = 9;
            this.txtDestinaion.DoubleClick += new System.EventHandler(this.txtDestinaion_DoubleClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(100, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(134, 22);
            this.txtPassword.TabIndex = 10;
            // 
            // cbIsImage
            // 
            this.cbIsImage.AutoSize = true;
            this.cbIsImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIsImage.Location = new System.Drawing.Point(240, 93);
            this.cbIsImage.Name = "cbIsImage";
            this.cbIsImage.Size = new System.Drawing.Size(529, 27);
            this.cbIsImage.TabIndex = 11;
            this.cbIsImage.Text = "Check this if the message is an image";
            this.cbIsImage.UseVisualStyleBackColor = true;
            this.cbIsImage.CheckedChanged += new System.EventHandler(this.cbIsImage_CheckedChanged);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingToolStripMenuItem.Text = "Settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cryptographySettingToolStripMenuItem
            // 
            this.cryptographySettingToolStripMenuItem.Name = "cryptographySettingToolStripMenuItem";
            this.cryptographySettingToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cryptographySettingToolStripMenuItem.Text = "AES Algorithm...";
            this.cryptographySettingToolStripMenuItem.Click += new System.EventHandler(this.cryptographySettingToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.settingToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::Revisi_Stegano_Audio.Properties.Resources._1302071844_application_exit;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // settingToolStripMenuItem1
            // 
            this.settingToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aESAlgorithmToolStripMenuItem});
            this.settingToolStripMenuItem1.Name = "settingToolStripMenuItem1";
            this.settingToolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem1.Text = "Setting";
            // 
            // aESAlgorithmToolStripMenuItem
            // 
            this.aESAlgorithmToolStripMenuItem.Image = global::Revisi_Stegano_Audio.Properties.Resources._1302064678_tools_preferences;
            this.aESAlgorithmToolStripMenuItem.Name = "aESAlgorithmToolStripMenuItem";
            this.aESAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.aESAlgorithmToolStripMenuItem.Text = "AES Algorithm...";
            this.aESAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.aESAlgorithmToolStripMenuItem_Click);
            // 
            // FrmExtraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmExtraction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmExtraction";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmExtraction_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnExtraction;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStopSteganoMP3;
        private System.Windows.Forms.Button btnPausedSteganoMP3;
        private System.Windows.Forms.Button btnPlaySteganoMP3;
        private System.Windows.Forms.Button btnOpenSteganofile;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnOpenMessage;
        private System.Windows.Forms.TextBox txtSteganofile;
        private System.Windows.Forms.TextBox txtDestinaion;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cbIsImage;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cryptographySettingToolStripMenuItem;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aESAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    }
}