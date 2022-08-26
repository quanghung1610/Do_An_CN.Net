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
    public partial class NhapHang : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtNhaphang, dtNhacc;
        DataColumn[] keynhaphang = new DataColumn[1];
        bool themmoi = false;
        public NhapHang()
        {
            InitializeComponent();
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NhapHang_Load(object sender, EventArgs e)
        {
            dtNhaphang = db.LAYDULIEU("select * from NHAPHANG");
            dtNhacc = db.LAYDULIEU("select * from NHACUNGCAP");

            keynhaphang[0] = dtNhaphang.Columns[0];
            dtNhaphang.PrimaryKey = keynhaphang;//chi dinh khoa chinh

            cboMacc.DataSource = dtNhacc;
            cboMacc.DisplayMember = "MACC";
            cboMacc.ValueMember = "MACC";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtNhaphang;
            dataGridView1.Columns[0].DataPropertyName = "MANH";
            dataGridView1.Columns[1].DataPropertyName = "NGAYNHAP";
            dataGridView1.Columns[2].DataPropertyName = "TONGTIEN";
            DataGridViewComboBoxColumn cbocol = (DataGridViewComboBoxColumn)dataGridView1.Columns[3];
            cbocol.DataSource = dtNhacc;
            cbocol.DisplayMember = "MACC";
            cbocol.ValueMember = "MACC";
            cbocol.DataPropertyName = "MACC";
            NH_Databiding();
        }
        public void NH_Databiding()
        {
            txtMaNH.DataBindings.Add("Text", dtNhaphang, "MANH");
            dtNgay.DataBindings.Add("Text", dtNhaphang, "NGAYNHAP");
            txtTongtien.DataBindings.Add("Text", dtNhaphang, "TONGTIEN");
            cboMacc.DataBindings.Add("SelectedValue", dtNhaphang, "MACC");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMaNH.DataBindings.Clear();
            cboMacc.DataBindings.Clear();
            dtNgay.DataBindings.Clear();
            txtTongtien.DataBindings.Clear();

            txtMaNH.Clear();
            txtTongtien.Clear();
            txtMaNH.Enabled = cboMacc.Enabled = txtTongtien.Enabled = true;

            btnThem.Enabled = btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                if (txtMaNH.Text != "" || txtTongtien.Text != "")
                {
                    DataRow newrow = dtNhaphang.NewRow();
                    newrow["MANH"] = txtMaNH.Text;
                    newrow["NGAYNHAP"] = dtNgay.Text;
                    newrow["TONGTIEN"] = txtTongtien.Text;
                    newrow["MACC"] = cboMacc.SelectedValue.ToString();
                    dtNhaphang.Rows.Add(newrow);
                }
                NH_Databiding();
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
            //string update = string.Format("Update NHAPHANG set MANH=N'" + txtMaNH.Text + "'where MACC = '" + cboMacc.Text + "'and NGAYNHAP = '"+dtNgay.Text+"'");
            //db.THEMXOASUA(update);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");
            themmoi = false;
            txtMaNH.Enabled = false;
            cboMacc.Enabled = txtTongtien.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dataGridView1.ReadOnly = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
              == DialogResult.Yes)
            {
                //ktr khóa ngoại 
                DataTable dtCTNH = db.LAYDULIEU("select distinct MANH from CHITIETNHAPHANG where MANH='" + txtMaNH.Text + "'");
                if (dtCTNH.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtNhaphang.Rows.Find(txtMaNH.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Hàng đang tồn tại không xóa được");
            }
        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            try
            {
                db.CAPNHAP("SELECT * FROM NHAPHANG", dtNhaphang);
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }


    }
}
