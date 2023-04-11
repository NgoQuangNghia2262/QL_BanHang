
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Xml.Linq;
using Color = System.Drawing.Color;

namespace QL_BanHang
{
    public partial class FormBill : Form
    {
        private Food food = new Food();
        private Bill bill = new Bill();
        private double sec = 0.5;//Thời gian delay tìm kiếm food
        
       
        public FormBill()
        {
            InitializeComponent();
        }
       
        public FormBill(Bill bill)
        {
            InitializeComponent();
            cssBody();
            this.bill = bill;
            LoadFlpContainer();
        }
        //CSS
        void cssBody()
        {
            int widthScreen = Screen.PrimaryScreen.WorkingArea.Width;
            int heightScreen = Screen.PrimaryScreen.WorkingArea.Height;

            //cho form hiển thị theo kích thước của màn hình
            this.Width = Convert.ToInt32(widthScreen * 0.8);
            this.Height = Convert.ToInt32(heightScreen * 0.9);
            flpContainer.Width = Convert.ToInt32(this.Width * 0.975);
            flpContainer.Height = Convert.ToInt32(this.Height * 0.888);
            cssFlpContainer();
        }
        void cssFlpContainer()
        {
            flpContainerLeft.Width = Convert.ToInt32(flpContainer.Width * 0.152);
            flpContainerLeft.Height = flpContainer.Height;
            flpContainerCenter.Width = Convert.ToInt32(flpContainer.Width * 0.386);
            flpContainerCenter.Height = flpContainer.Height;
            flpContainerRight.Width = flpContainer.Width - flpContainerLeft.Width - flpContainerCenter.Width-3;
            flpContainerRight.Height = flpContainer.Height -3;
            cssFlpContainerLeft();
            cssFlpContainerCenter();
            cssFlpContainerRight();
        }
        void cssFlpContainerLeft()
        {

        }
        void cssFlpContainerCenter()
        {

        }
        void cssFlpContainerRight()
        {
            int hei = flpContainerRight.Height;
            int wid = flpContainerRight.Width;
            cssFlpContainerRight_Header(wid,hei);
            cssFlpContainerRight_Bill(wid, hei);
            cssFlpContainerRight_pnlFotter(wid,hei);
            cssFlpContainerRight_Fotter(wid , hei);
        }
        void cssFlpContainerRight_Header(int wid, int hei)
        {
            flpContainerRight_Header.Width = wid - 3;
            flpContainerRight_Header.Height = Convert.ToInt32(hei * 0.08169) - 3;
            flpContainerRight_Header.BorderStyle = BorderStyle.FixedSingle;
        }
        void cssFlpContainerRight_Bill(int wid, int hei)
        {
            flpContainerRight_Bill.Width = wid - 3;
            flpContainerRight_Bill.Height = Convert.ToInt32(wid *0.70) - 3;
            flpContainerRight_Bill.BorderStyle = BorderStyle.FixedSingle;
        }
        void cssFlpContainerRight_pnlFotter(int wid , int hei)
        {
            flpContainerRight_pnlFotter.Width = wid - 3;
            flpContainerRight_pnlFotter.Height = Convert.ToInt32(hei * 0.27) - 3;
            flpContainerRight_pnlFotter.BorderStyle = BorderStyle.FixedSingle;
            flpContainerRight_pnlFotter.Location = new Point(0, hei - flpContainerRight_Fotter.Height-flpContainerRight_pnlFotter.Height);
            panel5.Width = wid - 3;
        }
        void cssFlpContainerRight_Fotter(int wid, int hei)
        {
            flpContainerRight_Fotter.Width = wid - 3;
            flpContainerRight_Fotter.Height = Convert.ToInt32(hei * 0.118) - 3;
            flpContainerRight_Fotter.BorderStyle = BorderStyle.FixedSingle;
            flpContainerRight_Fotter.Location = new Point(0, hei - flpContainerRight_Fotter.Height);
        }
        
        //Load
        void LoadFlpContainer()
        {
            LoadContainerLeft();
            LoadContainerCenter();
            LoadContainerRight(bill);
        }
        void LoadContainerLeft()
        {
            string[] categorys = food.getCategory();
            foreach (string item in categorys)
            {
                Button btn = new Button();
                btn.Width = Convert.ToInt32(flpContainerLeft.Width * 0.88);
                btn.Margin = new Padding(1);
                btn.Height = btn.Width * 625 / 1000;
                btn.Text = item;
                btn.BackColor = Color.LightYellow;
                btn.Click += foodCategory_Click;
                flpContainerLeft.Controls.Add(btn);
            }

        }
        void LoadContainerCenter()
        {

        }
        void LoadProduct(Food[] foods)
        {
            flpContainerCenter.Controls.Clear();
            foreach (Food item in foods)
            {
                Button btn = new Button();
                btn.Width = flpContainerCenter.Width/3 - 7;
                btn.Height = btn.Width * 625/1000;
                btn.Text = item.NameF;
                btn.BackColor = Color.LightYellow;
                btn.Click += food_Click;
                flpContainerCenter.Controls.Add(btn);
            }
        }
        void LoadContainerRight(Bill bill)
        {
            LoadContainerRight_Header();
            LoadContainerRight_Bill(bill);
            LoadContainerRight_pnlFotter();
            LoadContainerRight_Fotter();
        }
        void LoadContainerRight_Header() 
        {

        }
        void LoadContainerRight_Bill(Bill bill)
        {
            flpContainerRight_Bill.Controls.Clear();
            Bill_Info[] billinfos = bill.bill_Info;
            foreach (Bill_Info item in billinfos)
            {
                Panel containerBillInfo = CreateBillInfo(flpContainerRight_Bill,item);
                flpContainerRight_Bill.Controls.Add(containerBillInfo);
            }
        }
        void LoadContainerRight_pnlFotter()
        {
            lbTienHang.Text = bill.Total.ToString();
            tbDiscount.Text = (bill.Discount*100).ToString();
            lbTongTien.Text = (bill.Total*(1- bill.Discount)).ToString();
        }
        Button ButtonInFlpContainerRight_Fotter(string text)
        {
            int hei = flpContainerRight_Fotter.Height;
            int wid = flpContainerRight_Fotter.Width;
            Button btn = new Button();
            btn.Text = text;
            btn.Margin = new Padding(3, 0, 3, 0);
            btn.Width = Convert.ToInt32(wid / 4) - 6;
            btn.Height = flpContainerRight_Fotter.Height;
            btn.BackColor = Color.Gray;
            btn.ForeColor = Color.White;
            btn.Font = new System.Drawing.Font("MV Boli", 12, FontStyle.Bold);
            btn.Click += (object sender, EventArgs e) =>
            {
                switch (text)
                {
                    case "Thanh Toán":
                        {
                            ThanhToan();
                            break;
                        }
                    case "Gộp Đơn":
                        {
                            GopDon();
                            break;
                        }
                    case "Đóng":
                        {
                            Dong();
                            break;
                        }
                    case "Tạm tính":
                        {
                            break;
                        }

                    default:
                        break;
                }
            };
            return btn;
        }
        void LoadContainerRight_Fotter()
        {
            flpContainerRight_Fotter.Controls.Add(ButtonInFlpContainerRight_Fotter("Đóng"));
            flpContainerRight_Fotter.Controls.Add(ButtonInFlpContainerRight_Fotter("Gộp Đơn"));
            flpContainerRight_Fotter.Controls.Add(ButtonInFlpContainerRight_Fotter("Tạm Tính"));
            flpContainerRight_Fotter.Controls.Add(ButtonInFlpContainerRight_Fotter("Thanh Toán"));
        }
        
        internal Panel CreateBillInfo(FlowLayoutPanel flp , Bill_Info BI)
        {
            Panel panel = new Panel();
            int width = flp.Width;
            panel.Width = width-flp.Width/10;
            panel.Height = flp.Height/7 - 5;
            int height = panel.Height;


            Label lbl = new Label();
            lbl.Text = (BI.food.Price * BI.Amount).ToString();
            lbl.Font = new System.Drawing.Font("Bold", 12 , FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.Location = new Point(Convert.ToInt32(width * 0.73), Convert.ToInt32(height * 0.238));

            Label lblNameF = new Label();
            lblNameF.Text = BI.NameF;
            lblNameF.Font = new System.Drawing.Font("Bold", 10, FontStyle.Bold);
            lblNameF.AutoSize = true;
            lblNameF.Location = new Point(Convert.ToInt32(width * 0.02), Convert.ToInt32(height * 0.238));

            Label lblAmount = new Label();
            lblAmount.Text = BI.Amount.ToString();
            lblAmount.Font = new System.Drawing.Font("Bold", 12, FontStyle.Bold);
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(Convert.ToInt32(width * 0.56), Convert.ToInt32(height * 0.238));

            Label lblLabey = new Label();
            lblLabey.Text = "Giá Thường : ";
            lblLabey.AutoSize = true;
            lblLabey.Location = new Point(Convert.ToInt32(width * 0.03), Convert.ToInt32(height * 0.635));

            Label lblPrice = new Label();
            lblPrice.Text = BI.food.Price.ToString();
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(Convert.ToInt32(width * 0.24), Convert.ToInt32(height * 0.635));

            panel.Controls.Add(lblPrice);//0
            panel.Controls.Add(lblLabey);//1
            panel.Controls.Add(lblAmount);//2
            panel.Controls.Add(lblNameF);//3
            panel.Controls.Add(lbl);//4

            
            panel.Padding = new Padding(3);
            panel.MouseEnter += (object sender, EventArgs e) =>
            {
                panel.Height = panel.Height + 50;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BackColor = Color.Aqua;
            };
            panel.MouseLeave += (object sender, EventArgs e) =>
            {
                 panel.Height = panel.Height - 50;
                panel.BorderStyle = BorderStyle.None;
                panel.BackColor = Color.White;

            };

            return panel;
        }

        // Even
        private void food_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(bill.Id == 0) {
                bill = new Bill(0 , bill.IdTb , DateTime.Now , DateTime.Now , 0 , "");
                Table tb = new Table();
                tb = tb.Find(bill.IdTb);
                tb.Status = 1;
                tb.Save();
                bill.Save();
                bill = tb.bill;
                
            }
            
            Bill_Info billinfo = new Bill_Info(bill.Id, button.Text, 1);
            foreach (dynamic item in flpContainerRight_Bill.Controls)
            {
                if (item.Controls[3].Text == button.Text)
                {
                    // Tổng mới = tổng hiện tại (item.Controls[4].Text) + giá của food (button.Text là tên food) 
                    item.Controls[4].Text = (double.Parse(item.Controls[4].Text) + billinfo.food.Price).ToString();
                    // Số lg mới = sl hiện tại (item.Controls[2].Text) + 1
                    item.Controls[2].Text = (int.Parse(item.Controls[2].Text) + 1).ToString(); 
                    billinfo.Amount = int.Parse(item.Controls[2].Text);
                    goto Next;
                }
            }
            Panel panel = CreateBillInfo(flpContainerRight_Bill,billinfo);
            flpContainerRight_Bill.Controls.Add(panel);
        Next:
            billinfo.Save();
            billinfo.food.SubIngredient();
            LoadContainerRight_pnlFotter();
        }

        private void foodCategory_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Food[] foods = food.FindWithCategory(button.Text);
            LoadProduct(foods);
        }
        private void FormBill_Load(object sender, EventArgs e)
        {   
        }
       
        private void tbFind_Click(object sender, EventArgs e)
        {
            tbFind.Focus();
            label2.Visible = false;
        }
        void ThanhToan()
        {
            this.Hide();
            bill.Status = 1;
            bill.Save();
            Table tb = new Table();
            tb = tb.Find(bill.IdTb);
            tb.Status = 1;
            tb.Save();
            FormMain form = new FormMain();
            form.ShowDialog();
            this.Close();
        }
        private void Dong()
        {
            this.Hide();
            FormMain form = new FormMain();
            form.ShowDialog();
            this.Close();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            double discount = double.Parse(tbDiscount.Text) / 100;
            bill.Discount = discount;
            iconPictureBox1.Focus();
            bill.Save();
            LoadContainerRight_pnlFotter();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            
        }

        private void tbFind_TextChanged(object sender, EventArgs e)
        {
            if (tbSeach.Text == "") {
                lbSeach.Visible = true;
                iconClear.Visible = false; }
            else {
                lbSeach.Visible = false;
                iconClear.Visible = true; }
            timer1.Stop();
            sec = 0.5;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec-=0.5;
            if (sec == 0)
            { 
                Food[] foods = food.FindWithNameF(tbSeach.Text);
                LoadProduct(foods);
                timer1.Stop();
                sec = 0.5;
            }
        }

        private void iconPictureBox7_Click(object sender, EventArgs e)
        {
            tbSeach.Text = "";
        }

        private void GopDon()
        {
            this.Hide();
            FormMain form = new FormMain();
            form.ShowDialog();
            foreach (Control item in form.flpTable.Controls)
            {
                item.Click += (object sender, EventArgs e) => { MessageBox.Show("Hiii"); };
            }
            this.Close();
        }

      

        private void tbSeach_Click(object sender, EventArgs e)
        {
            lbSeach.Visible = false;
        }
    }
}
