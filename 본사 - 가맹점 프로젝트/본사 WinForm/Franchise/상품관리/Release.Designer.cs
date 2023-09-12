namespace Franchise
{
    partial class Release
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
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.ProductListView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.FranListView = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FranName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OwnerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RegiNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.FranTabControl = new System.Windows.Forms.TabControl();
            this.AccountSpin = new System.Windows.Forms.NumericUpDown();
            this.btnIn = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AccountSpin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(251, 40);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(148, 21);
            this.txtSearchName.TabIndex = 70;
            // 
            // ProductListView
            // 
            this.ProductListView.BackColor = System.Drawing.SystemColors.Window;
            this.ProductListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.PName,
            this.Price2,
            this.Account});
            this.ProductListView.FullRowSelect = true;
            this.ProductListView.HideSelection = false;
            this.ProductListView.Location = new System.Drawing.Point(12, 81);
            this.ProductListView.Name = "ProductListView";
            this.ProductListView.Size = new System.Drawing.Size(587, 227);
            this.ProductListView.TabIndex = 68;
            this.ProductListView.UseCompatibleStateImageBehavior = false;
            this.ProductListView.View = System.Windows.Forms.View.Details;
            this.ProductListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ProductListView_ColumnClick);
            this.ProductListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ProductListView_DrawColumnHeader);
            this.ProductListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ProductListView_DrawItem);
            this.ProductListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ProductListView_DrawSubItem);
            this.ProductListView.SelectedIndexChanged += new System.EventHandler(this.ProductListView_SelectedIndexChanged);
            this.ProductListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProductListView_MouseClick);
            // 
            // Id
            // 
            this.Id.Text = "제품코드";
            this.Id.Width = 120;
            // 
            // PName
            // 
            this.PName.Text = "제품명";
            this.PName.Width = 150;
            // 
            // Price2
            // 
            this.Price2.Text = "가격";
            this.Price2.Width = 150;
            // 
            // Account
            // 
            this.Account.Text = "수량";
            this.Account.Width = 120;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 33);
            this.label8.TabIndex = 72;
            this.label8.Text = "제품 리스트";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(405, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 51);
            this.btnSearch.TabIndex = 71;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(505, 24);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(94, 51);
            this.btnReset.TabIndex = 76;
            this.btnReset.Text = "전체 리스트";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1120, 583);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 51);
            this.btnExit.TabIndex = 75;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(1016, 583);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(98, 51);
            this.btnOut.TabIndex = 74;
            this.btnOut.Text = "출고";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // FranListView
            // 
            this.FranListView.BackColor = System.Drawing.SystemColors.Window;
            this.FranListView.CheckBoxes = true;
            this.FranListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cck,
            this.FranName,
            this.OwnerName,
            this.RegiNumber,
            this.Address});
            this.FranListView.FullRowSelect = true;
            this.FranListView.HideSelection = false;
            this.FranListView.Location = new System.Drawing.Point(622, 81);
            this.FranListView.Name = "FranListView";
            this.FranListView.OwnerDraw = true;
            this.FranListView.Size = new System.Drawing.Size(596, 227);
            this.FranListView.TabIndex = 78;
            this.FranListView.UseCompatibleStateImageBehavior = false;
            this.FranListView.View = System.Windows.Forms.View.Details;
            this.FranListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.FranListView_ColumnClick);
            this.FranListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.FranListView_DrawColumnHeader);
            this.FranListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.FranListView_DrawItem);
            this.FranListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.FranListView_DrawSubItem);
            this.FranListView.SelectedIndexChanged += new System.EventHandler(this.FranListView_SelectedIndexChanged);
            // 
            // cck
            // 
            this.cck.Text = "";
            this.cck.Width = 30;
            // 
            // FranName
            // 
            this.FranName.Text = "가맹점명";
            this.FranName.Width = 120;
            // 
            // OwnerName
            // 
            this.OwnerName.Text = "점주명";
            this.OwnerName.Width = 100;
            // 
            // RegiNumber
            // 
            this.RegiNumber.Text = "사업자등록번호";
            this.RegiNumber.Width = 120;
            // 
            // Address
            // 
            this.Address.Text = "주소";
            this.Address.Width = 220;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 11F);
            this.label7.Location = new System.Drawing.Point(184, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 23);
            this.label7.TabIndex = 69;
            this.label7.Text = "제품명 :";
            // 
            // FranTabControl
            // 
            this.FranTabControl.Location = new System.Drawing.Point(348, 377);
            this.FranTabControl.Name = "FranTabControl";
            this.FranTabControl.SelectedIndex = 0;
            this.FranTabControl.Size = new System.Drawing.Size(587, 257);
            this.FranTabControl.TabIndex = 79;
            // 
            // AccountSpin
            // 
            this.AccountSpin.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AccountSpin.Location = new System.Drawing.Point(437, 116);
            this.AccountSpin.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.AccountSpin.Name = "AccountSpin";
            this.AccountSpin.Size = new System.Drawing.Size(120, 21);
            this.AccountSpin.TabIndex = 81;
            this.AccountSpin.Visible = false;
            this.AccountSpin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountSpin_KeyDown);
            this.AccountSpin.Leave += new System.EventHandler(this.AccountSpin_Leave);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(557, 314);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(112, 57);
            this.btnIn.TabIndex = 82;
            this.btnIn.Text = "출고목록에 담기";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 0;
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "제품코드";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "제품명";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "가격";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "수량";
            this.columnHeader5.Width = 120;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(762, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 25);
            this.button1.TabIndex = 83;
            this.button1.Text = "현재 출고리스트 초기화";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AccountUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 668);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.AccountSpin);
            this.Controls.Add(this.FranTabControl);
            this.Controls.Add(this.FranListView);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ProductListView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOut);
            this.Name = "AccountUpDown";
            this.Text = "출고";
            this.Load += new System.EventHandler(this.Release_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AccountSpin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.ListView ProductListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.ColumnHeader Price2;
        private System.Windows.Forms.ColumnHeader Account;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.ListView FranListView;
        private System.Windows.Forms.ColumnHeader FranName;
        private System.Windows.Forms.ColumnHeader OwnerName;
        private System.Windows.Forms.ColumnHeader RegiNumber;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.TabControl FranTabControl;
        private System.Windows.Forms.NumericUpDown AccountSpin;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button button1;
    }
}