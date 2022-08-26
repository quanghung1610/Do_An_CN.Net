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
    public partial class DoiMatKhau : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_thuchien_Click(object sender, EventArgs e)
        {
            string update = string.Format("UPDATE NHANVIEN set PASSW ='" + txtmkm.Text + "' where (USERNAME = N'" + txtUser.Text + "'and PASSW'" + txtmkc.Text + "')");
            if (txtUser.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập");
            }
            else
            {
                if (txtmkc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
                else
                {
                    if (txtmkm.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                    }
                    else
                    {
                        if (txtgomkmoi.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập lại mật khẩu");
                        }
                        else
                        {
                            if (txtmkm.Text == txtgomkmoi.Text)
                            {
                                db.THEMXOASUA(update);
                                MessageBox.Show("Bạn đã thay đổi mật khẩu thành công");
                               
                            }
                            else
                            {
                                MessageBox.Show("Bạn nhập lại mật khẩu không đúng");
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtmkc.Text = "";
            txtmkm.Text = "";
            txtgomkmoi.Text = "";
            txtUser.Focus();

        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
