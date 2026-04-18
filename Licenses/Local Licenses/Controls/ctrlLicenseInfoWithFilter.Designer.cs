namespace DVLD_Project
{
    partial class ctrlLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctrlLicenseInfo1 = new DVLD_Project.ctrlLicenseInfo();
            this.gbFitler = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFitler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(5, 107);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(848, 358);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // gbFitler
            // 
            this.gbFitler.Controls.Add(this.btnSearch);
            this.gbFitler.Controls.Add(this.txtLicenseID);
            this.gbFitler.Controls.Add(this.label1);
            this.gbFitler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFitler.Location = new System.Drawing.Point(5, 26);
            this.gbFitler.Name = "gbFitler";
            this.gbFitler.Size = new System.Drawing.Size(592, 75);
            this.gbFitler.TabIndex = 1;
            this.gbFitler.TabStop = false;
            this.gbFitler.Text = "Filter";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::DVLD_Project.Properties.Resources.License_View_32;
            this.btnSearch.Location = new System.Drawing.Point(463, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 51);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(181, 36);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(225, 27);
            this.txtLicenseID.TabIndex = 1;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseID_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseID :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbFitler);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(856, 465);
            this.gbFitler.ResumeLayout(false);
            this.gbFitler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.GroupBox gbFitler;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
