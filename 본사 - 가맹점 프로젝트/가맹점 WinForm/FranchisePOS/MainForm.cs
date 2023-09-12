using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class MainForm : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        string id;
        int IsStaff;

        /*---------------------------------------------------------------------
        메서드명: MainForm

        기능 : MainForm 클래스 생성자

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public MainForm(string Id,int i)
        {
            InitializeComponent();
            Labeltxt.Text = Id + "님 어서오세요";
            if(i ==  1)
            {
                btnTime.Visible = false;
                IsStaff = i;
            }
            else
            {
                btnStaff.Visible = false;
                IsStaff = i;
            }
            id = Id;
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: btnOrder_Click : void

        기능 : 주문 버튼 클릭 시 주문 창을 띄우는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order wf = new Order(id);
            wf.FormCloseEvent += new Order.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnStock_Click : void

        기능 : 재고 관리 버튼 클릭 시 재고 관리 창을 띄우는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnStock_Click(object sender, EventArgs e)
        {
            StockMenu wf = new StockMenu(this, id);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnClient_Click : void

        기능 : 회원 관리 버튼 클릭 시 회원 관리 창을 띄우는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnClient_Click(object sender, EventArgs e)
        {
            ClientMenu wf = new ClientMenu();
            wf.FormCloseEvent += new ClientMenu.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnStaff_Click : void

        기능 : 직원 관리 버튼 클릭 시 직원 관리 창을 띄우는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnStaff_Click(object sender, EventArgs e)
        {
            StaffMenu wf = new StaffMenu(this,id);
            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 로그아웃 버튼 클릭 시 로그인 화면으로 돌아가는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: MainForm_FormClosing : void

        기능 : 메인폼 종료시 이전창으로 돌아가거나 로그를 생성하는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsStaff == 0)
            {
                LogSave();
            }
            Conn.Close();
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: LogSave : void 

        기능 : 로그아웃 시 직원의 로그아웃 기록을 저장하는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void LogSave()
        {
            Comm.CommandText = "Insert Into StaffLoginLog Values('"
                + id + "','" + getStaffName() + "','로그아웃',GetDate(),'" +
                getRegiNum() + "')";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: getStaffName : string 

        기능 : 해당 직원 Id로 직원명을 불러오는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getStaffName()
        {
            string name = string.Empty;
            Comm.CommandText = "Select [Name] From StaffLogin Where [Id] = '"
                + id + "'";


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
            catch(Exception ex)
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
        메서드명: ShowEvent : void 

        기능 : 해당 창을 다시 보여주는 기능

        만든날짜: 2023-04-13

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ShowEvent()
        {
            this.Show();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            ClientChat wf = new ClientChat(getRegiNumByOwner());
            wf.Show();
        }

        //2023-05-15
        private string getRegiNumByOwner()
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

        private void btnProfit_Click(object sender, EventArgs e)
        {
            ProfitMenu wf = new ProfitMenu(getRegiNumByOwner());
            wf.FormCloseEvent += new ProfitMenu.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }
    }
}
