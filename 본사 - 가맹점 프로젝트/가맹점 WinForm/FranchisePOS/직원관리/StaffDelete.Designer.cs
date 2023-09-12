namespace FranchisePOS
{
    partial class StaffDelete
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
            this.StaffListView = new System.Windows.Forms.ListView();
            this.StaffId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StaffName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("굴림", 20F);
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(226, 39);
            this.label8.TabIndex = 87;
            this.label8.Text = "직원 삭제";
            // 
            // StaffListView
            // 
            this.StaffListView.BackColor = System.Drawing.SystemColors.Window;
            this.StaffListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StaffId,
            this.StaffName});
            this.StaffListView.FullRowSelect = true;
            this.StaffListView.HideSelection = false;
            this.StaffListView.Location = new System.Drawing.Point(38, 51);
            this.StaffListView.Name = "StaffListView";
            this.StaffListView.Size = new System.Drawing.Size(241, 179);
            this.StaffListView.TabIndex = 85;
            this.StaffListView.UseCompatibleStateImageBehavior = false;
            this.StaffListView.View = System.Windows.Forms.View.Details;
            this.StaffListView.SelectedIndexChanged += new System.EventHandler(this.StaffListView_SelectedIndexChanged);
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
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(285, 236);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 91;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 236);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 90;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // StaffDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 286);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.StaffListView);
            this.Name = "StaffDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "직원 삭제";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffDelete_FormClosing);
            this.Load += new System.EventHandler(this.StaffDelete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView StaffListView;
        private System.Windows.Forms.ColumnHeader StaffId;
        private System.Windows.Forms.ColumnHeader StaffName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
    }
}