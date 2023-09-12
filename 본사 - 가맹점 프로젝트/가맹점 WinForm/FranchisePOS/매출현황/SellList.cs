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
    public partial class SellList : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string Date;
        private string RegiNum;
        private string LastDay;
        private int Card, Credit;


        public SellList(string regiNum)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Date = DT.Value.ToString("yyyyMMdd");
            RegiNum = regiNum;

        }

        private void SellList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            Card = 0;
            Credit = 0;

            if (rbDay.Checked)
            {
                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date],[Option] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Date] Between '" + Date + "' and '"
                    + (Convert.ToInt32(Date) + 1).ToString() + "'";
            }
            else if (rbMonth.Checked)
            {
                Date = Month();
                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date],[Option] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Date] Between '" + Date + "01' and '"
                    + Date + LastDay + "'";
            }

            var myRead = Comm.ExecuteReader();

            SellListView.Items.Clear();
            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[2].ToString(),myRead[1].ToString(),
                    myRead[3].ToString() });

                if(myRead[4].ToString() == "현금")
                {
                    Credit += Convert.ToInt32(myRead[1].ToString());
                }
                else if(myRead[4].ToString() == "카드")
                {
                    Card += Convert.ToInt32(myRead[1].ToString());
                }

                this.SellListView.Items.Add(lvi);
            }

            lblCard.Text = "카드 : " + Card.ToString();
            lblCredit.Text = "현금 : " + Credit.ToString();
            lblTotal.Text = "총 판매 금액 : " + (Card + Credit).ToString();
            myRead.Close();
        }

        /*private void btnSearch_Click(object sender, EventArgs e)
        {
            Card = 0;
            Credit = 0;

            if (rbDay.Checked)
            {
                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date],[Option] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Date] Between '" + Date + "' and '" 
                    + (Convert.ToInt32(Date) + 1).ToString() + "'";
            }
            else if (rbMonth.Checked)
            {
                Date = Month();
                string LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                    Convert.ToInt32(Date.Substring(4, 2))).ToString();

                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date],[Option] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Date] Between '" + Date + "01' and '" 
                    + Date + LastDay + "'";
            }

            var myRead = Comm.ExecuteReader();

            SellListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[2].ToString(),myRead[1].ToString(),
                    myRead[3].ToString() });

                if (myRead[4].ToString() == "현금")
                {
                    Credit += Convert.ToInt32(myRead[1].ToString());
                }
                else if (myRead[4].ToString() == "카드")
                {
                    Card += Convert.ToInt32(myRead[1].ToString());
                }

                this.SellListView.Items.Add(lvi);
            }

            lblCard.Text = "카드 : " + Card.ToString();
            lblCredit.Text = "현금 : " + Credit.ToString();
            lblTotal.Text = "총 판매 금액 : " + (Card + Credit).ToString();
            myRead.Close();
        }*/

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DT_ValueChanged(object sender, EventArgs e)
        {
            if (rbMonth.Checked)
            {
                Date = DT.Value.ToString("yyyyMM");
            }
            else
            {
                Date = DT.Value.ToString("yyyyMMdd");
            }
            DataLoad();
        }

        private void SellList_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMonth.Checked)
            {
                DT.CustomFormat = "yyyy-MM";
            }
            else
            {
                DT.CustomFormat = "yyyy-MM-dd";
            }
            DataLoad();
        }

        private string Month()
        {
            LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                Convert.ToInt32(Date.Substring(4, 2))).ToString();
            return Date = Date.Substring(0, 6);
        }
    }
}
