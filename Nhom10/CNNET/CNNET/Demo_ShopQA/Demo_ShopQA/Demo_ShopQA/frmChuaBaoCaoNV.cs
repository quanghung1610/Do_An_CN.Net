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
    public partial class frmChuaBaoCaoNV : Form
    {
        public frmChuaBaoCaoNV()
        {
            InitializeComponent();
        }

        private void frmChuaBaoCaoNV_Load(object sender, EventArgs e)
        {
            NhanVienBC nvbc = new NhanVienBC();
            crystalReportViewer1.ReportSource = nvbc;
        }
    }
}
