namespace Franchise
{
    partial class WebRegist
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
            this.lblRegi = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.RbFail1 = new System.Windows.Forms.RadioButton();
            this.RbFail2 = new System.Windows.Forms.RadioButton();
            this.RbFail3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRegi
            // 
            this.lblRegi.AutoSize = true;
            this.lblRegi.Location = new System.Drawing.Point(24, 28);
            this.lblRegi.Name = "lblRegi";
            this.lblRegi.Size = new System.Drawing.Size(101, 12);
            this.lblRegi.TabIndex = 0;
            this.lblRegi.Text = "사업자등록번호 : ";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(24, 74);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(28, 12);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID : ";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(24, 120);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(69, 12);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "승인 여부 : ";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(24, 166);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 12);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "요청일 : ";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(247, 187);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 34);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "승인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(328, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "거부";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RbFail1
            // 
            this.RbFail1.AutoSize = true;
            this.RbFail1.Checked = true;
            this.RbFail1.Location = new System.Drawing.Point(29, 20);
            this.RbFail1.Name = "RbFail1";
            this.RbFail1.Size = new System.Drawing.Size(75, 16);
            this.RbFail1.TabIndex = 7;
            this.RbFail1.TabStop = true;
            this.RbFail1.Text = "중복 요청";
            this.RbFail1.UseVisualStyleBackColor = true;
            // 
            // RbFail2
            // 
            this.RbFail2.AutoSize = true;
            this.RbFail2.Location = new System.Drawing.Point(29, 74);
            this.RbFail2.Name = "RbFail2";
            this.RbFail2.Size = new System.Drawing.Size(87, 16);
            this.RbFail2.TabIndex = 8;
            this.RbFail2.Text = "정보 불일치";
            this.RbFail2.UseVisualStyleBackColor = true;
            // 
            // RbFail3
            // 
            this.RbFail3.AutoSize = true;
            this.RbFail3.Location = new System.Drawing.Point(29, 128);
            this.RbFail3.Name = "RbFail3";
            this.RbFail3.Size = new System.Drawing.Size(87, 16);
            this.RbFail3.TabIndex = 9;
            this.RbFail3.Text = "사이트 개편";
            this.RbFail3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbFail1);
            this.groupBox1.Controls.Add(this.RbFail3);
            this.groupBox1.Controls.Add(this.RbFail2);
            this.groupBox1.Location = new System.Drawing.Point(255, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 150);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "취소 사유";
            // 
            // WebRegist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 233);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblRegi);
            this.Name = "WebRegist";
            this.Text = "회원 정보";
            this.Load += new System.EventHandler(this.WebRegist_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegi;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton RbFail1;
        private System.Windows.Forms.RadioButton RbFail2;
        private System.Windows.Forms.RadioButton RbFail3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}