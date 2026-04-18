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
using DVLD_Classess;

namespace DVLD_Project
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointmentID;

        clsTestType.enTestType _TestTypeID;

        clsTest _Test;

        int _TestID = -1;
        public frmTakeTest(int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
            InitializeComponent();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadData(_TestAppointmentID);

            _TestID = ctrlScheduledTest1.TestID;

            if(_TestID != -1)
            {
                _Test = clsTest.FindTestByID(_TestID); 

                if(_Test.TestResult)
                {
                    rbPass.Checked = true;
                }
                else
                {
                    rbFail.Checked = true;
                }

                lblMessage.Visible = true;
                txtnotes.Text = _Test.Notes;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
            else
            {
                _Test = new clsTest();
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?",
                  "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtnotes.Text;
            _Test.CreatedByUserID = clsGlobal.LoggedInUser.UserID;

            if(_Test.Save())
            {

                 MessageBox.Show("Data Saved Successfully","Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MessageBox.Show("Data Saving Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
