using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace Demo_ShopQA
{
    public partial class Login : Form
    {
        XULYDATABASE db = new XULYDATABASE();
        private SqlConnection con ;
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-G8B0JSH\SQLEXPRESS; database=QLSHOPQUANAO; Integrated Security=true;");
            
                con.Open();
                string tk = txtuser.Text;
                string mk = txtPass.Text;
                string login = "SELECT * FROM NHANVIEN Where USERNAME='" + tk + "'and PASSW='" + mk + "'and QUYEN = 'Admin' ";
                SqlCommand CMD = new SqlCommand(login, con);
                
                SqlDataReader rd = CMD.ExecuteReader();
                if (rd.Read())
                {

                    rd.Read();
                        MessageBox.Show("Đăng nhập vào hệ thống (Quyền Admin) !", "Thông báo !");
                        frmmain.quyen = "Admin";
                        frmmain f = new frmmain();
                        f.ShowDialog();
                        this.Hide();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập vào hệ thống (Quyền NhanVien) !", "Thông báo !");
                        frmmain.quyen = "NhanVien";
                        frmmain f = new frmmain();
                        f.ShowDialog();
                        this.Hide();
                        this.Close();
                    }
             
            
        }

        private void Cbmk_CheckedChanged(object sender, EventArgs e)
        {
            if (Cbmk.Checked == true)
            {
                txtPass.UseSystemPasswordChar = false;
                Cbmk.Text = "Hide Password";
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                Cbmk.Text = "Show Password";
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
         if(MessageBox.Show("Bạn có chắc muốn đóng chương trình?","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning) == DialogResult.OK)
         {
             this.Close();
         }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
