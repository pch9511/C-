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
    public partial class TotalProfit : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private string Date;
        private string LastDay;
        private string RegiNum;

        public TotalProfit(string regiNum)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Date = DT.Value.ToString("yyyyMM");
            LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                Convert.ToInt32(Date.Substring(4, 2))).ToString();
            RegiNum = regiNum;
        }

        private void TotalProfit_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void DataLoad()
        {
            Comm.CommandText = "Select [RegiNum],[Name],[Price],[Date] From FranStock " +
                "Where RegiNum = '" + RegiNum + "' and [Date] Between '" + Date + "01' and '"
                    + Date + LastDay + "' UNION " +
                "Select [RegiNum],[Content],[Price],[Date] From Pay Where RegiNum = '" +
                RegiNum + "' and [Date] Between '" + Date + "01' and '"
                    + Date + LastDay + "' Order by [Date] Asc";

            var myRead = Comm.ExecuteReader();

            TotalListView.Items.Clear();
            while (myRead.Read())
            {
                ListViewItem lvi =
                new ListViewItem(new string[] {  myRead[0].ToString(),
                    myRead[1].ToString(),myRead[2].ToString(),
                    myRead[3].ToString() });

                this.TotalListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DT_ValueChanged(object sender, EventArgs e)
        {
            Date = DT.Value.ToString("yyyyMM");
            LastDay = DateTime.DaysInMonth(Convert.ToInt32(Date.Substring(0, 4)),
                Convert.ToInt32(Date.Substring(4, 2))).ToString();
            DataLoad();
        }

        private void TotalProfit_FormClosing(object sender, FormClosingEventArgs e)
        {           
            FormCloseEvent();
        }
    }
}
