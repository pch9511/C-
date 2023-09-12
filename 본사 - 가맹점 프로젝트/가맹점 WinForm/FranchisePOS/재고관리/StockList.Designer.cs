namespace FranchisePOS
{
    partial class StockList
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
            this.FranStockListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FranStockListView
            // 
            this.FranStockListView.BackColor = System.Drawing.SystemColors.Window;
            this.FranStockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.FranStockListView.FullRowSelect = true;
            this.FranStockListView.HideSelection = false;
            this.FranStockListView.Location = new System.Drawing.Point(12, 60);
            this.FranStockListView.Name = "FranStockListView";
            this.FranStockListView.Size = new System.Drawing.Size(616, 316);
            this.FranStockListView.TabIndex = 25;
            this.FranStockListView.UseCompatibleStateImageBehavior = false;
            this.FranStockListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "제품코드";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "제품명";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "가격";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "수량";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "날짜";
            this.columnHeader7.Width = 150;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 90;
            this.label8.Text = "재고 내역";
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(337, 20);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(71, 16);
            this.rbCategory.TabIndex = 96;
            this.rbCategory.TabStop = true;
            this.rbCategory.Text = "카테고리";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(264, 20);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(59, 16);
            this.rbName.TabIndex = 95;
            this.rbName.TabStop = true;
            this.rbName.Text = "제품명";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Checked = true;
            this.rbCode.Location = new System.Drawing.Point(179, 20);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(71, 16);
            this.rbCode.TabIndex = 94;
            this.rbCode.TabStop = true;
            this.rbCode.Text = "제품코드";
            this.rbCode.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(591, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 51);
            this.btnSearch.TabIndex = 92;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(698, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 51);
            this.btnReset.TabIndex = 93;
            this.btnReset.Text = "전체 리스트";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(426, 19);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(148, 21);
            this.txtSearchName.TabIndex = 91;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(648, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 97;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // StockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 387);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rbCategory);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.rbCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.FranStockListView);
            this.Name = "StockList";
            this.Text = "재고 내역";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockList_FormClosing);
            this.Load += new System.EventHandler(this.StockList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView FranStockListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnExit;
    }
}