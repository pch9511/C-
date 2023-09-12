namespace FranchisePOS
{
    partial class SellList
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
            this.label8 = new System.Windows.Forms.Label();
            this.DT = new System.Windows.Forms.DateTimePicker();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblCard = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SellListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(519, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 123;
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
            this.label8.TabIndex = 117;
            this.label8.Text = "판매 현황";
            // 
            // DT
            // 
            this.DT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT.Location = new System.Drawing.Point(350, 16);
            this.DT.Name = "DT";
            this.DT.Size = new System.Drawing.Size(148, 21);
            this.DT.TabIndex = 127;
            this.DT.ValueChanged += new System.EventHandler(this.DT_ValueChanged);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(286, 20);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(47, 16);
            this.rbMonth.TabIndex = 126;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "월별";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Location = new System.Drawing.Point(217, 20);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(47, 16);
            this.rbDay.TabIndex = 125;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "일별";
            this.rbDay.UseVisualStyleBackColor = true;
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(527, 115);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(41, 12);
            this.lblCredit.TabIndex = 128;
            this.lblCredit.Text = "현금 : ";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(527, 181);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(37, 12);
            this.lblCard.TabIndex = 129;
            this.lblCard.Text = "카드 :";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(527, 247);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(81, 12);
            this.lblTotal.TabIndex = 130;
            this.lblTotal.Text = "총 판매 금액 :";
            // 
            // SellListView
            // 
            this.SellListView.BackColor = System.Drawing.SystemColors.Window;
            this.SellListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.SellListView.FullRowSelect = true;
            this.SellListView.HideSelection = false;
            this.SellListView.Location = new System.Drawing.Point(17, 60);
            this.SellListView.Name = "SellListView";
            this.SellListView.Size = new System.Drawing.Size(481, 316);
            this.SellListView.TabIndex = 131;
            this.SellListView.UseCompatibleStateImageBehavior = false;
            this.SellListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "판매 내용";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "가격";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "판매일";
            this.columnHeader5.Width = 150;
            // 
            // SellList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 387);
            this.Controls.Add(this.SellListView);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.DT);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbDay);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Name = "SellList";
            this.Text = "SellList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SellList_FormClosing);
            this.Load += new System.EventHandler(this.SellList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DT;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ListView SellListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}