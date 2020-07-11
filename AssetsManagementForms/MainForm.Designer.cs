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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.buttonAddOwner = new System.Windows.Forms.Button();
            this.buttonAddTenant = new System.Windows.Forms.Button();
            this.buttonAddRentalAgreement = new System.Windows.Forms.Button();
            this.groupBoxAssets = new System.Windows.Forms.GroupBox();
            this.dataGridViewAssets = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRentalAgreemntEnd = new System.Windows.Forms.Label();
            this.labelStartRentalAgreemnt = new System.Windows.Forms.Label();
            this.labelRentalAgreementTenant = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ownerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tenantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalAgreementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBoxAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAddCity
            // 
            this.buttonAddCity.Location = new System.Drawing.Point(12, 94);
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.Size = new System.Drawing.Size(100, 50);
            this.buttonAddCity.TabIndex = 0;
            this.buttonAddCity.Text = "Add City";
            this.buttonAddCity.UseVisualStyleBackColor = true;
            this.buttonAddCity.Click += new System.EventHandler(this.buttonAddCity_Click);
            // 
            // buttonAddOwner
            // 
            this.buttonAddOwner.Location = new System.Drawing.Point(12, 150);
            this.buttonAddOwner.Name = "buttonAddOwner";
            this.buttonAddOwner.Size = new System.Drawing.Size(100, 50);
            this.buttonAddOwner.TabIndex = 1;
            this.buttonAddOwner.Text = "Add Owner";
            this.buttonAddOwner.UseVisualStyleBackColor = true;
            this.buttonAddOwner.Click += new System.EventHandler(this.buttonAddOwner_Click);
            // 
            // buttonAddTenant
            // 
            this.buttonAddTenant.Location = new System.Drawing.Point(12, 206);
            this.buttonAddTenant.Name = "buttonAddTenant";
            this.buttonAddTenant.Size = new System.Drawing.Size(100, 50);
            this.buttonAddTenant.TabIndex = 2;
            this.buttonAddTenant.Text = "Add Tenant";
            this.buttonAddTenant.UseVisualStyleBackColor = true;
            this.buttonAddTenant.Click += new System.EventHandler(this.buttonAddTenant_Click);
            // 
            // buttonAddRentalAgreement
            // 
            this.buttonAddRentalAgreement.Location = new System.Drawing.Point(12, 318);
            this.buttonAddRentalAgreement.Name = "buttonAddRentalAgreement";
            this.buttonAddRentalAgreement.Size = new System.Drawing.Size(100, 50);
            this.buttonAddRentalAgreement.TabIndex = 3;
            this.buttonAddRentalAgreement.Text = "Add Rental Agreement";
            this.buttonAddRentalAgreement.UseVisualStyleBackColor = true;
            this.buttonAddRentalAgreement.Click += new System.EventHandler(this.buttonAddRentalAgreement_Click);
            // 
            // groupBoxAssets
            // 
            this.groupBoxAssets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAssets.Controls.Add(this.dataGridViewAssets);
            this.groupBoxAssets.Location = new System.Drawing.Point(130, 94);
            this.groupBoxAssets.Name = "groupBoxAssets";
            this.groupBoxAssets.Size = new System.Drawing.Size(839, 377);
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
            this.dataGridViewAssets.Size = new System.Drawing.Size(833, 356);
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
            this.groupBox1.Location = new System.Drawing.Point(130, 487);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(839, 100);
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(981, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cityToolStripMenuItem,
            this.ownerToolStripMenuItem,
            this.tenantToolStripMenuItem,
            this.assetToolStripMenuItem,
            this.rentalAgreementToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // cityToolStripMenuItem
            // 
            this.cityToolStripMenuItem.Name = "cityToolStripMenuItem";
            this.cityToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cityToolStripMenuItem.Text = "City...";
            this.cityToolStripMenuItem.Click += new System.EventHandler(this.cityToolStripMenuItem_Click);
            // 
            // ownerToolStripMenuItem
            // 
            this.ownerToolStripMenuItem.Name = "ownerToolStripMenuItem";
            this.ownerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ownerToolStripMenuItem.Text = "Owner...";
            this.ownerToolStripMenuItem.Click += new System.EventHandler(this.ownerToolStripMenuItem_Click);
            // 
            // tenantToolStripMenuItem
            // 
            this.tenantToolStripMenuItem.Name = "tenantToolStripMenuItem";
            this.tenantToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tenantToolStripMenuItem.Text = "Tenant...";
            this.tenantToolStripMenuItem.Click += new System.EventHandler(this.tenantToolStripMenuItem_Click);
            // 
            // assetToolStripMenuItem
            // 
            this.assetToolStripMenuItem.Name = "assetToolStripMenuItem";
            this.assetToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.assetToolStripMenuItem.Text = "Asset...";
            this.assetToolStripMenuItem.Click += new System.EventHandler(this.assetToolStripMenuItem_Click);
            // 
            // rentalAgreementToolStripMenuItem
            // 
            this.rentalAgreementToolStripMenuItem.Name = "rentalAgreementToolStripMenuItem";
            this.rentalAgreementToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rentalAgreementToolStripMenuItem.Text = "Rental Agreement....";
            this.rentalAgreementToolStripMenuItem.Click += new System.EventHandler(this.rentalAgreementToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip2
            // 
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip2.Location = new System.Drawing.Point(0, 618);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(981, 22);
            this.statusStrip2.TabIndex = 11;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(981, 27);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(43, 24);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.ToolTipText = "New entity...";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDelete.Enabled = false;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(57, 24);
            this.toolStripButtonDelete.Text = "Delete";
            this.toolStripButtonDelete.ToolTipText = "Delete entity...";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 640);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAssets);
            this.Controls.Add(this.buttonAddRentalAgreement);
            this.Controls.Add(this.buttonAddTenant);
            this.Controls.Add(this.buttonAddOwner);
            this.Controls.Add(this.buttonAddCity);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Assets Management";
            this.groupBoxAssets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAssets)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Button buttonAddOwner;
        private System.Windows.Forms.Button buttonAddTenant;
        private System.Windows.Forms.Button buttonAddRentalAgreement;
        private System.Windows.Forms.GroupBox groupBoxAssets;
        private System.Windows.Forms.DataGridView dataGridViewAssets;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelRentalAgreemntEnd;
        private System.Windows.Forms.Label labelStartRentalAgreemnt;
        private System.Windows.Forms.Label labelRentalAgreementTenant;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ownerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tenantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rentalAgreementToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
    }
}

