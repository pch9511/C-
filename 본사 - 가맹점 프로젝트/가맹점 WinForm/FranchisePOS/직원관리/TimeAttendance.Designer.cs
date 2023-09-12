namespace FranchisePOS
{
    partial class TimeAttendance
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
            this.LogListView = new System.Windows.Forms.ListView();
            this.StaffId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StaffName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogListView
            // 
            this.LogListView.BackColor = System.Drawing.SystemColors.Window;
            this.LogListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StaffId,
            this.StaffName,
            this.columnHeader1,
            this.columnHeader2});
            this.LogListView.FullRowSelect = true;
            this.LogListView.HideSelection = false;
            this.LogListView.Location = new System.Drawing.Point(32, 57);
            this.LogListView.Name = "LogListView";
            this.LogListView.Size = new System.Drawing.Size(534, 295);
            this.LogListView.TabIndex = 86;
            this.LogListView.UseCompatibleStateImageBehavior = false;
            this.LogListView.View = System.Windows.Forms.View.Details;
            // 
            // StaffId
            // 
            this.StaffId.Text = "Id";
            this.StaffId.Width = 120;
            // 
            // StaffName
            // 
            this.StaffName.Text = "이름";
            this.StaffName.Width = 100;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(27, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 39);
            this.label8.TabIndex = 88;
            this.label8.Text = "근태 조회";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "출/퇴근";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "시간";
            this.columnHeader2.Width = 150;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(439, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 45);
            this.btnExit.TabIndex = 89;
            this.btnExit.Text = "뒤로 가기";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // TimeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 368);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.LogListView);
            this.Name = "TimeAttendance";
            this.Text = "근태 조회";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimeAttendance_FormClosing);
            this.Load += new System.EventHandler(this.TimeAttendance_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LogListView;
        private System.Windows.Forms.ColumnHeader StaffId;
        private System.Windows.Forms.ColumnHeader StaffName;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExit;
    }
}