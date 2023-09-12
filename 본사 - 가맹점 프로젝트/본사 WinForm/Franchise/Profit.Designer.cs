namespace Franchise
{
    partial class Profit
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Top5ListVIew = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProfitTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.cbList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbFr = new System.Windows.Forms.CheckBox();
            this.cbPr = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFran = new System.Windows.Forms.RadioButton();
            this.rbCompany = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ProfitTabControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DT
            // 
            this.DT.CustomFormat = "yyyy년 MM월";
            this.DT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DT.Location = new System.Drawing.Point(522, 107);
            this.DT.Name = "DT";
            this.DT.Size = new System.Drawing.Size(148, 21);
            this.DT.TabIndex = 145;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1028, 359);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 144;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(804, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(144, 51);
            this.btnSearch.TabIndex = 143;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 18F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(23, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 25);
            this.label8.TabIndex = 142;
            this.label8.Text = "매출 관리";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 150;
            this.label1.Text = "순이익 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 151;
            this.label2.Text = "총 매출 :";
            // 
            // Top5ListVIew
            // 
            this.Top5ListVIew.BackColor = System.Drawing.SystemColors.Window;
            this.Top5ListVIew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11});
            this.Top5ListVIew.FullRowSelect = true;
            this.Top5ListVIew.HideSelection = false;
            this.Top5ListVIew.Location = new System.Drawing.Point(967, 37);
            this.Top5ListVIew.Name = "Top5ListVIew";
            this.Top5ListVIew.Size = new System.Drawing.Size(205, 316);
            this.Top5ListVIew.TabIndex = 152;
            this.Top5ListVIew.UseCompatibleStateImageBehavior = false;
            this.Top5ListVIew.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "제품명";
            this.columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "판매량";
            // 
            // ProfitTabControl
            // 
            this.ProfitTabControl.Controls.Add(this.tabPage1);
            this.ProfitTabControl.Controls.Add(this.tabPage2);
            this.ProfitTabControl.Controls.Add(this.tabPage3);
            this.ProfitTabControl.Controls.Add(this.tabPage4);
            this.ProfitTabControl.Location = new System.Drawing.Point(23, 94);
            this.ProfitTabControl.Name = "ProfitTabControl";
            this.ProfitTabControl.SelectedIndex = 0;
            this.ProfitTabControl.Size = new System.Drawing.Size(743, 303);
            this.ProfitTabControl.TabIndex = 155;
            this.ProfitTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.ProfitTabControl_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(735, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "매입";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(735, 277);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "매출";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(735, 277);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "반품";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(735, 277);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "불량률";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(559, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 159;
            this.label5.Text = "가맹점 목록 :";
            // 
            // cbList
            // 
            this.cbList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cbList.FormattingEnabled = true;
            this.cbList.Location = new System.Drawing.Point(645, 56);
            this.cbList.Name = "cbList";
            this.cbList.Size = new System.Drawing.Size(121, 20);
            this.cbList.TabIndex = 158;
            this.cbList.TextChanged += new System.EventHandler(this.cbList_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbFr);
            this.groupBox1.Controls.Add(this.cbPr);
            this.groupBox1.Location = new System.Drawing.Point(288, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 51);
            this.groupBox1.TabIndex = 160;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "정렬 기준";
            // 
            // cbFr
            // 
            this.cbFr.AutoSize = true;
            this.cbFr.Location = new System.Drawing.Point(108, 21);
            this.cbFr.Name = "cbFr";
            this.cbFr.Size = new System.Drawing.Size(72, 16);
            this.cbFr.TabIndex = 165;
            this.cbFr.Text = "가맹점별";
            this.cbFr.UseVisualStyleBackColor = true;
            this.cbFr.Click += new System.EventHandler(this.cbFr_Click);
            // 
            // cbPr
            // 
            this.cbPr.AutoSize = true;
            this.cbPr.Location = new System.Drawing.Point(16, 21);
            this.cbPr.Name = "cbPr";
            this.cbPr.Size = new System.Drawing.Size(60, 16);
            this.cbPr.TabIndex = 164;
            this.cbPr.Text = "제품별";
            this.cbPr.UseVisualStyleBackColor = true;
            this.cbPr.Click += new System.EventHandler(this.cbPr_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFran);
            this.groupBox2.Controls.Add(this.rbCompany);
            this.groupBox2.Location = new System.Drawing.Point(27, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 51);
            this.groupBox2.TabIndex = 161;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "회사 기준";
            // 
            // rbFran
            // 
            this.rbFran.AutoSize = true;
            this.rbFran.Location = new System.Drawing.Point(119, 20);
            this.rbFran.Name = "rbFran";
            this.rbFran.Size = new System.Drawing.Size(59, 16);
            this.rbFran.TabIndex = 1;
            this.rbFran.Text = "가맹점";
            this.rbFran.UseVisualStyleBackColor = true;
            // 
            // rbCompany
            // 
            this.rbCompany.AutoSize = true;
            this.rbCompany.Checked = true;
            this.rbCompany.Location = new System.Drawing.Point(23, 20);
            this.rbCompany.Name = "rbCompany";
            this.rbCompany.Size = new System.Drawing.Size(47, 16);
            this.rbCompany.TabIndex = 0;
            this.rbCompany.TabStop = true;
            this.rbCompany.Text = "본사";
            this.rbCompany.UseVisualStyleBackColor = true;
            this.rbCompany.CheckedChanged += new System.EventHandler(this.rbCompany_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 162;
            this.label3.Text = "총 반품액 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 163;
            this.label4.Text = "총 매입 :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("굴림", 20F);
            this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label6.Location = new System.Drawing.Point(962, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 33);
            this.label6.TabIndex = 165;
            this.label6.Text = "Top5 상품";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(772, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 277);
            this.groupBox3.TabIndex = 166;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "매출 정리";
            // 
            // Profit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 454);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbList);
            this.Controls.Add(this.ProfitTabControl);
            this.Controls.Add(this.Top5ListVIew);
            this.Controls.Add(this.DT);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label8);
            this.Name = "Profit";
            this.Text = "Profit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Profit_FormClosing);
            this.Load += new System.EventHandler(this.Profit_Load);
            this.ProfitTabControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DT;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Top5ListVIew;
        private System.Windows.Forms.TabControl ProfitTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFran;
        private System.Windows.Forms.RadioButton rbCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbFr;
        private System.Windows.Forms.CheckBox cbPr;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}