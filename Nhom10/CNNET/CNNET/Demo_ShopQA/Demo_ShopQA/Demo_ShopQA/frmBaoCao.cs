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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void btn_BCNV_Click(object sender, EventArgs e)
        {
            frmChuaBaoCaoNV bc1 = new frmChuaBaoCaoNV();
            bc1.Show();
        }

        private void btn_NhaCC_Click(object sender, EventArgs e)
        {
            frmChuaBCKhach bc2 = new frmChuaBCKhach();
            bc2.Show();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            frmchuabcSP bc3 = new frmchuabcSP();
            bc3.Show();
        }
    }
}
