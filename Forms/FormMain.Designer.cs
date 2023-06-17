namespace DriverDash
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            buttonDownload = new Button();
            buttonCheckFile = new Button();
            labelDownloaded = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labelTotal = new Label();
            buttonSetPath = new Button();
            panelTitleBar = new Panel();
            labelDriverDash = new Label();
            buttonMin = new Button();
            buttonMinimize = new Button();
            buttonExit = new Button();
            buttonClose = new Button();
            buttonMaximize = new Button();
            labelCurrentVersion = new Label();
            labelLatest = new Label();
            labelDriverVersion = new Label();
            labelLatestVersionData = new Label();
            labelCurrentVersionData = new Label();
            labelQueryState = new Label();
            labelTypeData = new Label();
            labelType = new Label();
            labelSeriesData = new Label();
            labelSeries = new Label();
            labelProductData = new Label();
            labelProduct = new Label();
            labelOSData = new Label();
            labelOS = new Label();
            labelLoadTypeData = new Label();
            labelLoadType = new Label();
            labelLanguageData = new Label();
            labelLanguage = new Label();
            labelState = new Label();
            labelLoadedData = new Label();
            labelStateData = new Label();
            labelTotalData = new Label();
            panelDriverStatus = new Panel();
            panelLoadState = new Panel();
            labelLoadStatus = new Label();
            panelQueryState = new Panel();
            panelTitleBar.SuspendLayout();
            panelDriverStatus.SuspendLayout();
            panelLoadState.SuspendLayout();
            panelQueryState.SuspendLayout();
            SuspendLayout();
            // 
            // buttonDownload
            // 
            buttonDownload.BackColor = Color.FromArgb(45, 45, 45);
            buttonDownload.FlatAppearance.BorderSize = 0;
            buttonDownload.FlatStyle = FlatStyle.Flat;
            buttonDownload.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDownload.ForeColor = SystemColors.Control;
            buttonDownload.Location = new Point(12, 370);
            buttonDownload.Margin = new Padding(10, 20, 10, 20);
            buttonDownload.Name = "buttonDownload";
            buttonDownload.Size = new Size(94, 28);
            buttonDownload.TabIndex = 4;
            buttonDownload.Text = "Download";
            buttonDownload.UseVisualStyleBackColor = false;
            buttonDownload.Click += buttonDownload_Click;
            // 
            // buttonCheckFile
            // 
            buttonCheckFile.BackColor = Color.FromArgb(45, 45, 45);
            buttonCheckFile.FlatAppearance.BorderSize = 0;
            buttonCheckFile.FlatStyle = FlatStyle.Flat;
            buttonCheckFile.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCheckFile.ForeColor = SystemColors.Control;
            buttonCheckFile.Location = new Point(268, 370);
            buttonCheckFile.Margin = new Padding(10, 20, 10, 20);
            buttonCheckFile.Name = "buttonCheckFile";
            buttonCheckFile.Size = new Size(85, 28);
            buttonCheckFile.TabIndex = 10;
            buttonCheckFile.Text = "Check file";
            buttonCheckFile.UseVisualStyleBackColor = false;
            buttonCheckFile.Click += buttonCheckFile_Click;
            // 
            // labelDownloaded
            // 
            labelDownloaded.AutoSize = true;
            labelDownloaded.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelDownloaded.ForeColor = Color.White;
            labelDownloaded.Location = new Point(8, 116);
            labelDownloaded.Margin = new Padding(5);
            labelDownloaded.Name = "labelDownloaded";
            labelDownloaded.Padding = new Padding(10, 0, 0, 0);
            labelDownloaded.Size = new Size(73, 20);
            labelDownloaded.TabIndex = 12;
            labelDownloaded.Text = "Loaded:";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotal.ForeColor = Color.White;
            labelTotal.Location = new Point(8, 86);
            labelTotal.Margin = new Padding(5);
            labelTotal.Name = "labelTotal";
            labelTotal.Padding = new Padding(10, 0, 0, 0);
            labelTotal.Size = new Size(57, 20);
            labelTotal.TabIndex = 13;
            labelTotal.Text = "Total:";
            // 
            // buttonSetPath
            // 
            buttonSetPath.BackColor = Color.FromArgb(45, 45, 45);
            buttonSetPath.FlatAppearance.BorderSize = 0;
            buttonSetPath.FlatStyle = FlatStyle.Flat;
            buttonSetPath.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSetPath.ForeColor = SystemColors.Control;
            buttonSetPath.Location = new Point(373, 370);
            buttonSetPath.Margin = new Padding(10, 20, 10, 20);
            buttonSetPath.Name = "buttonSetPath";
            buttonSetPath.Size = new Size(74, 28);
            buttonSetPath.TabIndex = 14;
            buttonSetPath.Text = "Set Path";
            buttonSetPath.UseVisualStyleBackColor = false;
            buttonSetPath.Click += buttonSetPath_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(45, 45, 45);
            panelTitleBar.Controls.Add(labelDriverDash);
            panelTitleBar.Controls.Add(buttonMin);
            panelTitleBar.Controls.Add(buttonMinimize);
            panelTitleBar.Controls.Add(buttonExit);
            panelTitleBar.Controls.Add(buttonClose);
            panelTitleBar.Controls.Add(buttonMaximize);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(694, 27);
            panelTitleBar.TabIndex = 15;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            panelTitleBar.MouseMove += panelTitleBar_MouseMove;
            panelTitleBar.MouseUp += panelTitleBar_MouseUp;
            // 
            // labelDriverDash
            // 
            labelDriverDash.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelDriverDash.ForeColor = Color.White;
            labelDriverDash.Location = new Point(0, 0);
            labelDriverDash.Name = "labelDriverDash";
            labelDriverDash.Size = new Size(98, 27);
            labelDriverDash.TabIndex = 16;
            labelDriverDash.Text = "DriverDash";
            labelDriverDash.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonMin
            // 
            buttonMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMin.FlatAppearance.BorderSize = 0;
            buttonMin.FlatStyle = FlatStyle.Flat;
            buttonMin.Image = Resources.minimize;
            buttonMin.Location = new Point(638, 0);
            buttonMin.Name = "buttonMin";
            buttonMin.Size = new Size(25, 27);
            buttonMin.TabIndex = 16;
            buttonMin.UseVisualStyleBackColor = true;
            buttonMin.Click += buttonMin_Click;
            // 
            // buttonMinimize
            // 
            buttonMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMinimize.FlatAppearance.BorderSize = 0;
            buttonMinimize.FlatStyle = FlatStyle.Flat;
            buttonMinimize.Location = new Point(1727, 0);
            buttonMinimize.Name = "buttonMinimize";
            buttonMinimize.Size = new Size(25, 27);
            buttonMinimize.TabIndex = 0;
            buttonMinimize.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Image = Resources.close;
            buttonExit.Location = new Point(669, 0);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(25, 27);
            buttonExit.TabIndex = 17;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClose.FlatAppearance.BorderSize = 0;
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.Location = new Point(1789, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(25, 27);
            buttonClose.TabIndex = 0;
            // 
            // buttonMaximize
            // 
            buttonMaximize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonMaximize.FlatAppearance.BorderSize = 0;
            buttonMaximize.FlatStyle = FlatStyle.Flat;
            buttonMaximize.ForeColor = Color.White;
            buttonMaximize.Location = new Point(1758, 0);
            buttonMaximize.Name = "buttonMaximize";
            buttonMaximize.Size = new Size(25, 27);
            buttonMaximize.TabIndex = 0;
            buttonMaximize.UseVisualStyleBackColor = true;
            // 
            // labelCurrentVersion
            // 
            labelCurrentVersion.AutoSize = true;
            labelCurrentVersion.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentVersion.ForeColor = Color.White;
            labelCurrentVersion.Location = new Point(8, 86);
            labelCurrentVersion.Margin = new Padding(5);
            labelCurrentVersion.Name = "labelCurrentVersion";
            labelCurrentVersion.Padding = new Padding(10, 0, 0, 0);
            labelCurrentVersion.Size = new Size(77, 20);
            labelCurrentVersion.TabIndex = 16;
            labelCurrentVersion.Text = "Current:";
            labelCurrentVersion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelLatest
            // 
            labelLatest.AutoSize = true;
            labelLatest.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLatest.ForeColor = Color.White;
            labelLatest.Location = new Point(8, 56);
            labelLatest.Margin = new Padding(5);
            labelLatest.Name = "labelLatest";
            labelLatest.Padding = new Padding(10, 0, 0, 0);
            labelLatest.Size = new Size(66, 20);
            labelLatest.TabIndex = 17;
            labelLatest.Text = "Latest:";
            labelLatest.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelDriverVersion
            // 
            labelDriverVersion.AutoSize = true;
            labelDriverVersion.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelDriverVersion.ForeColor = Color.White;
            labelDriverVersion.Location = new Point(8, 5);
            labelDriverVersion.Name = "labelDriverVersion";
            labelDriverVersion.Padding = new Padding(0, 10, 0, 10);
            labelDriverVersion.Size = new Size(138, 46);
            labelDriverVersion.TabIndex = 18;
            labelDriverVersion.Text = "Driver version";
            // 
            // labelLatestVersionData
            // 
            labelLatestVersionData.AutoSize = true;
            labelLatestVersionData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLatestVersionData.ForeColor = Color.White;
            labelLatestVersionData.Location = new Point(93, 56);
            labelLatestVersionData.Name = "labelLatestVersionData";
            labelLatestVersionData.Size = new Size(81, 20);
            labelLatestVersionData.TabIndex = 19;
            labelLatestVersionData.Text = "some-text";
            // 
            // labelCurrentVersionData
            // 
            labelCurrentVersionData.AutoSize = true;
            labelCurrentVersionData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelCurrentVersionData.ForeColor = Color.White;
            labelCurrentVersionData.Location = new Point(93, 86);
            labelCurrentVersionData.Name = "labelCurrentVersionData";
            labelCurrentVersionData.Size = new Size(81, 20);
            labelCurrentVersionData.TabIndex = 20;
            labelCurrentVersionData.Text = "some-text";
            // 
            // labelQueryState
            // 
            labelQueryState.AutoSize = true;
            labelQueryState.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelQueryState.ForeColor = Color.White;
            labelQueryState.Location = new Point(8, 5);
            labelQueryState.Name = "labelQueryState";
            labelQueryState.Padding = new Padding(0, 10, 0, 10);
            labelQueryState.Size = new Size(140, 46);
            labelQueryState.TabIndex = 21;
            labelQueryState.Text = "Query content";
            // 
            // labelTypeData
            // 
            labelTypeData.AutoSize = true;
            labelTypeData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTypeData.ForeColor = Color.White;
            labelTypeData.Location = new Point(108, 56);
            labelTypeData.Name = "labelTypeData";
            labelTypeData.Size = new Size(81, 20);
            labelTypeData.TabIndex = 23;
            labelTypeData.Text = "some-text";
            // 
            // labelType
            // 
            labelType.AutoSize = true;
            labelType.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelType.ForeColor = Color.White;
            labelType.Location = new Point(8, 56);
            labelType.Margin = new Padding(5);
            labelType.Name = "labelType";
            labelType.Padding = new Padding(10, 0, 0, 0);
            labelType.Size = new Size(55, 20);
            labelType.TabIndex = 22;
            labelType.Text = "Type:";
            labelType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSeriesData
            // 
            labelSeriesData.AutoSize = true;
            labelSeriesData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelSeriesData.ForeColor = Color.White;
            labelSeriesData.Location = new Point(108, 86);
            labelSeriesData.Name = "labelSeriesData";
            labelSeriesData.Size = new Size(81, 20);
            labelSeriesData.TabIndex = 25;
            labelSeriesData.Text = "some-text";
            // 
            // labelSeries
            // 
            labelSeries.AutoSize = true;
            labelSeries.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelSeries.ForeColor = Color.White;
            labelSeries.Location = new Point(8, 86);
            labelSeries.Margin = new Padding(5);
            labelSeries.Name = "labelSeries";
            labelSeries.Padding = new Padding(10, 0, 0, 0);
            labelSeries.Size = new Size(64, 20);
            labelSeries.TabIndex = 24;
            labelSeries.Text = "Series:";
            labelSeries.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelProductData
            // 
            labelProductData.AutoSize = true;
            labelProductData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelProductData.ForeColor = Color.White;
            labelProductData.Location = new Point(108, 116);
            labelProductData.Name = "labelProductData";
            labelProductData.Size = new Size(81, 20);
            labelProductData.TabIndex = 27;
            labelProductData.Text = "some-text";
            // 
            // labelProduct
            // 
            labelProduct.AutoSize = true;
            labelProduct.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelProduct.ForeColor = Color.White;
            labelProduct.Location = new Point(8, 116);
            labelProduct.Margin = new Padding(5);
            labelProduct.Name = "labelProduct";
            labelProduct.Padding = new Padding(10, 0, 0, 0);
            labelProduct.Size = new Size(78, 20);
            labelProduct.TabIndex = 26;
            labelProduct.Text = "Product:";
            labelProduct.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelOSData
            // 
            labelOSData.AutoSize = true;
            labelOSData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelOSData.ForeColor = Color.White;
            labelOSData.Location = new Point(108, 144);
            labelOSData.Name = "labelOSData";
            labelOSData.Size = new Size(81, 20);
            labelOSData.TabIndex = 29;
            labelOSData.Text = "some-text";
            // 
            // labelOS
            // 
            labelOS.AutoSize = true;
            labelOS.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelOS.ForeColor = Color.White;
            labelOS.Location = new Point(8, 146);
            labelOS.Margin = new Padding(5);
            labelOS.Name = "labelOS";
            labelOS.Padding = new Padding(10, 0, 0, 0);
            labelOS.Size = new Size(42, 20);
            labelOS.TabIndex = 28;
            labelOS.Text = "OS:";
            labelOS.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelLoadTypeData
            // 
            labelLoadTypeData.AutoSize = true;
            labelLoadTypeData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoadTypeData.ForeColor = Color.White;
            labelLoadTypeData.Location = new Point(108, 176);
            labelLoadTypeData.Name = "labelLoadTypeData";
            labelLoadTypeData.Size = new Size(81, 20);
            labelLoadTypeData.TabIndex = 31;
            labelLoadTypeData.Text = "some-text";
            // 
            // labelLoadType
            // 
            labelLoadType.AutoSize = true;
            labelLoadType.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoadType.ForeColor = Color.White;
            labelLoadType.Location = new Point(8, 176);
            labelLoadType.Margin = new Padding(5);
            labelLoadType.Name = "labelLoadType";
            labelLoadType.Padding = new Padding(10, 0, 0, 0);
            labelLoadType.Size = new Size(92, 20);
            labelLoadType.TabIndex = 30;
            labelLoadType.Text = "Load Type:";
            labelLoadType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelLanguageData
            // 
            labelLanguageData.AutoSize = true;
            labelLanguageData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLanguageData.ForeColor = Color.White;
            labelLanguageData.Location = new Point(108, 206);
            labelLanguageData.Name = "labelLanguageData";
            labelLanguageData.Size = new Size(81, 20);
            labelLanguageData.TabIndex = 33;
            labelLanguageData.Text = "some-text";
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLanguage.ForeColor = Color.White;
            labelLanguage.Location = new Point(8, 206);
            labelLanguage.Margin = new Padding(5);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Padding = new Padding(10, 0, 0, 0);
            labelLanguage.Size = new Size(91, 20);
            labelLanguage.TabIndex = 32;
            labelLanguage.Text = "Language:";
            labelLanguage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelState
            // 
            labelState.AutoSize = true;
            labelState.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelState.ForeColor = Color.White;
            labelState.Location = new Point(8, 57);
            labelState.Margin = new Padding(5);
            labelState.Name = "labelState";
            labelState.Padding = new Padding(10, 0, 0, 0);
            labelState.Size = new Size(67, 20);
            labelState.TabIndex = 34;
            labelState.Text = "Status:";
            // 
            // labelLoadedData
            // 
            labelLoadedData.AutoSize = true;
            labelLoadedData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoadedData.ForeColor = Color.White;
            labelLoadedData.Location = new Point(86, 116);
            labelLoadedData.Name = "labelLoadedData";
            labelLoadedData.Size = new Size(15, 20);
            labelLoadedData.TabIndex = 35;
            labelLoadedData.Text = "-";
            // 
            // labelStateData
            // 
            labelStateData.AutoSize = true;
            labelStateData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelStateData.ForeColor = Color.White;
            labelStateData.Location = new Point(86, 57);
            labelStateData.Name = "labelStateData";
            labelStateData.Size = new Size(15, 20);
            labelStateData.TabIndex = 36;
            labelStateData.Text = "-";
            // 
            // labelTotalData
            // 
            labelTotalData.AutoSize = true;
            labelTotalData.Font = new Font("Segoe UI Variable Small Semibol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalData.ForeColor = Color.White;
            labelTotalData.Location = new Point(86, 86);
            labelTotalData.Name = "labelTotalData";
            labelTotalData.Size = new Size(15, 20);
            labelTotalData.TabIndex = 37;
            labelTotalData.Text = "-";
            // 
            // panelDriverStatus
            // 
            panelDriverStatus.BackColor = Color.FromArgb(45, 45, 45);
            panelDriverStatus.Controls.Add(labelDriverVersion);
            panelDriverStatus.Controls.Add(labelCurrentVersion);
            panelDriverStatus.Controls.Add(labelLatest);
            panelDriverStatus.Controls.Add(labelLatestVersionData);
            panelDriverStatus.Controls.Add(labelCurrentVersionData);
            panelDriverStatus.Location = new Point(12, 50);
            panelDriverStatus.Margin = new Padding(5);
            panelDriverStatus.Name = "panelDriverStatus";
            panelDriverStatus.Padding = new Padding(5);
            panelDriverStatus.Size = new Size(246, 123);
            panelDriverStatus.TabIndex = 38;
            // 
            // panelLoadState
            // 
            panelLoadState.BackColor = Color.FromArgb(45, 45, 45);
            panelLoadState.Controls.Add(labelLoadStatus);
            panelLoadState.Controls.Add(labelDownloaded);
            panelLoadState.Controls.Add(labelTotal);
            panelLoadState.Controls.Add(labelState);
            panelLoadState.Controls.Add(labelTotalData);
            panelLoadState.Controls.Add(labelLoadedData);
            panelLoadState.Controls.Add(labelStateData);
            panelLoadState.Location = new Point(12, 183);
            panelLoadState.Margin = new Padding(5);
            panelLoadState.Name = "panelLoadState";
            panelLoadState.Padding = new Padding(5);
            panelLoadState.Size = new Size(246, 162);
            panelLoadState.TabIndex = 39;
            // 
            // labelLoadStatus
            // 
            labelLoadStatus.AutoSize = true;
            labelLoadStatus.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelLoadStatus.ForeColor = Color.White;
            labelLoadStatus.Location = new Point(8, 6);
            labelLoadStatus.Name = "labelLoadStatus";
            labelLoadStatus.Padding = new Padding(0, 10, 0, 10);
            labelLoadStatus.Size = new Size(114, 46);
            labelLoadStatus.TabIndex = 40;
            labelLoadStatus.Text = "Load status";
            // 
            // panelQueryState
            // 
            panelQueryState.BackColor = Color.FromArgb(45, 45, 45);
            panelQueryState.Controls.Add(labelQueryState);
            panelQueryState.Controls.Add(labelType);
            panelQueryState.Controls.Add(labelTypeData);
            panelQueryState.Controls.Add(labelLanguageData);
            panelQueryState.Controls.Add(labelSeries);
            panelQueryState.Controls.Add(labelLanguage);
            panelQueryState.Controls.Add(labelSeriesData);
            panelQueryState.Controls.Add(labelLoadTypeData);
            panelQueryState.Controls.Add(labelProduct);
            panelQueryState.Controls.Add(labelLoadType);
            panelQueryState.Controls.Add(labelProductData);
            panelQueryState.Controls.Add(labelOSData);
            panelQueryState.Controls.Add(labelOS);
            panelQueryState.Location = new Point(268, 50);
            panelQueryState.Margin = new Padding(5);
            panelQueryState.Name = "panelQueryState";
            panelQueryState.Padding = new Padding(5);
            panelQueryState.Size = new Size(411, 295);
            panelQueryState.TabIndex = 39;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(694, 423);
            Controls.Add(panelLoadState);
            Controls.Add(panelQueryState);
            Controls.Add(panelDriverStatus);
            Controls.Add(panelTitleBar);
            Controls.Add(buttonSetPath);
            Controls.Add(buttonCheckFile);
            Controls.Add(buttonDownload);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DriverDash";
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            panelTitleBar.ResumeLayout(false);
            panelDriverStatus.ResumeLayout(false);
            panelDriverStatus.PerformLayout();
            panelLoadState.ResumeLayout(false);
            panelLoadState.PerformLayout();
            panelQueryState.ResumeLayout(false);
            panelQueryState.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonDownload;
        private Button buttonCheckFile;
        private Label labelDownloaded;
        private System.Windows.Forms.Timer timer1;
        private Label labelTotal;
        private Button buttonSetPath;
        private Panel panelTitleBar;
        private Button buttonMin;
        private Button buttonMinimize;
        private Button buttonExit;
        private Button buttonClose;
        private Button buttonMaximize;
        private Label labelDriverDash;
        private Label labelCurrentVersion;
        private Label labelLatest;
        private Label labelDriverVersion;
        private Label labelLatestVersionData;
        private Label labelCurrentVersionData;
        private Label labelQueryState;
        private Label labelTypeData;
        private Label labelType;
        private Label labelSeriesData;
        private Label labelSeries;
        private Label labelProductData;
        private Label labelProduct;
        private Label labelOSData;
        private Label labelOS;
        private Label labelLoadTypeData;
        private Label labelLoadType;
        private Label labelLanguageData;
        private Label labelLanguage;
        private Label labelState;
        private Label labelLoadedData;
        private Label labelStateData;
        private Label labelTotalData;
        private Panel panelDriverStatus;
        private Panel panelLoadState;
        private Panel panelQueryState;
        private Label labelLoadStatus;
    }
}