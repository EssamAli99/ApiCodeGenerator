namespace ApiCodeGenerator
{
    partial class frmMain
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
            btnStart = new Button();
            lblWelcome = new Label();
            btnPervious3 = new Button();
            label5 = new Label();
            checkedListBoxEntities = new CheckedListBox();
            txtApiProjectName = new TextBox();
            txtApiName = new TextBox();
            label4 = new Label();
            txtConnectionString = new TextBox();
            btnTestConnection = new Button();
            btnPervious2 = new Button();
            btnNext2 = new Button();
            btnNext1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            fbdAppFolder = new FolderBrowserDialog();
            txtProjectFolder = new TextBox();
            pnlScreen2 = new Panel();
            label6 = new Label();
            ddlAuthType = new ComboBox();
            btnBrowse = new Button();
            pnlScreen1 = new Panel();
            btnGenerate = new Button();
            pnlScreen3 = new Panel();
            apiProjectSettingsBindingSource = new BindingSource(components);
            pnlScreen2.SuspendLayout();
            pnlScreen1.SuspendLayout();
            pnlScreen3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apiProjectSettingsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(0, 0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 14;
            // 
            // lblWelcome
            // 
            lblWelcome.Location = new Point(0, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(100, 23);
            lblWelcome.TabIndex = 13;
            // 
            // btnPervious3
            // 
            btnPervious3.Location = new Point(50, 366);
            btnPervious3.Name = "btnPervious3";
            btnPervious3.Size = new Size(94, 29);
            btnPervious3.TabIndex = 3;
            btnPervious3.Text = "Previous";
            btnPervious3.UseVisualStyleBackColor = true;
            btnPervious3.MouseCaptureChanged += btnPrevious3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 25);
            label5.Name = "label5";
            label5.Size = new Size(156, 20);
            label5.TabIndex = 1;
            label5.Text = "Entities (Tables/Views)";
            // 
            // checkedListBoxEntities
            // 
            checkedListBoxEntities.FormattingEnabled = true;
            checkedListBoxEntities.Location = new Point(174, 25);
            checkedListBoxEntities.Name = "checkedListBoxEntities";
            checkedListBoxEntities.Size = new Size(399, 334);
            checkedListBoxEntities.TabIndex = 0;
            // 
            // txtApiProjectName
            // 
            txtApiProjectName.Location = new Point(150, 15);
            txtApiProjectName.Name = "txtApiProjectName";
            txtApiProjectName.Size = new Size(423, 27);
            txtApiProjectName.TabIndex = 0;
            // 
            // txtApiName
            // 
            txtApiName.Location = new Point(150, 56);
            txtApiName.Name = "txtApiName";
            txtApiName.Size = new Size(423, 27);
            txtApiName.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 16);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 4;
            label4.Text = "Connection String: ";
            // 
            // txtConnectionString
            // 
            txtConnectionString.Location = new Point(152, 13);
            txtConnectionString.Name = "txtConnectionString";
            txtConnectionString.Size = new Size(421, 27);
            txtConnectionString.TabIndex = 3;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Location = new Point(385, 46);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(188, 29);
            btnTestConnection.TabIndex = 2;
            btnTestConnection.Text = "Test DB Connection";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnPervious2
            // 
            btnPervious2.Location = new Point(47, 266);
            btnPervious2.Name = "btnPervious2";
            btnPervious2.Size = new Size(94, 29);
            btnPervious2.TabIndex = 1;
            btnPervious2.Text = "Previous";
            btnPervious2.UseVisualStyleBackColor = true;
            btnPervious2.Click += btnPrevious2_Click;
            // 
            // btnNext2
            // 
            btnNext2.Location = new Point(479, 266);
            btnNext2.Name = "btnNext2";
            btnNext2.Size = new Size(94, 29);
            btnNext2.TabIndex = 0;
            btnNext2.Text = "Next";
            btnNext2.UseVisualStyleBackColor = true;
            btnNext2.Click += btnNext2_Click;
            // 
            // btnNext1
            // 
            btnNext1.Location = new Point(479, 154);
            btnNext1.Name = "btnNext1";
            btnNext1.Size = new Size(94, 29);
            btnNext1.TabIndex = 6;
            btnNext1.Text = "Next";
            btnNext1.UseVisualStyleBackColor = true;
            btnNext1.Click += btnNext1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 102);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 5;
            label3.Text = "Project Folder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 59);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 4;
            label2.Text = "API Name: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(132, 20);
            label1.TabIndex = 3;
            label1.Text = "API Project Name: ";
            // 
            // txtProjectFolder
            // 
            txtProjectFolder.Location = new Point(150, 99);
            txtProjectFolder.Name = "txtProjectFolder";
            txtProjectFolder.Size = new Size(387, 27);
            txtProjectFolder.TabIndex = 2;
            // 
            // pnlScreen2
            // 
            pnlScreen2.Controls.Add(label6);
            pnlScreen2.Controls.Add(ddlAuthType);
            pnlScreen2.Controls.Add(label4);
            pnlScreen2.Controls.Add(txtConnectionString);
            pnlScreen2.Controls.Add(btnTestConnection);
            pnlScreen2.Controls.Add(btnPervious2);
            pnlScreen2.Controls.Add(btnNext2);
            pnlScreen2.Location = new Point(106, 14);
            pnlScreen2.Name = "pnlScreen2";
            pnlScreen2.Size = new Size(591, 325);
            pnlScreen2.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 87);
            label6.Name = "label6";
            label6.Size = new Size(146, 20);
            label6.TabIndex = 6;
            label6.Text = "Authentication type: ";
            // 
            // ddlAuthType
            // 
            ddlAuthType.DataBindings.Add(new Binding("SelectedItem", apiProjectSettingsBindingSource, "AuthenticationType", true));
            ddlAuthType.DataBindings.Add(new Binding("SelectedValue", apiProjectSettingsBindingSource, "AuthenticationType", true));
            ddlAuthType.FormattingEnabled = true;
            ddlAuthType.Items.AddRange(new object[] { "None", "JWT", "API Key", "OAuth 2.0" });
            ddlAuthType.Location = new Point(152, 82);
            ddlAuthType.Name = "ddlAuthType";
            ddlAuthType.Size = new Size(421, 28);
            ddlAuthType.TabIndex = 5;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(543, 99);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(30, 29);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // pnlScreen1
            // 
            pnlScreen1.Controls.Add(btnBrowse);
            pnlScreen1.Controls.Add(txtApiProjectName);
            pnlScreen1.Controls.Add(btnNext1);
            pnlScreen1.Controls.Add(txtApiName);
            pnlScreen1.Controls.Add(label3);
            pnlScreen1.Controls.Add(txtProjectFolder);
            pnlScreen1.Controls.Add(label2);
            pnlScreen1.Controls.Add(label1);
            pnlScreen1.Location = new Point(15, 45);
            pnlScreen1.Name = "pnlScreen1";
            pnlScreen1.Size = new Size(591, 199);
            pnlScreen1.TabIndex = 10;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(479, 366);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(94, 29);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // pnlScreen3
            // 
            pnlScreen3.Controls.Add(btnPervious3);
            pnlScreen3.Controls.Add(btnGenerate);
            pnlScreen3.Controls.Add(label5);
            pnlScreen3.Controls.Add(checkedListBoxEntities);
            pnlScreen3.Location = new Point(15, 250);
            pnlScreen3.Name = "pnlScreen3";
            pnlScreen3.Size = new Size(591, 408);
            pnlScreen3.TabIndex = 12;
            // 
            // apiProjectSettingsBindingSource
            // 
            apiProjectSettingsBindingSource.DataSource = typeof(ApiProjectSettings);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 670);
            Controls.Add(pnlScreen2);
            Controls.Add(pnlScreen1);
            Controls.Add(pnlScreen3);
            Controls.Add(lblWelcome);
            Controls.Add(btnStart);
            Name = "frmMain";
            Text = "API Code Generator";
            pnlScreen2.ResumeLayout(false);
            pnlScreen2.PerformLayout();
            pnlScreen1.ResumeLayout(false);
            pnlScreen1.PerformLayout();
            pnlScreen3.ResumeLayout(false);
            pnlScreen3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)apiProjectSettingsBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnStart;
        private Label lblWelcome;
        private Button btnPervious3;
        private Label label5;
        private CheckedListBox checkedListBoxEntities;
        private TextBox txtApiProjectName;
        private TextBox txtApiName;
        private Label label4;
        private TextBox txtConnectionString;
        private Button btnTestConnection;
        private Button btnPervious2;
        private Button btnNext2;
        private Button btnNext1;
        private Label label3;
        private Label label2;
        private Label label1;
        private FolderBrowserDialog fbdAppFolder;
        private TextBox txtProjectFolder;
        private Panel pnlScreen2;
        private Panel pnlScreen1;
        private Button btnGenerate;
        private Panel pnlScreen3;
        private Button btnBrowse;
        private Label label6;
        private ComboBox ddlAuthType;
        private BindingSource apiProjectSettingsBindingSource;
    }
}
