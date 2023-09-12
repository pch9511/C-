namespace FranchisePOS
{
    partial class MainForm
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
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnClient = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.Labeltxt = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnProfit = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(26, 73);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(170, 150);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "주문";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(238, 73);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(170, 150);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "재고 관리";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(26, 252);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(170, 150);
            this.btnClient.TabIndex = 3;
            this.btnClient.Text = "회원 관리";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(238, 252);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(170, 150);
            this.btnStaff.TabIndex = 4;
            this.btnStaff.Text = "직원 관리";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // Labeltxt
            // 
            this.Labeltxt.AutoSize = true;
            this.Labeltxt.Location = new System.Drawing.Point(24, 22);
            this.Labeltxt.Name = "Labeltxt";
            this.Labeltxt.Size = new System.Drawing.Size(38, 12);
            this.Labeltxt.TabIndex = 0;
            this.Labeltxt.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(493, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "로그 아웃";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(450, 73);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(170, 150);
            this.btnChat.TabIndex = 7;
            this.btnChat.Text = "채팅방";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnProfit
            // 
            this.btnProfit.Location = new System.Drawing.Point(450, 252);
            this.btnProfit.Name = "btnProfit";
            this.btnProfit.Size = new System.Drawing.Size(170, 150);
            this.btnProfit.TabIndex = 8;
            this.btnProfit.Text = "판매현황";
            this.btnProfit.UseVisualStyleBackColor = true;
            this.btnProfit.Click += new System.EventHandler(this.btnProfit_Click);
            // 
            // btnTime
            // 
            this.btnTime.Location = new System.Drawing.Point(238, 252);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(170, 150);
            this.btnTime.TabIndex = 6;
            this.btnTime.Text = "근태 정보";
            this.btnTime.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 422);
            this.ControlBox = false;
            this.Controls.Add(this.btnProfit);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.Labeltxt);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Label Labeltxt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnProfit;
        private System.Windows.Forms.Button btnTime;
    }
}