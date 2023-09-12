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

//수정해야함 아직 

namespace FranchisePOS
{
    public partial class StockOrderCancel : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string BackReaseon;


        /*---------------------------------------------------------------------
        메서드명: StockOrderCancel 

        기능 : StockOrderCancel 클래스 생성자

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StockOrderCancel()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            BackReaseon = rbBack1.Text;
        }

        /*---------------------------------------------------------------------
        메서드명: StockOrderCancel_Load : void 

        기능 : 해당 창 로드 시 발생하는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockOrderCancel_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void 

        기능 : DB에서 주문 요청한 리스트를 가져와 리스트뷰에서 보여주는 기능

        만든날짜: 2023-04-17

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
                    new ListViewItem(new string[] { "", myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString(), myRead[6].ToString() });

                this.OrderListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void 

        기능 : 조회 버튼 클릭 시 조건에 맞는 정보를 DB에서 가져와 리스트뷰에 보여줌

        만든날짜: 2023-04-17

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
                    new ListViewItem(new string[] { "", myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString(), myRead[6].ToString() });

                this.OrderListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void 

        기능 : 전체리스트 버튼 클릭시 전체리스트를 리스트뷰에서 다시 보여주는 기능

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
        메서드명: btnCancel_Click : void 

        기능 : 취소 요청을 하는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("선택한 제품들을 반품요청을 하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (ListViewItem Item in OrderListView.CheckedItems)
                    {
                        if (Item.Checked)
                        {
                            if(Item.SubItems[7].Text.Contains("반품완료"))
                            {
                                throw new Exception("선택한 제품들중 반품이 완료된 제품이 있습니다.");
                            }
                            Comm.CommandText = "Update [Order] Set [State] = '반품요청 : " + BackReaseon + "' Where Num = "
                                + Convert.ToInt32(Item.SubItems[1].Text);

                            try
                            {
                                Comm.ExecuteNonQuery();
                                MessageBox.Show("반품 요청을 했습니다.");
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void 

        기능 : 버튼 클릭 시 현재 창을 닫는 기능

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
        메서드명: StockOrderCancel_FormClosing : void 

        기능 : 창을 닫을 때 DB 연결을 끊는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockOrderCancel_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("반품완료된 목록은 자동으로 삭제됩니다.");
            Comm.CommandText = "Delete From [Order] Where [State] = '반품완료'";

            Comm.ExecuteNonQuery();

            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: OrderListView_SelectedIndexChanged : void 

        기능 : 리스트뷰에서 목록 선택 시 해당 인덱스의 정보를 가져오는 기능

        만든날짜: 2023-04-17

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void OrderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.OrderListView.SelectedItems.Count > 0)
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
                //Price = this.OrderListView.Items[index].SubItems[3].Text;
            }
        }

        //2023-05-17
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

        private void OrderListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void OrderListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void rbBack1_CheckedChanged(object sender, EventArgs e)
        {
            if(rbBack1.Checked)
            {
                BackReaseon = rbBack1.Text;
            }
        }

        private void rbBack2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBack2.Checked)
            {
                BackReaseon = rbBack2.Text;
            }
        }

        private void rbBack3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBack3.Checked)
            {
                BackReaseon = rbBack3.Text;
            }
        }
    }
}
