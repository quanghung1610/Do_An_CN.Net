using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Demo_ShopQA
{
    class XULYDATABASE
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public XULYDATABASE()
        {
            string chuoiketnoi = @"server=DESKTOP-G8B0JSH\SQLEXPRESS; database=QLSHOPQUANAO; Integrated Security=true;"; //them \ hoac @
            con = new SqlConnection(chuoiketnoi);
        }

        public XULYDATABASE(string serverName, string dbName, bool auth, string uid, string pwd)
        {
            string chuoiketnoi;
            if (auth) // window authentication
                chuoiketnoi = string.Format(@"server=DESKTOP-G8B0JSH\SQLEXPRESS; database=QLSHOPQUANAO; Integrated Security=true;");
            else // sqlserver authentication
                chuoiketnoi = string.Format(@"server=DESKTOP-G8B0JSH\SQLEXPRESS;Initial Catalog=QLSHOPQUANAO;User ID=sa;Password=***********");
            con = new SqlConnection(chuoiketnoi);
        }

        public DataTable LAYDULIEU(string lenhsql)
        {
            da = new SqlDataAdapter(lenhsql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
           
        }

        //public DataTable tim(string MaSP)
        //{
            
        //    con.Open();
        //    string sql = "select * from SANPHAM where MASP like'%" + MaSP + "%'";
        //    da = new SqlDataAdapter(sql, con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        
        public void CAPNHAP(string lenhsql,DataTable table)
        {
            da = new SqlDataAdapter(lenhsql, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.Update(table);
        }

        

        public void THEMXOASUA(string lenhsql)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand com = new SqlCommand(lenhsql, con);
            com.ExecuteNonQuery();
            con.Close();
            
        }
    }
    }

