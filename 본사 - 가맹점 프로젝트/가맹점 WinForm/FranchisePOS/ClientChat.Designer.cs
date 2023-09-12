namespace FranchisePOS
{
    partial class ClientChat
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
            this.plMessage = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.plGroup = new System.Windows.Forms.Panel();
            this.cbPersonal = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInvite = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tsslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssBar = new System.Windows.Forms.StatusStrip();
            this.plRoomAbout = new System.Windows.Forms.Panel();
            this.btnBack2 = new System.Windows.Forms.Button();
            this.btnCorS = new System.Windows.Forms.Button();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.plRoom = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRoomSearch = new System.Windows.Forms.Button();
            this.plFranInvite = new System.Windows.Forms.Panel();
            this.cbFran = new System.Windows.Forms.ComboBox();
            this.btnBack3 = new System.Windows.Forms.Button();
            this.btnInviteFran = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.plMessage.SuspendLayout();
            this.plGroup.SuspendLayout();
            this.ssBar.SuspendLayout();
            this.plRoomAbout.SuspendLayout();
            this.plRoom.SuspendLayout();
            this.plFranInvite.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMessage
            // 
            this.plMessage.BackColor = System.Drawing.Color.White;
            this.plMessage.Controls.Add(this.txtMessage);
            this.plMessage.Location = new System.Drawing.Point(15, 334);
            this.plMessage.Name = "plMessage";
            this.plMessage.Size = new System.Drawing.Size(382, 79);
            this.plMessage.TabIndex = 5;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.White;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(379, 76);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(403, 337);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 76);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "보내기";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // plGroup
            // 
            this.plGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.plGroup.Controls.Add(this.cbPersonal);
            this.plGroup.Controls.Add(this.lblTitle);
            this.plGroup.Controls.Add(this.btnInvite);
            this.plGroup.Controls.Add(this.plMessage);
            this.plGroup.Controls.Add(this.btnBack);
            this.plGroup.Controls.Add(this.btnSend);
            this.plGroup.Controls.Add(this.rtbText);
            this.plGroup.Location = new System.Drawing.Point(12, 12);
            this.plGroup.Name = "plGroup";
            this.plGroup.Size = new System.Drawing.Size(498, 422);
            this.plGroup.TabIndex = 9;
            this.plGroup.Visible = false;
            this.plGroup.VisibleChanged += new System.EventHandler(this.plGroup_VisibleChanged);
            // 
            // cbPersonal
            // 
            this.cbPersonal.AutoSize = true;
            this.cbPersonal.Location = new System.Drawing.Point(182, 25);
            this.cbPersonal.Name = "cbPersonal";
            this.cbPersonal.Size = new System.Drawing.Size(68, 16);
            this.cbPersonal.TabIndex = 16;
            this.cbPersonal.Text = "1:1 문의";
            this.cbPersonal.UseVisualStyleBackColor = true;
            this.cbPersonal.CheckedChanged += new System.EventHandler(this.cbPersonal_CheckedChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 20F);
            this.lblTitle.Location = new System.Drawing.Point(13, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(156, 27);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "채팅방 이름";
            // 
            // btnInvite
            // 
            this.btnInvite.Location = new System.Drawing.Point(269, 13);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(102, 45);
            this.btnInvite.TabIndex = 11;
            this.btnInvite.Text = "초대하기";
            this.btnInvite.UseVisualStyleBackColor = true;
            this.btnInvite.Visible = false;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(376, 13);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(102, 45);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "방 나가기";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbText
            // 
            this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rtbText.BackColor = System.Drawing.Color.White;
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.Location = new System.Drawing.Point(14, 74);
            this.rtbText.Name = "rtbText";
            this.rtbText.ReadOnly = true;
            this.rtbText.Size = new System.Drawing.Size(464, 254);
            this.rtbText.TabIndex = 10;
            this.rtbText.TabStop = false;
            this.rtbText.Text = "";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(173, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(102, 45);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "채팅방 만들기";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
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
            this.ssBar.Location = new System.Drawing.Point(0, 437);
            this.ssBar.Name = "ssBar";
            this.ssBar.Size = new System.Drawing.Size(525, 22);
            this.ssBar.TabIndex = 6;
            this.ssBar.Text = "statusStrip1";
            this.ssBar.UseWaitCursor = true;
            // 
            // plRoomAbout
            // 
            this.plRoomAbout.BackColor = System.Drawing.Color.White;
            this.plRoomAbout.Controls.Add(this.btnBack2);
            this.plRoomAbout.Controls.Add(this.btnCorS);
            this.plRoomAbout.Controls.Add(this.lbName);
            this.plRoomAbout.Controls.Add(this.txtName);
            this.plRoomAbout.Location = new System.Drawing.Point(45, 146);
            this.plRoomAbout.Name = "plRoomAbout";
            this.plRoomAbout.Size = new System.Drawing.Size(382, 208);
            this.plRoomAbout.TabIndex = 16;
            this.plRoomAbout.Visible = false;
            // 
            // btnBack2
            // 
            this.btnBack2.Location = new System.Drawing.Point(232, 128);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(102, 45);
            this.btnBack2.TabIndex = 6;
            this.btnBack2.Text = "돌아가기";
            this.btnBack2.UseVisualStyleBackColor = true;
            this.btnBack2.Click += new System.EventHandler(this.btnBack2_Click);
            // 
            // btnCorS
            // 
            this.btnCorS.Location = new System.Drawing.Point(124, 128);
            this.btnCorS.Name = "btnCorS";
            this.btnCorS.Size = new System.Drawing.Size(102, 45);
            this.btnCorS.TabIndex = 5;
            this.btnCorS.Text = "생성하기";
            this.btnCorS.UseVisualStyleBackColor = true;
            this.btnCorS.Click += new System.EventHandler(this.btnCorS_Click);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(54, 67);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(77, 12);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "채팅방 이름 :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 58);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(458, 342);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F);
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 17;
            this.label3.Text = "채팅방";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(377, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 45);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // plRoom
            // 
            this.plRoom.Controls.Add(this.flowLayoutPanel2);
            this.plRoom.Controls.Add(this.label3);
            this.plRoom.Controls.Add(this.flowLayoutPanel1);
            this.plRoom.Controls.Add(this.btnExit);
            this.plRoom.Controls.Add(this.btnCreate);
            this.plRoom.Controls.Add(this.btnRoomSearch);
            this.plRoom.Location = new System.Drawing.Point(12, 12);
            this.plRoom.Name = "plRoom";
            this.plRoom.Size = new System.Drawing.Size(498, 422);
            this.plRoom.TabIndex = 22;
            this.plRoom.VisibleChanged += new System.EventHandler(this.plRoom_VisibleChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Enabled = false;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(20, 58);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(458, 342);
            this.flowLayoutPanel2.TabIndex = 22;
            this.flowLayoutPanel2.Visible = false;
            // 
            // btnRoomSearch
            // 
            this.btnRoomSearch.Location = new System.Drawing.Point(275, 7);
            this.btnRoomSearch.Name = "btnRoomSearch";
            this.btnRoomSearch.Size = new System.Drawing.Size(102, 45);
            this.btnRoomSearch.TabIndex = 19;
            this.btnRoomSearch.Text = "채팅방 찾기";
            this.btnRoomSearch.UseVisualStyleBackColor = true;
            this.btnRoomSearch.Click += new System.EventHandler(this.btnRoomSearch_Click);
            // 
            // plFranInvite
            // 
            this.plFranInvite.BackColor = System.Drawing.Color.White;
            this.plFranInvite.Controls.Add(this.cbFran);
            this.plFranInvite.Controls.Add(this.btnBack3);
            this.plFranInvite.Controls.Add(this.btnInviteFran);
            this.plFranInvite.Controls.Add(this.label2);
            this.plFranInvite.Location = new System.Drawing.Point(45, 146);
            this.plFranInvite.Name = "plFranInvite";
            this.plFranInvite.Size = new System.Drawing.Size(382, 208);
            this.plFranInvite.TabIndex = 17;
            this.plFranInvite.Visible = false;
            // 
            // cbFran
            // 
            this.cbFran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFran.FormattingEnabled = true;
            this.cbFran.Location = new System.Drawing.Point(153, 64);
            this.cbFran.Name = "cbFran";
            this.cbFran.Size = new System.Drawing.Size(100, 20);
            this.cbFran.TabIndex = 7;
            // 
            // btnBack3
            // 
            this.btnBack3.Location = new System.Drawing.Point(232, 128);
            this.btnBack3.Name = "btnBack3";
            this.btnBack3.Size = new System.Drawing.Size(102, 45);
            this.btnBack3.TabIndex = 6;
            this.btnBack3.Text = "돌아가기";
            this.btnBack3.UseVisualStyleBackColor = true;
            this.btnBack3.Click += new System.EventHandler(this.btnBack3_Click);
            // 
            // btnInviteFran
            // 
            this.btnInviteFran.Location = new System.Drawing.Point(124, 128);
            this.btnInviteFran.Name = "btnInviteFran";
            this.btnInviteFran.Size = new System.Drawing.Size(102, 45);
            this.btnInviteFran.TabIndex = 5;
            this.btnInviteFran.Text = "초대하기";
            this.btnInviteFran.UseVisualStyleBackColor = true;
            this.btnInviteFran.Click += new System.EventHandler(this.btnInviteFran_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "가맹점 리스트 : ";
            // 
            // ClientChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 459);
            this.Controls.Add(this.plFranInvite);
            this.Controls.Add(this.plRoomAbout);
            this.Controls.Add(this.plRoom);
            this.Controls.Add(this.plGroup);
            this.Controls.Add(this.ssBar);
            this.Name = "ClientChat";
            this.Text = "ClientChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientChat_FormClosing);
            this.Load += new System.EventHandler(this.ClientChat_Load);
            this.plMessage.ResumeLayout(false);
            this.plMessage.PerformLayout();
            this.plGroup.ResumeLayout(false);
            this.plGroup.PerformLayout();
            this.ssBar.ResumeLayout(false);
            this.ssBar.PerformLayout();
            this.plRoomAbout.ResumeLayout(false);
            this.plRoomAbout.PerformLayout();
            this.plRoom.ResumeLayout(false);
            this.plRoom.PerformLayout();
            this.plFranInvite.ResumeLayout(false);
            this.plFranInvite.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel plGroup;
        private System.Windows.Forms.ToolStripStatusLabel tsslblTime;
        private System.Windows.Forms.StatusStrip ssBar;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnInvite;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel plRoomAbout;
        private System.Windows.Forms.Button btnBack2;
        private System.Windows.Forms.Button btnCorS;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel plRoom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel plFranInvite;
        private System.Windows.Forms.ComboBox cbFran;
        private System.Windows.Forms.Button btnBack3;
        private System.Windows.Forms.Button btnInviteFran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbPersonal;
        private System.Windows.Forms.Button btnRoomSearch;
    }
}