using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Franchise
{
    public partial class Store : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string name;
        private string price;


        /*---------------------------------------------------------------------
        메서드명: Store

        기능 : Store 클래스의 생성자

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Store()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: Store_Load : void

        기능 : Store 창 로드 시 발생하는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Store_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : Product DB를 가지고 와서 리스트뷰에 담는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select * From Product";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                        myRead[2].ToString(), myRead[3].ToString() });
                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_SelectedIndexChanged : void

        기능 : 리스트 뷰의 인덱스 선택시 정보를 가져오는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItems.Count > 0)
            {
                int index = this.ProductListView.SelectedItems[0].Index;

                this.txtCode.Text = this.ProductListView.Items[index].SubItems[0].Text;
                name = this.ProductListView.Items[index].SubItems[1].Text;
                price = this.ProductListView.Items[index].SubItems[3].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnIn_Click : void

        기능 : 입고 버튼 클릭 시 입고 정보를 DB에 담는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                /*for (int i = 0; i < this.ProductListView.Items.Count; i++)
                {
                    if (this.txtCode.Text == this.ProductListView.Items[i].SubItems[1].Text)
                    {
                        throw new Exception("이미 있는 제품명입니다.");
                    }
                }*/
                if (this.txtCode.Text == "" || this.txtAccount.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");
                Comm.CommandText = "INSERT INTO HeadStock Values('" +
                     txtCode.Text + "','','" + name + "','" +
                     price + "',NULL,'" + txtAccount.Text + "', Default, '입고','')";

                Comm.ExecuteNonQuery();

                MessageBox.Show("입고되었습니다.");
                DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 종료 버튼 클릭 시 입고 창 닫는 기능

        만든날짜: 2023-04-07

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

        기능 : 검색 시 해당하는 정보를 리스트 뷰에 나타내는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select * From Product Where [Name] = '"
                + txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString() });
                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 리스트뷰의 전체 리스트를 보여주는 기능

        만든날짜: 2023-04-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void Store_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
        }
    }
}
