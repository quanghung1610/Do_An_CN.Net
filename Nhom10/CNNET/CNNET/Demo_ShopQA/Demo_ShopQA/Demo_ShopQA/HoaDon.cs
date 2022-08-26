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
    public partial class HoaDon : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        DataTable dthd, dtnv, dtkh;
        DataColumn[] key = new DataColumn[1];
        bool themmoi = false;
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            dthd = db.LAYDULIEU("SELECT * FROM HOADON");
            dtkh = db.LAYDULIEU("SELECT * FROM KHACH");
            dtnv = db.LAYDULIEU("SELECT * FROM NHANVIEN");

            dthd.PrimaryKey = key;
            dataGridView1.DataSource = dthd;
            cbkh.DataSource = dtkh;
            cbkh.ValueMember = "MAKH";
            cbnv.DataSource = dtnv;
            cbnv.ValueMember = "MANV";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dthd;
            dataGridView1.Columns[0].DataPropertyName = "MAHD";
            dataGridView1.Columns[1].DataPropertyName = "NGAYBAN";
            DataGridViewComboBoxColumn cboco1 = (DataGridViewComboBoxColumn)dataGridView1.Columns[2];
            DataGridViewComboBoxColumn cboco2 = (DataGridViewComboBoxColumn)dataGridView1.Columns[3];
            dataGridView1.Columns[4].DataPropertyName = "GIAMGIA";
            dataGridView1.Columns[5].DataPropertyName = "THANHTOAN";
            cboco1.DataSource = dtkh;
            cboco2.DataSource = dtnv;
            cboco1.ValueMember = "MAKH";
            cboco1.DataPropertyName = "MAKH";
            cboco2.ValueMember = "MANV";
            cboco2.DataPropertyName = "MANV";
            Hoadon_databings();
        }
        void Hoadon_databings()
        {
            txtMaHD.DataBindings.Add("Text", dthd, "MAHD");
            dtNB.DataBindings.Add("Text", dthd, "NGAYBAN");
            cbkh.DataBindings.Add("Text", dthd, "MAKH");
            cbnv.DataBindings.Add("Text", dthd, "MANV");
            txtGG.DataBindings.Add("Text", dthd, "GIAMGIA");
            txtTT.DataBindings.Add("Text", dthd, "THANHTOAN");
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            themmoi = true;
            txtMaHD.Clear();
            txtGG.Clear();
            txtTT.Clear();
            dtNB.DataBindings.Clear();
            cbkh.DataBindings.Clear();
            cbnv.DataBindings.Clear();
            txtMaHD.DataBindings.Clear();
            txtGG.DataBindings.Clear();
            txtTT.DataBindings.Clear();
            dtNB.DataBindings.Clear();
            cbkh.DataBindings.Clear();
            cbnv.DataBindings.Clear();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(themmoi)
            {
                if (txtMaHD.Text != "" || dtNB.Text != "" || cbkh.Text != "" || cbnv.Text != "" || txtGG.Text != "" || txtTT.Text != "")
                {
                    DataRow newrow = dthd.NewRow();
                    newrow[0] = txtMaHD.Text;
                    newrow[1] = dtNB.Text;
                    newrow[2] = cbkh.Text;
                    newrow[3] = cbnv.Text;
                    newrow[4] = txtGG.Text;
                    newrow[5] = txtTT.Text;
                    dthd.Rows.Add(newrow);
                }
                Hoadon_databings();
            }
            else
            {
                dataGridView1.Refresh();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string delete = string.Format("delete HOADON where MAHD= '{0}'", txtMaHD.Text);
            db.THEMXOASUA(delete);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string update = string.Format("Update HOADON set MAHD=N'{0}'where NGAYBAN = '{1} '", txtMaHD.Text, dtNB.Text);
            db.THEMXOASUA(update);
            dataGridView1.Refresh();
            MessageBox.Show("Success");
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            db.LAYDULIEU("SELECT * FROM HOADON");
            MessageBox.Show("Sucsses");
        }

        private void button1_Click(object sender, EventArgs e)
        {
              XULYDATABASE tim = new XULYDATABASE();
              dataGridView1.DataSource = tim.LAYDULIEU("select * from HOADON where MAHD like'%" + txtFind.Text + "'");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
