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
    public partial class StockOrderList : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        string id;

        /*---------------------------------------------------------------------
        메서드명: StockOrderList 

        기능 : StockOrderList 클래스 생성자

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StockOrderList(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: StockOrderList_Load : void 

        기능 : 해당 창 로드 시 발생하는 기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockOrderList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void 

        기능 : DB에서 해당 가맹점에서 주문한 리스트를 가져와서 리스트뷰에 보여주는
                기능

        만든날짜: 2023-04-18

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select * From [Order] Where [RegiNum] = '"
                + getRegiNum() + "'";

            var myRead = Comm.ExecuteReader();

            OrderListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] {"" ,myRead[0].ToString(),
                    myRead[1].ToString(), myRead[3].ToString(),
                    myRead[4].ToString(), myRead[5].ToString(),
                    myRead[6].ToString(), myRead[8].ToString()  });

                this.OrderListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void 

        기능 : 조회 버튼 클릭 시 조건에 맞는 정보를 DB에서 가져와 리스트뷰에 
                 보여주는 기능

        만든날짜: 2023-04-18

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

            Comm.CommandText = "Select * From [Order] " + SqlWhere +
                txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            OrderListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] {"" ,myRead[0].ToString(),
                    myRead[1].ToString(), myRead[3].ToString(),
                    myRead[4].ToString(), myRead[5].ToString(),
                    myRead[6].ToString(), myRead[7].ToString()  });

                this.OrderListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void 

        기능 : 전체리스트 클릭시 리스트뷰에서 전체리스트를 다시 보여주는 기능

        만든날짜: 2023-04-18

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
         메서드명: StockOrderList_FormClosing : void 

         기능 : 창을 닫을 때 DB 연결을 끊는 기능

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void StockOrderList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
         메서드명: OrderListView_DrawColumnHeader : void 

         기능 : 리스트뷰에서 칼럼헤더를 그리는 기능(체크박스 포함)

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
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

         기능 : 리스트뷰의 항목을 그리는 기능

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void OrderListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
         메서드명: OrderListView_DrawSubItem : void 

         기능 : 리스트뷰의 하위항목을 그리는 기능

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void OrderListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
         메서드명: OrderListView_ColumnClick : void 

         기능 : 머리글을 클릭할때 발생하는 기능(체크박스 전체 체크/해제)

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
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
         메서드명: OrderListView_SelectedIndexChanged : void 

         기능 : 리스트뷰 항목을 선택 시 체크박스 체크 해제 기능

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

                if (OrderListView.Items[index].Checked)
                {
                    OrderListView.Items[index].Checked = false;
                }
                else
                {
                    OrderListView.Items[index].Checked = true;
                }
            }
        }

        /*---------------------------------------------------------------------
         메서드명: btnReceive_Click : void 

         기능 : 제품 수령 버튼 클릭 시 제품 수령 후 가맹점 재고에 등록하는 기능 

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 리스트의 제품들이 도착했습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (ListViewItem Item in OrderListView.CheckedItems)
                {
                    if (Item.Checked)
                    {
                        if (StateCheck(Convert.ToInt32(Item.SubItems[1].Text)))
                        {
                            Comm.CommandText = "Update [Order] Set [State] = '배송완료' Where Num = "
                                + Convert.ToInt32(Item.SubItems[1].Text);

                            try
                            {
                                Comm.ExecuteNonQuery();
                                MessageBox.Show(Item.SubItems[0].Text + "번 수령 완료");

                                MessageBox.Show(Item.SubItems[2].Text + Item.SubItems[3].Text + Item.SubItems[4].Text +
                                    Item.SubItems[5].Text);
                                SaveItem(Item.SubItems[2].Text, Item.SubItems[3].Text,
                                    Convert.ToInt32(Item.SubItems[4].Text),
                                    Convert.ToInt32(Item.SubItems[5].Text));
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Error");
                            }
                        }
                        else
                        {
                            MessageBox.Show(Item.SubItems[1].Text + "번은 배송중인 제품이 아닙니다.");
                        }
                    }
                }
            }
            DataLoad();
        }

        /*---------------------------------------------------------------------
         메서드명: StateCheck : bool 

         기능 : 주문한 상품이 배송중인지 아닌지를 확인하는 기능

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private bool StateCheck(int Num)
        {
            bool Check = false;

            Comm.CommandText = "Select [State] From [Order] Where Num = "
                + Num;

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                if (myRead[0].ToString() == "배송중")
                {
                    Check = true;
                }
            }

            myRead.Close();

            return Check;
        }

        /*---------------------------------------------------------------------
         메서드명: SaveItem : void 

         기능 : 가맹점의 재고에 제품을 등록하는 기능

         만든날짜: 2023-04-18

         수정날짜 : X
         기타사항 : X
         연관함수 : X
         -----------------------------------------------------------------------*/
        private void SaveItem(string Id, string Name, int Price, int Account)
        {
            Comm.CommandText = "INSERT INTO [FranStock] Values('" +
            Id + "','" + getRegiNum() + "','" + Name + "'," +
            Price + "," + Account + ",'입고', Default)";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
         메서드명: getRegiNum : void 

         기능 : 해당 가맹점의 사업자등록번호를 가져오는 기능

         만든날짜: 2023-04-18

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 리스트의 주문 목록을 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (ListViewItem Item in OrderListView.CheckedItems)
                {
                    if (Item.Checked)
                    {
                        Comm.CommandText = "Delete From [Order] Where Num = "
                            + Convert.ToInt32(Item.SubItems[1].Text);
                        try
                        {
                            Comm.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                }
            }
            DataLoad();
        }
    }
}
