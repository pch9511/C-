namespace FranchisePOS
{
    partial class StockOrderList
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
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.OrderListView = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.btnReceive = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbCategory
            // 
            this.rbCategory.AutoSize = true;
            this.rbCategory.Location = new System.Drawing.Point(338, 20);
            this.rbCategory.Name = "rbCategory";
            this.rbCategory.Size = new System.Drawing.Size(71, 16);
            this.rbCategory.TabIndex = 85;
            this.rbCategory.TabStop = true;
            this.rbCategory.Text = "발주현황";
            this.rbCategory.UseVisualStyleBackColor = true;
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(265, 20);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(59, 16);
            this.rbName.TabIndex = 84;
            this.rbName.TabStop = true;
            this.rbName.Text = "제품명";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbCode
            // 
            this.rbCode.AutoSize = true;
            this.rbCode.Checked = true;
            this.rbCode.Location = new System.Drawing.Point(180, 20);
            this.rbCode.Name = "rbCode";
            this.rbCode.Size = new System.Drawing.Size(71, 16);
            this.rbCode.TabIndex = 83;
            this.rbCode.TabStop = true;
            this.rbCode.Text = "제품코드";
            this.rbCode.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(656, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 51);
            this.btnSearch.TabIndex = 78;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(763, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 51);
            this.btnReset.TabIndex = 82;
            this.btnReset.Text = "전체 리스트";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Price
            // 
            this.Price.Text = "가격";
            this.Price.Width = 100;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(427, 19);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(148, 21);
            this.txtSearchName.TabIndex = 77;
            // 
            // Id
            // 
            this.Id.Text = "제품코드";
            this.Id.Width = 80;
            // 
            // PName
            // 
            this.PName.Text = "제품명";
            this.PName.Width = 100;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(715, 311);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 81;
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
            this.columnHeader4,
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
            this.OrderListView.Size = new System.Drawing.Size(684, 294);
            this.OrderListView.TabIndex = 76;
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
            // columnHeader4
            // 
            this.columnHeader4.Text = "No";
            this.columnHeader4.Width = 30;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "수량";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "발주현황";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "갱신";
            this.columnHeader3.Width = 100;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 33);
            this.label8.TabIndex = 79;
            this.label8.Text = "발주 내역";
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(715, 243);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(144, 51);
            this.btnReceive.TabIndex = 86;
            this.btnReceive.Text = "제품 수령";
            this.btnReceive.UseVisualStyleBackColor = true;
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(713, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 51);
            this.btnDelete.TabIndex = 87;
            this.btnDelete.Text = "주문 삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // StockOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 387);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.rbCategory);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.rbCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.OrderListView);
            this.Controls.Add(this.label8);
            this.Name = "StockOrderList";
            this.Text = "발주 내역";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockOrderList_FormClosing);
            this.Load += new System.EventHandler(this.StockOrderList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbCategory;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListView OrderListView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnReceive;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnDelete;
    }
}