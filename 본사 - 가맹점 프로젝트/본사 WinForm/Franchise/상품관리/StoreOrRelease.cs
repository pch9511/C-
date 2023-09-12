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

namespace Franchise
{
    public partial class StoreOrRelease : Form
    {
        private string temp;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private ProductManagement Wf;
        string Account;

        /*---------------------------------------------------------------------
        메서드명: StoreOrRelease 

        기능 : 입출고 관리 생성자 

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StoreOrRelease(ProductManagement wf)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            temp = string.Empty;
            Account = string.Empty;
            Wf = wf;
        }

        /*---------------------------------------------------------------------
        메서드명: StoreOrRelease_Load : void

        기능 : 입출고 관리 창을 열때 발생하는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StoreOrRelease_Load(object sender, EventArgs e)
        {
            DataLoad();
        }


        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 본사의 재고상태를 DB에서 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.HeadStockListView.Items.Clear();

            Comm.CommandText = "Select * From HeadStock Order By Date Desc";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                if(myRead[7].ToString() == "출고")
                {
                    Account = myRead[5].ToString().Substring(1, myRead[5].ToString().Length - 1);
                }
                else
                {
                    Account = myRead[5].ToString();
                }
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                        myRead[2].ToString(), myRead[3].ToString() , myRead[4].ToString() 
                        , Account, myRead[6].ToString(), myRead[7].ToString() });
                this.HeadStockListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnIn_Click : void

        기능 : 입고 버튼 클릭시 입고창을 띄우는 기능

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : https://link2me.tistory.com/880 자식창 고정하는방법
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnIn_Click(object sender, EventArgs e)
        {
            Store wf = new Store();
            Point parentPoint = this.Location;
            wf.StartPosition = FormStartPosition.Manual;
            wf.Location = new Point(parentPoint.X + 100, parentPoint.Y + 100);

            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: StoreOrRelease_FormClosed : void

        기능 : 현재 창을 닫은 후 이전 창을 보여주는 기능

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StoreOrRelease_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wf.Show();
        }

        /*---------------------------------------------------------------------
        메서드명: StoreOrRelease_Activated : void

        기능 : 활성화할때마다 재고창 갱신해주는 기능

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StoreOrRelease_Activated(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 제품명으로 조회하는 기능 

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.HeadStockListView.Items.Clear();

            Comm.CommandText = "Select * From HeadStock Where [Name] = '"
                + txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                if (myRead[7].ToString() == "출고")
                {
                    Account = myRead[5].ToString().Substring(1, myRead[5].ToString().Length - 1);
                }
                else
                {
                    Account = myRead[5].ToString();
                }
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString() , myRead[4].ToString()
                        , myRead[5].ToString() , myRead[6].ToString(), myRead[7].ToString() });
                this.HeadStockListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 전체 리스트로 초기화 하는 기능

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: btnOut_Click : void

        기능 : 출고 버튼 클릭시 출고창 띄우는 기능

        만든날짜: 2023-04-06

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOut_Click(object sender, EventArgs e)
        {
            Release wf = new Release();
            Point parentPoint = this.Location;
            wf.StartPosition = FormStartPosition.Manual;
            wf.Location = new Point(parentPoint.X + 100, parentPoint.Y + 100);
            wf.ShowDialog();
        }
    }
}
