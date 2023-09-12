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


namespace Server
{
    public partial class ServerConnect : Form
    {
        private TcpListener Server;         //TCP 네트워크 클라이언트에서 연결 수신
        //TCP 네트워크 서비스에 대한 클라이언트 연결 제공
        //private List<TcpClient> SerClient = new List<TcpClient>();
        private NetworkStream myStream;     //네트워크 스트림
        private StreamReader myRead;        //스트림 읽기
        private StreamWriter myWrite;       //스트림 쓰기
        private Boolean Start = false;      //서버 시작
        //private Boolean ClientCon = false;  //클라이언트 시작
        private int myPort;                 //포트
        private string myName;              //별칭
        private Thread myServer;  //스레드
        private Thread myReader;
        private List<Thread> myRoom = new List<Thread>();
        //private Boolean TextChange = false; //입력 컨트롤의 데이터 입력 체크
        //private RegistryKey key = Registry.LocalMachine.OpenSubKey(
        //"SOFTWARE\\Microsoft\\.NETFramework", true);    //레지스트리 쓰기,읽기
        private delegate void AddTextDelegate(string strText,string Color);  //델리게이트 개체 생성
        private AddTextDelegate AddText = null;                 //델리게이트 개체 생성
        private SqlConnection Conn;
        private SqlCommand Comm;
        private object obj = new object();
        private object obj2 = new object();
        private object obj3 = new object();
        private int RoomNum = 0;
        private List<Client> clients = new List<Client>();


        // 04-26 ~ 04-28

        /*---------------------------------------------------------------------
        메서드명: ServerConnect

        기능 : 서버 클래스의 생성자

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ServerConnect()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: ServerConnect_FormClosing : void

        기능 : 서버 창 종료 시 종료관련 함수 작동

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteChatRoom();
            ServerStop();
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: MessageView : void

        기능 : 채팅창에 채팅 기록을 띄워주는 기능

        만든날짜: 2023-04-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MessageView(string strText,string color)
        {
            if (color == "0")
            {
                this.rtbText.SelectionColor = Color.Red;
            }
            else
            {
                this.rtbText.SelectionColor = Color.Black;
            }
            this.rtbText.AppendText(strText + "\r\n");
            this.rtbText.Focus();
            this.rtbText.ScrollToCaret();
            this.txtMessage.Focus();
        }

        /*---------------------------------------------------------------------
        메서드명: ServerStart : void

        기능 : 서버를 실행하여 클라이언트의 접속을 받는 기능

        만든날짜: 2023-04-26

        수정날짜 : 2023-05-22 ~ 2023-06-05
        기타사항 : 여러 방 개설을 위해 클라이언트의 정보를 클래스로 담고
                   다중스레드를 돌리다보니 지역변수 외에는 lock으로 제어
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerStart()
        {
            int cnt = 0;
            Invoke(AddText, "서버 실행","1");
            while (Start)
            {
                try
                {
                    lock (obj)
                    {

                        clients.Add(new Client { SerClient = Server.AcceptTcpClient(), RoomNum = -2, Main = true, Room = false });
                        cnt = clients.Count - 1;

                        myStream = clients[cnt].SerClient.GetStream();
                        myRead = new StreamReader(myStream);

                        if (myStream.CanRead)
                        {
                            var msg = myRead.ReadLine();
                            string[] Smsg = msg.Split('&');
                            if (msg.Length > 0)
                            {
                                for (int i = 0; i < cnt; i++)
                                {
                                    if (clients[i].RegiNum == Smsg[0])
                                    {
                                        foreach (Client cli in clients)
                                        {
                                            if (cli.SerClient == clients[i].SerClient)
                                            {
                                                NetworkStream stream = cli.SerClient.GetStream();
                                                StreamWriter mywrite = new StreamWriter(stream);
                                                mywrite.WriteLine(cli.RegiNum + "& & & &연결 끊음");
                                                mywrite.Flush();
                                            }
                                        }
                                        clients.RemoveAt(i);
                                        cnt = clients.Count - 1;
                                        break;
                                    }
                                }
                                clients[cnt].RegiNum = Smsg[0];

                                Invoke(AddText, GetNameByRegiNum(Smsg[0]) + " 님이 입장하셨습니다.", "1");
                            }
                        }
                    }
                    myReader = new Thread(() => Run(clients[cnt]));
                    myReader.IsBackground = true;
                    myReader.Start();          
                }
                catch
                {
                }

            }
        }

        /*---------------------------------------------------------------------
        메서드명: Run : void

        기능 : 클라이언트의 메시지를 받아 관련 기능을 작동시키는 함수 

        만든날짜: 2023-04-27

        수정날짜 : 2023-05-22 ~ 2023-06-05
        기타사항 : 여러개의 방을 개설 및 1:1문의(귓속말) 기능 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Run(Client client)
        {
            try
            {                
                NetworkStream Stream;
                Stream = client.SerClient.GetStream();             
                StreamReader Read = new StreamReader(Stream);
                StreamWriter myWrite = new StreamWriter(Stream);

                while (true)
                {
                    if (Stream.CanRead)
                    {
                        var msg = Read.ReadLine();
                        string[] Smsg = msg.Split('&');
                        if (msg.Length > 0)
                        {
                            if (Smsg[4] == "방 초대")
                            {
                                lock (obj3)
                                {
                                    ChatterAdd(Smsg[0], Smsg[3]);
                                    foreach (Client cli in clients)
                                    {
                                        if (cli.RoomNum == Convert.ToInt32(Smsg[3]))
                                        {
                                            NetworkStream stream = cli.SerClient.GetStream();
                                            StreamWriter mywrite = new StreamWriter(stream);
                                            mywrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&" + Smsg[3]);
                                            mywrite.Flush();
                                        }

                                    }
                                    Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                                }
                            }
                            else if (Smsg[4] == "방 개설")
                            {
                                lock (obj3)
                                {
                                    StreamWriter mywrite = new StreamWriter(Stream);
                                    client.RoomNum = RoomNum;
                                    RoomNum++;
                                    mywrite.WriteLine(Smsg[0] + "&" + "방 개설 완료&" + client.RoomNum + "&" + Smsg[3] + "&방 개설 완료");
                                    mywrite.Flush();
                                    CreateRoom(Smsg[0], Smsg[1], client.RoomNum);

                                    myRoom.Add(new Thread(() => RoomChat(client)));
                                }
                                Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                            }
                            else if (Smsg[4] == "방 입장")
                            {
                                lock (obj3)
                                {
                                    StreamWriter mywrite = new StreamWriter(Stream);
                                    client.RoomNum = Convert.ToInt32(Smsg[3]);
                                    Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");

                                    if (client.RoomNum != -1)
                                    {
                                        client.Main = false;
                                        client.Room = true;
                                        myRoom[client.RoomNum].IsBackground = true;
                                        myRoom[client.RoomNum].Start();
                                        myRoom[client.RoomNum].Join();
                                    }
                                }
                            }
                            else if (Smsg[4] == "연결 끊음")
                            {
                                lock (obj3)
                                {
                                    for (int i = 0; i < clients.Count; i++)
                                    {
                                        if (clients[i].RegiNum == Smsg[0])
                                        {
                                            Invoke(AddText, clients[i].RegiNum + "님이 나가셨습니다.", "1");
                                            clients.RemoveAt(i);
                                        }
                                    }

                                }
                                Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                            }
                            else
                            {
                                lock (obj3)
                                {
                                    if (Smsg[5] == "0")
                                    {
                                        Invoke(AddText, Smsg[0] + "의 문의 : " + Smsg[1], "0");
                                        QuestionListView.Items.Add(new ListViewItem(new string[] { "", Smsg[0], GetNameByRegiNum(Smsg[0]), Smsg[1] }));
                                        myWrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&/Answer");
                                        myWrite.Flush();
                                    }
                                    else
                                    {
                                        foreach (Client cli in clients)
                                        {
                                            if (cli.RoomNum == Convert.ToInt32(Smsg[3]))
                                            {
                                                NetworkStream stream = cli.SerClient.GetStream();
                                                StreamWriter mywrite = new StreamWriter(stream);
                                                mywrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&" + Smsg[3] + "&" + Smsg[4]);
                                                mywrite.Flush();
                                            }
                                        }
                                    }
                                    Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                                }
                            }
                        }
                        this.tsslblTime.Text = "마지막으로 받은 시각:" + Smsg[2];
                    }
                }               
            }
            catch
            { }
        }

        /*---------------------------------------------------------------------
        메서드명: RoomChat : void

        기능 : 클라이언트가 만든 채팅방에 들어왔을때 작동하는 스레드함수

        만든날짜: 2023-05-28

        수정날짜 : 2023-05-28 ~ 2023-06-05
        기타사항 : 1:1문의(귓속말) 기능 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void RoomChat(Client client)
        {
            try
            {
                NetworkStream Stream;
                Stream = client.SerClient.GetStream();
                StreamReader Read = new StreamReader(Stream);
                StreamWriter myWrite = new StreamWriter(Stream);

                while (client.Room)
                {
                    if (Stream.CanRead)
                    {
                        var msg = Read.ReadLine();
                        string[] Smsg = msg.Split('&');
                        if (msg.Length > 0)
                        {
                            if (Smsg[4] == "방 나가기")
                            {
                                lock (obj2)
                                {
                                    if (IsHost(client.RegiNum, Smsg[3]))
                                    {
                                        foreach (Client cli in clients)
                                        {
                                            if (cli.RoomNum == client.RoomNum && client != cli)
                                            {
                                                NetworkStream stream = cli.SerClient.GetStream();
                                                StreamWriter mywrite = new StreamWriter(stream);
                                                mywrite.WriteLine(Smsg[0] + "&" + "방을 나갔습니다." + "&" + Smsg[2] + "&" + Smsg[3] + "&방 폭파");
                                                mywrite.Flush();
                                            }
                                        }
                                        ExitRoom(Smsg[3]);
                                        Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                                    }
                                    else
                                    {
                                        foreach (Client cli in clients)
                                        {
                                            if (cli.RoomNum == client.RoomNum && client != cli)
                                            {
                                                NetworkStream stream = cli.SerClient.GetStream();
                                                StreamWriter mywrite = new StreamWriter(stream);
                                                mywrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&" + Smsg[3]);
                                                mywrite.Flush();
                                            }
                                        }
                                        Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                                    }
                                    client.Room = false;
                                    client.Main = true;
                                }                      
                            }
                            else if (Smsg[4] == "접속 리스트")
                            {
                                lock (obj2)
                                {
                                    string[] allList = InviteList(Smsg[3]).Split(' ');
                                    string list = string.Empty;
                                    foreach (Client cli in clients)
                                    {
                                        for (int i = 0; i < allList.Length - 1; i++)
                                        {
                                            if (cli.RegiNum != allList[i])
                                            {
                                                list += cli.RegiNum + " ";
                                            }
                                        }
                                    }
                                    myWrite.WriteLine(Smsg[0] + "&" + list + "&" + DateTime.Now + "&" + Smsg[3] + "&접속 리스트");
                                    myWrite.Flush();
                                }
                                Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                            }
                            else
                            {
                                lock (obj2)
                                {
                                    if (Smsg[5] == "0")
                                    {
                                        Invoke(AddText, Smsg[0] + "의 문의 : " + Smsg[1], "0");
                                        QuestionListView.Items.Add(new ListViewItem(new string[] { "", Smsg[0], GetNameByRegiNum(Smsg[0]), Smsg[1] }));
                                        myWrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&" + Smsg[3] + "&답변");
                                        myWrite.Flush();
                                    }
                                    else
                                    {
                                        foreach (Client cli in clients)
                                        {
                                            if (cli.RoomNum == client.RoomNum)
                                            {
                                                NetworkStream stream = cli.SerClient.GetStream();
                                                StreamWriter mywrite = new StreamWriter(stream);
                                                mywrite.WriteLine(Smsg[0] + "&" + Smsg[1] + "&" + Smsg[2] + "&" + Smsg[3] + "&" + Smsg[4]);
                                                mywrite.Flush();
                                            }
                                        }
                                    }
                                }
                                Invoke(AddText, Smsg[0] + "," + Smsg[1] + "," + Smsg[2] + "," + Smsg[3] + "," + Smsg[4] + ",", "1");
                            }
                        }
                        this.tsslblTime.Text = "마지막으로 받은 시각:" + Smsg[2];
                    }
                }
                
            }
            catch
            { }
        }

        private string InviteList(string RoomNum)
        {
            string list = string.Empty;
            Comm.CommandText = "Select [Chatter] From [ChatRoom] Where [Num] = '" + RoomNum + "'";

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                list = myRead[0].ToString();
            }

            myRead.Close();

            return list;
        }

        /*---------------------------------------------------------------------
        메서드명: ServerStop : void

        기능 : 채팅창 종료 시 서버 및 스레드 기능을 중단

        만든날짜: 2023-04-28

        수정날짜 : 2023-05-28 ~ 2023-06-05
        기타사항 : 변수 변화에 맞춰서 중단할 기능 추가 및 수정
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerStop()
        {
            this.Start = false;

            if(myStream != null)
            {
                myStream.Close();
            }
            if (myRead != null)
            {
                myRead.Close();
            }
            if(myWrite != null)
            {
                myWrite.Close();
            }
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].SerClient != null)
                {
                    clients[i].SerClient.Close();
                }
            }
            if (Server != null)
            {
                Server.Stop();
            }
            if (myServer != null)
            {
                myServer.Abort();
            }
            if(myReader != null)
            {
                myReader.Abort();
            }
            foreach(Thread a in myRoom)
            {
                a.Abort();
            }
        }


        //2023 -05 -22 추가사항
        /*---------------------------------------------------------------------
        메서드명: ChatterAdd : void

        기능 : 채팅방 정보를 DB에 담는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ChatterAdd(string Chatter, string Num)
        {
            Comm.CommandText = "Update [ChatRoom] Set [Chatter] += '" + Chatter + " ' Where Num = " + Num;

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: GetNameByRegiNum : string

        기능 : 가맹점 이름을 받아오는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string GetNameByRegiNum(string RegiNum)
        {
            string Name = string.Empty;

            Comm.CommandText = "Select [Name] From [FranchiseInfo] Where [RegistrationNumber] = '" + RegiNum + "'";

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                Name = myRead[0].ToString();
            }

            myRead.Close();

            return Name;
        }

        /*---------------------------------------------------------------------
        메서드명: btnSend_Click : void

        기능 : 메시지를 전송하는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txtMessage.Text == "")
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

        기능 : 메시지를 클라이언트에게 보내는 기능

        만든날짜: 2023-05-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MsgSend()
        {
            try
            {
                foreach (Client cli in clients)
                {
                    NetworkStream stream = cli.SerClient.GetStream();
                    myWrite = new StreamWriter(stream);
                    var dt = Convert.ToString(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                    myWrite.WriteLine(myName + "&" +
                        this.txtMessage.Text + "&" + dt);
                    myWrite.Flush();
                    MessageView("Admin : " + this.txtMessage.Text,"1");
                    if (this.txtMessage.Text != "서버 종료")
                    {
                        this.txtMessage.Clear();
                    }

                }
            }
            catch
            {
                Invoke(AddText, "데이터를 보내는 동안 오류가 발생하였습니다.","1");
                this.txtMessage.Clear();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: CreateRoom : void

        기능 : 방 정보를 DB에 담는 기능

        만든날짜: 2023-05-23

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void CreateRoom(string RegiNum,string name,int RoomNum)
        {
            Comm.CommandText = "Insert Into ChatRoom Values('" + 
                RoomNum + "','" + name + "','" + RegiNum + " ', GetDate())";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: DeleteChatRoom : void

        기능 : 모든 방 정보를 DB에서 제거하는 기능

        만든날짜: 2023-05-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DeleteChatRoom()
        {
            Comm.CommandText = "Delete From ChatRoom";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: IsHost : void

        기능 : 방의 호스트를 찾는 기능

        만든날짜: 2023-05-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool IsHost(string RegiNum,string RoomNum)
        {
            string Chatter = string.Empty;
            Comm.CommandText = "Select [Chatter] From ChatRoom Where [Num] = '" + RoomNum + "'";

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                Chatter = myRead[0].ToString();
            }

            myRead.Close();

            string[] Host = Chatter.Split(' ');

            if(Host[0] == RegiNum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ExitRoom : void

        기능 : 특정 방 정보를 DB에서 제거하는 기능

        만든날짜: 2023-05-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ExitRoom(string RoomNum)
        {
            Comm.CommandText = "Delete From ChatRoom Where [Num] = '" + RoomNum + "'";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: btnConnect_Click : void

        기능 : 서버 시작 클릭 시 서버 생성하는 기능

        만든날짜: 2023-05-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnConnect_Click(object sender, EventArgs e)
        {
            AddText = new AddTextDelegate(MessageView);
            var addr = new IPAddress(0);

            this.myName = "Admin";
            this.myPort = 62000;

            if (!(this.Start))
            {
                try
                {
                    Server = new TcpListener(addr, this.myPort);
                    Server.Start();

                    this.Start = true;
                    this.txtMessage.Enabled = true;
                    this.btnSend.Enabled = true;
                    this.txtMessage.Focus();


                    myServer = new Thread(ServerStart);
                    myServer.Start();
                }
                catch
                {
                    Invoke(AddText, "서버를 실행할 수 없습니다.","1");
                }
            }          
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 서버 종료 버튼 클릭 시 채팅창 종료 

        만든날짜: 2023-05-25

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("서버를 정말로 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtMessage.Text = "서버 종료";
                MsgSend();

                this.Close();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSave_Click : void

        기능 : 서버 종료 버튼 클릭 시 채팅창 종료 

        만든날짜: 2023-05-25

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] lines = rtbText.Text.Split('\n');
            foreach(string msg in lines)
            {
                MessageBox.Show(msg);
                if(msg.Contains("문의"))
                {                  
                    MessageBox.Show("문의 관련 내용을 DB에 저장합니다.");
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: txtMessage_KeyPress : void

        기능 : 엔터키 입력 시 메시지 전송하는 기능

        만든날짜: 2023-05-26

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (this.txtMessage.Text == "")
                {
                    this.txtMessage.Focus();
                }
                else
                {
                    MsgSend();
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ServerConnect_Load : void

        기능 : 채팅방 로드 시 작동하는 기능

        만든날짜: 2023-05-29

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ServerConnect_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : DB에서 저장된 '답변' 관련 채팅로그를 불러오는 기능

        만든날짜: 2023-06-02

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            try
            {
                Comm.CommandText = "Select [Question],[ChatLog] From [ChatLog] Where State = '답변'";

                var myRead = Comm.ExecuteReader();

                AnswerListView.Items.Clear();

                while (myRead.Read())
                {
                    ListViewItem lvi =
                        new ListViewItem(new string[] { "", myRead[0].ToString(), myRead[1].ToString() });

                    this.AnswerListView.Items.Add(lvi);
                }

                myRead.Close();
            }
            catch { }
        }

        /*---------------------------------------------------------------------
        메서드명: QuestionListView_DrawColumnHeader : void

        기능 : 열 머리글을 그리는 기능

        만든날짜: 2023-06-02

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void QuestionListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: QuestionListView_DrawItem : void

        기능 : 항목을 그리는 기능

        만든날짜: 2023-06-02

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void QuestionListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: QuestionListView_DrawSubItem : void

        기능 : 하위 항목을 그리는 기능

        만든날짜: 2023-06-02

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void QuestionListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: QuestionListView_SelectedIndexChanged : void

        기능 : 인덱스 클릭 할때마다 체크박스 체크/해제

        만든날짜: 2023-06-02

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void QuestionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.QuestionListView.SelectedItems.Count > 0)
            {
                int index = this.QuestionListView.SelectedItems[0].Index;

                if (QuestionListView.Items[index].Checked)
                {
                    QuestionListView.Items[index].Checked = false;
                }
                else
                {
                    QuestionListView.Items[index].Checked = true;
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: AnswerListView_SelectedIndexChanged : void

        기능 : 인덱스 클릭 할때마다 체크박스 체크/해제 및 답변 내용 텍스트 박스에
                담기

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AnswerListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.AnswerListView.SelectedItems.Count > 0)
            {
                int index = this.AnswerListView.SelectedItems[0].Index;

                if (AnswerListView.Items[index].Checked)
                {
                    AnswerListView.Items[index].Checked = false;
                }
                else
                {
                    AnswerListView.Items[index].Checked = true;
                }
                txtAnswer.Text = AnswerListView.Items[index].SubItems[2].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnAnswer_Click : void

        기능 : 답변 버튼 클릭 시 문의 답변 후 해당 내용을 저장 할지 결정

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 문의에 대한 답변을 하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //저장? 저장안함?
                if (MessageBox.Show("해당 답변(들)을 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ListViewItem Item in QuestionListView.CheckedItems)
                    {
                        foreach (Client cli in clients)
                        {
                            if (cli.RegiNum == Item.SubItems[1].Text)
                            {
                                NetworkStream stream = cli.SerClient.GetStream();
                                StreamWriter mywrite = new StreamWriter(stream);
                                mywrite.WriteLine(Item.SubItems[2].Text + "의 답변&" + txtAnswer.Text + "&" + DateTime.Now.ToString() + "&/Answer");
                                mywrite.Flush();
                                ChattingAdd("답변",Item.SubItems[2].Text,txtAnswer.Text);
                            }
                        }
                        Item.Remove();
                    }
                }
                else
                {
                    foreach (ListViewItem Item in QuestionListView.CheckedItems)
                    {
                        foreach (Client cli in clients)
                        {
                            if (cli.RegiNum == Item.SubItems[1].Text)
                            {
                                NetworkStream stream = cli.SerClient.GetStream();
                                StreamWriter mywrite = new StreamWriter(stream);
                                mywrite.WriteLine(myName + "의 답변&" + txtAnswer.Text + "&" + DateTime.Now.ToString());
                                mywrite.Flush();
                            }
                        }
                        Item.Remove();
                    }
                }
                DataLoad();
                txtAnswer.Clear();
                MessageBox.Show("답변완료");

            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSaveLog_Click : void

        기능 : 선택한 기록 저장 버튼 클릭 시 리스트에서 선택한 질문을 DB에 저장

        만든날짜: 2023-06-05

        수정날짜 : 2023-06-05
        기타사항 : 질문과 답변을 한번에 저장함
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private void btnSaveLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("해당 질문(들)을 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem Item in QuestionListView.CheckedItems)
                {
                     ChattingAdd("질문", Item.SubItems[2].Text, "");    
                }
            }
            DataLoad();
        }*/

        /*---------------------------------------------------------------------
        메서드명: ChattingAdd : void

        기능 : 채팅로그 DB에 내용을 저장

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ChattingAdd(string state,string Question,string ChatLog)
        {
            //MessageBox.Show(Chat[2]);5            
            if (!ChatLogIs(state, Question, ChatLog))
            {
                Comm.CommandText = "Insert Into [ChatLog] Values('" + state + "','" + Question + "','" + ChatLog + "',GetDate())";

                Comm.ExecuteNonQuery();
            }   
            else
            {
                MessageBox.Show("기존 저장한 답변이 있습니다.");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: QuestionListView_ColumnClick : void

        기능 : 체크박스의 머리글 클릭 시 전체선택을 작동시키는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void QuestionListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.QuestionListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.QuestionListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.QuestionListView.Items) item.Checked = !value;
                this.QuestionListView.Invalidate();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: AnswerListView_DrawColumnHeader : void

        기능 : 열 머리글을 그리는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AnswerListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: AnswerListView_DrawItem : void

        기능 : 항목을 그리는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AnswerListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: AnswerListView_DrawSubItem : void

        기능 : 하위 항목을 그리는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AnswerListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: AnswerListView_ColumnClick : void

        기능 : 체크박스의 머리글 클릭 시 전체선택을 작동시키는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AnswerListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.AnswerListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.AnswerListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.AnswerListView.Items) item.Checked = !value;
                this.AnswerListView.Invalidate();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnAnswerDel_Click : void

        기능 : 선택한 답변 삭제 클릭 시 리스트에 체크된 답변들을 지우는 기능

        만든날짜: 2023-06-05

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnAnswerDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("해당 답변(들)을 삭제하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (ListViewItem Item in AnswerListView.CheckedItems)
                {
                    ChattingDel(Item.SubItems[1].Text, Item.SubItems[2].Text);
                }
            }

            DataLoad();
        }

        private void ChattingDel(string Question, string ChatLog)
        {
            Comm.CommandText = "Delete From [ChatLog] Where [Question] = '" + Question + "' and [ChatLog] = '" + ChatLog + "'";

            Comm.ExecuteNonQuery();
        }

        private bool ChatLogIs(string State, string Question, string ChatLog)
        {
            bool Check = false;

            Comm.CommandText = "Select [Question],[ChatLog] From ChatLog Where [State] = '" + State + "'";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(myRead[0].ToString() == Question && myRead[1].ToString() == ChatLog)
                {
                    Check = true;
                }
            }

            myRead.Close();

            return Check;
        }
    }
}
