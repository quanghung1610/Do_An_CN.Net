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
using System.Data;
using System.IO;
namespace Demo_ShopQA
{
    public partial class SanPham : Form
    {
        String DuongDanFile = "";//duong dan file
        Image DefaultImage;// anh mac dinh khi chay code
        Byte[] ImageByteArray;//ma hoa anh thanh mang bam
        XULYDATABASE db = new XULYDATABASE();
        DataTable dtSPham, dtLA;
        DataColumn[] keySP = new DataColumn[1];

        bool themmoi = false;
        public SanPham()
        {
            InitializeComponent();
            DefaultImage = ImgHinhAnh.Image;
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            dtSPham = db.LAYDULIEU("select * from SANPHAM");
            dtLA = db.LAYDULIEU("select * from LOAI");

            keySP[0] = dtSPham.Columns[0];
            dtSPham.PrimaryKey = keySP;

            cboLoai.DataSource = dtLA;
            cboLoai.DisplayMember = "MALOAI";
            cboLoai.ValueMember = "MALOAI";

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dtSPham;
            dataGridView1.Columns[0].DataPropertyName = "MASP";
            DataGridViewComboBoxColumn cbocol = (DataGridViewComboBoxColumn)dataGridView1.Columns[1];
            dataGridView1.Columns[2].DataPropertyName = "TENSP";
            dataGridView1.Columns[3].DataPropertyName = "GIABANTHAMKHAO";
            dataGridView1.Columns[4].DataPropertyName = "SIZE";
            dataGridView1.Columns[5].DataPropertyName = "CHATLIEU";
            dataGridView1.Columns[6].DataPropertyName = "MAUSAC";
            dataGridView1.Columns[7].DataPropertyName = "HINH";


            cbocol.DataSource = dtLA;
            cbocol.DisplayMember = "MALOAI";
            cbocol.ValueMember = "MALOAI";
            cbocol.DataPropertyName = "MALOAI";

            SP_DataBiding();
        }
        void SP_DataBiding()
        {
            txtMaSP.DataBindings.Add("Text", dtSPham, "MASP");
            cboLoai.DataBindings.Add("Text", dtSPham, "MALOAI");
            txtSanpham.DataBindings.Add("Text", dtSPham, "TENSP");
            txtGiaban.DataBindings.Add("Text", dtSPham, "GIABANTHAMKHAO");
            txtSize.DataBindings.Add("Text", dtSPham, "SIZE");
            txtChatlieu.DataBindings.Add("Text", dtSPham, "CHATLIEU");
            txtMausac.DataBindings.Add("Text", dtSPham, "MAUSAC");
            ImgHinhAnh.DataBindings.Add("Text", dtSPham, "HINH");
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            db.CAPNHAP("SELECT * FROM SANPHAM", dtSPham);
            MessageBox.Show("Success");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themmoi = true;

            txtMaSP.DataBindings.Clear();
            txtSanpham.DataBindings.Clear();
            txtGiaban.DataBindings.Clear();
            txtChatlieu.DataBindings.Clear();
            txtSize.DataBindings.Clear();
            txtMausac.DataBindings.Clear();
            cboLoai.DataBindings.Clear();
            ImgHinhAnh.DataBindings.Clear();

            txtMaSP.Clear();
            txtSanpham.Clear();
            txtGiaban.Clear();
            txtChatlieu.Clear();
            txtSize.Clear();
            txtMausac.Clear();
            ImgHinhAnh.Image = DefaultImage;
            DuongDanFile = "";//reset lai duong dan file

            cboLoai.Enabled = txtMaSP.Enabled = txtSanpham.Enabled = txtGiaban.Enabled = txtSize.Enabled = txtChatlieu.Enabled = txtMausac.Enabled = true;

            btnThem.Enabled = btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (themmoi)
            {
                if (DuongDanFile == "")
                {
                    MessageBox.Show("Vui long chon anh", "thong bao");
                    return;
                }
                else
                {
                    Image temp = new Bitmap(DuongDanFile);// ánh xạ đường dẫn ảnh
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);//Lưu ảnh
                    ImageByteArray = strm.ToArray();// mã hóa ảnh thành mãng băm
                }
                if (txtMaSP.Text != "" || txtSanpham.Text != "" || txtGiaban.Text != "" || txtSize.Text != "" || txtChatlieu.Text != "" || txtMausac.Text != "")
                {
                    DataRow newrow = dtSPham.NewRow();
                    newrow[0] = txtMaSP.Text;
                    newrow[1] = cboLoai.SelectedValue.ToString();
                    newrow[2] = txtSanpham.Text;
                    newrow[3] = txtGiaban.Text;
                    newrow[4] = txtSize.Text;
                    newrow[5] = txtChatlieu.Text;
                    newrow[6] = txtMausac.Text;
                    newrow[7] = ImageByteArray;//
                    dtSPham.Rows.Add(newrow);
                }
                SP_DataBiding();
            }
            else
            {
                dataGridView1.Refresh();
            }
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //string update = string.Format("Update SANPHAM set MASP=N'{0}'where TenSP = '{1}'", txtMaSP.Text, txtSanpham.Text);
            //db.THEMXOASUA(update);
            //dataGridView1.Refresh();
            //MessageBox.Show("Success");
            themmoi = false;
            txtMaSP.Enabled = false;
            cboLoai.Enabled = txtSanpham.Enabled = txtGiaban.Enabled = txtSize.Enabled = txtChatlieu.Enabled = txtMausac.Enabled = true;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dataGridView1.ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc không?", "Cảnh báo xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                //ktr khóa ngoại 
                DataTable dtCTNH = db.LAYDULIEU("select distinct MASP from CHITIETNHAPHANG where MASP='" + txtMaSP.Text + "'");
                if (dtCTNH.Rows.Count == 0)//ko tồn tại trong bảng sinh viên
                {
                    DataRow r = dtSPham.Rows.Find(txtMaSP.Text);
                    if (r != null)
                        r.Delete();
                }
                else
                    MessageBox.Show("Hàng đang tồn tại không xóa được");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            XULYDATABASE tim = new XULYDATABASE();
            dataGridView1.DataSource = tim.LAYDULIEU("select * from SANPHAM where MASP like'%" + txtTim.Text + "%'");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg"; //chọn các file có duôi là png và jpg
            if (ofd.ShowDialog() == DialogResult.OK)//nếu chọn oke
            {
                DuongDanFile = ofd.FileName;//đường dẫn ảnh bằng đường dẫn đã chọn
                ImgHinhAnh.Image = new Bitmap(DuongDanFile);// ảnh mặc định dc thay bằng đường dẫn ảnh dòng trên
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                byte[] ImageArray = (byte[])dataGridView1.CurrentRow.Cells[7].Value;// lấy lại ảnh đã mã hóa và xuất lên ảnh mặc định
                if (ImageArray.Length == 0)// nếu mảng băm của ảnh rỗng hoặc sai
                    ImgHinhAnh.Image = DefaultImage;// ảnh hiện tại =ảnh mặc định
                else//thành công
                {
                    ImageByteArray = ImageArray;
                    ImgHinhAnh.Image = Image.FromStream(new MemoryStream(ImageArray));// lấy lại ảnh đã mã hóa và xuất lên ảnh mặc định
                }
            }
        }


    }
}
