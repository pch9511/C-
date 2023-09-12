namespace FranchisePOS
{
    partial class StockOrder
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
            this.btnOrder = new System.Windows.Forms.Button();
            this.PName123 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProductListView = new System.Windows.Forms.ListView();
            this.Id123 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category123 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price123 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCredit = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.rbCode = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbCategory = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(646, 237);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 66;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(496, 237);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(144, 51);
            this.btnOrder.TabIndex = 64;
            this.btnOrder.Text = "발주";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // PName123
            // 
            this.PName123.Text = "제품명";
            this.PName123.Width = 100;
            // 
            // ProductListView
            // 
            this.ProductListView.BackColor = System.Drawing.SystemColors.Window;
            this.ProductListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id123,
            this.PName123,
            this.Category123,
            this.Price123});
            this.ProductListView.FullRowSelect = true;
            this.ProductListView.HideSelection = false;
            this.ProductListView.Location = new System.Drawing.Point(17, 57);
            this.ProductListView.Name = "ProductListView";
            this.ProductListView.Size = new System.Drawing.Size(461, 231);
            this.ProductListView.TabIndex = 58;
            this.ProductListView.UseCompatibleStateImageBehavior = false;
            this.ProductListView.View = System.Windows.Forms.View.Details;
            this.ProductListView.SelectedIndexChanged += new System.EventHandler(this.ProductListView_SelectedIndexChanged);
            // 
            // Id123
            // 
            this.Id123.Text = "제품코드";
            this.Id123.Width = 120;
            // 
            // Category123
            // 
            this.Category123.Text = "카테고리";
            this.Category123.Width = 100;
            // 
            // Price123
            // 
            this.Price123.Text = "가격";
            this.Price123.Width = 120;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 33);
            this.label8.TabIndex = 62;
            this.label8.Text = "제품 리스트";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(694, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 51);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "전체 리스트";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(587, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 51);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(570, 154);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(155, 21);
            this.txtAccount.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "개수 :";
            // 
            // txtName
            // 
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(576, 93);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(149, 21);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "제품명 :";
            // 
            // rbCash
            // 
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Location = new System.Drawing.Point(606, 197);
            this.rbCash.Name = "rbCash";
            this.rbCash.Size = new System.Drawing.Size(47, 16);
            this.rbCash.TabIndex = 72;
            this.rbCash.TabStop = true;
            this.rbCash.Text = "현금";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.CheckedChanged += new System.EventHandler(this.rbCash_CheckedChanged);
            // 
            // rbCredit
            // 
            this.rbCredit.AutoSize = true;
            this.rbCredit.Location = new System.Drawing.Point(678, 197);
            this.rbCredit.Name = "rbCredit";
            this.rbCredit.Size = new System.Drawing.Size(47, 16);
            this.rbCredit.TabIndex = 73;
            this.rbCredit.Text = "외상";
            this.rbCredit.UseVisualStyleBackColor = true;
            this.rbCredit.CheckedChanged += new System.EventHandler(this.rbCredit_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(521, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 74;
            this.label2.Text = "지불 방식 :";
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(254, 16);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(148, 21);
            this.txtSearchName.TabIndex = 60;
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Checked = true;
            this.rbCode.Location = new System.Drawing.Point(7, 17);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(71, 16);
            this.rbCode.TabIndex = 69;
            this.rbCode.TabStop = true;
            this.rbCode.Text = "제품코드";
            this.rbCode.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(95, 17);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(59, 16);
            this.rbName.TabIndex = 70;
            this.rbName.Text = "제품명";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(166, 17);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(71, 16);
            this.rbCategory.TabIndex = 71;
            this.rbCategory.Text = "카테고리";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCategory);
            this.groupBox1.Controls.Add(this.rbName);
            this.groupBox1.Controls.Add(this.rbCode);
            this.groupBox1.Controls.Add(this.txtSearchName);
            this.groupBox1.Location = new System.Drawing.Point(168, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 47);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // StockOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbCredit);
            this.Controls.Add(this.rbCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.ProductListView);
            this.Controls.Add(this.label8);
            this.Name = "StockOrder";
            this.Text = "발주";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockOrder_FormClosing);
            this.Load += new System.EventHandler(this.StockOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.ColumnHeader PName123;
        private System.Windows.Forms.ListView ProductListView;
        private System.Windows.Forms.ColumnHeader Id123;
        private System.Windows.Forms.ColumnHeader Category123;
        private System.Windows.Forms.ColumnHeader Price123;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCredit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}