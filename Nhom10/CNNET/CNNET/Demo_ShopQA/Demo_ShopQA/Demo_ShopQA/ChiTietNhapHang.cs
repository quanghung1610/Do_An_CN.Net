using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_ShopQA
{
    public partial class ChiTietNhapHang : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtCTNH, dtSPham;
        DataColumn[] keyCTNH = new DataColumn[1];
        bool themmoi = false;
        public ChiTietNhapHang()
        {
            InitializeComponent();
        }

        private void ChiTietNhapHang_Load(object sender, EventArgs e)
        {
            dtCTNH = db.LAYDULIEU("SELECT * FROM CHITIETNHAPHANG");
            dtSPham = db.LAYDULIEU("select * from SANPHAM");

            keyCTNH[0] = dtCTNH.Columns[0];
            dtCTNH.PrimaryKey = keyCTNH;

            cboMaSP.DataSource = dtSPham;
            cboMaSP.DisplayMember = "MASP";
            cboMaSP.ValueMember = "MASP";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtCTNH;
            dataGridView1.Columns[0].DataPropertyName = "MANH";
            DataGridViewComboBoxColumn cbo2 = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
            dataGridView1.Columns[2].DataPropertyName = "GIANHAP";
            dataGridView1.Columns[3].DataPropertyName = "THANHTIEN";

            cbo2.DataSource = dtSPham;
            cbo2.DisplayMember = "MASP";
            cbo2.ValueMember = "MASP";
            cbo2.DataPropertyName = "MASP";
            CTNH_Databiding();
        }
        void CTNH_Databiding()
        {
            txtMaNH.DataBindings.Add("Text", dtCTNH, "MANH");
            cboMaSP.DataBindings.Add("Text", dtCTNH, "MASP");
            txtGianhap.DataBindings.Add("Text", dtCTNH, "GIANHAP");
            txtThanhtien.DataBindings.Add("Text", dtCTNH, "THANHTIEN");
        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            db.CAPNHAP("SELECT * FROM SANPHAM", dtSPham);
            MessageBox.Show("Success");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;

            txtGianhap.DataBindings.Clear();
            txtThanhtien.DataBindings.Clear();
            txtMaNH.DataBindings.Clear();
            cboMaSP.DataBindings.Clear();

            txtGianhap.Clear();
            txtThanhtien.Clear();
            txtMaNH.Clear();

            txtMaNH.Enabled = cboMaSP.Enabled = txtGianhap.Enabled = txtThanhtien.Enabled = true;


            btnThem.Enabled = btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                if (txtGianhap.Text != "" || txtThanhtien.Text != "")
                {
                    DataRow newrow = dtCTNH.NewRow();
                    newrow[0] = txtMaNH.Text;
                    newrow[1] = cboMaSP.SelectedValue.ToString();
                    newrow[2] = txtGianhap.Text;
                    newrow[3] = txtThanhtien.Text;
                    dtCTNH.Rows.Add(newrow);
                }
                CTNH_Databiding();
            }
            else
            {
                dataGridView1.Refresh();
            }
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            //string update = string.Format("Update CHITIETNHAPHANG set MANH=N'" + txtMaNH.Text + "'where MACC = '" + cboMaSP.Text + "'");
            //db.THEMXOASUA(update);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");
            themmoi = false;
            txtMaNH.Enabled = false;
            cboMaSP.Enabled = txtGianhap.Enabled = txtThanhtien.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dataGridView1.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            themmoi = true;

            txtGianhap.DataBindings.Clear();
            txtThanhtien.DataBindings.Clear();
            txtMaNH.DataBindings.Clear();
            cboMaSP.DataBindings.Clear();

            txtGianhap.Clear();
            txtThanhtien.Clear();
            txtMaNH.Clear();

            txtMaNH.Enabled = cboMaSP.Enabled = txtGianhap.Enabled = txtThanhtien.Enabled = true;


            btnThem.Enabled = btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }


    }
}
