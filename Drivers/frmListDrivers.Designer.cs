namespace DVLD_Project
{
    partial class frmListDrivers
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
            this.txtFilterByValue = new System.Windows.Forms.TextBox();
            this.dgvAllDrivers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrivers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterByValue
            // 
            this.txtFilterByValue.Location = new System.Drawing.Point(301, 338);
            this.txtFilterByValue.Name = "txtFilterByValue";
            this.txtFilterByValue.Size = new System.Drawing.Size(209, 22);
            this.txtFilterByValue.TabIndex = 13;
            this.txtFilterByValue.TextChanged += new System.EventHandler(this.txtFilterByValue_TextChanged);
            this.txtFilterByValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterByValue_KeyPress);
            // 
            // dgvAllDrivers
            // 
            this.dgvAllDrivers.AllowUserToAddRows = false;
            this.dgvAllDrivers.AllowUserToDeleteRows = false;
            this.dgvAllDrivers.BackgroundColor = System.Drawing.Color.White;
            this.dgvAllDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllDrivers.Location = new System.Drawing.Point(13, 371);
            this.dgvAllDrivers.Name = "dgvAllDrivers";
            this.dgvAllDrivers.ReadOnly = true;
            this.dgvAllDrivers.RowHeadersWidth = 51;
            this.dgvAllDrivers.RowTemplate.Height = 24;
            this.dgvAllDrivers.Size = new System.Drawing.Size(1034, 280);
            this.dgvAllDrivers.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(389, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Manage Drivers";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.Window;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "DriverID",
            "PersonID",
            "NationalNo.",
            "FullName"});
            this.cbFilterBy.Location = new System.Drawing.Point(98, 336);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(181, 24);
            this.cbFilterBy.TabIndex = 15;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Filter By :";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::DVLD_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(912, 669);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 44);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.Driver_Main;
            this.pictureBox1.Location = new System.Drawing.Point(396, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 212);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Location = new System.Drawing.Point(98, 669);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(15, 16);
            this.lblRecordsNumber.TabIndex = 18;
            this.lblRecordsNumber.Text = "--";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(14, 669);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(78, 16);
            this.lblRecords.TabIndex = 17;
            this.lblRecords.Text = "# Records : ";
            // 
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 725);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilterByValue);
            this.Controls.Add(this.dgvAllDrivers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Drivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllDrivers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterByValue;
        private System.Windows.Forms.DataGridView dgvAllDrivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label lblRecords;
    }
}