namespace Franchise
{
    partial class SelectFran
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
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OwnerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FranName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.FranListView = new System.Windows.Forms.ListView();
            this.RegiNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(189, 33);
            this.label8.TabIndex = 81;
            this.label8.Text = "가맹점 리스트";
            // 
            // Address
            // 
            this.Address.Text = "주소";
            this.Address.Width = 220;
            // 
            // OwnerName
            // 
            this.OwnerName.Text = "점주명";
            this.OwnerName.Width = 100;
            // 
            // FranName
            // 
            this.FranName.Text = "가맹점명";
            this.FranName.Width = 120;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("굴림", 11F);
            this.label7.Location = new System.Drawing.Point(225, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 23);
            this.label7.TabIndex = 78;
            this.label7.Text = "버튼식으로 변경";
            // 
            // FranListView
            // 
            this.FranListView.BackColor = System.Drawing.SystemColors.Window;
            this.FranListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FranName,
            this.OwnerName,
            this.RegiNumber,
            this.Address});
            this.FranListView.FullRowSelect = true;
            this.FranListView.HideSelection = false;
            this.FranListView.Location = new System.Drawing.Point(12, 79);
            this.FranListView.Name = "FranListView";
            this.FranListView.Size = new System.Drawing.Size(567, 243);
            this.FranListView.TabIndex = 77;
            this.FranListView.UseCompatibleStateImageBehavior = false;
            this.FranListView.View = System.Windows.Forms.View.Details;
            this.FranListView.SelectedIndexChanged += new System.EventHandler(this.FranListView_SelectedIndexChanged);
            // 
            // RegiNumber
            // 
            this.RegiNumber.Text = "사업자등록번호";
            this.RegiNumber.Width = 120;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(377, 328);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(98, 51);
            this.btnSelect.TabIndex = 83;
            this.btnSelect.Text = "선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(481, 328);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 51);
            this.btnExit.TabIndex = 84;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // SelectFran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 389);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.FranListView);
            this.Name = "SelectFran";
            this.Text = "가맹점 선택";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectFran_FormClosing);
            this.Load += new System.EventHandler(this.SelectFran_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader OwnerName;
        private System.Windows.Forms.ColumnHeader FranName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView FranListView;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader RegiNumber;
    }
}