namespace FranchisePOS
{
    partial class StockOrderCancel
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
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbBack3 = new System.Windows.Forms.RadioButton();
            this.rbBack2 = new System.Windows.Forms.RadioButton();
            this.rbBack1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(180, 17);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(71, 16);
            this.rbCategory.TabIndex = 94;
            this.rbCategory.Text = "발주현황";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(107, 17);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(59, 16);
            this.rbName.TabIndex = 93;
            this.rbName.Text = "제품명";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Checked = true;
            this.rbCode.Location = new System.Drawing.Point(22, 17);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(71, 16);
            this.rbCode.TabIndex = 92;
            this.rbCode.TabStop = true;
            this.rbCode.Text = "제품코드";
            this.rbCode.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(592, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 51);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(699, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 51);
            this.btnReset.TabIndex = 91;
            this.btnReset.Text = "전체 리스트";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(427, 19);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(148, 21);
            this.txtSearchName.TabIndex = 87;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(651, 311);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 90;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // OrderListView
            // 
            this.OrderListView.BackColor = System.Drawing.SystemColors.Window;
            this.OrderListView.CheckBoxes = true;
            this.OrderListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cck,
            this.No,
            this.Id,
            this.PName,
            this.Price,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.OrderListView.FullRowSelect = true;
            this.OrderListView.HideSelection = false;
            this.OrderListView.Location = new System.Drawing.Point(17, 68);
            this.OrderListView.Name = "OrderListView";
            this.OrderListView.OwnerDraw = true;
            this.OrderListView.Size = new System.Drawing.Size(628, 293);
            this.OrderListView.TabIndex = 86;
            this.OrderListView.UseCompatibleStateImageBehavior = false;
            this.OrderListView.View = System.Windows.Forms.View.Details;
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
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 0;
            // 
            // Id
            // 
            this.Id.Text = "제품코드";
            this.Id.Width = 80;
            // 
            // PName
            // 
            this.PName.Text = "제품명";
            this.PName.Width = 80;
            // 
            // Price
            // 
            this.Price.Text = "가격";
            this.Price.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "수량";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "발주현황";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "갱신";
            this.columnHeader3.Width = 150;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 89;
            this.label8.Text = "발주 내역";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(651, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 51);
            this.btnCancel.TabIndex = 95;
            this.btnCancel.Text = "반품 요청";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbBack3
            // 
            this.rbBack3.AutoSize = true;
            this.rbBack3.Location = new System.Drawing.Point(22, 103);
            this.rbBack3.Name = "rbBack3";
            this.rbBack3.Size = new System.Drawing.Size(75, 16);
            this.rbBack3.TabIndex = 99;
            this.rbBack3.Text = "단순 변심";
            this.rbBack3.UseVisualStyleBackColor = true;
            this.rbBack3.CheckedChanged += new System.EventHandler(this.rbBack3_CheckedChanged);
            // 
            // rbBack2
            // 
            this.rbBack2.AutoSize = true;
            this.rbBack2.Location = new System.Drawing.Point(22, 67);
            this.rbBack2.Name = "rbBack2";
            this.rbBack2.Size = new System.Drawing.Size(47, 16);
            this.rbBack2.TabIndex = 98;
            this.rbBack2.Text = "불량";
            this.rbBack2.UseVisualStyleBackColor = true;
            this.rbBack2.CheckedChanged += new System.EventHandler(this.rbBack2_CheckedChanged);
            // 
            // rbBack1
            // 
            this.rbBack1.AutoSize = true;
            this.rbBack1.Checked = true;
            this.rbBack1.Location = new System.Drawing.Point(22, 32);
            this.rbBack1.Name = "rbBack1";
            this.rbBack1.Size = new System.Drawing.Size(75, 16);
            this.rbBack1.TabIndex = 97;
            this.rbBack1.TabStop = true;
            this.rbBack1.Text = "재고 많음";
            this.rbBack1.UseVisualStyleBackColor = true;
            this.rbBack1.CheckedChanged += new System.EventHandler(this.rbBack1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCategory);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Controls.Add(this.rbCode);
            this.groupBox1.Location = new System.Drawing.Point(149, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 39);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbBack3);
            this.groupBox2.Controls.Add(this.rbBack2);
            this.groupBox2.Controls.Add(this.rbBack1);
            this.groupBox2.Location = new System.Drawing.Point(661, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(121, 142);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "반품 사유";
            // 
            // StockOrderCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.label8);
            this.Name = "StockOrderCancel";
            this.Text = "반품";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockOrderCancel_FormClosing);
            this.Load += new System.EventHandler(this.StockOrderCancel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbBack3;
        private System.Windows.Forms.RadioButton rbBack2;
        private System.Windows.Forms.RadioButton rbBack1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.ColumnHeader No;
    }
}