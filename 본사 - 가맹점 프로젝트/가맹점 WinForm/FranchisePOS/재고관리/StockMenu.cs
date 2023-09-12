using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FranchisePOS
{
    public partial class StockMenu : Form
    {
        MainForm wf;
        string id;

        /*---------------------------------------------------------------------
        메서드명: StockMenu 

        기능 : StockMenu 클래스 생성자 

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StockMenu(MainForm Wf, string Id)
        {
            InitializeComponent();
            wf = Wf;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: btnOrder_Click : void 

        기능 : 발주요청 창 여는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOrder_Click(object sender, EventArgs e)
        {
            StockOrder wf = new StockOrder(id);
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnOrderList_Click : void 

        기능 : 발주내역 창 여는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOrderList_Click(object sender, EventArgs e)
        {
            StockOrderList wf = new StockOrderList(id);
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnOrderCancel_Click : void 

        기능 : 발주취소 창 여는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOrderCancel_Click(object sender, EventArgs e)
        {
            StockOrderCancel wf = new StockOrderCancel();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnStockList_Click : void 

        기능 : 재고내역 창 여는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnStockList_Click(object sender, EventArgs e)
        {
            StockList wf = new StockList(id);
            wf.ShowDialog();
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
        메서드명: StockMenu_FormClosing : void 

        기능 : 현재 창을 닫고 난 후 이전 창을 보여주는 기능

        만든날짜: 2023-04-14

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StockMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            wf.Show();
        }
    }
}
