using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class StockOrder : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string Code,Price,id,Pay;

        /*---------------------------------------------------------------------
        메서드명: StockOrder

        기능 : StockOrder 클래스 생성자

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StockOrder(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Code = string.Empty;
            Price = string.Empty;
            Pay = "현금";
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: StockOrder_Load : void

        기능 : 현재 창 로드 시 작동하는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockOrder_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : DB에서 제품 정보를 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {

            Comm.CommandText = "Select * From Product";

            var myRead = Comm.ExecuteReader();

            ProductListView.Items.Clear();

            while(myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), (Convert.ToDouble(myRead[3].ToString()) * 1.2).ToString() });

                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_SelectedIndexChanged : void

        기능 : 리스트뷰의 인덱스 선택 시 해당 인덱스의 정보들을 가져오는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ProductListView.SelectedItems.Count > 0)
            {
                int index = this.ProductListView.SelectedItems[0].Index;
                Code = this.ProductListView.Items[index].SubItems[0].Text;
                txtName.Text = this.ProductListView.Items[index].SubItems[1].Text;
                Price = this.ProductListView.Items[index].SubItems[3].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnOrder_Click : void

        기능 : 발주 버튼 클릭시 입력된 수량과 제품정보를 바탕으로 본사에 
                주문하는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text == "" || txtAccount.Text == "")
                {
                    throw new Exception("제품 리스트를 선택 한 후 요청할 수량을 입력해주세요.");
                }
                Comm.CommandText = "Insert Into [Order] Values('" + Code
                    + "','" + getRegiNum() + "','" + txtName.Text + "','" +
                    Price + "','" + txtAccount.Text + "','발주요청','" + Pay + "', GetDate())";

                Comm.ExecuteNonQuery();

                MessageBox.Show("해당 상품 발주를 요청하였습니다.");

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-17

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

        기능 : 조회 버튼 클릭 시 조건에 맞는 제품정보를 DB에서 가져와 
                리스트뷰에서 보여주는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string SqlWhere = string.Empty;
            if(rbCategory.Checked)
            {
                SqlWhere = "Where [Category] = '";
            }
            else if(rbName.Checked)
            {
                SqlWhere = "Where [Name] = '";
            }
            else
            {
                SqlWhere = "Where [Id] = '";
            }

            Comm.CommandText = "Select * From Product " + SqlWhere +
                txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            ProductListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), (Convert.ToDouble(myRead[3].ToString()) * 1.2).ToString() });

                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: StockOrder_FormClosing : void

        기능 : 현재 창 닫을 때 DB연결을 끊는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        private void rbCash_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCash.Checked)
            {
                Pay = "현금";
            }
        }

        private void rbCredit_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCredit.Checked)
            {
                Pay = "외상";
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 전체리스트 버튼 클릭 시 전체리스트를 리스트뷰에 다시 보여줌

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string

        기능 : DB에서 해당 가맹점의 사업자등록번호를 가져오는 기능

        만든날짜: 2023-04-17

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
