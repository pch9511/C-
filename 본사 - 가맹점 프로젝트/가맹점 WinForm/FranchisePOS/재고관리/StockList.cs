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
    public partial class StockList : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string id;

        /*---------------------------------------------------------------------
        메서드명: StockList 

        기능 : StockList 클래스 생성자

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StockList(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: StockList_Load : void 

        기능 : 재고내역 창 로드 시 작동하는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void 

        기능 : DB에서 해당 가맹점의 재고내역을 불러오는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select * From [FranStock] Where [RegiNum] = '"
                + getRegiNum() + "'";

            var myRead = Comm.ExecuteReader();

            FranStockListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[2].ToString(), myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString() });

                this.FranStockListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void 

        기능 : 조회 버튼 클릭시 찾는 정보를 바탕으로 
               DB에서 정보를 가져와 리스트뷰에 보여주는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SqlWhere = string.Empty;
            if (rbCategory.Checked)
            {
                SqlWhere = "Where [Category] = '";
            }
            else if (rbName.Checked)
            {
                SqlWhere = "Where [Name] = '";
            }
            else
            {
                SqlWhere = "Where [Id] = '";
            }

            Comm.CommandText = "Select * From [FranStock] " + SqlWhere +
                txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            FranStockListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString() });

                this.FranStockListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void 

        기능 : 전체리스트 버튼 클릭시 전체리스트를 다시 보여주는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void 

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: StockList_FormClosing : void 

        기능 : 창을 닫을 때 DB 연결을 끊는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string

        기능 : DB에서 사업자등록번호를 가져오는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getRegiNum()
        {
            Comm.CommandText = "Select [RegiNum] From [Login] Where [Id] = '"
                + id + "'";

            string RegiNum = string.Empty;

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                RegiNum = myRead[0].ToString();
            }

            myRead.Close();

            return RegiNum;
        }
    }
}
