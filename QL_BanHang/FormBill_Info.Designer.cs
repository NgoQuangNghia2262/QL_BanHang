namespace QL_BanHang
{
    partial class FormBill_Info
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
            this.flpBill_Info = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // flpBill_Info
            // 
            this.flpBill_Info.AutoScroll = true;
            this.flpBill_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBill_Info.Location = new System.Drawing.Point(13, 172);
            this.flpBill_Info.Name = "flpBill_Info";
            this.flpBill_Info.Size = new System.Drawing.Size(477, 470);
            this.flpBill_Info.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 153);
            this.panel1.TabIndex = 1;
            // 
            // FormBill_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 787);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpBill_Info);
            this.Name = "FormBill_Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBill_Info";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBill_Info;
        private System.Windows.Forms.Panel panel1;
    }
}