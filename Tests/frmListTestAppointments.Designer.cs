namespace DVLD_Project
{
    partial class frmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTestAppointmets = new System.Windows.Forms.DataGridView();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.ctrlDrivingLicenseApplicationInfo1 = new DVLD_Project.ctrlDrivingLicenseApplicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.pbTitleImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmets)).BeginInit();
            this.cmsDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(300, 134);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(411, 38);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Vision Test Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 626);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Appointments :";
            // 
            // dgvTestAppointmets
            // 
            this.dgvTestAppointmets.AllowUserToAddRows = false;
            this.dgvTestAppointmets.AllowUserToDeleteRows = false;
            this.dgvTestAppointmets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestAppointmets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointmets.ContextMenuStrip = this.cmsDGV;
            this.dgvTestAppointmets.Location = new System.Drawing.Point(24, 670);
            this.dgvTestAppointmets.Name = "dgvTestAppointmets";
            this.dgvTestAppointmets.ReadOnly = true;
            this.dgvTestAppointmets.RowHeadersWidth = 51;
            this.dgvTestAppointmets.RowTemplate.Height = 24;
            this.dgvTestAppointmets.Size = new System.Drawing.Size(971, 118);
            this.dgvTestAppointmets.TabIndex = 14;
            // 
            // cmsDGV
            // 
            this.cmsDGV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsDGV.Name = "cmsDGV";
            this.cmsDGV.Size = new System.Drawing.Size(154, 80);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(153, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Location = new System.Drawing.Point(105, 808);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(15, 16);
            this.lblRecordsNumber.TabIndex = 19;
            this.lblRecordsNumber.Text = "--";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(21, 808);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(78, 16);
            this.lblRecords.TabIndex = 18;
            this.lblRecords.Text = "# Records : ";
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(7, 175);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(995, 446);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(860, 794);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAppointment.Image = global::DVLD_Project.Properties.Resources.AddAppointment_32;
            this.btnAddTestAppointment.Location = new System.Drawing.Point(941, 626);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(54, 38);
            this.btnAddTestAppointment.TabIndex = 13;
            this.btnAddTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click);
            // 
            // pbTitleImage
            // 
            this.pbTitleImage.Image = global::DVLD_Project.Properties.Resources.Vision_512;
            this.pbTitleImage.Location = new System.Drawing.Point(426, 12);
            this.pbTitleImage.Name = "pbTitleImage";
            this.pbTitleImage.Size = new System.Drawing.Size(141, 110);
            this.pbTitleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitleImage.TabIndex = 10;
            this.pbTitleImage.TabStop = false;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1015, 857);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.dgvTestAppointmets);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.pbTitleImage);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ListTestAppointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmets)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitleImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTitleImage;
        private ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.DataGridView dgvTestAppointmets;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}