namespace Franchise
{
    partial class MainMenu
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.MailReset = new System.Windows.Forms.Button();
            this.ProductListView = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MailReset
            // 
            this.MailReset.Location = new System.Drawing.Point(417, 172);
            this.MailReset.Name = "MailReset";
            this.MailReset.Size = new System.Drawing.Size(133, 116);
            this.MailReset.TabIndex = 78;
            this.MailReset.Text = "메일 초기화";
            this.MailReset.UseVisualStyleBackColor = true;
            this.MailReset.Click += new System.EventHandler(this.MailReset_Click);
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
            this.ProductListView.Location = new System.Drawing.Point(31, 315);
            this.ProductListView.Name = "ProductListView";
            this.ProductListView.Size = new System.Drawing.Size(519, 227);
            this.ProductListView.TabIndex = 77;
            this.ProductListView.UseCompatibleStateImageBehavior = false;
            this.ProductListView.View = System.Windows.Forms.View.Details;
            this.ProductListView.Click += new System.EventHandler(this.ProductListView_Click);
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
            this.Price2.Width = 120;
            // 
            // Account
            // 
            this.Account.Text = "수량";
            this.Account.Width = 120;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(224, 172);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 116);
            this.button5.TabIndex = 76;
            this.button5.Text = "매출관리";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(31, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 116);
            this.button4.TabIndex = 75;
            this.button4.Text = "가맹점 요청";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(417, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 116);
            this.button3.TabIndex = 74;
            this.button3.Text = "제품 관리";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(224, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 116);
            this.button2.TabIndex = 73;
            this.button2.Text = "Web 회원 관리";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 116);
            this.button1.TabIndex = 72;
            this.button1.Text = "가맹점 관리";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 553);
            this.Controls.Add(this.MailReset);
            this.Controls.Add(this.ProductListView);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MailReset;
        private System.Windows.Forms.ListView ProductListView;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader PName;
        private System.Windows.Forms.ColumnHeader Price2;
        private System.Windows.Forms.ColumnHeader Account;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

