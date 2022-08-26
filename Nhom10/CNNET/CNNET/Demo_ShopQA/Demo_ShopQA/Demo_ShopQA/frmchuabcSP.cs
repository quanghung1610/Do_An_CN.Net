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
    public partial class frmchuabcSP : Form
    {
        public frmchuabcSP()
        {
            InitializeComponent();
        }

        private void frmchuabcSP_Load(object sender, EventArgs e)
        {
            SanPham1 sp = new SanPham1();
            crystalReportViewer1.ReportSource = sp;
        }
    }
}
