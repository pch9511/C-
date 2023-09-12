namespace FranchisePOS
{
    partial class Order
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
            this.btnMenu4 = new System.Windows.Forms.Button();
            this.btnMenu3 = new System.Windows.Forms.Button();
            this.btnMenu2 = new System.Windows.Forms.Button();
            this.btnMenu1 = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.btnDessert = new System.Windows.Forms.Button();
            this.btnDrink = new System.Windows.Forms.Button();
            this.btnCoffee = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnMenu4
            // 
            this.btnMenu4.BackColor = System.Drawing.Color.White;
            this.btnMenu4.Location = new System.Drawing.Point(470, 317);
            this.btnMenu4.Name = "btnMenu4";
            this.btnMenu4.Size = new System.Drawing.Size(215, 173);
            this.btnMenu4.TabIndex = 23;
            this.btnMenu4.Text = "Coffee4";
            this.btnMenu4.UseVisualStyleBackColor = false;
            this.btnMenu4.Click += new System.EventHandler(this.btnMenu4_Click);
            // 
            // btnMenu3
            // 
            this.btnMenu3.BackColor = System.Drawing.Color.White;
            this.btnMenu3.Location = new System.Drawing.Point(170, 317);
            this.btnMenu3.Name = "btnMenu3";
            this.btnMenu3.Size = new System.Drawing.Size(215, 173);
            this.btnMenu3.TabIndex = 22;
            this.btnMenu3.Text = "Coffee3";
            this.btnMenu3.UseVisualStyleBackColor = false;
            this.btnMenu3.Click += new System.EventHandler(this.btnMenu3_Click);
            // 
            // btnMenu2
            // 
            this.btnMenu2.BackColor = System.Drawing.Color.White;
            this.btnMenu2.Location = new System.Drawing.Point(470, 119);
            this.btnMenu2.Name = "btnMenu2";
            this.btnMenu2.Size = new System.Drawing.Size(215, 173);
            this.btnMenu2.TabIndex = 21;
            this.btnMenu2.Text = "Coffee2";
            this.btnMenu2.UseVisualStyleBackColor = false;
            this.btnMenu2.Click += new System.EventHandler(this.btnMenu2_Click);
            // 
            // btnMenu1
            // 
            this.btnMenu1.BackColor = System.Drawing.Color.White;
            this.btnMenu1.Location = new System.Drawing.Point(170, 119);
            this.btnMenu1.Name = "btnMenu1";
            this.btnMenu1.Size = new System.Drawing.Size(215, 173);
            this.btnMenu1.TabIndex = 20;
            this.btnMenu1.Text = "Coffee1";
            this.btnMenu1.UseVisualStyleBackColor = false;
            this.btnMenu1.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.Location = new System.Drawing.Point(644, 12);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(194, 89);
            this.btnEvent.TabIndex = 19;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = true;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // btnDessert
            // 
            this.btnDessert.Location = new System.Drawing.Point(437, 12);
            this.btnDessert.Name = "btnDessert";
            this.btnDessert.Size = new System.Drawing.Size(194, 89);
            this.btnDessert.TabIndex = 18;
            this.btnDessert.Text = "Dessert";
            this.btnDessert.UseVisualStyleBackColor = true;
            this.btnDessert.Click += new System.EventHandler(this.btnDessert_Click);
            // 
            // btnDrink
            // 
            this.btnDrink.Location = new System.Drawing.Point(230, 12);
            this.btnDrink.Name = "btnDrink";
            this.btnDrink.Size = new System.Drawing.Size(194, 89);
            this.btnDrink.TabIndex = 17;
            this.btnDrink.Text = "Drink";
            this.btnDrink.UseVisualStyleBackColor = true;
            this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
            // 
            // btnCoffee
            // 
            this.btnCoffee.Location = new System.Drawing.Point(23, 12);
            this.btnCoffee.Name = "btnCoffee";
            this.btnCoffee.Size = new System.Drawing.Size(194, 89);
            this.btnCoffee.TabIndex = 16;
            this.btnCoffee.Text = "Coffee";
            this.btnCoffee.UseVisualStyleBackColor = true;
            this.btnCoffee.Click += new System.EventHandler(this.btnCoffee_Click);
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(580, 505);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(126, 115);
            this.btnPay.TabIndex = 27;
            this.btnPay.Text = "결제";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(712, 505);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(126, 115);
            this.btnExit.TabIndex = 28;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // OrderListView
            // 
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.OrderListView.HideSelection = false;
            this.OrderListView.Location = new System.Drawing.Point(23, 505);
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.Size = new System.Drawing.Size(551, 115);
            this.OrderListView.TabIndex = 29;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "상품명";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "가격";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "개수";
            this.columnHeader3.Width = 160;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 632);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.btnMenu4);
            this.Controls.Add(this.btnMenu3);
            this.Controls.Add(this.btnMenu2);
            this.Controls.Add(this.btnMenu1);
            this.Controls.Add(this.btnEvent);
            this.Controls.Add(this.btnDessert);
            this.Controls.Add(this.btnDrink);
            this.Controls.Add(this.btnCoffee);
            this.Name = "Order";
            this.Text = "1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Order_FormClosing);
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnMenu4;
        private System.Windows.Forms.Button btnMenu3;
        private System.Windows.Forms.Button btnMenu2;
        private System.Windows.Forms.Button btnMenu1;
        private System.Windows.Forms.Button btnEvent;
        private System.Windows.Forms.Button btnDessert;
        private System.Windows.Forms.Button btnDrink;
        private System.Windows.Forms.Button btnCoffee;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}