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
    public partial class ChiTietHoaDon : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtcthd, dthd;
        DataColumn[] key = new DataColumn[1];
        bool themmoi = false;
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            dtcthd = db.LAYDULIEU("SELECT * FROM CHITIETHD");
            dthd = db.LAYDULIEU("SELECT * FROM HOADON");
            dataGridView1.DataSource = dtcthd;
            dtcthd.PrimaryKey = key;
            cbcthd.DataSource = dthd;
            cbcthd.ValueMember = "MAHD";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtcthd;
            DataGridViewComboBoxColumn cboco1 = (DataGridViewComboBoxColumn)dataGridView1.Columns[0];
            dataGridView1.Columns[1].DataPropertyName = "MASP";
            dataGridView1.Columns[2].DataPropertyName = "SOLUONG";
            dataGridView1.Columns[3].DataPropertyName = "GIABAN";
            dataGridView1.Columns[4].DataPropertyName = "THANHTOAN";
            cboco1.DataSource = dthd;
            cboco1.ValueMember = "MAHD";
            cboco1.DataPropertyName = "MAHD";
            CTHD_databings();
        }
        void CTHD_databings()
        {
            cbcthd.DataBindings.Add("SelectedValue", dtcthd, "MAHD");
            txtMASP.DataBindings.Add("Text", dtcthd, "MASP");
            txtSL.DataBindings.Add("Text", dtcthd, "SOLUONG");
            txtGB.DataBindings.Add("Text", dtcthd, "GIABAN");
            txtTT.DataBindings.Add("Text", dtcthd, "THANHTIEN");
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMASP.Clear();
            txtSL.Clear();
            txtGB.Clear();
            txtTT.Clear();
            txtMASP.DataBindings.Clear();
            txtSL.DataBindings.Clear();
            txtGB.DataBindings.Clear();
            txtTT.DataBindings.Clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(themmoi)
            {
                if (cbcthd.Text != "" || txtMASP.Text != "" || txtSL.Text != "" || txtGB.Text != "" || txtTT.Text != "")
                {
                    DataRow n = dtcthd.NewRow();
                    n[0] = cbcthd.Text;
                    n[1] = txtMASP.Text;
                    n[2] = txtSL.Text;
                    n[3] = txtGB.Text;
                    n[4] = txtTT.Text;
                    dtcthd.Rows.Add(n);
                }
                CTHD_databings();
            }
            else
            {
                dataGridView1.Refresh();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string delete = string.Format("delete CHITIETHD where MAHD= '{0}'", txtMASP.Text);
            db.THEMXOASUA(delete);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string delete = string.Format("Update CHITIETHOADON set MAHD=N'{0}'where MASP = '{1} '",cbcthd.Text,txtMASP.Text);
            db.THEMXOASUA(delete);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
