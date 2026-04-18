namespace DVLD_Project
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.txtFilterByValue = new System.Windows.Forms.TextBox();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.dgvAllLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleDrivingTestMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.issueDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalDrivingLicense = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalDrivingLicenseApplications)).BeginInit();
            this.cmsDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterByValue
            // 
            this.txtFilterByValue.Location = new System.Drawing.Point(283, 322);
            this.txtFilterByValue.Name = "txtFilterByValue";
            this.txtFilterByValue.Size = new System.Drawing.Size(209, 22);
            this.txtFilterByValue.TabIndex = 18;
            this.txtFilterByValue.TextChanged += new System.EventHandler(this.txtFilterByValue_TextChanged);
            this.txtFilterByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterByValue_KeyPress);
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Location = new System.Drawing.Point(90, 753);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(15, 16);
            this.lblRecordsNumber.TabIndex = 17;
            this.lblRecordsNumber.Text = "--";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(6, 753);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(78, 16);
            this.lblRecords.TabIndex = 16;
            this.lblRecords.Text = "# Records : ";
            // 
            // dgvAllLocalDrivingLicenseApplications
            // 
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvAllLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvAllLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsDGV;
            this.dgvAllLocalDrivingLicenseApplications.Location = new System.Drawing.Point(6, 362);
            this.dgvAllLocalDrivingLicenseApplications.Name = "dgvAllLocalDrivingLicenseApplications";
            this.dgvAllLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvAllLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvAllLocalDrivingLicenseApplications.RowTemplate.Height = 24;
            this.dgvAllLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1380, 371);
            this.dgvAllLocalDrivingLicenseApplications.TabIndex = 13;
            // 
            // cmsDGV
            // 
            this.cmsDGV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator2,
            this.scheduleTestsMenu,
            this.toolStripSeparator3,
            this.issueDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLicenseToolStripMenuItem,
            this.toolStripSeparator5,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsDGV.Name = "cmsDGV";
            this.cmsDGV.Size = new System.Drawing.Size(305, 366);
            this.cmsDGV.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDGV_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_321;
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_321;
            this.editApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(301, 6);
            // 
            // scheduleTestsMenu
            // 
            this.scheduleTestsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestMenuItem,
            this.scheduleWrittenTestMenuItem,
            this.scheduleDrivingTestMenuItem});
            this.scheduleTestsMenu.Image = global::DVLD_Project.Properties.Resources.Schedule_Test_32;
            this.scheduleTestsMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleTestsMenu.Name = "scheduleTestsMenu";
            this.scheduleTestsMenu.Size = new System.Drawing.Size(304, 38);
            this.scheduleTestsMenu.Text = "Schedule Tests";
            // 
            // scheduleVisionTestMenuItem
            // 
            this.scheduleVisionTestMenuItem.Image = global::DVLD_Project.Properties.Resources.Vision_Test_Schdule;
            this.scheduleVisionTestMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleVisionTestMenuItem.Name = "scheduleVisionTestMenuItem";
            this.scheduleVisionTestMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleVisionTestMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestMenuItem
            // 
            this.scheduleWrittenTestMenuItem.Image = global::DVLD_Project.Properties.Resources.Written_Test_32;
            this.scheduleWrittenTestMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTestMenuItem.Name = "scheduleWrittenTestMenuItem";
            this.scheduleWrittenTestMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleWrittenTestMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleDrivingTestMenuItem
            // 
            this.scheduleDrivingTestMenuItem.Image = global::DVLD_Project.Properties.Resources.Street_Test_32;
            this.scheduleDrivingTestMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleDrivingTestMenuItem.Name = "scheduleDrivingTestMenuItem";
            this.scheduleDrivingTestMenuItem.Size = new System.Drawing.Size(247, 38);
            this.scheduleDrivingTestMenuItem.Text = "Schedule Driving Test";
            this.scheduleDrivingTestMenuItem.Click += new System.EventHandler(this.scheduleToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(301, 6);
            // 
            // issueDrivingLicenseToolStripMenuItem
            // 
            this.issueDrivingLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseToolStripMenuItem.Name = "issueDrivingLicenseToolStripMenuItem";
            this.issueDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.issueDrivingLicenseToolStripMenuItem.Text = "Issue Driving License(First Time)";
            this.issueDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(301, 6);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(301, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(304, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.Window;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "NationalNo.",
            "FullName",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(81, 321);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(181, 24);
            this.cbFilterBy.TabIndex = 12;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 321);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filter By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(433, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "Local Driving License Applications";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.Local_321;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(812, 73);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 131;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(606, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddNewLocalDrivingLicense
            // 
            this.btnAddNewLocalDrivingLicense.BackColor = System.Drawing.Color.White;
            this.btnAddNewLocalDrivingLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalDrivingLicense.Image = global::DVLD_Project.Properties.Resources.New_Application_64;
            this.btnAddNewLocalDrivingLicense.Location = new System.Drawing.Point(1289, 266);
            this.btnAddNewLocalDrivingLicense.Name = "btnAddNewLocalDrivingLicense";
            this.btnAddNewLocalDrivingLicense.Size = new System.Drawing.Size(97, 90);
            this.btnAddNewLocalDrivingLicense.TabIndex = 15;
            this.btnAddNewLocalDrivingLicense.UseVisualStyleBackColor = false;
            this.btnAddNewLocalDrivingLicense.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicense_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1251, 739);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 809);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilterByValue);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnAddNewLocalDrivingLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAllLocalDrivingLicenseApplications);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllLocalDrivingLicenseApplications)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterByValue;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicense;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvAllLocalDrivingLicenseApplications;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsMenu;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleDrivingTestMenuItem;
    }
}