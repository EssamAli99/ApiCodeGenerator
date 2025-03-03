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
            btnNext1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            fbdAppFolder = new FolderBrowserDialog();
            txtProjectFolder = new TextBox();
            pnlScreen2 = new Panel();
            btnGenerate = new Button();
            label6 = new Label();
            ddlAuthType = new ComboBox();
            apiProjectSettingsBindingSource = new BindingSource(components);
            btnBrowse = new Button();
            pnlScreen1 = new Panel();
            label7 = new Label();
            ddlLoggingType = new ComboBox();
            pnlScreen2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)apiProjectSettingsBindingSource).BeginInit();
            pnlScreen1.SuspendLayout();
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
            btnPervious3.Location = new Point(74, 432);
            btnPervious3.Name = "btnPervious3";
            btnPervious3.Size = new Size(94, 29);
            btnPervious3.TabIndex = 3;
            btnPervious3.Text = "Previous";
            btnPervious3.UseVisualStyleBackColor = true;
            btnPervious3.Click += btnPrevious3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 81);
            label5.Name = "label5";
            label5.Size = new Size(156, 20);
            label5.TabIndex = 1;
            label5.Text = "Entities (Tables/Views)";
            // 
            // checkedListBoxEntities
            // 
            checkedListBoxEntities.FormattingEnabled = true;
            checkedListBoxEntities.Location = new Point(174, 81);
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
            btnTestConnection.Text = "Connect";
            btnTestConnection.UseVisualStyleBackColor = true;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // btnNext1
            // 
            btnNext1.Location = new Point(479, 240);
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
            pnlScreen2.Controls.Add(btnPervious3);
            pnlScreen2.Controls.Add(label4);
            pnlScreen2.Controls.Add(btnGenerate);
            pnlScreen2.Controls.Add(txtConnectionString);
            pnlScreen2.Controls.Add(label5);
            pnlScreen2.Controls.Add(btnTestConnection);
            pnlScreen2.Controls.Add(checkedListBoxEntities);
            pnlScreen2.Location = new Point(609, 12);
            pnlScreen2.Name = "pnlScreen2";
            pnlScreen2.Size = new Size(591, 474);
            pnlScreen2.TabIndex = 9;
            pnlScreen2.Visible = false;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(479, 432);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(94, 29);
            btnGenerate.TabIndex = 2;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 192);
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
            ddlAuthType.Location = new Point(152, 187);
            ddlAuthType.Name = "ddlAuthType";
            ddlAuthType.Size = new Size(421, 28);
            ddlAuthType.TabIndex = 5;
            // 
            // apiProjectSettingsBindingSource
            // 
            apiProjectSettingsBindingSource.DataSource = typeof(ApiProjectSettings);
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
            pnlScreen1.Controls.Add(label6);
            pnlScreen1.Controls.Add(label7);
            pnlScreen1.Controls.Add(ddlAuthType);
            pnlScreen1.Controls.Add(ddlLoggingType);
            pnlScreen1.Controls.Add(btnBrowse);
            pnlScreen1.Controls.Add(txtApiProjectName);
            pnlScreen1.Controls.Add(btnNext1);
            pnlScreen1.Controls.Add(txtApiName);
            pnlScreen1.Controls.Add(label3);
            pnlScreen1.Controls.Add(txtProjectFolder);
            pnlScreen1.Controls.Add(label2);
            pnlScreen1.Controls.Add(label1);
            pnlScreen1.Location = new Point(12, 12);
            pnlScreen1.Name = "pnlScreen1";
            pnlScreen1.Size = new Size(591, 288);
            pnlScreen1.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 145);
            label7.Name = "label7";
            label7.Size = new Size(71, 20);
            label7.TabIndex = 13;
            label7.Text = "Logging: ";
            // 
            // ddlLoggingType
            // 
            ddlLoggingType.FormattingEnabled = true;
            ddlLoggingType.Location = new Point(150, 142);
            ddlLoggingType.Name = "ddlLoggingType";
            ddlLoggingType.Size = new Size(423, 28);
            ddlLoggingType.TabIndex = 12;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 553);
            Controls.Add(pnlScreen2);
            Controls.Add(lblWelcome);
            Controls.Add(btnStart);
            Controls.Add(pnlScreen1);
            Name = "frmMain";
            Text = "API Code Generator";
            pnlScreen2.ResumeLayout(false);
            pnlScreen2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)apiProjectSettingsBindingSource).EndInit();
            pnlScreen1.ResumeLayout(false);
            pnlScreen1.PerformLayout();
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
        private Button btnNext1;
        private Label label3;
        private Label label2;
        private Label label1;
        private FolderBrowserDialog fbdAppFolder;
        private TextBox txtProjectFolder;
        private Panel pnlScreen2;
        private Panel pnlScreen1;
        private Button btnGenerate;
        private Button btnBrowse;
        private Label label6;
        private ComboBox ddlAuthType;
        private BindingSource apiProjectSettingsBindingSource;
        private ComboBox ddlLoggingType;
        private Label label7;
    }
}
