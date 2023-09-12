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
    public partial class ClientDelete : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string Id = string.Empty;

        /*---------------------------------------------------------------------
        메서드명: ClientDelete

        기능 : ClientDelete 클래스 생성자

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientDelete()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: ClientDelete_Load : void

        기능 : 현재 창 로드 시 발생하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientDelete_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 회원 정보를 DB에서 가져와 리스트뷰에 보여주는 기능

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

            while(myRead.Read())
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
        메서드명: ClientDelete_FormClosing : void

        기능 : 현재 창을 닫을 때 DB 연결 및 부모 창에 이벤트 전달

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientDelete_FormClosing(object sender, FormClosingEventArgs e)
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
        메서드명: btnDelete_Click : void

        기능 : 삭제 버튼 클릭 시 DB에서 해당하는 회원정보를 삭제하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Id != string.Empty)
            {
                Comm.CommandText = "Delete From Client Where Id = '"
                    + Id + "'";

                Comm.ExecuteNonQuery();

                MessageBox.Show("삭제 완료");

                DataLoad();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 조건에 맞는 검색 결과를 리스트뷰에 보여주는 기능

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

        기능 : 전체 리스트뷰를 다시 보여주는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: ClientListView_SelectedIndexChanged : void

        기능 : 리스트뷰에서 인덱스 선택 시 해당 정보를 변수에 담는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientListView.SelectedItems.Count > 0)
            {
                int index = this.ClientListView.SelectedItems[0].Index;

                Id = ClientListView.Items[index].SubItems[0].Text;
            }
        }
    }
}
