namespace QL_BanHang
{
    partial class FormImportingInvoices
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
            this.dgvHDB = new System.Windows.Forms.DataGridView();
            this.dgvTTHDB = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.aaaaaaaaa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHDB
            // 
            this.dgvHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDB.Location = new System.Drawing.Point(12, 195);
            this.dgvHDB.Name = "dgvHDB";
            this.dgvHDB.RowHeadersWidth = 51;
            this.dgvHDB.RowTemplate.Height = 24;
            this.dgvHDB.Size = new System.Drawing.Size(505, 410);
            this.dgvHDB.TabIndex = 0;
            // 
            // dgvTTHDB
            // 
            this.dgvTTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTHDB.Location = new System.Drawing.Point(523, 195);
            this.dgvTTHDB.Name = "dgvTTHDB";
            this.dgvTTHDB.RowHeadersWidth = 51;
            this.dgvTTHDB.RowTemplate.Height = 24;
            this.dgvTTHDB.Size = new System.Drawing.Size(505, 410);
            this.dgvTTHDB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "HÓA ĐƠN BÁN";
            // 
            // aaaaaaaaa
            // 
            this.aaaaaaaaa.AutoSize = true;
            this.aaaaaaaaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aaaaaaaaa.Location = new System.Drawing.Point(602, 85);
            this.aaaaaaaaa.Name = "aaaaaaaaa";
            this.aaaaaaaaa.Size = new System.Drawing.Size(340, 29);
            this.aaaaaaaaa.TabIndex = 1;
            this.aaaaaaaaa.Text = "THÔNG TIN HÓA ĐƠN BÁN";
            // 
            // FormImportingInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 619);
            this.Controls.Add(this.aaaaaaaaa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTTHDB);
            this.Controls.Add(this.dgvHDB);
            this.Name = "FormImportingInvoices";
            this.Text = "FormImportingInvoices";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHDB;
        private System.Windows.Forms.DataGridView dgvTTHDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label aaaaaaaaa;
    }
}