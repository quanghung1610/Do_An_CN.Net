namespace Demo_ShopQA
{
    partial class Backup
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_restore = new System.Windows.Forms.Button();
            this.btn_browsw2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_browse1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 371);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lime;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.btn_restore);
            this.groupBox2.Controls.Add(this.btn_browsw2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 183);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(667, 184);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BacKup Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(134, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(417, 30);
            this.textBox2.TabIndex = 3;
            // 
            // btn_restore
            // 
            this.btn_restore.Image = global::Demo_ShopQA.Properties.Resources.Backup_restore;
            this.btn_restore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_restore.Location = new System.Drawing.Point(415, 116);
            this.btn_restore.Name = "btn_restore";
            this.btn_restore.Size = new System.Drawing.Size(136, 36);
            this.btn_restore.TabIndex = 2;
            this.btn_restore.Text = "Restore";
            this.btn_restore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_restore.UseVisualStyleBackColor = true;
            this.btn_restore.Click += new System.EventHandler(this.btn_restore_Click);
            // 
            // btn_browsw2
            // 
            this.btn_browsw2.Image = global::Demo_ShopQA.Properties.Resources.icon_browse;
            this.btn_browsw2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_browsw2.Location = new System.Drawing.Point(193, 116);
            this.btn_browsw2.Name = "btn_browsw2";
            this.btn_browsw2.Size = new System.Drawing.Size(140, 36);
            this.btn_browsw2.TabIndex = 1;
            this.btn_browsw2.Text = "Browse";
            this.btn_browsw2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_browsw2.UseVisualStyleBackColor = true;
            this.btn_browsw2.Click += new System.EventHandler(this.btn_browsw2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Yellow;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btn_backup);
            this.groupBox1.Controls.Add(this.btn_browse1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BacKup Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(417, 30);
            this.textBox1.TabIndex = 2;
            // 
            // btn_backup
            // 
            this.btn_backup.Image = global::Demo_ShopQA.Properties.Resources.Backup_restore;
            this.btn_backup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_backup.Location = new System.Drawing.Point(415, 111);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(128, 37);
            this.btn_backup.TabIndex = 1;
            this.btn_backup.Text = "Backup";
            this.btn_backup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.btn_backup_Click);
            // 
            // btn_browse1
            // 
            this.btn_browse1.Image = global::Demo_ShopQA.Properties.Resources.icon_browse;
            this.btn_browse1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_browse1.Location = new System.Drawing.Point(193, 112);
            this.btn_browse1.Name = "btn_browse1";
            this.btn_browse1.Size = new System.Drawing.Size(132, 36);
            this.btn_browse1.TabIndex = 0;
            this.btn_browse1.Text = "Browse";
            this.btn_browse1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_browse1.UseVisualStyleBackColor = true;
            this.btn_browse1.Click += new System.EventHandler(this.btn_browse1_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 371);
            this.Controls.Add(this.panel1);
            this.Name = "Backup";
            this.Text = "Backup";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_restore;
        private System.Windows.Forms.Button btn_browsw2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_browse1;
    }
}