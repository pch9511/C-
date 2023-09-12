using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class ClientChat : Form
    {
        //TCP 네트워크 서비스에 대한 클라이언트 연결 제공
        private TcpClient  client;
        private NetworkStream myStream;     //네트워크 스트림
        private StreamReader myRead;        //스트림 읽기
        private StreamWriter myWrite;       //스트림 쓰기
        private Thread myReader;
        private delegate void AddTextDelegate(string strText);  //델리게이트 개체 생성
        private AddTextDelegate AddText = null;                 //델리게이트 개체 생성
        List<Button> ChatRoom = new List<Button>();
        List<int> RoomNum = new List<int>();
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string RegiNum;
        int CurrentChatRoom = -1;
        List<string> cbRegiNum = new List<string>();
        private object obj = new object();
        int Checked = 1;
        private string instruction = string.Empty;

        //04 - 26 ~ 04 - 28 
        /*---------------------------------------------------------------------
        메서드명: ClientChat 

        기능 : ClientChat 클래스의 생성자

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientChat(string regiNum)
        {
            InitializeComponent();
                Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
                Conn.Open();
                Comm = new SqlCommand();
                Comm.Connection = Conn;
                RegiNum = regiNum;
        }

        /*---------------------------------------------------------------------
        메서드명: Receive : void

        기능 : 서버에게 메시지를 받는 기능

        만든날짜: 2023-04-26

        수정날짜 : 2023-05-22 ~ 2023-06-05
        기타사항 : 추가기능을 적용하면서 여러 조건을 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Receive(TcpClient client)
        {
            NetworkStream Stream;
            Stream = client.GetStream();
            StreamReader Read = new StreamReader(Stream);
            try
            {
                while (true)
                {
                    if (Stream.CanRead)
                    {
                        var msg = Read.ReadLine();
                        string[] Smsg = msg.Split('&');
                        if (msg.Length > 0)
                        {
                            if(Smsg[1] == "서버 종료")
                            {
                                MessageBox.Show("서버가 종료되었습니다. 종료합니다.");
                                this.Close();
                            }
                            else if(Smsg[4] == "방 개설 완료")
                            {
                                lock (obj)
                                {
                                    RoomNum.Add(Convert.ToInt32(Smsg[2]));
                                }
                            }
                            else if(Smsg[4] == "방 폭파")
                            {
                                lock(obj)
                                {
                                    plGroup.Visible = false;

                                    plRoom.Visible = true;

                                    DataLoad();

                                    MessageBox.Show("호스트가 방을 나갔습니다.");
                                }
                            }
                            else if(Smsg[4] == "연결 끊음")
                            {
                                MessageBox.Show("다른곳에서 로그인됨");
                                this.Close();
                            }
                            else if(Smsg[4] == "답변")
                            {
                                this.rtbText.SelectionColor = Color.Red;
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]);
                                this.rtbText.SelectionColor = Color.Black;
                            }
                            else if(Smsg[4] == "접속 리스트")
                            {
                                string[] list = Smsg[1].Split(' ');
                                for(int i=0; i<list.Length - 1; i++)
                                {                                    
                                    cbFran.Items.Add(GetNameByRegiNum(list[i]));
                                    cbRegiNum.Add(list[i]);
                                }
                            }
                            else if(Smsg[4] == "방 나가기")
                            {

                            }
                            else
                            {
                                Invoke(AddText, Smsg[0] + " : " + Smsg[1]);
                            }
                            
                        }
                        this.tsslblTime.Text = "마지막으로 받은 시각:" + Smsg[2];
                    }
                }
            }
            catch { }
        }

        /*---------------------------------------------------------------------
        메서드명: btnClose_Click : void

        기능 : 종료 버튼 클릭 시 채팅창을 닫는 기능

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: MessageView : void

        기능 : 채팅한 기록을 띄워주는 기능

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MessageView(string strText)
        {
            this.rtbText.AppendText(strText + "\r\n");
            this.rtbText.Focus();
            this.rtbText.ScrollToCaret();
            this.txtMessage.Focus();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSend_Click : void

        기능 : 보내기 버튼 클릭 시 메시지를 보내는 기능

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSend_Click(object sender, EventArgs e)
        {
            if(this.txtMessage.Text == "")
            {
                this.txtMessage.Focus();
            }
            else
            {
                MsgSend();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: MsgSend : void

        기능 : 입력한 메시지를 서버에 보내는 기능

        만든날짜: 2023-04-27

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MsgSend()
        {
            try
            {
                if(client.Connected)
                {
                    var dt = Convert.ToString(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    myWrite.WriteLine(RegiNum + "&" +
                        this.txtMessage.Text + "&" + dt + "&" + CurrentChatRoom + "&" + instruction + "&" + Checked);
                    myWrite.Flush();
                    this.txtMessage.Clear();
                }
                else
                {
                    MessageBox.Show("연결 끊겨있음");
                }
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다.");
                this.txtMessage.Clear();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ClientChat_FormClosing : void

        기능 : 채팅창 종료 시 서버에 전달 및 스레드 등을 종료시키는 함수 작동

        만든날짜: 2023-04-27

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            instruction = "연결 끊음";
            MsgSend();
            ServerStop();
            instruction = "";
        }

        /*---------------------------------------------------------------------
        메서드명: ServerStop : void

        기능 : Tcp 관련 기능 및 스레드 중지 기능

        만든날짜: 2023-04-27

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerStop()
        {
            if (myStream != null)
            {
                myStream.Close();
            }
            if (myRead != null)
            {
                myRead.Close();
            }
            if (myWrite != null)
            {
                myWrite.Close();
            }
            if( myReader != null)
            {
                myReader.Abort();
            }

        }

        /*---------------------------------------------------------------------
        메서드명: txtMessage_KeyPress : void

        기능 : 엔터키 클릭시 메시지 보내는 기능을 작동

        만든날짜: 2023-04-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                e.Handled = true;
                if(this.txtMessage.Text == "")
                {
                    this.txtMessage.Focus();
                }
                else
                {
                    MsgSend();
                }
            }
        }

        //2023-05-19
        /*---------------------------------------------------------------------
        메서드명: button1_Click : void

        기능 : 방을 나가는 기능

        만든날짜: 2023-05-19

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            cbPersonal.Checked = false;
            Checked = 1;
            instruction = "방 나가기";
            MsgSend();
            txtMessage.Text = "";
            instruction = "";
            plGroup.Visible = false;

            plRoom.Visible = true;
            rtbText.Clear();
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: button1_Click : void

        기능 : 방을 나가는 기능

        만든날짜: 2023-05-19

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/   
        private void btn_ChatClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            for(int i=0; i<ChatRoom.Count; i++)
            {
                if(ChatRoom[0] == btn)
                {
                    lblTitle.Text = ChatRoom[0].Text;
                    CurrentChatRoom = -1;
                    break;
                }
                if(ChatRoom[i] == btn)
                {
                    lblTitle.Text = ChatRoom[i].Text;
                    CurrentChatRoom = RoomNum[i - 1];                
                    break;
                }
            }

            instruction = "방 입장";
            MsgSend();
            plGroup.Visible = true;

            plRoom.Visible = false;
            instruction = "";
        }

        /*---------------------------------------------------------------------
        메서드명: ClientChat_Load : void

        기능 : 채팅창 로드시 작동하는 기능

        만든날짜: 2023-05-19

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientChat_Load(object sender, EventArgs e)
        {
            DataLoad();
            ServerConnect();
        }

        /*---------------------------------------------------------------------
        메서드명: ServerConnect : void

        기능 : 서버에 접속하는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerConnect()
        {
            AddText = new AddTextDelegate(MessageView);
            try
            {
                client = new TcpClient("127.0.0.1", 62000);
                Invoke(AddText, "서버에 접속 했습니다.");


                myStream = client.GetStream();
                this.txtMessage.Focus();

                myRead = new StreamReader(myStream);
                myWrite = new StreamWriter(myStream);

                myWrite.WriteLine(RegiNum + "& &" + DateTime.Now);
                myWrite.Flush();

                myReader = new Thread(() => Receive(client));
                myReader.IsBackground = true;
                myReader.Start();

            }
            catch
            {
                MessageBox.Show("서버에 연결할 수 없습니다.", "Error");
                this.Close();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 채팅방 DB에 저장되어 있는 방을 불러와 화면에 나타내는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {

            ChatRoom.Clear();

            flowLayoutPanel1.Controls.Clear();

            ChatRoom.Add(new Button());
            ChatRoom[ChatRoom.Count - 1].Text = "메인채팅방";
            ChatRoom[ChatRoom.Count - 1].Click += new EventHandler(btn_ChatClick);
            ChatRoom[ChatRoom.Count - 1].Width = 430;
            ChatRoom[ChatRoom.Count - 1].Height = 50;
            flowLayoutPanel1.Controls.Add(ChatRoom[ChatRoom.Count - 1]);

            Comm.CommandText = "Select [Num],[Name],[Chatter] From ChatRoom";

            var myRead = Comm.ExecuteReader();           
            
            RoomNum.Clear();

            flowLayoutPanel1.Controls.Add(ChatRoom[0]);

            while (myRead.Read())
            {
                string[] chatter = myRead[2].ToString().Split(' ');

                foreach(string Chatter in chatter)
                {
                    if(Chatter == RegiNum)
                    {
                        ChatRoom.Add(new Button());
                        RoomNum.Add(Convert.ToInt32(myRead[0].ToString()));
                        ChatRoom[ChatRoom.Count - 1].Text = myRead[1].ToString();
                        ChatRoom[ChatRoom.Count - 1].Click += new EventHandler(btn_ChatClick);
                        ChatRoom[ChatRoom.Count - 1].Width = 430;
                        ChatRoom[ChatRoom.Count - 1].Height = 50;
                        flowLayoutPanel1.Controls.Add(ChatRoom[ChatRoom.Count - 1]);
                        break;
                    }
                }                                             
            }
            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 종료 버튼 클릭 시 채팅방을 나가는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
         메서드명: btnCreate_Click : void

         기능 : 채팅방 만들기 클릭시 방 생성 패널을 띄우는 기능

         만든날짜: 2023-05-22

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnCreate_Click(object sender, EventArgs e)
        {
            plRoom.Enabled = false;

            plRoomAbout.Visible = true;
            plRoomAbout.Enabled = true;
            btnCorS.Text = "생성";
        }

        /*---------------------------------------------------------------------
         메서드명: btnCreate_Click : void

         기능 : 채팅방 만들기 클릭시 방 생성 패널을 띄우는 기능

         만든날짜: 2023-05-23

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnRoomSearch_Click(object sender, EventArgs e)
        {
            switch(btnRoomSearch.Text)
            {
                case "채팅방 찾기":
                    plRoom.Enabled = false;

                    plRoomAbout.Visible = true;
                    plRoomAbout.Enabled = true;
                    btnCorS.Text = "찾기";
                    break;
                case "전체 목록 보기":
                    DataLoad();
                    btnRoomSearch.Text = "채팅방 찾기";
                    break;
                default:
                    return;
            }
        }

        /*---------------------------------------------------------------------
         메서드명: btnCorS_Click : void

         기능 : 특정 상황에 맞게 방을 생성하는 버튼 혹은 방을 찾는 버튼으로 작동
                하는 기능

         만든날짜: 2023-05-23

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnCorS_Click(object sender, EventArgs e)
        {

            switch (btnCorS.Text)
            {
                case "생성":
                    txtMessage.Text = txtName.Text;
                    instruction = "방 개설";
                    MsgSend();
                    CreateRoom();
                    plRoomAbout.Visible = false;
                    btnInvite.Visible = true;

                    plRoom.Enabled = true;
                    txtMessage.Text = "";
                    instruction = "";
                    break;

                case "찾기":
                    plRoomAbout.Visible = false;
                    plRoomAbout.Enabled = false;

                    SearchRoom();
                    btnRoomSearch.Text = "전체 목록 보기";
                    plRoom.Enabled = true;
                    break;

                default:
                    return;
            }

            //개설자 및 
            //myWrite.WriteLine(RegiNum + "&" + "방 개설&" + name);
            //myWrite.Flush();
        }

        /*---------------------------------------------------------------------
         메서드명: SearchRoom : void

         기능 : 검색한 방을 보여주는 기능

         만든날짜: 2023-05-24

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void SearchRoom()
        {
            flowLayoutPanel1.Controls.Clear();

            for(int i=0; i<ChatRoom.Count; i++)
            {
                if(ChatRoom[i].Text == txtName.Text)
                {
                    flowLayoutPanel1.Controls.Add(ChatRoom[i]);
                }
            }
        }

        /*---------------------------------------------------------------------
         메서드명: btnBack2_Click : void

         기능 : 해당 버튼 클릭 시 채팅방 리스트 패널을 보여줌

         만든날짜: 2023-05-24

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnBack2_Click(object sender, EventArgs e)
        {
            plRoomAbout.Visible = false;
            plRoom.Enabled = true;
        }

        /*---------------------------------------------------------------------
         메서드명: btnInvite_Click : void

         기능 : 초대 버튼 클릭 시 초대 관련 패널을 띄우고 콤보박스에 
                초대 가능한 리스트를 불러오는 기능

         만든날짜: 2023-05-24

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnInvite_Click(object sender, EventArgs e)
        {
            plFranInvite.Visible = true;
            plFranInvite.Enabled = true;

            instruction = "접속 리스트";            
            MsgSend();
            instruction = "";
        }

        /*---------------------------------------------------------------------
         메서드명: plGroup_VisibleChanged : void

         기능 : 패널 Visible에 따라 작동하는 기능

         만든날짜: 2023-05-25

         수정날짜 : 2023-06-02
         기타사항 : 채팅 로그를 채팅창에 띄우는 용도였지만 일회성 채팅방이므로 
                    필요 없어짐
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void plGroup_VisibleChanged(object sender, EventArgs e)
        {
            /*if(plGroup.Visible == true)
            {
                Comm.CommandText = "Select [Id],[Content] From [ChatLog] Where [Num] = " + CurrentChatRoom + " Order By [Date] Asc";

                var myRead = Comm.ExecuteReader();

                while(myRead.Read())
                {
                    MessageView(myRead[0].ToString() + ": " + myRead[1].ToString());
                }

                myRead.Close();
            }*/
        }

        /*---------------------------------------------------------------------
         메서드명: CreateRoom : void

         기능 : 채팅방 생성 시 채팅방(버튼)을 만들고 보이게 하는 기능

         만든날짜: 2023-05-29

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void CreateRoom()
        {
            ChatRoom.Add(new Button());
            ChatRoom[ChatRoom.Count - 1].Text = txtName.Text;
            ChatRoom[ChatRoom.Count - 1].Click += new EventHandler(btn_ChatClick);
            ChatRoom[ChatRoom.Count - 1].Width = 430;
            ChatRoom[ChatRoom.Count - 1].Height = 50;
            flowLayoutPanel1.Controls.Add(ChatRoom[ChatRoom.Count - 1]);
        }

        /*---------------------------------------------------------------------
         메서드명: btnBack3_Click : void

         기능 : 이전 패널로 돌아가는 기능

         만든날짜: 2023-05-29

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnBack3_Click(object sender, EventArgs e)
        {
            plFranInvite.Visible = false;
            plFranInvite.Enabled = false;
        }

        /*---------------------------------------------------------------------
         메서드명: btnInviteFran_Click : void

         기능 : 해당 방에 선택한 가맹점을 초대하는 기능

         만든날짜: 2023-05-29

         수정날짜 : 2023-06-02 ~ 2023-06-05
         기타사항 : 서버에서 방 초대를 진행
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnInviteFran_Click(object sender, EventArgs e)
        {
            plFranInvite.Visible = false;
            plFranInvite.Enabled = false;

            myWrite.WriteLine(cbRegiNum[cbFran.SelectedIndex] + "&방 초대&" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "&" + CurrentChatRoom + "&" + lblTitle.Text);
            myWrite.Flush();
        }

        /*---------------------------------------------------------------------
         메서드명: GetNameByRegiNum : string

         기능 : 가맹점명을 받아오는 기능

         만든날짜: 2023-05-30

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private string GetNameByRegiNum(string regiNum)
        {
            string Name = string.Empty;

            Comm.CommandText = "Select [Name] From [FranchiseInfo] Where [RegistrationNumber] = '" + RegiNum + "'";

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                Name = myRead[0].ToString();
            }

            myRead.Close();

            return Name;
        }


        /*---------------------------------------------------------------------
         메서드명: cbPersonal_CheckedChanged : string

         기능 : 1:1문의 여부를 확인하는 기능

         만든날짜: 2023-06-01

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void cbPersonal_CheckedChanged(object sender, EventArgs e)
        { 
            if (cbPersonal.Checked)
            {
                Checked = 0;
            }
            else
            {
                Checked = 1;
            }
        }

        private void plRoom_VisibleChanged(object sender, EventArgs e)
        {
            if(plRoom.Visible == true)
            {
                DataLoad();
            }
        }
    }
}
