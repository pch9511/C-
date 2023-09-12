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
    public partial class PaySelect : Form
    {
        public delegate void WhichPayHandelr(string WhichPay);
        public event WhichPayHandelr WhichPayEvent;
        public PaySelect()
        {
            InitializeComponent();
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            WhichPayEvent("현금");
            this.Close();
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            WhichPayEvent("카드");
            this.Close();
        }
    }
}
