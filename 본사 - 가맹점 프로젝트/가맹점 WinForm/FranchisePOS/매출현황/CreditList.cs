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
    public partial class CreditList : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string Date;
        private string LastDay;
        private string RegiNum;

        public CreditList(string regiNum)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Date = DT.Value.ToString("yyyyMMdd");
            RegiNum = regiNum;
            
                
        }

        private void CreditList_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            if (rbDay.Checked)
            {
                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Option] = '현금' and [Date] Between '" + Date
                    + "' and '" + (Convert.ToInt32(Date) + 1).ToString() + "'";
            }
            else if (rbMonth.Checked)
            {
                Date = Month();
                string LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                    Convert.ToInt32(Date.Substring(4, 2))).ToString();

                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Option] = '현금' and [Date] Between '" + Date
                    + "01' and '" + Date + LastDay + "'";
            }

            var myRead = Comm.ExecuteReader();

            CreditListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[2].ToString(),myRead[1].ToString(),
                    myRead[3].ToString() });

                this.CreditListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbDay.Checked)
            {
                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Option] = '현금' and [Date] Between '" + Date
                    + "' and '" + (Convert.ToInt32(Date) + 1).ToString() + "'";
            }
            else if(rbMonth.Checked)
            {
                Date = Month();
                string LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                    Convert.ToInt32(Date.Substring(4, 2))).ToString();

                Comm.CommandText = "Select [RegiNum],[Price],[Content],[Date] From Pay" +
                    " Where [RegiNum] = '" + RegiNum + "' and [Option] = '현금' and [Date] Between '" + Date
                    + "01' and '" + Date + LastDay + "'";
            }

            var myRead = Comm.ExecuteReader();

            CreditListView.Items.Clear();

            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[2].ToString(),myRead[1].ToString(),
                    myRead[3].ToString() });

                this.CreditListView.Items.Add(lvi);
            }

            myRead.Close();
        }*/

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void CreditList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            FormCloseEvent();
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

        private string Month()
        {
            LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
               Convert.ToInt32(Date.Substring(4, 2))).ToString();
            return Date = Date.Substring(0, 6);
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonth.Checked)
            {
                DT.CustomFormat = "yyyy-MM";
            }
            else
            {
                DT.CustomFormat = "yyyy-MM-dd";
            }
            DataLoad();
        }
    }
}
