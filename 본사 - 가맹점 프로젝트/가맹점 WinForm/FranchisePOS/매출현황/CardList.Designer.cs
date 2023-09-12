namespace FranchisePOS
{
    partial class CardList
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
            this.DT = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbDay = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.CardListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // DT
            // 
            this.DT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT.Location = new System.Drawing.Point(350, 16);
            this.DT.Name = "DT";
            this.DT.Size = new System.Drawing.Size(148, 21);
            this.DT.TabIndex = 131;
            this.DT.ValueChanged += new System.EventHandler(this.DT_ValueChanged);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(519, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 130;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(273, 20);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(47, 16);
            this.rbMonth.TabIndex = 129;
            this.rbMonth.TabStop = true;
            this.rbMonth.Text = "월별";
            this.rbMonth.UseVisualStyleBackColor = true;
            this.rbMonth.CheckedChanged += new System.EventHandler(this.rbMonth_CheckedChanged);
            // 
            // rbDay
            // 
            this.rbDay.AutoSize = true;
            this.rbDay.Checked = true;
            this.rbDay.Location = new System.Drawing.Point(204, 20);
            this.rbDay.Name = "rbDay";
            this.rbDay.Size = new System.Drawing.Size(47, 16);
            this.rbDay.TabIndex = 128;
            this.rbDay.TabStop = true;
            this.rbDay.Text = "일별";
            this.rbDay.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 126;
            this.label8.Text = "현금 판매";
            // 
            // CardListView
            // 
            this.CardListView.BackColor = System.Drawing.SystemColors.Window;
            this.CardListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.CardListView.FullRowSelect = true;
            this.CardListView.HideSelection = false;
            this.CardListView.Location = new System.Drawing.Point(17, 60);
            this.CardListView.Name = "CardListView";
            this.CardListView.Size = new System.Drawing.Size(481, 316);
            this.CardListView.TabIndex = 125;
            this.CardListView.UseCompatibleStateImageBehavior = false;
            this.CardListView.View = System.Windows.Forms.View.Details;
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
            // CardList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 385);
            this.Controls.Add(this.DT);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbDay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CardListView);
            this.Name = "CardList";
            this.Text = "CardList";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CardList_FormClosing);
            this.Load += new System.EventHandler(this.CardList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DT;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView CardListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}