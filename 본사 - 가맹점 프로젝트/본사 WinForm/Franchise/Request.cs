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
    public partial class Request : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        string ReturnReason = String.Empty;

        /*---------------------------------------------------------------------
        메서드명: Request 

        기능 : Request 클래스 생성자

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Request()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            OrderListView.CheckBoxes = true;
        }

        /*---------------------------------------------------------------------
        메서드명: Request_Load : void 

        기능 : 해당 창 로드 시 발생하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Request_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void 

        기능 : DB에서 주문 리스트를 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select * From [Order]";

            var myRead = Comm.ExecuteReader();

            OrderListView.Items.Clear();
            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { "" ,myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString(),
                    myRead[4].ToString(), myRead[5].ToString(),
                    myRead[6].ToString(), myRead[7].ToString(), myRead[8].ToString() });

                this.OrderListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: Request_FormClosing : void 

        기능 : 창을 닫을 때 DB 연결을 끊고 이벤트를 이전 창에 전달하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Request_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void 

        기능 : 해당 창을 닫는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_DrawColumnHeader : void 

        기능 : 리스트뷰 머리글을 그리는 기능(체크박스)

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {
                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                    System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_DrawItem : void 

        기능 : 리스트뷰 항목 그리는 기능(체크박스)

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_DrawSubItem : void 

        기능 : 리스트뷰 하위항목 그리는 기능(체크박스)

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_ColumnClick : void 

        기능 : 리스트뷰 머리글 클릭 시 체크박스 전체 선택/해제 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.OrderListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.OrderListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.OrderListView.Items) item.Checked = !value;
                this.OrderListView.Invalidate();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSelect_Click : void 

        기능 : 승인 버튼 클릭 시 해당 가맹점으로 제품을 보내는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 리스트의 요청을 허용하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (ListViewItem Item in OrderListView.CheckedItems)
                {
                    if (Item.Checked)
                    {
                        if ((Item.SubItems[7].Text).Contains("반품요청"))
                        {
                            Comm.CommandText = "Insert Into [Itemback] Values('" +
                                 Item.SubItems[2].Text + "','" + Item.SubItems[3].Text + "','" + Item.SubItems[4].Text + "'," + Convert.ToInt32(Item.SubItems[5].Text) / 1.2 + "," +
                                 Convert.ToInt32(Item.SubItems[5].Text) + "," + Convert.ToInt32(Item.SubItems[6].Text) + ",'" + Item.SubItems[7].Text +
                                 "', Default) ";
                            Comm.CommandText += "Update [Order] Set [State] = '반품완료' Where Num = "
                              + Convert.ToInt32(Item.SubItems[1].Text);


                            if (Item.SubItems[7].Text.Contains("불량"))
                            {
                                /*Comm.CommandText += "Insert Into [HeadStock] Values('" + Item.SubItems[2].Text + "','" + Item.SubItems[3].Text + "','"
                                    + Item.SubItems[4].Text + "'," + Convert.ToInt32(Item.SubItems[5].Text) / 1.2 + "," + Convert.ToInt32(Item.SubItems[5].Text) +
                                    "," + Convert.ToInt32(Item.SubItems[6].Text) + ", Default, '반품','" + Item.SubItems[8].Text + "')";*/
                                Comm.CommandText += "Update Top(1) [HeadStock] Set State = '불량' Where [State] = '출고' and [Id] = '" + Item.SubItems[2].Text + "' and [Account] = '-"
                                    + Item.SubItems[6].Text + "' and [OutPrice] = '" + Item.SubItems[5].Text + "'";
                                //수량과 아이템이 같은거 아무거나 하나 바꿀수있게끔 해야함
                                //
                                /*Comm.CommandText += "Insert Into [HeadStock] Values('" + Item.SubItems[2].Text + "','" + Item.SubItems[3].Text + "','"
                                    + Item.SubItems[4].Text + "'," + Convert.ToInt32(Item.SubItems[5].Text) / 1.2 + "," + Convert.ToInt32(Item.SubItems[5].Text) +
                                    ",'-" + Item.SubItems[6].Text + "', Default, '불량','" + Item.SubItems[8].Text + "')";*/
                            }
                            else
                            {
                                Comm.CommandText += "Insert Into [HeadStock] Values('" + Item.SubItems[2].Text + "','" + Item.SubItems[3].Text + "','"
                                    + Item.SubItems[4].Text + "'," + Convert.ToInt32(Item.SubItems[5].Text) / 1.2 + "," + Convert.ToInt32(Item.SubItems[5].Text) +
                                    "," + Convert.ToInt32(Item.SubItems[6].Text) + ", Default, '반품','" + Item.SubItems[8].Text + "')";
                            }

                            Comm.ExecuteNonQuery();
                            MessageBox.Show("반품완료");
                        }
                        else if ((Item.SubItems[7].Text).Contains("발주요청"))
                        {
                            Comm.CommandText = "Update [Order] Set [State] = '배송중' Where Num = "
                                + Convert.ToInt32(Item.SubItems[1].Text);

                            Comm.ExecuteNonQuery();
                            MessageBox.Show(Item.SubItems[1].Text + "번 발송 완료");

                            SendItem(Item.SubItems[2].Text, getFranName(Item.SubItems[3].Text),
                                Item.SubItems[4].Text, Convert.ToInt32(Item.SubItems[5].Text)
                                , Convert.ToInt32(Item.SubItems[6].Text), Item.SubItems[8].Text);
                        }
                        else
                        {
                            MessageBox.Show(Item.SubItems[1].Text + "번은 배송중이거나 완료된 상품입니다.");
                        }
                    }
                }
            }
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_SelectedIndexChanged : void 

        기능 : 리스트뷰 항목 선택 시 체크 박스를 체크/해제 하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderListView.SelectedItems.Count > 0)
            {
                int index = this.OrderListView.SelectedItems[0].Index;

                if (StockCheck(OrderListView.Items[index].SubItems[2].Text,
                    Convert.ToInt32(OrderListView.Items[index].SubItems[6].Text)))
                {
                    if (OrderListView.Items[index].Checked)
                    {
                        OrderListView.Items[index].Checked = false;
                    }
                    else
                    {
                        OrderListView.Items[index].Checked = true;
                    }
                }
                else
                {
                    if (MessageBox.Show("재고가 부족합니다. 요청을 취소하시겠습니까?"
                        , "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        OrderCancel(OrderListView.Items[index].SubItems[1].Text);
                    }
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: StateCheck : bool 

        기능 : 승인하기 이전인 상태인지 아닌지를 체크하는 기능

        만든날짜: 2023-04-18

        수정날짜 : 2023-05-17
        기타사항 : Contains로 최소화
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private bool StateCheck(int Num)
        {
            bool Check = false;

            Comm.CommandText = "Select [State] From [Order] Where Num = "
                + Num;

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                if(myRead[0].ToString().Contains("발주요청"))
                {
                    Check = true;
                }
            }

            myRead.Close();

            return Check;
        }*/

        /*---------------------------------------------------------------------
        메서드명: SendItem : bool 

        기능 : 승인 이후 제품을 본사재고에서 출고로 기록하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void SendItem(string Id, string FranName, string Name, int Price, int Account, string Pay)
        {
            Comm.CommandText = "INSERT INTO HeadStock Values('" +
            Id + "','" + FranName + "','" + Name + "'," +
            Price / 1.2 + "," + Price + ",-" + Account + ",GetDate(), '출고','" + Pay + "')";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: getFranName : string 

        기능 : 사업자등록번호에 맞는 가맹점 이름을 가져오는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getFranName(string RegiNum)
        {
            Comm.CommandText = "Select Name From FranchiseInfo Where RegistrationNumber = '"
                + RegiNum + "'";
            string FranName = string.Empty;

            var myRead = Comm.ExecuteReader();
            if (myRead.Read())
            {
                FranName = myRead[0].ToString();
            }


            myRead.Close();

            return FranName;
        }

        /*---------------------------------------------------------------------
        메서드명: StockCheck : bool 

        기능 : 요청한 수량만큼의 재고가 있는지 확인하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool StockCheck(string Code, int Account)
        {
            bool check = false;
            Comm.CommandText = "Select [Id],sum(Account) From HeadStock Where [Id] = '"
                + Code + "' Group By [Id]";

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                if (Convert.ToInt32(myRead[1].ToString()) >= Account)
                {
                    check = true;
                }
            }

            myRead.Close();

            return check;
        }

        /*---------------------------------------------------------------------
        메서드명: OrderCancel : void 

        기능 : 가맹점에게 주문 취소 사유를 DB에 보내는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderCancel(string index)
        {
            Comm.CommandText = "Update [Order] Set [State] = '재고부족으로 취소' Where Num = '"
                + index + "'";

            Comm.ExecuteNonQuery();

            DataLoad();
        }

        //2023-05-18
        /*---------------------------------------------------------------------
        메서드명: getFranName : void 

        기능 : 요청거절 버튼 클릭 시 사유를 포함해 가맹점에게 요청 거절을 보냄

        만든날짜: 2023-05-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("선택한 리스트의 요청들을 거부하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (ListViewItem Item in OrderListView.CheckedItems)
                    {
                        if (Item.Checked)
                        {
                            if (Item.SubItems[7].Text == "배송중" || Item.SubItems[7].Text == "배송완료")
                            {
                                throw new Exception("배송중이거나 배송이 완료된 제품들은 이미 요청을 허용한 상품들입니다. ");
                            }
                            Comm.CommandText = "Update [Order] Set [State] = '요청거부 : " + ReturnReason + "' Where Num = "
                            + Convert.ToInt32(Item.SubItems[1].Text);

                            Comm.ExecuteNonQuery();
                        }
                    }
                }
                DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: rbReturn1_CheckedChanged : void 

        기능 : 라디오 버튼 클릭 시 사유를 저장하는 기능

        만든날짜: 2023-05-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void rbReturn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn1.Checked)
            {
                ReturnReason = rbReturn1.Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: rbReturn2_CheckedChanged : void 

        기능 : 라디오 버튼 클릭 시 사유를 저장하는 기능

        만든날짜: 2023-05-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void rbReturn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn2.Checked)
            {
                ReturnReason = rbReturn2.Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: rbReturn3_CheckedChanged : void 

        기능 : 라디오 버튼 클릭 시 사유를 저장하는 기능

        만든날짜: 2023-05-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void rbReturn3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn3.Checked)
            {
                ReturnReason = rbReturn3.Text;
            }
        }
    }
}
