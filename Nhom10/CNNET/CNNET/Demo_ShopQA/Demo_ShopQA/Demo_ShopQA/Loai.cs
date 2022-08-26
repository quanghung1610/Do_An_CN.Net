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
    public partial class Loai : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtloai, dt;
        DataColumn[] key = new DataColumn[1];
        bool themmoi = false;
        public Loai()
        {
            InitializeComponent();
        }

        private void Loai_Load(object sender, EventArgs e)
        {
            dtloai = db.LAYDULIEU("Select * from LOAI");
            dataGridView1.DataSource = dtloai;
            dtloai.PrimaryKey = key;
            dataGridView1.DataSource = dtloai;
            Loai_databiding();
        }
        void Loai_databiding()
        {
            txtMaSP.DataBindings.Add("Text", dtloai, "MALOAI");
            txtTenSP.DataBindings.Add("Text", dtloai, "TenLoai");
        }
        private void btn__Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtMaSP.DataBindings.Clear();
            txtTenSP.DataBindings.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(themmoi)
            {
                if(txtMaSP.Text == "" || txtTenSP.Text == "")
                {
                    DataRow newrow = dtloai.NewRow();
                    newrow[0] = txtMaSP.Text;
                    newrow[1] = txtTenSP.Text;
                    dtloai.Rows.Add(newrow);
                }
                Loai_databiding();
            }
            else
            {
                dataGridView1.Refresh();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string delete = string.Format("delete Loai where MASP = '" + txtMaSP.Text + "'");
            db.THEMXOASUA(delete);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string update = string.Format("Update NHANVIEN set MASP=N'{0}'where TenSP = '{1}'", txtMaSP.Text, txtTenSP.Text);
            db.THEMXOASUA(update);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            db.CAPNHAP("SELECT * FROM LOAI", dtloai);
            MessageBox.Show("Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XULYDATABASE tim = new XULYDATABASE();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from LOAI where MALOAI like'%" + txtFind.Text + "%' and TENLOAI LIKE'%"+txtTenSP.Text+"%'");
        }
    }
}
