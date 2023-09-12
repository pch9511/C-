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
    public partial class ProfitMenu : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private string RegiNum;
        public ProfitMenu(string regiNum)
        {
            InitializeComponent();
            RegiNum = regiNum;
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            CreditList wf = new CreditList(RegiNum);
            wf.FormCloseEvent += new CreditList.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            CardList wf = new CardList(RegiNum);
            wf.FormCloseEvent += new CardList.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            SellList wf = new SellList(RegiNum);
            wf.FormCloseEvent += new SellList.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            TotalProfit wf = new TotalProfit(RegiNum);
            wf.FormCloseEvent += new TotalProfit.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        private void ShowEvent()
        {
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProfitMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }
    }
}
