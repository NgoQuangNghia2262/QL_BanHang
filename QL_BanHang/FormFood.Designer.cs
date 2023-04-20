namespace QL_BanHang
{
    partial class FormFood
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpFood = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbLoaiMH = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.lbTenMH = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ccbLoaiMH = new System.Windows.Forms.ComboBox();
            this.iconClear = new FontAwesome.Sharp.IconPictureBox();
            this.lbSeach = new System.Windows.Forms.Label();
            this.iconshare = new FontAwesome.Sharp.IconPictureBox();
            this.tbSeach = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconshare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flpFood);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(191, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 583);
            this.panel1.TabIndex = 0;
            // 
            // flpFood
            // 
            this.flpFood.AutoScroll = true;
            this.flpFood.Location = new System.Drawing.Point(0, 167);
            this.flpFood.Margin = new System.Windows.Forms.Padding(0);
            this.flpFood.Name = "flpFood";
            this.flpFood.Size = new System.Drawing.Size(664, 416);
            this.flpFood.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.lbLoaiMH);
            this.panel4.Controls.Add(this.lbGia);
            this.panel4.Controls.Add(this.lbTenMH);
            this.panel4.Location = new System.Drawing.Point(0, 124);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(664, 40);
            this.panel4.TabIndex = 3;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.LightGray;
            this.panel7.Location = new System.Drawing.Point(0, 38);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(664, 2);
            this.panel7.TabIndex = 1;
            // 
            // lbLoaiMH
            // 
            this.lbLoaiMH.AutoSize = true;
            this.lbLoaiMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiMH.Location = new System.Drawing.Point(270, 12);
            this.lbLoaiMH.Name = "lbLoaiMH";
            this.lbLoaiMH.Size = new System.Drawing.Size(107, 16);
            this.lbLoaiMH.TabIndex = 0;
            this.lbLoaiMH.Text = "Loại Mặt Hàng";
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.Location = new System.Drawing.Point(471, 12);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(78, 16);
            this.lbGia.TabIndex = 0;
            this.lbGia.Text = "Giá Thành";
            // 
            // lbTenMH
            // 
            this.lbTenMH.AutoSize = true;
            this.lbTenMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMH.Location = new System.Drawing.Point(43, 12);
            this.lbTenMH.Name = "lbTenMH";
            this.lbTenMH.Size = new System.Drawing.Size(104, 16);
            this.lbTenMH.TabIndex = 0;
            this.lbTenMH.Text = "Tên Mặt Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tất cả mặt hàng";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(26, 81);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(603, 40);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ccbLoaiMH);
            this.panel2.Controls.Add(this.iconClear);
            this.panel2.Controls.Add(this.lbSeach);
            this.panel2.Controls.Add(this.iconshare);
            this.panel2.Controls.Add(this.tbSeach);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(621, 42);
            this.panel2.TabIndex = 16;
            // 
            // ccbLoaiMH
            // 
            this.ccbLoaiMH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbLoaiMH.FormattingEnabled = true;
            this.ccbLoaiMH.Items.AddRange(new object[] {
            "All"});
            this.ccbLoaiMH.Location = new System.Drawing.Point(0, 0);
            this.ccbLoaiMH.Margin = new System.Windows.Forms.Padding(0);
            this.ccbLoaiMH.Name = "ccbLoaiMH";
            this.ccbLoaiMH.Size = new System.Drawing.Size(175, 37);
            this.ccbLoaiMH.TabIndex = 16;
            this.ccbLoaiMH.Text = "Lọc mặt hàng";
            this.ccbLoaiMH.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // iconClear
            // 
            this.iconClear.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconClear.ForeColor = System.Drawing.Color.Black;
            this.iconClear.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconClear.IconColor = System.Drawing.Color.Black;
            this.iconClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconClear.IconSize = 26;
            this.iconClear.Location = new System.Drawing.Point(567, 3);
            this.iconClear.Name = "iconClear";
            this.iconClear.Size = new System.Drawing.Size(32, 32);
            this.iconClear.TabIndex = 15;
            this.iconClear.TabStop = false;
            this.iconClear.Visible = false;
            this.iconClear.Click += new System.EventHandler(this.iconClear_Click);
            // 
            // lbSeach
            // 
            this.lbSeach.AutoSize = true;
            this.lbSeach.Enabled = false;
            this.lbSeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSeach.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSeach.Location = new System.Drawing.Point(210, 3);
            this.lbSeach.Name = "lbSeach";
            this.lbSeach.Size = new System.Drawing.Size(147, 22);
            this.lbSeach.TabIndex = 14;
            this.lbSeach.Text = "Nhập tên món ăn";
            // 
            // iconshare
            // 
            this.iconshare.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconshare.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconshare.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconshare.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconshare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconshare.Location = new System.Drawing.Point(175, 4);
            this.iconshare.Margin = new System.Windows.Forms.Padding(0);
            this.iconshare.Name = "iconshare";
            this.iconshare.Size = new System.Drawing.Size(32, 32);
            this.iconshare.TabIndex = 11;
            this.iconshare.TabStop = false;
            // 
            // tbSeach
            // 
            this.tbSeach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSeach.Location = new System.Drawing.Point(207, 2);
            this.tbSeach.Margin = new System.Windows.Forms.Padding(0);
            this.tbSeach.Name = "tbSeach";
            this.tbSeach.Size = new System.Drawing.Size(357, 27);
            this.tbSeach.TabIndex = 12;
            this.tbSeach.Click += new System.EventHandler(this.tbSeach_Click);
            this.tbSeach.TextChanged += new System.EventHandler(this.tbSeach_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(0, 63);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(664, 4);
            this.panel3.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh Sách Mặt Hàng";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PaintBrush;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton1.IconSize = 26;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(707, 49);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.iconButton1.Size = new System.Drawing.Size(166, 38);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.Text = "Sửa mặt hàng";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(-6, 90);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1062, 4);
            this.panel5.TabIndex = 0;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Add;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton2.IconSize = 26;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(537, 49);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.iconButton2.Size = new System.Drawing.Size(166, 38);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "Thêm mặt hàng";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton2.UseVisualStyleBackColor = false;
            this.iconButton2.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.Red;
            this.iconButton3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Recycle;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.iconButton3.IconSize = 26;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(879, 49);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.iconButton3.Size = new System.Drawing.Size(166, 38);
            this.iconButton3.TabIndex = 2;
            this.iconButton3.Text = "Xóa mặt hàng";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton3.UseVisualStyleBackColor = false;
            this.iconButton3.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.iconPictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 20;
            this.iconPictureBox1.Location = new System.Drawing.Point(21, 18);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(20, 20);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.iconPictureBox1.TabIndex = 5;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quay lại form quản lý";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // FormFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1057, 733);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.iconButton3);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "FormFood";
            this.Text = "FormFood";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconshare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ccbLoaiMH;
        private FontAwesome.Sharp.IconPictureBox iconClear;
        private System.Windows.Forms.Label lbSeach;
        private FontAwesome.Sharp.IconPictureBox iconshare;
        private System.Windows.Forms.TextBox tbSeach;
        private System.Windows.Forms.FlowLayoutPanel flpFood;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbLoaiMH;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.Label lbTenMH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel5;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label3;
    }
}