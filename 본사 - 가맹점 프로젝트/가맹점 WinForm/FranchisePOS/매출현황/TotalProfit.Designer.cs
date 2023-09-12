namespace FranchisePOS
{
    partial class TotalProfit
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
            this.TotalListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblCredit = new System.Windows.Forms.Label();
            this.DT = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TotalListView
            // 
            this.TotalListView.BackColor = System.Drawing.SystemColors.Window;
            this.TotalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.TotalListView.FullRowSelect = true;
            this.TotalListView.HideSelection = false;
            this.TotalListView.Location = new System.Drawing.Point(17, 60);
            this.TotalListView.Name = "TotalListView";
            this.TotalListView.Size = new System.Drawing.Size(481, 316);
            this.TotalListView.TabIndex = 141;
            this.TotalListView.UseCompatibleStateImageBehavior = false;
            this.TotalListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "구입/판매 내역";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "가격";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "구매/판매일";
            this.columnHeader5.Width = 150;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(527, 247);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 12);
            this.lblTotal.TabIndex = 140;
            this.lblTotal.Text = "총 판매 금액 :";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(527, 181);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(37, 12);
            this.lblCard.TabIndex = 139;
            this.lblCard.Text = "카드 :";
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(527, 115);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(41, 12);
            this.lblCredit.TabIndex = 138;
            this.lblCredit.Text = "현금 : ";
            // 
            // DT
            // 
            this.DT.CustomFormat = "yyyy년 MM월";
            this.DT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT.Location = new System.Drawing.Point(350, 16);
            this.DT.Name = "DT";
            this.DT.Size = new System.Drawing.Size(148, 21);
            this.DT.TabIndex = 137;
            this.DT.ValueChanged += new System.EventHandler(this.DT_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(519, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 134;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 132;
            this.label8.Text = "매출 현황";
            // 
            // TotalProfit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 391);
            this.Controls.Add(this.TotalListView);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.DT);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Name = "TotalProfit";
            this.Text = "TotalProfit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TotalProfit_FormClosing);
            this.Load += new System.EventHandler(this.TotalProfit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TotalListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.DateTimePicker DT;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
    }
}