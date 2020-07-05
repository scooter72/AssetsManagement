namespace AssetsManagementForms
{
    partial class MainForm
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
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.buttonAddOwner = new System.Windows.Forms.Button();
            this.buttonAddTenant = new System.Windows.Forms.Button();
            this.buttonAddRentalAgreement = new System.Windows.Forms.Button();
            this.buttonAddAsset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxAssets = new System.Windows.Forms.GroupBox();
            this.dataGridViewAssets = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRentalAgreemntEnd = new System.Windows.Forms.Label();
            this.labelStartRentalAgreemnt = new System.Windows.Forms.Label();
            this.labelRentalAgreementTenant = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBoxAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddCity
            // 
            this.buttonAddCity.Location = new System.Drawing.Point(12, 18);
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.Size = new System.Drawing.Size(100, 50);
            this.buttonAddCity.TabIndex = 0;
            this.buttonAddCity.Text = "Add City";
            this.buttonAddCity.UseVisualStyleBackColor = true;
            this.buttonAddCity.Click += new System.EventHandler(this.buttonAddCity_Click);
            // 
            // buttonAddOwner
            // 
            this.buttonAddOwner.Location = new System.Drawing.Point(12, 74);
            this.buttonAddOwner.Name = "buttonAddOwner";
            this.buttonAddOwner.Size = new System.Drawing.Size(100, 50);
            this.buttonAddOwner.TabIndex = 1;
            this.buttonAddOwner.Text = "Add Owner";
            this.buttonAddOwner.UseVisualStyleBackColor = true;
            this.buttonAddOwner.Click += new System.EventHandler(this.buttonAddOwner_Click);
            // 
            // buttonAddTenant
            // 
            this.buttonAddTenant.Location = new System.Drawing.Point(12, 130);
            this.buttonAddTenant.Name = "buttonAddTenant";
            this.buttonAddTenant.Size = new System.Drawing.Size(100, 50);
            this.buttonAddTenant.TabIndex = 2;
            this.buttonAddTenant.Text = "Add Tenant";
            this.buttonAddTenant.UseVisualStyleBackColor = true;
            this.buttonAddTenant.Click += new System.EventHandler(this.buttonAddTenant_Click);
            // 
            // buttonAddRentalAgreement
            // 
            this.buttonAddRentalAgreement.Location = new System.Drawing.Point(12, 242);
            this.buttonAddRentalAgreement.Name = "buttonAddRentalAgreement";
            this.buttonAddRentalAgreement.Size = new System.Drawing.Size(100, 50);
            this.buttonAddRentalAgreement.TabIndex = 3;
            this.buttonAddRentalAgreement.Text = "Add Rental Agreement";
            this.buttonAddRentalAgreement.UseVisualStyleBackColor = true;
            this.buttonAddRentalAgreement.Click += new System.EventHandler(this.buttonAddRentalAgreement_Click);
            // 
            // buttonAddAsset
            // 
            this.buttonAddAsset.Location = new System.Drawing.Point(12, 186);
            this.buttonAddAsset.Name = "buttonAddAsset";
            this.buttonAddAsset.Size = new System.Drawing.Size(100, 50);
            this.buttonAddAsset.TabIndex = 4;
            this.buttonAddAsset.Text = "Add Asset";
            this.buttonAddAsset.UseVisualStyleBackColor = true;
            this.buttonAddAsset.Click += new System.EventHandler(this.buttonAddAsset_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 25);
            this.panel1.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(30, 0, 3, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            this.labelStatus.TabIndex = 0;
            // 
            // groupBoxAssets
            // 
            this.groupBoxAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAssets.Controls.Add(this.dataGridViewAssets);
            this.groupBoxAssets.Location = new System.Drawing.Point(140, 18);
            this.groupBoxAssets.Name = "groupBoxAssets";
            this.groupBoxAssets.Size = new System.Drawing.Size(820, 350);
            this.groupBoxAssets.TabIndex = 6;
            this.groupBoxAssets.TabStop = false;
            this.groupBoxAssets.Text = "Assets";
            // 
            // dataGridViewAssets
            // 
            this.dataGridViewAssets.AllowUserToAddRows = false;
            this.dataGridViewAssets.AllowUserToDeleteRows = false;
            this.dataGridViewAssets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAssets.Location = new System.Drawing.Point(3, 18);
            this.dataGridViewAssets.MultiSelect = false;
            this.dataGridViewAssets.Name = "dataGridViewAssets";
            this.dataGridViewAssets.ReadOnly = true;
            this.dataGridViewAssets.RowHeadersVisible = false;
            this.dataGridViewAssets.RowHeadersWidth = 51;
            this.dataGridViewAssets.RowTemplate.Height = 24;
            this.dataGridViewAssets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAssets.Size = new System.Drawing.Size(814, 329);
            this.dataGridViewAssets.TabIndex = 0;
            this.dataGridViewAssets.SelectionChanged += new System.EventHandler(this.dataGridViewAssets_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelRentalAgreemntEnd);
            this.groupBox1.Controls.Add(this.labelStartRentalAgreemnt);
            this.groupBox1.Controls.Add(this.labelRentalAgreementTenant);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(140, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rental Agreement";
            // 
            // labelRentalAgreemntEnd
            // 
            this.labelRentalAgreemntEnd.AutoSize = true;
            this.labelRentalAgreemntEnd.Location = new System.Drawing.Point(404, 64);
            this.labelRentalAgreemntEnd.Name = "labelRentalAgreemntEnd";
            this.labelRentalAgreemntEnd.Size = new System.Drawing.Size(0, 17);
            this.labelRentalAgreemntEnd.TabIndex = 5;
            // 
            // labelStartRentalAgreemnt
            // 
            this.labelStartRentalAgreemnt.AutoSize = true;
            this.labelStartRentalAgreemnt.Location = new System.Drawing.Point(404, 26);
            this.labelStartRentalAgreemnt.Name = "labelStartRentalAgreemnt";
            this.labelStartRentalAgreemnt.Size = new System.Drawing.Size(0, 17);
            this.labelStartRentalAgreemnt.TabIndex = 4;
            // 
            // labelRentalAgreementTenant
            // 
            this.labelRentalAgreementTenant.AutoSize = true;
            this.labelRentalAgreementTenant.Location = new System.Drawing.Point(119, 26);
            this.labelRentalAgreementTenant.Name = "labelRentalAgreementTenant";
            this.labelRentalAgreementTenant.Size = new System.Drawing.Size(0, 17);
            this.labelRentalAgreementTenant.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(347, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Start:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(347, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "End:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tenant:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 537);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAssets);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonAddAsset);
            this.Controls.Add(this.buttonAddRentalAgreement);
            this.Controls.Add(this.buttonAddTenant);
            this.Controls.Add(this.buttonAddOwner);
            this.Controls.Add(this.buttonAddCity);
            this.Name = "MainForm";
            this.Text = "Assets Management";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Button buttonAddOwner;
        private System.Windows.Forms.Button buttonAddTenant;
        private System.Windows.Forms.Button buttonAddRentalAgreement;
        private System.Windows.Forms.Button buttonAddAsset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBoxAssets;
        private System.Windows.Forms.DataGridView dataGridViewAssets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRentalAgreemntEnd;
        private System.Windows.Forms.Label labelStartRentalAgreemnt;
        private System.Windows.Forms.Label labelRentalAgreementTenant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
    }
}

