using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class Login : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;

        /*---------------------------------------------------------------------
        메서드명: Login 

        기능 : Login 클래스 생성자

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Login()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: btnLogin_Click : void 

        기능 : 로그인 버튼 클릭 시 ID PW 일치 하면 메인화면 창으로 가는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtID.Text == "" || txtPW.Text == "")
                {
                    throw new Exception("ID 또는 PW를 입력해주세요.");
                }
                if ((AdministratorCheck()) != string.Empty)
                {
                    MainForm wf = new MainForm(txtID.Text, 1);
                    wf.FormCloseEvent += new MainForm.FormCloseHandler(Event);

                    this.Hide();
                    wf.ShowDialog();
                }
                else
                {
                    if (StaffCheck())
                    {
                        MainForm wf = new MainForm(txtID.Text, 0);
                        wf.FormCloseEvent += new MainForm.FormCloseHandler(Event);

                        LogSave();
                        this.Hide();
                        wf.ShowDialog();
                    }
                    else
                    {
                        throw new Exception("아이디 혹은 패스워드가 일치하지 않습니다.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: AdministratorCheck : void 

        기능 : 가맹점주의 ID,PW인지 판단하는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string AdministratorCheck()
        {
            string None = string.Empty;

            Comm.CommandText = "Select [Id],[Password] From Login";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(txtID.Text == myRead[0].ToString() && txtPW.Text == myRead[1].ToString())
                {
                    None = myRead[0].ToString();
                }
            }

            myRead.Close();

            return None;
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void 

        기능 : 종료 버튼 클릭 시 해당 창을 종료하는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();         
        }

        /*---------------------------------------------------------------------
        메서드명: Login_FormClosing : void 

        기능 : 폼 종료 시 DB 연결 끊는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: Event : void 

        기능 : 메인화면 창에서 로그아웃 시 로그인창을 다시 보여주는 이벤트

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Event()
        {
            this.Show();
        }

        /*---------------------------------------------------------------------
        메서드명: LogSave : void 

        기능 : 직원이 로그인 시 로그인 기록을 저장하는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void LogSave()
        {
            Comm.CommandText = "Insert Into StaffLoginLog Values('"
                + txtID.Text + "','" + getStaffName() + "','로그인',GetDate(),'" +
                getRegiNum() + "')";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: StaffCheck : bool 

        기능 : 로그인 시 해당 ID PW 가 직원의 로그인 정보와 
                일치하는지 확인하는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool StaffCheck()
        {
            bool Check = false;
            Comm.CommandText = "Select [Id],[Password] From [StaffLogin]";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(myRead[0].ToString() == txtID.Text && 
                        myRead[1].ToString() == txtPW.Text)
                {
                    Check = true;
                    break;
                }
            }

            myRead.Close();

            return Check;
        }

        /*---------------------------------------------------------------------
        메서드명: getStaffName : string 

        기능 : 해당 Id의 직원명을 불러오는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getStaffName()
        {
            string name = string.Empty;
            Comm.CommandText = "Select [Name] From StaffLogin Where [Id] = '"
                + txtID.Text + "'";


            var myRead = Comm.ExecuteReader();

            try
            {
                if (myRead.Read())
                {
                    name = myRead[0].ToString();
                }
                else
                {
                    throw new Exception("해당사항 없음");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

            myRead.Close();

            return name;
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string 

        기능 : 해당 Id가 어느 가맹점 소속인지 특정할 수 있는 
                사업자등록번호를 가져오는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getRegiNum()
        {
            string RegiNum = string.Empty;
            Comm.CommandText = "Select [RegiNum] From StaffLogin Where [Id] = '"
                + txtID.Text + "'";


            var myRead = Comm.ExecuteReader();

            try
            {
                if (myRead.Read())
                {
                    RegiNum = myRead[0].ToString();
                }
                else
                {
                    throw new Exception("해당사항 없음");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

            myRead.Close();

            return RegiNum;
        }
    }
}
