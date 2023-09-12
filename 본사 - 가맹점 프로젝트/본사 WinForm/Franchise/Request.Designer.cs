namespace Franchise
{
    partial class Request
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReturn = new System.Windows.Forms.Button();
            this.rbReturn1 = new System.Windows.Forms.RadioButton();
            this.rbReturn2 = new System.Windows.Forms.RadioButton();
            this.rbReturn3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 33);
            this.label8.TabIndex = 87;
            this.label8.Text = "재고 요청 리스트";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(682, 328);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 51);
            this.btnExit.TabIndex = 89;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(474, 328);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 51);
            this.btnSend.TabIndex = 88;
            this.btnSend.Text = "요청 허용";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // OrderListView
            // 
            this.OrderListView.BackColor = System.Drawing.SystemColors.Window;
            this.OrderListView.CheckBoxes = true;
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cck,
            this.columnHeader8,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9,
            this.columnHeader7});
            this.OrderListView.FullRowSelect = true;
            this.OrderListView.HideSelection = false;
            this.OrderListView.Location = new System.Drawing.Point(12, 79);
            this.OrderListView.MultiSelect = false;
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.OwnerDraw = true;
            this.OrderListView.Size = new System.Drawing.Size(768, 243);
            this.OrderListView.TabIndex = 85;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
            this.OrderListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OrderListView_ColumnClick);
            this.OrderListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.OrderListView_DrawColumnHeader);
            this.OrderListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.OrderListView_DrawItem);
            this.OrderListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.OrderListView_DrawSubItem);
            this.OrderListView.SelectedIndexChanged += new System.EventHandler(this.OrderListView_SelectedIndexChanged);
            // 
            // cck
            // 
            this.cck.Text = "";
            this.cck.Width = 30;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Index";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "제품코드";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "사업자등록번호";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "제품명";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "가격";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "요청개수";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "발주현황";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 9;
            this.columnHeader7.Text = "갱신일";
            this.columnHeader7.Width = 100;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(578, 328);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(98, 51);
            this.btnReturn.TabIndex = 90;
            this.btnReturn.Text = "요청 거절";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // rbReturn1
            // 
            this.rbReturn1.AutoSize = true;
            this.rbReturn1.Location = new System.Drawing.Point(24, 28);
            this.rbReturn1.Name = "rbReturn1";
            this.rbReturn1.Size = new System.Drawing.Size(75, 16);
            this.rbReturn1.TabIndex = 91;
            this.rbReturn1.TabStop = true;
            this.rbReturn1.Text = "재고 부족";
            this.rbReturn1.UseVisualStyleBackColor = true;
            this.rbReturn1.CheckedChanged += new System.EventHandler(this.rbReturn1_CheckedChanged);
            // 
            // rbReturn2
            // 
            this.rbReturn2.AutoSize = true;
            this.rbReturn2.Location = new System.Drawing.Point(125, 28);
            this.rbReturn2.Name = "rbReturn2";
            this.rbReturn2.Size = new System.Drawing.Size(75, 16);
            this.rbReturn2.TabIndex = 92;
            this.rbReturn2.TabStop = true;
            this.rbReturn2.Text = "제품 점검";
            this.rbReturn2.UseVisualStyleBackColor = true;
            this.rbReturn2.CheckedChanged += new System.EventHandler(this.rbReturn2_CheckedChanged);
            // 
            // rbReturn3
            // 
            this.rbReturn3.AutoSize = true;
            this.rbReturn3.Location = new System.Drawing.Point(226, 28);
            this.rbReturn3.Name = "rbReturn3";
            this.rbReturn3.Size = new System.Drawing.Size(75, 16);
            this.rbReturn3.TabIndex = 93;
            this.rbReturn3.TabStop = true;
            this.rbReturn3.Text = "제품 개편";
            this.rbReturn3.UseVisualStyleBackColor = true;
            this.rbReturn3.CheckedChanged += new System.EventHandler(this.rbReturn3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbReturn3);
            this.groupBox1.Controls.Add(this.rbReturn2);
            this.groupBox1.Controls.Add(this.rbReturn1);
            this.groupBox1.Location = new System.Drawing.Point(444, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 68);
            this.groupBox1.TabIndex = 94;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "거절 사유";
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 8;
            this.columnHeader9.Text = "지불방식";
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 385);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.OrderListView);
            this.Name = "Request";
            this.Text = "가맹점 요청";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Request_FormClosing);
            this.Load += new System.EventHandler(this.Request_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.RadioButton rbReturn1;
        private System.Windows.Forms.RadioButton rbReturn2;
        private System.Windows.Forms.RadioButton rbReturn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}