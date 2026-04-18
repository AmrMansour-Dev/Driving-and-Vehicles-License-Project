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
    public partial class ctrlDriverLicenses : UserControl
    {
        DataTable _dtDriverLocalLicenses;
        DataTable _dtDriverInternationalLicenses;

        int _DriverID;
        clsDriver _Driver;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        void _LoadLocalLicensesInfo()
        {
            _dtDriverLocalLicenses = clsDriver.GetAllDriverLicenses(_DriverID);

            dgvLocal.DataSource = _dtDriverLocalLicenses;
            lblRecords.Text = dgvLocal.Rows.Count.ToString();

            if (dgvLocal.Rows.Count > 0)
            {
                dgvLocal.Columns[0].HeaderText = "Lic.ID";
                dgvLocal.Columns[0].Width = 110;

                dgvLocal.Columns[1].HeaderText = "App.ID";
                dgvLocal.Columns[1].Width = 110;

                dgvLocal.Columns[2].HeaderText = "Class Name";
                dgvLocal.Columns[2].Width = 270;

                dgvLocal.Columns[3].HeaderText = "Issue Date";
                dgvLocal.Columns[3].Width = 130;

                dgvLocal.Columns[4].HeaderText = "Expiration Date";
                dgvLocal.Columns[4].Width = 130;

                dgvLocal.Columns[5].HeaderText = "Is Active";
                dgvLocal.Columns[5].Width = 110;

            }
        }


        void _LoadInternationalLicensesInfo()
        {
            _dtDriverInternationalLicenses = clsDriver.GetDriverInternationalLicenses(_DriverID);

            dgvInternantional.DataSource = _dtDriverInternationalLicenses;
            lblrecord.Text = dgvInternantional.Rows.Count.ToString();

            if (dgvInternantional.Rows.Count > 0)
            {
                dgvInternantional.Columns[0].HeaderText = "Int.License ID";
                dgvInternantional.Columns[0].Width = 160;

                dgvInternantional.Columns[1].HeaderText = "Application ID";
                dgvInternantional.Columns[1].Width = 130;

                dgvInternantional.Columns[2].HeaderText = "L.License ID";
                dgvInternantional.Columns[2].Width = 130;

                dgvInternantional.Columns[3].HeaderText = "Issue Date";
                dgvInternantional.Columns[3].Width = 130;

                dgvInternantional.Columns[4].HeaderText = "Expiration Date";
                dgvInternantional.Columns[4].Width = 130;

                dgvInternantional.Columns[5].HeaderText = "Is Active";
                dgvInternantional.Columns[5].Width = 120;

            }
        }

        public void LoadInfoWithPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if(_Driver != null)
            {
                _DriverID = _Driver.DriverID;
            }

            _LoadInternationalLicensesInfo();
            _LoadLocalLicensesInfo();
        }
    }
}
