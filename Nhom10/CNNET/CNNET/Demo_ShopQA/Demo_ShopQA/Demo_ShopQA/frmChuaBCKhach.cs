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
    public partial class frmChuaBCKhach : Form
    {
        public frmChuaBCKhach()
        {
            InitializeComponent();
        }

        private void frmChuaBCKhach_Load(object sender, EventArgs e)
        {
            BCkhach k = new BCkhach();
            crystalReportViewer1.ReportSource = k;
        }
    }
}
