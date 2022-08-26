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
    public partial class NhaCungCap : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtNhacc;
        DataColumn[] keynhacc = new DataColumn[1];
        public NhaCungCap()
        {
            InitializeComponent();
        }

        void Nhacc_DataBiding()
        {
            txtMacc.DataBindings.Add("Text", dtNhacc, "MACC");
            txtTenncc.DataBindings.Add("Text", dtNhacc, "TENNCC");
            txtDchi.DataBindings.Add("Text", dtNhacc, "DCHI");
            txtSdt.DataBindings.Add("Text", dtNhacc, "SDT");
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            dtNhacc = db.LAYDULIEU("select * from NHACUNGCAP");
            keynhacc[0] = dtNhacc.Columns[0];
            dtNhacc.PrimaryKey = keynhacc;
            dataGridView1.DataSource = dtNhacc;
            Nhacc_DataBiding();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMacc.Enabled = txtTenncc.Enabled = txtDchi.Enabled = txtSdt.Enabled = true;
            txtMacc.Clear();
            txtTenncc.Clear();
            txtDchi.Clear();
            txtSdt.Clear();
            txtMacc.DataBindings.Clear();
            txtTenncc.DataBindings.Clear();
            txtDchi.DataBindings.Clear();
            txtSdt.DataBindings.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //string update = string.Format("Update NHACUNGCAP set MACC=N'{0}'where TENNCC = '{1}'", txtMacc.Text, txtTenncc.Text);
            //db.THEMXOASUA(update);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");
            txtMacc.Enabled = txtTenncc.Enabled = txtDchi.Enabled = txtSdt.Enabled = true;
        }

        private void btnCapnhap_Click(object sender, EventArgs e)
        {
            try
            {
                db.CAPNHAP("select * from NHACUNGCAP", dtNhacc);
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataRow newrow = dtNhacc.NewRow();
            newrow["MACC"] = txtMacc.Text;
            newrow["TENNCC"] = txtTenncc.Text;
            newrow["DCHI"] = txtDchi.Text;
            newrow["SDT"] = txtSdt.Text;
            dtNhacc.Rows.Add(newrow);
            Nhacc_DataBiding();

            txtMacc.Enabled = txtTenncc.Enabled = txtDchi.Enabled = txtSdt.Enabled = false;
        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                //ktr khóa ngoại 
                DataTable dtNhaphang = db.LAYDULIEU("select distinct MACC from SANPHAM where MACC='" + txtMacc.Text + "'");
                if (dtNhaphang.Rows.Count == 0)//ko tồn tại trong bảng NHAPHANG
                {
                    DataRow r = dtNhacc.Rows.Find(txtMacc.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Hàng đang tồn tại không xóa được");
            }
        }


    }
}
