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
using System.Reflection;

namespace Franchise
{
    public partial class Release : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        ListViewItem curItem;
        ListViewItem.ListViewSubItem curSItem;
        private bool cancelEdit = false;
        List<ListView> ReleaseListView = new List<ListView>();

        /*---------------------------------------------------------------------
        메서드명: Release

        기능 : Release 클래스의 생성자

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Release()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;

        }

        /*---------------------------------------------------------------------
        메서드명: Release_Load : void

        기능 : 출고 창 로드 시 발생하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Release_Load(object sender, EventArgs e)
        {
            DataLoad();
            FranDataLoad();
            //ReleaseListView.Location = new Point(375, 376);
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : DB의 재고 정보를 가져와 리스트 뷰에 담는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select [Id],[Name],[InPrice] ,sum(Account) From HeadStock Group By [Id],[Name],[InPrice]";

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
        메서드명: FranDataLoad : void

        기능 : DB에서 가맹점 정보를 리스트뷰에 담는 기능

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranDataLoad()
        {
            this.FranListView.Items.Clear();

            Comm.CommandText = "Select * From FranchiseInfo";
            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { "",myRead[0].ToString(), myRead[1].ToString(),
                    myRead[3].ToString() ,myRead[5].ToString() });

                this.FranListView.Items.Add(lvi);
            }

            myRead.Close();
        }


        /*---------------------------------------------------------------------
        메서드명: ProductListView_SelectedIndexChanged : void

        기능 : 리스트 뷰 인덱스 선택 시 해당 인덱스 정보를 가져오는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItems.Count > 0)
            {
                int index = this.ProductListView.SelectedItems[0].Index;

                /*this.txtCode.Text = this.ProductListView.Items[index].SubItems[0].Text;
                name = this.ProductListView.Items[index].SubItems[1].Text;
                price = Convert.ToDouble(this.ProductListView.Items[index].SubItems[2].Text) * 1.2;
                txtPrice.Text = price.ToString();               */
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 검색 버튼 클릭시 해당하는 재고 정보를 리스트뷰에 보여주는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select [Id],[Name],[Price],sum(Account) as 개수 From HeadStock Where [Name] = '"
                + txtSearchName.Text + "'Group By [Id],[Price]";

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

        기능 : 전체 재고 정보를 보여주는 기능

        만든날짜: 2023-04-08

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

        기능 : 출고 버튼 클릭 시 출고할 상품을 보낼 가맹점을 선택하는 창으로
               이동하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("가맹점들에게 제품을 발송하시겠습니까? 발송하면 취소가 불가능합니다.", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    for (int i = 0; i < ReleaseListView.Count; i++)
                    {                       
                        foreach (ListViewItem Item in ReleaseListView[i].Items)
                        {
                            if (!AccountCheck(Item.SubItems[0].Text,Item.SubItems[3].Text))
                            {
                                MessageBox.Show(FranTabControl.TabPages[i].Text + "에 보내는 제품 " + Item.SubItems[0].Text + "이 재고가 부족합니다 다시 확인해주세요.");
                                continue;
                            }
                            Comm.CommandText = "INSERT INTO HeadStock Values('" +
                                    Item.SubItems[0].Text + "','" + FranTabControl.TabPages[i].Text + "','" + Item.SubItems[1].Text + "'," +
                                    Convert.ToInt32(Item.SubItems[2].Text) + "," + Convert.ToInt32(Item.SubItems[2].Text) * 1.2 + ",'-" + Item.SubItems[3].Text + "', Default, '출고' ,'현금')"
                                    + " Insert INTO FranStock Values('" + Item.SubItems[0].Text + "','" +  FranTabControl.TabPages[i].Text +
                                    "','" + Item.SubItems[1].Text + "'," + Convert.ToInt32(Item.SubItems[2].Text) * 1.2  + "," + Item.SubItems[3].Text + ",'입고', Default)";


                            Comm.ExecuteNonQuery();
                            DataLoad();
                            MessageBox.Show("정상적으로 출고 완료.");
                        }
                    }
                    DataLoad();
                } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 출고 창 종료하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: OutEvent : void

        기능 : 가맹점 선택 후 선택 창 종료시 발생하는 이벤트
                가맹점 정보와 출고 정보를 재고 정보에 담는 기능

        만든날짜: 2023-04-08

        수정날짜 : 2023-05-12
        기타사항 : Select Fran 과 Release 를 결합
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private void OutEvent(object sender)
        {

            string regiNum = sender.ToString();
            string Msg = string.Empty;
            string FranName = getFranName(regiNum);
            if(regiNum != string.Empty)
            {
                MessageBox.Show(regiNum);
                // 가맹점명을 받아와야하나?

                Msg = FranName + " 에게 " + name + " 제품" + txtAccount.Text + "만큼"
                    + price + "의 가격으로 보냅니다.";

                if (MessageBox.Show(Msg, "Test", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Comm.CommandText = "INSERT INTO HeadStock Values('" +
                         txtCode.Text + "','" + FranName + "','" + name + "'," +
                         price/1.2 + "," + price + ",'-" + txtAccount.Text + "', Default, '출고')";

                    Comm.ExecuteNonQuery();
                    DataLoad();
                }
            }
        }*/

        /*---------------------------------------------------------------------
        메서드명: getFranName : string

        기능 : 가맹점명을 가져오는 기능

        만든날짜: 2023-04-08

        수정날짜 : 2023-05-12 
        기타사항 : 윈폼 결합으로 인한 불필요한 함수
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private string getFranName(string regiNum)
        {
            Comm.CommandText = "Select Name From FranchiseInfo Where RegistrationNumber = '"
                + regiNum + "'";
            string FranName = string.Empty;

            var myRead = Comm.ExecuteReader();
            if (myRead.Read())
            {
                FranName = myRead[0].ToString();
            }
            

            myRead.Close();

            return FranName;
        }*/

        /*---------------------------------------------------------------------
        메서드명: AccountCheck : bool

        기능 : 출고할 제품의 수량이 있는지 판단하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool AccountCheck(string code,string Account)
        {
            int ac = 0;

            Comm.CommandText = "Select sum(Account) as 개수 From HeadStock Where [Id] ='"
                + code + "' Group By [Id]";

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                ac = Convert.ToInt32(myRead[0].ToString());
            }


            myRead.Close();

            if (ac < Convert.ToInt32(Account))
            {
                return false;
            }           
            return true;
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_ColumnClick : void

        기능 : 리스트뷰 머리글 클릭 시 체크박스 전체 선택/해제 기능

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.FranListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.FranListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.FranListView.Items) item.Checked = !value;
                this.FranListView.Invalidate();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_DrawColumnHeader : void 

        기능 : 리스트뷰 머리글을 그리는 기능(체크박스)

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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
        메서드명: FranListView_DrawItem : void 

        기능 : 리스트뷰 항목 그리는 기능(체크박스)

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 + 윈폼 결합이므로 04-18에 제작한 SelectFran Form 형식을 
                    현재 윈폼에 이식
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_DrawSubItem : void 

        기능 : 리스트뷰 하위항목 그리는 기능(체크박스)

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : https://hyokim.tistory.com/16 체크박스 관련 + 윈폼 결합이므로 04-18에 제작한 SelectFran Form 형식을 
                    현재 윈폼에 이식
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_SelectedIndexChanged : void 

        기능 : 리스트뷰 항목 선택 시 체크 박스를 체크/해제 하는 기능

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FranListView.SelectedItems.Count > 0)
            {
                int index = this.FranListView.SelectedItems[0].Index;

                if (FranListView.Items[index].Checked)
                {
                    FranListView.Items[index].Checked = false;
                }
                else
                {
                    FranListView.Items[index].Checked = true;
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_DrawColumnHeader : void 

        기능 : 리스트뷰 머리글을 그리는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
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

        //2023-05-15~
        /*---------------------------------------------------------------------
        메서드명: ProductListView_DrawItem : void 

        기능 : 리스트뷰 항목 그리는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_DrawSubItem : void 

        기능 : 리스트뷰 하위 항목 그리는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_ColumnClick : void 

        기능 : 리스트뷰 체크박스 전체선택 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.FranListView.Columns[e.Column].Tag);
                }
                catch (Exception)
                {
                }
                this.FranListView.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.FranListView.Items) item.Checked = !value;
                this.FranListView.Invalidate();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_MouseClick : void 

        기능 : 수량의 하위항목 클릭 시 개수 조절이 가능하게 하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_MouseClick(object sender, MouseEventArgs e)
        {
            curItem = ProductListView.GetItemAt(e.X, e.Y);
            if (curItem == null) return;

            int idxRow = ProductListView.Items.IndexOf(curItem);

            curSItem = curItem.GetSubItemAt(e.X, e.Y);
            int idxSub = curItem.SubItems.IndexOf(curSItem);

            switch(idxSub)
            {
                case 0:
                case 1:
                case 2:
                    return;
                case 3:
                    break;                   
            }

            int left = curSItem.Bounds.Left + 2;
            int width = curSItem.Bounds.Width;

            AccountSpin.SetBounds(left + ProductListView.Left,
                curSItem.Bounds.Top + ProductListView.Top,
                width, curSItem.Bounds.Height);

            if(String.IsNullOrEmpty(curSItem.Text))
            {
                AccountSpin.Text = "";
            }
            else
            {
                AccountSpin.Text = curSItem.Text;
            }

            
            AccountSpin.Show();
            AccountSpin.Focus();

        }
        /*---------------------------------------------------------------------
        메서드명: AccountSpin_KeyDown : void 

        기능 : 특정 키 클릭 시 해당 수량 적용하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AccountSpin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Enter:
                    e.Handled = true;
                    cancelEdit = false;
                    AccountSpin.Hide();
                    break;
                case System.Windows.Forms.Keys.Escape:
                    e.Handled = true;
                    cancelEdit = true;
                    AccountSpin.Hide();
                    break;
                default:
                    return;
            }
        }
        /*---------------------------------------------------------------------
        메서드명: AccountSpin_Leave : void 

        기능 : AccountSpin을 벗어날때 발생하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : https://rainflys.tistory.com/221
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AccountSpin_Leave(object sender, EventArgs e)
        {
            AccountSpin.Hide();
            if (!cancelEdit)
            {
                curSItem.Text = AccountSpin.Text;
            }

            cancelEdit = false;
            ProductListView.Focus();
        }

        /*---------------------------------------------------------------------
        메서드명: btnIn_Click : void 

        기능 : 출고목록에 담기 버튼 클릭 시 발생하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnIn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in FranListView.CheckedItems)
            {
                if(pageCheck(Item.SubItems[3].Text))
                {
                    AddList(Item.SubItems[3].Text);
                }
                else
                {
                    AddTapPage(Item);
                }            
                /*foreach (TabPage page in FranTabControl.TabPages)
                {
                    if (page.Text != Item.SubItems[3].Text)
                    {
                        AddRelease(Item);
                    }
                }*/
            }
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: AddList : void 

        기능 : 탭이름과 같은 곳에 제품들을 담는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AddList(string regiNum)
        {
            bool Check = false;
            for(int i=0; i<FranTabControl.TabPages.Count; i++)
            {
                if(FranTabControl.TabPages[i].Text == regiNum)
                {
                    foreach (ListViewItem item in ProductListView.Items)
                    {
                        if (item.SubItems[3].Text != "0")
                        {
                            foreach (ListViewItem item2 in ReleaseListView[i].Items)
                            {
                                if (item.SubItems[0].Text == item2.SubItems[0].Text)
                                {
                                    Check = true;
                                    item2.SubItems[3].Text = (Convert.ToInt32(item.SubItems[3].Text) + Convert.ToInt32(item2.SubItems[3].Text)).ToString();
                                    break;
                                }
                            }
                            if (Check == false)
                            {
                                ListViewItem lvi = new ListViewItem(new string[]{item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text,
                                 item.SubItems[3].Text });
                                ReleaseListView[i].Items.Add(lvi);
                            }
                        }
                        Check = false;
                    }                    
                    break;
                }
            }       
        }


        /*---------------------------------------------------------------------
        메서드명: pageCheck : bool 

        기능 : 탭 이름 중복을 체크하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool pageCheck(string regiNum)
        {
            foreach (TabPage page in FranTabControl.TabPages)
            {
                if (page.Text == regiNum)
                {
                    return true;
                }
            }
            return false;
        }

        /*---------------------------------------------------------------------
        메서드명: AddTapPage : void 

        기능 : 탭을 만들고 해당 탭에 설정한 상품을 담는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AddTapPage(ListViewItem listview)
        {
            FranTabControl.TabPages.Add(listview.SubItems[3].Text);

            ReleaseListView.Add(new ListView());
            int cnt = ReleaseListView.Count;
            ReleaseListView[cnt - 1].View = View.Details;
            ReleaseListView[cnt - 1].FullRowSelect = true;

            ReleaseListView[cnt - 1].SetBounds(0, 0, 700, 350);
            ReleaseListView[cnt - 1].GridLines = false;
            ReleaseListView[cnt - 1].Columns.Add("제품코드", 100);
            ReleaseListView[cnt - 1].Columns.Add("제품명", 100);
            ReleaseListView[cnt - 1].Columns.Add("가격", 100);
            ReleaseListView[cnt - 1].Columns.Add("수량", 100);
            foreach (ListViewItem item in ProductListView.Items)
            {
                if (item.SubItems[3].Text != "0")
                {
                    ListViewItem lvi = new ListViewItem(new string[]{item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text,
                        item.SubItems[3].Text });
                    ReleaseListView[cnt - 1].Items.Add(lvi);
                }
            }
            //ListViewItem item = new ListViewItem(new string[] { "a", "b", "c" });

            FranTabControl.TabPages[ReleaseListView.Count - 1].Controls.Add(ReleaseListView[cnt - 1]);
        }

        /*---------------------------------------------------------------------
        메서드명: button1_Click : void 

        기능 : 탭 초기화 하는 기능

        만든날짜: 2023-05-15

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            ReleaseListView[FranTabControl.SelectedIndex].Items.Clear();
        }
    }
}
