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

namespace DVLD_Project
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        string _NationalNo;
        public frmShowPersonLicenseHistory(string NationalNo)
        {
            _NationalNo = NationalNo;
            InitializeComponent();
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.FindByNationalNo(_NationalNo);

            if (Person == null )
            {
                MessageBox.Show("No Person Has This National No., Please Enter a Valid One!");
                return;
            }

            ctrlPersonInformationWithFilter1.LoadPersonInfo(Person.PersonID);
            ctrlPersonInformationWithFilter1.FilterByGroupBoxDisable();
        }

        private void ctrlPersonInformationWithFilter1_OnPersonSelected(int obj)
        {
            int PersonID = obj;

            if (PersonID !=-1)
            {
                ctrlDriverLicenses1.LoadInfoWithPersonID(PersonID);
            }
        }
    }
}
