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
    public partial class NhanVien : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtnv, dttk;
        DataColumn[] key = new DataColumn[1];
        bool themmoi= false;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btn__Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMa.DataBindings.Clear();
            txtName.DataBindings.Clear();
            dateNgayS.DataBindings.Clear();
            cbnv.DataBindings.Clear();
            dateNVL.DataBindings.Clear();
            txtDC.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtUser.DataBindings.Clear();
            txtPass.DataBindings.Clear();

            txtMa.Clear();
            txtName.Clear();
            dateNgayS.DataBindings.Clear();
            cbnv.DataBindings.Clear();
            dateNVL.DataBindings.Clear();
            txtDC.Clear();
            txtPhone.Clear();
            txtUser.Clear();
            txtPass.Clear();
            txtMa.Focus();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            dtnv = db.LAYDULIEU("select * from NhanVien");
            key[0] = dtnv.Columns[0];
            dtnv.PrimaryKey = key;
            cbnv.Items.Add("Nam");
            cbnv.Items.Add("Nữ");
            cbnv.Items.Add("Khác");
            cbquyen.Items.Add("Admin");
            cbquyen.Items.Add("NhanVien");
            dataGridView1.DataSource = dtnv;
            NhanVien_databiding();
            dttk = db.LAYDULIEU("Select * from NHANVIEN");
            dataGridView1.DataSource = dttk;
        }

        void NhanVien_databiding()
        {
            txtMa.DataBindings.Add("text", dtnv, "MaNV");
            txtName.DataBindings.Add("text", dtnv, "TenNV");
            dateNgayS.DataBindings.Add("text", dtnv, "NgaySinh");
            cbnv.DataBindings.Add("text", dtnv, "GTINH");
            dateNVL.DataBindings.Add("text", dtnv, "NgayVaoLam");
            txtDC.DataBindings.Add("text", dtnv, "DCHI");
            txtPhone.DataBindings.Add("text", dtnv, "SDT");
            txtUser.DataBindings.Add("text", dtnv, "UserName");
            txtPass.DataBindings.Add("text", dtnv, "Passw");
            //cbquyen.DataBindings.Add("Text", dtnv, "QUYEN");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

          
                if (txtMa.Text != "" || txtName.Text != "" || dateNgayS.Text != "" || cbnv.Text != "" || dateNVL.Text != "" || txtDC.Text != "" || txtPhone.Text != "" || txtUser.Text != "" || txtPass.Text != "" || cbquyen.Text != "")
                {
                    DataRow newrow = dtnv.NewRow();
                    newrow[0] = txtMa.Text;
                    newrow[1] = txtName.Text;
                    newrow[2] = dateNgayS.Text;
                    newrow[3] = cbnv.Text;
                    newrow[4] = dateNVL.Text;
                    newrow[5] = txtDC.Text;
                    newrow[6] = txtPhone.Text;
                    newrow[7] = txtUser.Text;
                    newrow[8] = txtPass.Text;
                    newrow[9] = cbquyen.Text;
                    dtnv.Rows.Add(newrow);
            
                NhanVien_databiding();
            }
            else
            {
                dataGridView1.Refresh();
            }
                btn_.Enabled = btn_delete.Enabled = true;
                btn_save.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.ReadOnly = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            //string delete = string.Format("delete NHANVIEN where MaNV = '" + txtMa.Text.Trim() + "'");
            //db.THEMXOASUA(delete);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");

            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                //ktr khóa ngoại 
                DataTable dtCTNH = db.LAYDULIEU("select distinct MASP from CHITIETNHAPHANG where MASP='" + txtMa.Text + "'");
                if (dtCTNH.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtnv.Rows.Find(txtMa.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Hàng đang tồn tại không xóa được");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //string update = string.Format("Update NHANVIEN set MANV=N'" + txtMa.Text + "'where TenNV = '" + txtName.Text + "'");
            //db.THEMXOASUA(update);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");
            themmoi = false;
            txtMa.Enabled = false;
            txtName.Enabled = dateNgayS.Enabled = dateNVL.Enabled = txtDC.Enabled = txtMausac.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dataGridView1.ReadOnly = true;
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            db.CAPNHAP("SELECT * FROM NHANVIEN", dtnv);
            MessageBox.Show("Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
              XULYDATABASE tim = new XULYDATABASE();
              dataGridView1.DataSource = tim.LAYDULIEU("select * from NHANVIEN where MANV like'%" + txtFind.Text + "%'");
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
