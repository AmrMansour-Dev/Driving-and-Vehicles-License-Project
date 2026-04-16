using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmLogin : Form
    {
        clsUser _User;
        string _SavedUserName = "";
        string _SavedPassword = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        string _FilePath = @"C:\Users\user\Desktop\LoginCredits.txt";

        private void _ShowMainMenu()
        {
            this.Hide();
            frmMainMenu frm = new frmMainMenu();
            frm.ShowDialog();
            this.Close();   
        }

        private void _SaveLoginCredentials()
        {
            if (cbRememberMe.Checked)
            {
                using (StreamWriter writer = new StreamWriter(_FilePath, false))
                {
                    writer.WriteLine($"{txtUserName.Text}#//#{txtPassword.Text}");
                    //_SavedUserName = txtUserName.Text;
                    //_SavedPassword = txtPassword.Text;
                }
            }
            else
            {
                File.WriteAllText(_FilePath, "");
            }
        }

        private void _SaveLoginCredentialsToRegistry()
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            if (cbRememberMe.Checked)
            {
                try
                {
                    Registry.SetValue(KeyPath, "UserName", txtUserName.Text);
                    Registry.SetValue(KeyPath, "Password", txtPassword.Text);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DVLD", true))
                    {
                        if (key != null)
                        {
                            key.DeleteValue("UserName", false); 
                            key.DeleteValue("Password", false);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        bool _IsTextFileEmpty(string FilePath)
        {
            //FilePath = @"C:\Users\Amr Mansour\Desktop\LoginCredits.txt";
            string Content = File.ReadAllText(FilePath);

            if (string.IsNullOrWhiteSpace(Content))
            {
                return true;
            }
            return false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //OLD CODE Without using registry :

            //if (!_IsTextFileEmpty(_FilePath))
            //{
            //    if (clsGlobal.GetUserCredentials(ref _SavedUserName, ref _SavedPassword))
            //    {
            //        cbRememberMe.Checked = true;
            //        txtUserName.Text = _SavedUserName.Trim();
            //        txtPassword.Text = _SavedPassword.Trim();
            //    }
            //}
            //else
            //{
            //    cbRememberMe.Checked = false;
            //}

            // New Code Using Registry

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";

            try
            {
                txtUserName.Text = Registry.GetValue(KeyPath, "UserName", null) as string;
                txtPassword.Text = Registry.GetValue(KeyPath, "Password", null) as string;

                if (txtPassword.Text != null && txtUserName != null)
                {
                    cbRememberMe.Checked = true;
                }
                else
                {
                    cbRememberMe.Checked = false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _User = clsUser.FindByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

            if(_User != null)
            {
                clsGlobal.LoggedInUser = _User;

                //_SaveLoginCredentials();
                _SaveLoginCredentialsToRegistry();

                if (_User.IsActive == 0)
                {
                    MessageBox.Show("This Account is InActive, Contact Admin", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _ShowMainMenu();
            }
            else
            {
                MessageBox.Show("Invalid UserName/Password", "Wrong Credentials",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
