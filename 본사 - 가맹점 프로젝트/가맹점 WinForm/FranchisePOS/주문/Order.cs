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
    //2023-04-20
    public partial class Order : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        string word,id,whichpay,regiNum;
        string FrName, FrPrice;
        string[] words;
        int TotalPrice;

        /*---------------------------------------------------------------------
        메서드명: Order 

        기능 : Order 클래스 생성자

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Order(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
            regiNum = getRegiNum();
            TotalPrice = 0;
        }

        /*---------------------------------------------------------------------
        메서드명: btnCoffee_Click : void

        기능 : 커피 버튼 클릭 시 커피 메뉴판을 보여준다.

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCoffee_Click(object sender, EventArgs e)
        {
            MenuSelect("Coffee");
        }

        /*---------------------------------------------------------------------
        메서드명: btnDrink_Click : void

        기능 : 드링크 버튼 클릭 시 드링크 메뉴판을 보여준다.

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDrink_Click(object sender, EventArgs e)
        {
            MenuSelect("Drink");
        }

        /*---------------------------------------------------------------------
        메서드명: btnDessert_Click : void

        기능 : 디저트 버튼 클릭 시 디저트 메뉴를 보여주는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDessert_Click(object sender, EventArgs e)
        {
            MenuSelect("Dessert");
        }

        /*---------------------------------------------------------------------
        메서드명: btnEvent_Click : void

        기능 : 이벤트 버튼 클릭 시 이벤트 메뉴를 보여주는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnEvent_Click(object sender, EventArgs e)
        {
            MenuSelect("Event");
        }

        /*---------------------------------------------------------------------
        메서드명: Order_Load : void

        기능 : 주문 창 로드 시 커피 메뉴판이 기본으로 나오게 한다.

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Order_Load(object sender, EventArgs e)
        {
            MenuSelect("Coffee");
        }

        /*---------------------------------------------------------------------
        메서드명: MenuSelect : void

        기능 : 메뉴 카테고리 클릭 시 해당 메뉴판을 보여주는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MenuSelect(string MenuName)
        {
            Comm.CommandText = "Select [Name],[Price] From [Menu] Where [Category] = '" +
                MenuName + "'";

            var myRead = Comm.ExecuteReader();

            int cnt = 0;
            while(myRead.Read())
            {
                switch(cnt)
                {
                    case 0:
                        btnMenu1.Text = myRead[0].ToString() + "\r\n\r\n" + myRead[1].ToString() ;
                        break;
                    case 1:
                        btnMenu2.Text = myRead[0].ToString() + "\r\n\r\n" + myRead[1].ToString() ;
                        break;
                    case 2:
                        btnMenu3.Text = myRead[0].ToString() + "\r\n\r\n" + myRead[1].ToString() ;
                        break;
                    case 3:
                        btnMenu4.Text = myRead[0].ToString() + "\r\n\r\n" + myRead[1].ToString() ;
                        break;
                }
                cnt++;
            }

            for(int i = cnt; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        btnMenu4.Enabled = false;
                        btnMenu1.Text = "X";
                        break;
                    case 1:
                        btnMenu4.Enabled = false;
                        btnMenu2.Text = "X";
                        break;
                    case 2:
                        btnMenu4.Enabled = false;
                        btnMenu3.Text = "X";
                        break;
                    case 3:
                        btnMenu4.Enabled = false;
                        btnMenu4.Text = "X";
                        break;
                }
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnPay_Click : void

        기능 : 장바구니에 담긴 제품을 결제하는 기능

        만든날짜: 2023-04-20

        수정날짜 : 2023-04-24
        기타사항 : 수정사항 ) 포인트 적립 기능 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnPay_Click(object sender, EventArgs e)
        {
            TotalPrice = 0;
            string Content = string.Empty; // 내용
            try
            {
                foreach (ListViewItem list in OrderListView.Items)
                {
                    TotalPrice += Convert.ToInt32(list.SubItems[1].Text)
                        * Convert.ToInt32(list.SubItems[2].Text);
                    StockSub(list.SubItems[0].Text, Convert.ToInt32(list.SubItems[2].Text));
                    Content += list.SubItems[0].Text + " " + list.SubItems[2].Text +"개 ";
                }
                if (TotalPrice == 0) throw new Exception("담긴 제품이 없습니다.");
                    MessageBox.Show("총 금액 :" + TotalPrice);
                if (MessageBox.Show("적립하시겠습니까?", "포인트 적립", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    ClientCheck wf = new ClientCheck(TotalPrice);

                    wf.UsePoint += new ClientCheck.UsePointHandler(PointSub);

                    wf.ShowDialog();
                }
                if (TotalPrice != 0)
                {
                    PaySelect wf = new PaySelect();

                    wf.WhichPayEvent += new PaySelect.WhichPayHandelr(WhichPay);
                    wf.ShowDialog();
                }
                RegistPay(TotalPrice, Content);
                //결제한 상품들을 DB에 담는기능이 필요함(가장 잘팔리는 상품찾기)
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /*---------------------------------------------------------------------
        메서드명: MenuIn : void

        기능 : 선택한 제품을 장바구니에 담는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void MenuIn(string[] words)
        {
            bool check = false;
            foreach (ListViewItem list in OrderListView.Items)
            {
                if (list.SubItems[0].Text == words[0].ToString())
                {
                    list.SubItems[2].Text = (Convert.ToInt32(list.SubItems[2].Text) + 1).ToString();
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { words[0].ToString(), words[1].ToString(), "1" });

                this.OrderListView.Items.Add(lvi);
            }
        }

        /*---------------------------------------------------------------------
        메서드명: StockSub : void

        기능 : 제품 결제 후 가맹점 내 재고를 자동으로 차감

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockSub(string Name, int num)
        {
            Comm.CommandText = "Select [UseProduct],[UseAccount] From Menu Where " +
                "Name = '" + Name + "'";

            var myRead = Comm.ExecuteReader();

            string ProductCode = string.Empty; ;
            int Account = 0;
            if(myRead.Read())
            {
                ProductCode = myRead[0].ToString();
                Account = Convert.ToInt32(myRead[1].ToString());
            }

            myRead.Close();


            getProductInfo(ProductCode);

            /*"INSERT INTO [FranStock] Values('" +
            ProductCode + "','" + regiNum + "','" + FrName + "'," +
            FrPrice + "," + -Account * num + ",'출고', Default)";*/
            Comm.CommandText = "INSERT INTO [FranStock] Values('" + ProductCode + "','" + regiNum + "','" + FrName + "'," +
                    FrPrice + "," + -Account * num + ",'소모', Default)";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string

        기능 : 현재 가맹점의 사업자등록번호를 얻어오는 기능

        만든날짜: 2023-04-20

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

        private void getProductInfo(string Code)
        {
            Comm.CommandText = "Select [Name],[Price] From [FranStock] Where [Id] = '"
                           + Code + "' and RegiNum = '" + regiNum + "'";


            var myRead = Comm.ExecuteReader();

            try
            {
                if (myRead.Read())
                {
                    FrName = myRead[0].ToString();
                    FrPrice = myRead[1].ToString();
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
        }
        /*---------------------------------------------------------------------
        메서드명: Order_FormClosing : void

        기능 : 창을 닫을 때 이전 창에게 이벤트를 전달

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: RegistPay : void

        기능 : 결제내역을 DB에 저장하는 기능

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void RegistPay(int TotalPrice,string Content)
        {
            Comm.CommandText = "Insert Into Pay Values('" + regiNum +
                "','" + whichpay + "'," + TotalPrice + ",'"
                + Content + "',Default)";

            Comm.ExecuteNonQuery();
            SaveSellProduct();

            OrderListView.Items.Clear();
        }

        /*---------------------------------------------------------------------
        메서드명: PointSub : void

        기능 : 포인트로 구매 시 입력한 포인트만큼 총 결제 금액 차감

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void PointSub(string Point)
        {
            TotalPrice -= Convert.ToInt32(Point);
        }

        /*---------------------------------------------------------------------
        메서드명: btnMenu1_Click : void

        기능 : 메뉴1번을 클릭 시 메뉴이름과 가격을 나누기 쉽게하고 
                장바구니에 담는 기능에 전달

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnMenu1_Click(object sender, EventArgs e)
        {
            word = btnMenu1.Text.Replace("\r\n\r\n", "-");
            words = word.Split('-');

            MenuIn(words);
        }

        /*---------------------------------------------------------------------
        메서드명: btnMenu2_Click : void

        기능 : 메뉴2번을 클릭 시 메뉴이름과 가격을 나누기 쉽게하고 
                장바구니에 담는 기능에 전달

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnMenu2_Click(object sender, EventArgs e)
        {
            word = btnMenu2.Text.Replace("\r\n\r\n", "-");
            words = word.Split('-');

            MenuIn(words);
        }

        /*---------------------------------------------------------------------
        메서드명: btnMenu3_Click : void

        기능 : 메뉴3번을 클릭 시 메뉴이름과 가격을 나누기 쉽게하고 
                장바구니에 담는 기능에 전달

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnMenu3_Click(object sender, EventArgs e)
        {
            word = btnMenu3.Text.Replace("\r\n\r\n", "-");
            words = word.Split('-');

            MenuIn(words);
        }

        /*---------------------------------------------------------------------
        메서드명: btnMenu4_Click : void

        기능 : 메뉴4번을 클릭 시 메뉴이름과 가격을 나누기 쉽게하고 
                장바구니에 담는 기능에 전달

        만든날짜: 2023-04-20

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnMenu4_Click(object sender, EventArgs e)
        {
            word = btnMenu4.Text.Replace("\r\n\r\n", "-");
            words = word.Split('-');

            MenuIn(words);
        }

        /*---------------------------------------------------------------------
        메서드명: WhichPay : void

        기능 : 결제 방식이 어떤것인지 받아오는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void WhichPay(string WhichPay)
        {
            whichpay = WhichPay;
        }

        private void SaveSellProduct()
        {

            Comm.CommandText = "";
            foreach (ListViewItem list in OrderListView.Items)
            {
                Comm.CommandText += "Insert Into [SellProduct] VALUES('" + regiNum + "','" + list.SubItems[0].Text + "','" + list.SubItems[1].Text + "','"
                    + list.SubItems[2].Text + "',Default)";
            }

            Comm.ExecuteNonQuery();
        }
    }
}
