using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    
    public partial class frmInternationalDriverInfo : Form
    {
        int _InternationalLicenseID;
        public frmInternationalDriverInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void frmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalDriverInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
