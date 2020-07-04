namespace AssetsManagementForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBoxAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 25);
            this.panel1.TabIndex = 5;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelStatus.Enabled = false;
            this.labelStatus.Location = new System.Drawing.Point(0, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            this.labelStatus.TabIndex = 0;
            // 
            // groupBoxAssets
            // 
            this.groupBoxAssets.Controls.Add(this.dataGridView1);
            this.groupBoxAssets.Location = new System.Drawing.Point(140, 18);
            this.groupBoxAssets.Name = "groupBoxAssets";
            this.groupBoxAssets.Size = new System.Drawing.Size(648, 388);
            this.groupBoxAssets.TabIndex = 6;
            this.groupBoxAssets.TabStop = false;
            this.groupBoxAssets.Text = "Assets";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(614, 349);
            this.dataGridView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

