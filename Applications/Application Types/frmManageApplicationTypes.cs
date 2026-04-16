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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        public static DataTable _OriginalApplicationTypesTable = clsApplicationType.GetAllApplicationTypes();

        private DataTable _dtApplicationTypes = _OriginalApplicationTypesTable.DefaultView.ToTable();

        private void _RefreshApplicationTypesList()
        {
            _OriginalApplicationTypesTable = clsApplicationType.GetAllApplicationTypes();

            _dtApplicationTypes = _OriginalApplicationTypesTable.DefaultView.ToTable();

            dgvAllApplicationTypes.DataSource = _dtApplicationTypes;

            dgvAllApplicationTypes.AutoResizeColumn(dgvAllApplicationTypes.Columns["Title"].Index, DataGridViewAutoSizeColumnMode.AllCells);


            lblRecordsNumber.Text = dgvAllApplicationTypes.RowCount.ToString();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvAllApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}
