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
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        public static DataTable _OriginalTestTypesTable = clsTestType.GetAllTestTypes();

        //private DataTable _dtApplicationTypes = _OriginalApplicationTypesTable.DefaultView.ToTable();

        private void _RefreshTestTypesList()
        {
            _OriginalTestTypesTable = clsTestType.GetAllTestTypes();

            //_dtApplicationTypes = _OriginalApplicationTypesTable.DefaultView.ToTable();

            dgvAllTestTypes.DataSource = _OriginalTestTypesTable;

            dgvAllTestTypes.AutoResizeColumn(dgvAllTestTypes.Columns["Title"].Index, DataGridViewAutoSizeColumnMode.AllCells);

            dgvAllTestTypes.Columns["Description"].Width = 310;

            lblRecordsNumber.Text = dgvAllTestTypes.RowCount.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestTypes frm = new frmUpdateTestTypes((int)dgvAllTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesList();
        }
    }
}
