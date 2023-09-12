using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class ClientList : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;

        /*---------------------------------------------------------------------
        메서드명: ClientList 

        기능 : ClientList 클래스 생성자

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientList()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: ClientList_Load : void

        기능 : 현재 창 로드 시 발생하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 회원정보를 DB에서 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select * From Client";

            var myRead = Comm.ExecuteReader();

            ClientListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[1].ToString(),myRead[2].ToString(),
                    myRead[3].ToString() });

                this.ClientListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: ClientList_FormClosing : void

        기능 : 현재 창을 닫을 때 DB 연결 및 이전 창에게 이벤트 전달

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 조건에 맞는 검색결과를 리스트뷰에 보여주는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SqlWhere = string.Empty;
            if (rbName.Checked)
            {
                SqlWhere = "Where [Name] = '";
            }
            else
            {
                SqlWhere = "Where [Phone] = '";
            }

            Comm.CommandText = "Select * From [Client] " + SqlWhere +
                txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            ClientListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString() });

                this.ClientListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 전체 리스트를 다시 보여주는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }
    }
}
