namespace FranchisePOS
{
    partial class StockMenu
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOrderCancel = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnStockList = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(295, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 45);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "뒤로 가기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOrderCancel
            // 
            this.btnOrderCancel.Location = new System.Drawing.Point(26, 252);
            this.btnOrderCancel.Name = "btnOrderCancel";
            this.btnOrderCancel.Size = new System.Drawing.Size(170, 150);
            this.btnOrderCancel.TabIndex = 13;
            this.btnOrderCancel.Text = "반품";
            this.btnOrderCancel.UseVisualStyleBackColor = true;
            this.btnOrderCancel.Click += new System.EventHandler(this.btnOrderCancel_Click);
            // 
            // btnOrderList
            // 
            this.btnOrderList.Location = new System.Drawing.Point(231, 73);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(170, 150);
            this.btnOrderList.TabIndex = 12;
            this.btnOrderList.Text = "발주 내역";
            this.btnOrderList.UseVisualStyleBackColor = true;
            this.btnOrderList.Click += new System.EventHandler(this.btnOrderList_Click);
            // 
            // btnStockList
            // 
            this.btnStockList.Location = new System.Drawing.Point(231, 252);
            this.btnStockList.Name = "btnStockList";
            this.btnStockList.Size = new System.Drawing.Size(170, 150);
            this.btnStockList.TabIndex = 11;
            this.btnStockList.Text = "재고 내역";
            this.btnStockList.UseVisualStyleBackColor = true;
            this.btnStockList.Click += new System.EventHandler(this.btnStockList_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(26, 73);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(170, 150);
            this.btnOrder.TabIndex = 10;
            this.btnOrder.Text = "발주 요청";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // StockMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 422);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOrderCancel);
            this.Controls.Add(this.btnOrderList);
            this.Controls.Add(this.btnStockList);
            this.Controls.Add(this.btnOrder);
            this.Name = "StockMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "재고 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOrderCancel;
        private System.Windows.Forms.Button btnOrderList;
        private System.Windows.Forms.Button btnStockList;
        private System.Windows.Forms.Button btnOrder;
    }
}