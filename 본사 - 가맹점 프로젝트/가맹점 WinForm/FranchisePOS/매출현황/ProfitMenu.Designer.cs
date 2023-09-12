namespace FranchisePOS
{
    partial class ProfitMenu
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
            this.btnSell = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnTotal = new System.Windows.Forms.Button();
            this.btnCredit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(295, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 45);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "뒤로 가기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSell
            // 
            this.btnSell.Location = new System.Drawing.Point(26, 252);
            this.btnSell.Name = "btnSell";
            this.btnSell.Size = new System.Drawing.Size(170, 150);
            this.btnSell.TabIndex = 23;
            this.btnSell.Text = "판매 현황";
            this.btnSell.UseVisualStyleBackColor = true;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnCard
            // 
            this.btnCard.Location = new System.Drawing.Point(231, 73);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(170, 150);
            this.btnCard.TabIndex = 22;
            this.btnCard.Text = "카드 판매";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnTotal
            // 
            this.btnTotal.Location = new System.Drawing.Point(231, 252);
            this.btnTotal.Name = "btnTotal";
            this.btnTotal.Size = new System.Drawing.Size(170, 150);
            this.btnTotal.TabIndex = 21;
            this.btnTotal.Text = "총 수익";
            this.btnTotal.UseVisualStyleBackColor = true;
            this.btnTotal.Click += new System.EventHandler(this.btnTotal_Click);
            // 
            // btnCredit
            // 
            this.btnCredit.Location = new System.Drawing.Point(26, 73);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(170, 150);
            this.btnCredit.TabIndex = 20;
            this.btnCredit.Text = "현금 판매";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // ProfitMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 416);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSell);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnTotal);
            this.Controls.Add(this.btnCredit);
            this.Name = "ProfitMenu";
            this.Text = "ProfitMenu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfitMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSell;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Button btnTotal;
        private System.Windows.Forms.Button btnCredit;
    }
}