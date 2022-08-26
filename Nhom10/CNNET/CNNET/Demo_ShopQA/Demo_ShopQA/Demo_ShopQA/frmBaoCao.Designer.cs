namespace Demo_ShopQA
{
    partial class frmBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_BCNV = new System.Windows.Forms.Button();
            this.btn_KhachHang = new System.Windows.Forms.Button();
            this.btn_NhaCC = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.btn_BCNV);
            this.flowLayoutPanel1.Controls.Add(this.btn_KhachHang);
            this.flowLayoutPanel1.Controls.Add(this.btn_NhaCC);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(958, 401);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lime;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1145, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giao Diện Báo Cáo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(257, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_BCNV
            // 
            this.btn_BCNV.BackColor = System.Drawing.Color.Aqua;
            this.btn_BCNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BCNV.Image = global::Demo_ShopQA.Properties.Resources.BCnhanvien;
            this.btn_BCNV.Location = new System.Drawing.Point(3, 109);
            this.btn_BCNV.Name = "btn_BCNV";
            this.btn_BCNV.Size = new System.Drawing.Size(313, 164);
            this.btn_BCNV.TabIndex = 1;
            this.btn_BCNV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BCNV.UseVisualStyleBackColor = false;
            this.btn_BCNV.Click += new System.EventHandler(this.btn_BCNV_Click);
            // 
            // btn_KhachHang
            // 
            this.btn_KhachHang.BackColor = System.Drawing.Color.Yellow;
            this.btn_KhachHang.Image = global::Demo_ShopQA.Properties.Resources.icon;
            this.btn_KhachHang.Location = new System.Drawing.Point(322, 109);
            this.btn_KhachHang.Name = "btn_KhachHang";
            this.btn_KhachHang.Size = new System.Drawing.Size(310, 164);
            this.btn_KhachHang.TabIndex = 2;
            this.btn_KhachHang.UseVisualStyleBackColor = false;
            this.btn_KhachHang.Click += new System.EventHandler(this.btn_KhachHang_Click);
            // 
            // btn_NhaCC
            // 
            this.btn_NhaCC.BackColor = System.Drawing.Color.Red;
            this.btn_NhaCC.Image = global::Demo_ShopQA.Properties.Resources.Icon0119;
            this.btn_NhaCC.Location = new System.Drawing.Point(638, 109);
            this.btn_NhaCC.Name = "btn_NhaCC";
            this.btn_NhaCC.Size = new System.Drawing.Size(310, 164);
            this.btn_NhaCC.TabIndex = 3;
            this.btn_NhaCC.UseVisualStyleBackColor = false;
            this.btn_NhaCC.Click += new System.EventHandler(this.btn_NhaCC_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 396);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_BCNV;
        private System.Windows.Forms.Button btn_KhachHang;
        private System.Windows.Forms.Button btn_NhaCC;
    }
}