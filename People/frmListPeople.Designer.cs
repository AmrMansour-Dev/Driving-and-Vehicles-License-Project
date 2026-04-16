namespace DVLD_Project
{
    partial class frmListPeople
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dgvAllPeople = new System.Windows.Forms.DataGridView();
            this.cmsDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.txtFilterByValue = new System.Windows.Forms.TextBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ShowDetailstoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddPersontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmailtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhoneCalltoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).BeginInit();
            this.cmsDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(634, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.Window;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo.",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Nationality ",
            "Gendor",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(88, 378);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(181, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dgvAllPeople
            // 
            this.dgvAllPeople.AllowUserToAddRows = false;
            this.dgvAllPeople.AllowUserToDeleteRows = false;
            this.dgvAllPeople.AllowUserToOrderColumns = true;
            this.dgvAllPeople.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllPeople.ContextMenuStrip = this.cmsDGV;
            this.dgvAllPeople.Location = new System.Drawing.Point(12, 408);
            this.dgvAllPeople.Name = "dgvAllPeople";
            this.dgvAllPeople.ReadOnly = true;
            this.dgvAllPeople.RowHeadersWidth = 51;
            this.dgvAllPeople.RowTemplate.Height = 24;
            this.dgvAllPeople.Size = new System.Drawing.Size(1484, 371);
            this.dgvAllPeople.TabIndex = 4;
            // 
            // cmsDGV
            // 
            this.cmsDGV.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailstoolStripMenuItem,
            this.toolStripSeparator1,
            this.AddPersontoolStripMenuItem,
            this.EdittoolStripMenuItem,
            this.DeletetoolStripMenuItem,
            this.toolStripSeparator2,
            this.SendEmailtoolStripMenuItem,
            this.PhoneCalltoolStripMenuItem});
            this.cmsDGV.Name = "cmsDGV";
            this.cmsDGV.Size = new System.Drawing.Size(169, 172);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(12, 799);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(78, 16);
            this.lblRecords.TabIndex = 7;
            this.lblRecords.Text = "# Records : ";
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Location = new System.Drawing.Point(96, 799);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(15, 16);
            this.lblRecordsNumber.TabIndex = 8;
            this.lblRecordsNumber.Text = "--";
            // 
            // txtFilterByValue
            // 
            this.txtFilterByValue.Location = new System.Drawing.Point(290, 379);
            this.txtFilterByValue.Name = "txtFilterByValue";
            this.txtFilterByValue.Size = new System.Drawing.Size(209, 22);
            this.txtFilterByValue.TabIndex = 9;
            this.txtFilterByValue.TextChanged += new System.EventHandler(this.txtFilterByValue_TextChanged);
            this.txtFilterByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterByValue_KeyPress);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::DVLD_Project.Properties.Resources.Add_Person_40;
            this.btnAddPerson.Location = new System.Drawing.Point(1421, 342);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(75, 60);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1361, 785);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ShowDetailstoolStripMenuItem
            // 
            this.ShowDetailstoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.PersonDetails_32;
            this.ShowDetailstoolStripMenuItem.Name = "ShowDetailstoolStripMenuItem";
            this.ShowDetailstoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.ShowDetailstoolStripMenuItem.Text = "Show Details";
            this.ShowDetailstoolStripMenuItem.Click += new System.EventHandler(this.ShowDetailstoolStripMenuItem_Click);
            // 
            // AddPersontoolStripMenuItem
            // 
            this.AddPersontoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.AddPerson_32;
            this.AddPersontoolStripMenuItem.Name = "AddPersontoolStripMenuItem";
            this.AddPersontoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.AddPersontoolStripMenuItem.Text = "Add Person";
            this.AddPersontoolStripMenuItem.Click += new System.EventHandler(this.AddPersontoolStripMenuItem_Click);
            // 
            // EdittoolStripMenuItem
            // 
            this.EdittoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit_32;
            this.EdittoolStripMenuItem.Name = "EdittoolStripMenuItem";
            this.EdittoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.EdittoolStripMenuItem.Text = "Edit";
            this.EdittoolStripMenuItem.Click += new System.EventHandler(this.EdittoolStripMenuItem_Click);
            // 
            // DeletetoolStripMenuItem
            // 
            this.DeletetoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.Delete_32;
            this.DeletetoolStripMenuItem.Name = "DeletetoolStripMenuItem";
            this.DeletetoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.DeletetoolStripMenuItem.Text = "Delete";
            this.DeletetoolStripMenuItem.Click += new System.EventHandler(this.DeletetoolStripMenuItem_Click);
            // 
            // SendEmailtoolStripMenuItem
            // 
            this.SendEmailtoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.send_email_32;
            this.SendEmailtoolStripMenuItem.Name = "SendEmailtoolStripMenuItem";
            this.SendEmailtoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.SendEmailtoolStripMenuItem.Text = "Send Email";
            this.SendEmailtoolStripMenuItem.Click += new System.EventHandler(this.SendEmailtoolStripMenuItem_Click);
            // 
            // PhoneCalltoolStripMenuItem
            // 
            this.PhoneCalltoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.call_32;
            this.PhoneCalltoolStripMenuItem.Name = "PhoneCalltoolStripMenuItem";
            this.PhoneCalltoolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.PhoneCalltoolStripMenuItem.Text = "Phone Call";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(641, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmListPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1520, 886);
            this.Controls.Add(this.txtFilterByValue);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvAllPeople);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmListPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllPeople)).EndInit();
            this.cmsDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dgvAllPeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.TextBox txtFilterByValue;
        private System.Windows.Forms.ContextMenuStrip cmsDGV;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailstoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddPersontoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EdittoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeletetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendEmailtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhoneCalltoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}