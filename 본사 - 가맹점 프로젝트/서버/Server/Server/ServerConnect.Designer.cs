namespace Server
{
    partial class ServerConnect
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
            this.plMessage = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.plGroup = new System.Windows.Forms.Panel();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.tsslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssBar = new System.Windows.Forms.StatusStrip();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAnswerDel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.QuestionListView = new System.Windows.Forms.ListView();
            this.cck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Content = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.AnswerListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.plMessage.SuspendLayout();
            this.plGroup.SuspendLayout();
            this.ssBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMessage
            // 
            this.plMessage.BackColor = System.Drawing.Color.White;
            this.plMessage.Controls.Add(this.txtMessage);
            this.plMessage.Location = new System.Drawing.Point(10, 7);
            this.plMessage.Name = "plMessage";
            this.plMessage.Size = new System.Drawing.Size(354, 81);
            this.plMessage.TabIndex = 5;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(348, 75);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(380, 18);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 56);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // plGroup
            // 
            this.plGroup.BackColor = System.Drawing.Color.RoyalBlue;
            this.plGroup.Controls.Add(this.plMessage);
            this.plGroup.Controls.Add(this.btnSend);
            this.plGroup.Location = new System.Drawing.Point(7, 350);
            this.plGroup.Name = "plGroup";
            this.plGroup.Size = new System.Drawing.Size(467, 98);
            this.plGroup.TabIndex = 9;
            // 
            // rtbText
            // 
            this.rtbText.BackColor = System.Drawing.Color.White;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Location = new System.Drawing.Point(5, 52);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(469, 299);
            this.rtbText.TabIndex = 7;
            this.rtbText.TabStop = false;
            this.rtbText.Text = "";
            // 
            // tsslblTime
            // 
            this.tsslblTime.Name = "tsslblTime";
            this.tsslblTime.Size = new System.Drawing.Size(127, 17);
            this.tsslblTime.Text = "메시지 받은 시간 출력";
            // 
            // ssBar
            // 
            this.ssBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblTime});
            this.ssBar.Location = new System.Drawing.Point(0, 474);
            this.ssBar.Name = "ssBar";
            this.ssBar.Size = new System.Drawing.Size(1458, 22);
            this.ssBar.TabIndex = 6;
            this.ssBar.Text = "statusStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(155, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(158, 43);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "서버 시작";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(319, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(158, 43);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "서버 종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAnswerDel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.QuestionListView);
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.btnAnswer);
            this.groupBox1.Controls.Add(this.AnswerListView);
            this.groupBox1.Location = new System.Drawing.Point(485, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 459);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "문의 응답";
            // 
            // btnAnswerDel
            // 
            this.btnAnswerDel.Location = new System.Drawing.Point(822, 12);
            this.btnAnswerDel.Name = "btnAnswerDel";
            this.btnAnswerDel.Size = new System.Drawing.Size(133, 33);
            this.btnAnswerDel.TabIndex = 95;
            this.btnAnswerDel.Text = "선택한 답변 삭제";
            this.btnAnswerDel.UseVisualStyleBackColor = true;
            this.btnAnswerDel.Click += new System.EventHandler(this.btnAnswerDel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 94;
            this.label2.Text = "현재 문의";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "이전 답변";
            // 
            // QuestionListView
            // 
            this.QuestionListView.BackColor = System.Drawing.SystemColors.Window;
            this.QuestionListView.CheckBoxes = true;
            this.QuestionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cck,
            this.No,
            this.Id,
            this.Content});
            this.QuestionListView.FullRowSelect = true;
            this.QuestionListView.HideSelection = false;
            this.QuestionListView.Location = new System.Drawing.Point(16, 45);
            this.QuestionListView.Name = "QuestionListView";
            this.QuestionListView.OwnerDraw = true;
            this.QuestionListView.Size = new System.Drawing.Size(452, 408);
            this.QuestionListView.TabIndex = 87;
            this.QuestionListView.UseCompatibleStateImageBehavior = false;
            this.QuestionListView.View = System.Windows.Forms.View.Details;
            this.QuestionListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.QuestionListView_ColumnClick);
            this.QuestionListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.QuestionListView_DrawColumnHeader);
            this.QuestionListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.QuestionListView_DrawItem);
            this.QuestionListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.QuestionListView_DrawSubItem);
            this.QuestionListView.SelectedIndexChanged += new System.EventHandler(this.QuestionListView_SelectedIndexChanged);
            // 
            // cck
            // 
            this.cck.Text = "";
            this.cck.Width = 30;
            // 
            // No
            // 
            this.No.Text = "RegiNum";
            this.No.Width = 100;
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 80;
            // 
            // Content
            // 
            this.Content.Text = "Content";
            this.Content.Width = 230;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(483, 379);
            this.txtAnswer.Multiline = true;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(340, 76);
            this.txtAnswer.TabIndex = 91;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(822, 378);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(133, 77);
            this.btnAnswer.TabIndex = 90;
            this.btnAnswer.Text = "답변";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // AnswerListView
            // 
            this.AnswerListView.BackColor = System.Drawing.SystemColors.Window;
            this.AnswerListView.CheckBoxes = true;
            this.AnswerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.AnswerListView.FullRowSelect = true;
            this.AnswerListView.HideSelection = false;
            this.AnswerListView.Location = new System.Drawing.Point(489, 45);
            this.AnswerListView.Name = "AnswerListView";
            this.AnswerListView.OwnerDraw = true;
            this.AnswerListView.Size = new System.Drawing.Size(472, 316);
            this.AnswerListView.TabIndex = 92;
            this.AnswerListView.UseCompatibleStateImageBehavior = false;
            this.AnswerListView.View = System.Windows.Forms.View.Details;
            this.AnswerListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AnswerListView_ColumnClick);
            this.AnswerListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.AnswerListView_DrawColumnHeader);
            this.AnswerListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.AnswerListView_DrawItem);
            this.AnswerListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.AnswerListView_DrawSubItem);
            this.AnswerListView.SelectedIndexChanged += new System.EventHandler(this.AnswerListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "질문";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "답변 내용";
            this.columnHeader3.Width = 230;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F);
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 27);
            this.label3.TabIndex = 15;
            this.label3.Text = "채팅 서버";
            // 
            // ServerConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 496);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.plGroup);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.ssBar);
            this.Name = "ServerConnect";
            this.Text = "서버 연결";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConnect_FormClosing);
            this.Load += new System.EventHandler(this.ServerConnect_Load);
            this.plMessage.ResumeLayout(false);
            this.plMessage.PerformLayout();
            this.plGroup.ResumeLayout(false);
            this.ssBar.ResumeLayout(false);
            this.ssBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel plGroup;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTime;
        private System.Windows.Forms.StatusStrip ssBar;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView QuestionListView;
        private System.Windows.Forms.ColumnHeader cck;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Content;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.ListView AnswerListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAnswerDel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

