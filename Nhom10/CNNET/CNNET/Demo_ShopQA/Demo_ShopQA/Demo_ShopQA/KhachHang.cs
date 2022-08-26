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
    public partial class KhachHang : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtkh;
        DataColumn[] key = new DataColumn[1];
        bool themmoi = false;
        public KhachHang()
        {
            InitializeComponent();
        }

    

        private void KhachHang_Load(object sender, EventArgs e)
        {
            dtkh = db.LAYDULIEU("SELECT * FROM KHACH");
            dataGridView1.DataSource = dtkh;
            cbKH.Items.Add("Nam");
            cbKH.Items.Add("Nữ");
            cbKH.Items.Add("Khác");
            dtkh.PrimaryKey = key;
            dataGridView1.DataSource = dtkh;
            Khachhang_databings();
        }
        void Khachhang_databings()
        {
            txtMaKH.DataBindings.Add("Text", dtkh, "MAKH");
            txtTenKH.DataBindings.Add("Text", dtkh, "TENKH");
            //dtNS.DataBindings.Add("Text", dtkh, "NGAYSINH");
            dtNS.DataBindings.Add("Text",dtkh,"NGAYSINH");
            dtNDK.DataBindings.Add("Text", dtkh, "NGAYDK");
            cbKH.DataBindings.Add("Text", dtkh, "GTINH");
            txtDC.DataBindings.Add("Text", dtkh, "DCHI");
            txtSDT.DataBindings.Add("Text", dtkh, "SDT");
            
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMaKH.Clear();
            txtTenKH.Clear();
            dtNS.DataBindings.Clear();
            dtNDK.DataBindings.Clear();
            cbKH.DataBindings.Clear();
            txtSDT.Clear();
            txtDC.Clear();

            dtNS.DataBindings.Clear();
            dtNDK.DataBindings.Clear();
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDC.DataBindings.Clear();
            cbKH.DataBindings.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                if (txtMaKH.Text != null || txtTenKH.Text != null || dtNS.Text != null || dtNDK.Text != null || cbKH.Text != null || txtDC.Text != null || txtSDT.Text != null)
                {
                    DataRow newrow = dtkh.NewRow();
                    newrow[0] = txtMaKH.Text;
                    newrow[1] = txtTenKH.Text;
                    newrow[2] = dtNS.Text;
                    newrow[3] = dtNDK.Text;
                    newrow[4] = cbKH.Text;
                    newrow[5] = txtDC.Text;
                    newrow[6] = txtSDT.Text;
                    dtkh.Rows.Add(newrow);
                }
                Khachhang_databings();
            }
            else
            {
                dataGridView1.Refresh();
            }
           }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string delete = string.Format("delete KHACH where MAKH = '{0}'", txtMaKH.Text);
            db.THEMXOASUA(delete);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string update = string.Format("Update KHACH set MAKH=N'{0}'where TenKH = '{1} '", txtMaKH.Text, txtTenKH.Text);
            db.THEMXOASUA(update);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            db.CAPNHAP("SELECT * FROM KHACH", dtkh);
            MessageBox.Show("Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XULYDATABASE tim = new XULYDATABASE();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from KHACH where MAKH like'%" + txtFind.Text + "%'");
        }


    }
}
