using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Project
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private static DataTable _OriginalUsersTable = clsUser.GetUsersList();

        private DataTable _dtUsers = _OriginalUsersTable.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

        private void _RefreshUsersList()
        {
            _OriginalUsersTable = clsUser.GetUsersList();
            _dtUsers = _OriginalUsersTable.DefaultView.ToTable(false, "UserID", "PersonID", "FullName", "UserName", "IsActive");

            dgvAllUsers.DataSource = _dtUsers;

            // this to adjust width of "Fullname" Field.
            dgvAllUsers.AutoResizeColumn(dgvAllUsers.Columns["FullName"].Index, DataGridViewAutoSizeColumnMode.AllCells); 

            lblRecordsNumber.Text = dgvAllUsers.RowCount.ToString();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Visible = false;
            _RefreshUsersList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "None") 
            {
                txtFilterBy.Visible = false;


            }
            else if(cbFilterBy.Text == "Is Active")
            {
                txtFilterBy.Visible=false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterBy.Visible = true;
                cbIsActive.Visible = false;
            }

        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {



            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "FullName":
                    FilterColumn = "FullName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
            }

            if(cbFilterBy.Text == "None" || txtFilterBy.Text == "")
            {
                _dtUsers.DefaultView.RowFilter = "";
                return;
            }

            if(cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterBy.Text.Trim());
            
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterBy.Text.Trim());

            }

            lblRecordsNumber.Text = dgvAllUsers.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(cbIsActive.Text == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
                return;
            }
            if(cbIsActive.Text == "Yes")
            {
                _dtUsers.DefaultView.RowFilter = string.Format("IsActive = 1");
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = string.Format("IsActive = 0");
            }

            lblRecordsNumber.Text = dgvAllUsers.Rows.Count.ToString();

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "User ID" || cbFilterBy.Text == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(-1);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are You Sure You Want Delete User [{dgvAllUsers.CurrentRow.Cells[0].Value.ToString()}] ?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully", "Successfull");
                }
                else
                {
                    MessageBox.Show("Can Not Delete User as It's Connected to Another Data", "Failed");

                }

            }
            _RefreshUsersList();
        }

        private void ChangePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserChangePassword frm = new frmUserChangePassword((int)dgvAllUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Working Yet");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Working Yet");
        }

    }
}
