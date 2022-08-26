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
namespace Demo_ShopQA
{
    public partial class Backup : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=HUNG\SQLEXPRESS2012;Initial Catalog=QLSHOPQUANAO;Integrated Security=True");
        public Backup()
        {
            InitializeComponent();
        }

        private void btn_browse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            if(fld.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fld.SelectedPath;
                btn_backup.Enabled = true;
            }
        }

        private void btn_backup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if(textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please enter backup file locatio");
            }
            else
            {
                string cmd = "BACKUP DATABASE ["+database+"] TO DISK ='"+textBox1.Text+"\\"+"database"+"-"+DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss")+".bak'";
                con.Open();
                SqlCommand com = new SqlCommand(cmd,con);
                com.ExecuteNonQuery();
                MessageBox.Show("Database backup done successfuly");
                con.Close();
                btn_backup.Enabled = false;
            }
        }

        private void btn_browsw2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup file |*.bak";
            dlg.Title = "Database restore";
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                btn_restore.Enabled = true;
            }
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();

            try
            {
                string str1 = string.Format("ALTER DATABASE ["+database+"] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1,con);
                cmd1.ExecuteNonQuery();

                string str2 = string.Format("USE MASTER RESTORE DATABASE ["+database+"] FROM DISK='"+textBox2.Text+"'WITH REPLACE;");
                SqlCommand cmd2 = new SqlCommand(str2,con);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE ["+database+"] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3,con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Database restore done successfuly");
                con.Close();
            }
            catch
            {

            }
        }
    }
}
