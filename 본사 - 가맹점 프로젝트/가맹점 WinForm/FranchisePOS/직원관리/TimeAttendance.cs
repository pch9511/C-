using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class TimeAttendance : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        string id;

        /*---------------------------------------------------------------------
        메서드명: TimeAttendance 

        기능 : TimeAttendance 클래스의 생성자

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public TimeAttendance(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: TimeAttendance_Load : void

        기능 : 근태 조회 창을 열었을때 발생하는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void TimeAttendance_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : DB에서 직원의 로그인 기록을 불러와 그 정보를 바탕으로 
                근태기록을 리스트뷰에 등록

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select * From StaffLoginLog Where RegiNum = '"
                + getRegiNum() + "'";

            var myRead = Comm.ExecuteReader();

            this.LogListView.Items.Clear();

            while (myRead.Read())
            {
                string temp = string.Empty;
                if (myRead[2].ToString() == "로그인")
                {
                    temp = "출근";
                }
                else
                {
                    temp = "퇴근";
                }
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    temp, myRead[3].ToString() });

                this.LogListView.Items.Add(lvi);
            }

            myRead.Close();
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
            Comm.CommandText = "Select [RegiNum] From Login Where [Id] = '"
                + id + "'";


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

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 해당 창을 닫는 기능
    
        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: TimeAttendance_FormClosing : void

        기능 : 해당 창을 닫을 때 DB 연결을 끊는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void TimeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }
    }
}
