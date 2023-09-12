namespace FranchisePOS
{
    partial class PaySelect
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
            this.btnCredit = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCredit
            // 
            this.btnCredit.Font = new System.Drawing.Font("굴림", 45F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCredit.ForeColor = System.Drawing.Color.Black;
            this.btnCredit.Location = new System.Drawing.Point(32, 12);
            this.btnCredit.Name = "btnCredit";
            this.btnCredit.Size = new System.Drawing.Size(205, 177);
            this.btnCredit.TabIndex = 0;
            this.btnCredit.Text = "현금";
            this.btnCredit.UseVisualStyleBackColor = true;
            this.btnCredit.Click += new System.EventHandler(this.btnCredit_Click);
            // 
            // btnCard
            // 
            this.btnCard.Font = new System.Drawing.Font("굴림", 45F);
            this.btnCard.ForeColor = System.Drawing.Color.Red;
            this.btnCard.Location = new System.Drawing.Point(266, 12);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(205, 177);
            this.btnCard.TabIndex = 1;
            this.btnCard.Text = "카드";
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // PaySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 204);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.btnCredit);
            this.Name = "PaySelect";
            this.Text = "PaySelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCredit;
        private System.Windows.Forms.Button btnCard;
    }
}