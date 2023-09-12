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
using System.Threading;

namespace Franchise
{
    public partial class Profit : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private SqlCommand Comm2;
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private int ComTotal = 0;
        private int FrTotal = 0;
        private int TotalIn = 0;
        private int TotalOut = 0;
        private int TotalBack = 0;
        List<ListView> ListViews = new List<ListView>();
        List<string> RegiNum = new List<string>();
        private string Query = string.Empty;
        private string Query2 = string.Empty;
        private string Query3 = string.Empty;
        private string ftQuery, ftQuery2, ftQuery3;
        private string mdQuery, mdQuery2, mdQuery3;
        private string ltQuery, ltQuery2, ltQuery3;
        private string FranSelection = string.Empty;
        private int index = 0;
        private Thread Top5;
        private Object obj = new Object();
        private bool Run = true;
        //05-03

        /*---------------------------------------------------------------------
        메서드명: Profit

        기능 : Profit 클래스의 생성자

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Profit()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Comm2 = new SqlCommand();
            Comm2.Connection = Conn;
            Query = "Select * From [HeadStock] Where State = '입고' Order by [Date] Desc";
            Query2 = "Select * From [HeadStock] Where State = '출고' Order by [Date] Desc";
            Query3 = "Select * From [ItemBack] Order by [Date] Desc";
            mdQuery = "From [HeadStock] Where State = '입고'";
            mdQuery2 = "From [HeadStock] Where State = '출고'";
            mdQuery3 = "From [ItemBack]";
            ftQuery = string.Empty;
            ftQuery2 = string.Empty;
            ftQuery3 = string.Empty;
            ltQuery = string.Empty;
            ltQuery2 = string.Empty;       
            for (int i=0; i<4; i++)
            {
                ListViews.Add(new ListView());
            }
        }


        /*---------------------------------------------------------------------
        메서드명: Profit_Load : void

        기능 : 해당 창 로드시 발생하는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Profit_Load(object sender, EventArgs e)
        {   
            CreateListView();
            cbDataLoad();
            Calc();
            label1.Text = "순이익 : " + ComTotal.ToString();
            label4.Text = "총 매입 : " + TotalIn.ToString();
            label2.Text = "총 매출 : " + TotalOut.ToString();
            label3.Text = "총 반품액 : " + TotalBack.ToString();

            Top5 = new Thread(() => Top5Load());
            Top5.IsBackground = true;
            Top5.Start();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 매출 관련 리스트를 DB에서 가져오는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            
            Comm.CommandText = Query;

            var myRead = Comm.ExecuteReader();

            TotalIn = 0;

            while (myRead.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[2].ToString(),
                    myRead[3].ToString(),myRead[5].ToString(), myRead[6].ToString() });
                ListViews[0].Items.Add(lvi);
                TotalIn += Convert.ToInt32(myRead[3].ToString()) * Convert.ToInt32(myRead[5].ToString());
            }
            this.ProfitTabControl.TabPages[0].Controls.Add(ListViews[0]);
            myRead.Close();
        }

        private void DataLoad2()
        {
            Comm.CommandText = Query2;

            var myRead = Comm.ExecuteReader();

            TotalOut = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    "", myRead[2].ToString(), myRead[4].ToString(), (Convert.ToInt32(myRead[5].ToString()) * -1).ToString(),
                    myRead[6].ToString(), myRead[8].ToString() });

                ListViews[1].Items.Add(lvi);
                TotalOut += Convert.ToInt32(myRead[4].ToString()) * Convert.ToInt32(myRead[5].ToString()) * -1;
            }

            myRead.Close();

            foreach(ListViewItem a in  ListViews[1].Items)
            {
                a.SubItems[2].Text = getFranName(a.SubItems[1].Text);
            }

            this.ProfitTabControl.TabPages[1].Controls.Add(ListViews[1]);

        }

        private void DataLoad3()
        {
            Comm.CommandText = Query3;

            var myRead = Comm.ExecuteReader();

            TotalBack = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(),"", myRead[3].ToString(), myRead[5].ToString(),
                    myRead[6].ToString(), myRead[7].ToString(), myRead[8].ToString() });

                ListViews[2].Items.Add(lvi);
                TotalBack += Convert.ToInt32(myRead[5].ToString()) * Convert.ToInt32(myRead[6].ToString());
            }

            myRead.Close();

            foreach (ListViewItem a in ListViews[2].Items)
            {
                a.SubItems[3].Text = getFranName(a.SubItems[2].Text);
            }
            this.ProfitTabControl.TabPages[2].Controls.Add(ListViews[2]);
        }

        /*---------------------------------------------------------------------
        메서드명: Calc : void

        기능 : 총 매상매출을 계산하는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Calc()
        {
            ComTotal = 0;

            ComTotal = TotalOut - TotalIn - TotalBack;

            FrTotal = 0;

            FrTotal = TotalOut - TotalIn + TotalBack;
        }

        /*---------------------------------------------------------------------
        메서드명: Profit_FormClosing : void

        기능 : 해당 창을 닫을때 발생하는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Profit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            FormCloseEvent();
            if(Top5 != null)
            {
                Run = false;
                Top5.Abort();
            }
        }


        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 종료 버튼 클릭 시 발생하는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 조건에 맞는 리스트뷰를 보여주는 기능

        만든날짜: 2023-05-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!cbFr.Checked && !cbPr.Checked)
            {

                if (rbCompany.Checked)
                {
                    Query = "Select * From [HeadStock] Where State = '입고'" + FranSelection + " Order by [Date] Desc";
                    Query2 = "Select * From [HeadStock] Where State = '출고'" + FranSelection + " Order by [Date] Desc";
                    Query3 = "Select * From [ItemBack]" + FranSelection + " Order by [Date] Desc";
                }
                else
                {
                    Query = "Select * From [FranStock] Where State = '입고'" + FranSelection + " Order by [Date] Desc";
                    Query2 = "Select * From [SellProduct]" + FranSelection + " Order by [Date] Desc";
                    Query3 = "Select * From [ItemBack]" + FranSelection + " Order by [Date] Desc";
                }
            }
            else
            {
                Query = ftQuery + mdQuery + FranSelection + ltQuery;
                if (cbFr.Checked && rbCompany.Checked)
                {
                    Query = "Select * From [HeadStock] Where State = '입고'" + FranSelection + " Order by [Date] Desc";
                    Query2 = ftQuery2 + mdQuery2 + FranSelection + ltQuery2;
                }
                else if(cbPr.Checked && rbFran.Checked)
                {
                    Query2 = ftQuery2 + mdQuery2 + FranSelection + ltQuery2;
                }
                else
                {
                    Query2 = ftQuery2 + mdQuery2 + FranSelection + ltQuery;
                }
                Query3 = ftQuery3 + mdQuery3 + FranSelection + ltQuery3;

            }
            if (!Query.Contains("Where"))
            {
                Query = Query.Replace("and", "Where");
            }
            if (!Query2.Contains("Where"))
            {
                Query2 = Query2.Replace("and", "Where");
            }
            if (!Query3.Contains("Where"))
            {
                Query3 = Query3.Replace("and", "Where");
            }
            CreateListView();

            Calc();
            label1.Text = "총 매출 : " + FrTotal.ToString();
            label4.Text = "총 매입 : " + TotalIn.ToString();
            label2.Text = "총 매출 : " + TotalOut.ToString();
            label3.Text = "총 반품액 : " + TotalBack.ToString();
        }

        private void ComFranLoad()
        {
            Comm.CommandText = Query2;

            var myRead = Comm.ExecuteReader();

            TotalOut = 0;

            while (myRead.Read())
            {               
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(), "",
                    myRead[1].ToString(), myRead[2].ToString(), myRead[3].ToString() });

                ListViews[1].Items.Add(lvi);
                TotalOut += Convert.ToInt32(myRead[1].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            foreach (ListViewItem a in ListViews[1].Items)
            {
                a.SubItems[1].Text = getFranName(a.SubItems[0].Text);
            }

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[1].Controls.Add(ListViews[1]);
        }

        private void ComFranLoad2()
        {
            Comm.CommandText = Query3;

            var myRead = Comm.ExecuteReader();

            TotalBack = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;
                //Calc(Convert.ToInt32(myRead[3].ToString()), Convert.ToInt32(myRead[4].ToString()));
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), "",
                    myRead[1].ToString(), myRead[2].ToString() , myRead[3].ToString() });

                ListViews[2].Items.Add(lvi);
                TotalBack += Convert.ToInt32(myRead[1].ToString());
                //Calc(Convert.ToInt32(myRead[5].ToString()), Convert.ToInt32(myRead[6].ToString()));
            }

            myRead.Close();

            foreach (ListViewItem a in ListViews[2].Items)
            {
                a.SubItems[1].Text = getFranName(a.SubItems[0].Text);
            }
            //label3.Text = "총 반품액 : " + TotalBack.ToString();
            this.ProfitTabControl.TabPages[2].Controls.Add(ListViews[2]);
        }

        private void ComPrLoad()
        {
            Comm.CommandText = Query;

            var myRead = Comm.ExecuteReader();

            TotalIn = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[1].ToString(), myRead[2].ToString() });

                ListViews[0].Items.Add(lvi);
                TotalIn += Convert.ToInt32(myRead[1].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[0].Controls.Add(ListViews[0]);
        }

        private void ComPrLoad2()
        {
            Comm.CommandText = Query2;

            var myRead = Comm.ExecuteReader();

            TotalOut = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[1].ToString(), myRead[2].ToString() });

                ListViews[1].Items.Add(lvi);
                TotalOut += Convert.ToInt32(myRead[1].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[1].Controls.Add(ListViews[1]);
        }

        private void ComPrLoad3()
        {
            Comm.CommandText = Query3;

            var myRead = Comm.ExecuteReader();

            TotalBack = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[1].ToString(), myRead[2].ToString() ,myRead[3].ToString() });

                ListViews[2].Items.Add(lvi);
                TotalBack += Convert.ToInt32(myRead[1].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[2].Controls.Add(ListViews[2]);
        }

        private void FranDefaultLoad()
        {
            Comm.CommandText = Query;

            var myRead = Comm.ExecuteReader();

            TotalIn = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[1].ToString(), myRead[2].ToString(),
                    myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString() });

                ListViews[0].Items.Add(lvi);
                TotalIn += Convert.ToInt32(myRead[3].ToString()) * Convert.ToInt32(myRead[4].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[0].Controls.Add(ListViews[0]);
        }

        private void FranDefaultLoad2()
        {
            Comm.CommandText = Query2;

            var myRead = Comm.ExecuteReader();

            TotalOut = 0;

            while (myRead.Read())
            {
                ListViewItem lvi;

                lvi = new ListViewItem(new string[] { myRead[0].ToString(),
                    myRead[1].ToString(), myRead[2].ToString(),
                    myRead[3].ToString(), myRead[4].ToString(),
                    myRead[5].ToString() });

                ListViews[1].Items.Add(lvi);
                TotalOut += Convert.ToInt32(myRead[3].ToString()) * Convert.ToInt32(myRead[4].ToString());
                //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
            }

            myRead.Close();

            //label2.Text = "총 매출 : " + TotalOut.ToString();
            this.ProfitTabControl.TabPages[1].Controls.Add(ListViews[1]);
        }
        //2023-06-16
        private void CreateListView()
        {
            ListViews[3].Clear();
            ListViews[3].View = View.Details;
            ListViews[3].FullRowSelect = true;
            ListViews[3].SetBounds(0, 0, 733, 277);
            ListViews[3].GridLines = false;
            ListViews[3].Columns.Add("RegiNum", 200);
            ListViews[3].Columns.Add("총 수량", 100);
            ListViews[3].Columns.Add("불량 수량 ", 100);
            ListViews[3].Columns.Add("불량률", 100);
            if (rbCompany.Checked)
            {
                if (cbFr.Checked)
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("ID", 0);
                    ListViews[0].Columns.Add("상품명", 150);
                    ListViews[0].Columns.Add("가격", 100);
                    ListViews[0].Columns.Add("수량", 100);
                    ListViews[0].Columns.Add("입고일", 300);

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("RegiNum", 200);
                    ListViews[1].Columns.Add("가맹점명", 150);
                    ListViews[1].Columns.Add("총 금액", 100);
                    ListViews[1].Columns.Add("총 수량", 100);
                    ListViews[1].Columns.Add("지불방식", 100);

                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("RegiNum", 200);
                    ListViews[2].Columns.Add("가맹점명", 150);
                    ListViews[2].Columns.Add("총 금액", 100);
                    ListViews[2].Columns.Add("총 수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 150);

                    ListViews[3].Columns[0].Text = "RegiNum";

                    //가맹점 기준
                    DataLoad();
                    ComFranLoad();
                    ComFranLoad2();
                    Faulty();
                }
                else if (cbPr.Checked)
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("상품코드", 200);
                    ListViews[0].Columns.Add("총 금액", 100);
                    ListViews[0].Columns.Add("총 수량", 100);

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("상품코드", 200);
                    ListViews[1].Columns.Add("총 금액", 100);
                    ListViews[1].Columns.Add("총 수량", 100);

                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("상품코드", 200);
                    ListViews[2].Columns.Add("총 금액", 100);
                    ListViews[2].Columns.Add("총 수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 150);

                    ListViews[3].Columns[0].Text = "상품코드";
                    ComPrLoad();
                    ComPrLoad2();
                    ComPrLoad3();
                    //제품
                    Faulty2();
                }
                else
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("ID", 0);
                    ListViews[0].Columns.Add("상품명", 150);
                    ListViews[0].Columns.Add("가격", 100);
                    ListViews[0].Columns.Add("수량", 100);
                    ListViews[0].Columns.Add("입고일", 300);

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("ID", 0);
                    ListViews[1].Columns.Add("RegiNum", 0);
                    ListViews[1].Columns.Add("가맹점명", 150);
                    ListViews[1].Columns.Add("상품명", 150);
                    ListViews[1].Columns.Add("가격", 100);
                    ListViews[1].Columns.Add("수량", 90);
                    ListViews[1].Columns.Add("판매일", 150);
                    ListViews[1].Columns.Add("지불방식", 80);

                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("Num", 0);
                    ListViews[2].Columns.Add("ID", 0);
                    ListViews[2].Columns.Add("RegiNum", 0);
                    ListViews[2].Columns.Add("가맹점명", 150);
                    ListViews[2].Columns.Add("상품명", 100);
                    ListViews[2].Columns.Add("가격", 100);
                    ListViews[2].Columns.Add("수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 100);
                    ListViews[2].Columns.Add("날짜", 150);

                    ListViews[3].Columns[0].Width = 0;

                    DataLoad();
                    DataLoad2();
                    DataLoad3();
                    //전체 기준
                    Faulty3();
                }
            }  
            else
            {
                if (cbFr.Checked)
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("RegiNum", 200);
                    ListViews[0].Columns.Add("총 매입액", 100);
                    ListViews[0].Columns.Add("총 수량", 100);                  

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("RegiNum", 200);
                    ListViews[1].Columns.Add("총 판매액", 100);
                    ListViews[1].Columns.Add("총 수량", 100);
                
                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("RegiNum", 200);
                    ListViews[2].Columns.Add("가맹점명", 150);
                    ListViews[2].Columns.Add("총 금액", 100);
                    ListViews[2].Columns.Add("총 수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 150);

                    ListViews[3].Columns[0].Text = "RegiNum";

                    ComPrLoad();
                    ComPrLoad2();
                    ComFranLoad2();
                    FrFaulty();
                }
                else if (cbPr.Checked)
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("상품코드", 200);
                    ListViews[0].Columns.Add("총 금액", 100);
                    ListViews[0].Columns.Add("총 수량", 100);

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("상품코드", 200);
                    ListViews[1].Columns.Add("총 금액", 100);
                    ListViews[1].Columns.Add("총 수량", 100);

                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("상품코드", 200);
                    ListViews[2].Columns.Add("총 금액", 100);
                    ListViews[2].Columns.Add("총 수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 150);

                    ListViews[3].Columns[0].Text = "상품코드";
                    //추가해야함
                    ComPrLoad();
                    ComPrLoad2();
                    ComPrLoad3();
                    FrFaulty2();

                }
                else
                {
                    ListViews[0].Clear();
                    ListViews[0].View = View.Details;
                    ListViews[0].FullRowSelect = true;
                    ListViews[0].SetBounds(0, 0, 733, 277);
                    ListViews[0].GridLines = false;
                    ListViews[0].Columns.Add("ID", 0);
                    ListViews[0].Columns.Add("RegiNum", 100);
                    ListViews[0].Columns.Add("상품명", 150);
                    ListViews[0].Columns.Add("가격", 100);
                    ListViews[0].Columns.Add("수량", 100);
                    ListViews[0].Columns.Add("입고일", 150);

                    ListViews[1].Clear();
                    ListViews[1].View = View.Details;
                    ListViews[1].FullRowSelect = true;
                    ListViews[1].SetBounds(0, 0, 733, 277);
                    ListViews[1].GridLines = false;
                    ListViews[1].Columns.Add("ID", 0);
                    ListViews[1].Columns.Add("RegiNum", 0);
                    ListViews[1].Columns.Add("제품명", 150);
                    ListViews[1].Columns.Add("가격", 100);
                    ListViews[1].Columns.Add("수량", 90);
                    ListViews[1].Columns.Add("판매일", 150);

                    ListViews[2].Clear();
                    ListViews[2].View = View.Details;
                    ListViews[2].FullRowSelect = true;
                    ListViews[2].SetBounds(0, 0, 733, 277);
                    ListViews[2].GridLines = false;
                    ListViews[2].Columns.Add("Num", 0);
                    ListViews[2].Columns.Add("ID", 0);
                    ListViews[2].Columns.Add("RegiNum", 0);
                    ListViews[2].Columns.Add("가맹점명", 150);
                    ListViews[2].Columns.Add("상품명", 100);
                    ListViews[2].Columns.Add("가격", 100);
                    ListViews[2].Columns.Add("수량", 100);
                    ListViews[2].Columns.Add("반품 사유", 100);
                    ListViews[2].Columns.Add("날짜", 150);

                    ListViews[3].Columns[0].Width = 0;

                    FranDefaultLoad();
                    FranDefaultLoad2();
                    DataLoad3();
                    FrFaulty3();
                }
            }
            this.ProfitTabControl.TabPages[3].Controls.Add(ListViews[3]);
        }

        private void cbDataLoad()
        {
            Comm.CommandText = "SELECT [RegistrationNumber] FROM FranchiseInfo";

            var myRead = Comm.ExecuteReader();

            cbList.Items.Clear();

            while(myRead.Read())
            {
                cbList.Items.Add(myRead[0].ToString());
            }


            myRead.Close();
        }

        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            if(rbCompany.Checked)
            {
                mdQuery = "From [HeadStock] Where State = '입고'";
                mdQuery2 = "From [HeadStock] Where State = '출고'";
                mdQuery3 = "From [ItemBack]";
            }
            else
            {
                mdQuery = "From [FranStock] Where State = '입고'";
                mdQuery2 = "From [SellProduct]";
                mdQuery3 = "From [ItemBack]";
            }
            QuerySet();
        }

        private void cbList_TextChanged(object sender, EventArgs e)
        {
            if (cbList.Text == "")
            {
                FranSelection = "";
            }
            else
            {
                FranSelection = " and RegiNum = '";
                FranSelection += cbList.Text + "' ";
            }
        }

        //탭페이지 클릭 시 나타나는 기능
        private void ProfitTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            index = ProfitTabControl.SelectedIndex;
        }

        private string getFranName(string RegiNum)
        {
            Comm.CommandText = "Select [Name] From [FranchiseInfo] Where [RegistrationNumber] = '"
                 + RegiNum + "'";

            string Name = string.Empty;

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                Name = myRead[0].ToString();
            }

            myRead.Close();

            return Name;
        }

        private void cbFr_Click(object sender, EventArgs e)
        {
            if (cbPr.Checked)
            {
                cbPr.Checked = false;
                cbFr.Checked = true;
            }
            QuerySet();
        }

        private void cbPr_Click(object sender, EventArgs e)
        {
            if (cbFr.Checked)
            {
                cbPr.Checked = true;
                cbFr.Checked = false;
            }
            QuerySet();
        }

        private void QuerySet()
        {
            if (cbFr.Checked)
            {
                if (rbCompany.Checked)
                {
                    ftQuery = "Select * ";
                    ftQuery2 = "Select [RegiNum],Sum(Account * -OutPrice) as 매출액,Sum(-Account),[Pay] ";
                    ltQuery2 = " Group by [RegiNum],[Pay]";
                }
                else
                {
                    ftQuery = "Select [RegiNum],Sum(Account * Price) as '총 매입액', Sum(Account) as '총 매입수량' ";
                    ftQuery2 = "Select [RegiNum],Sum(Account * Price) as '총 판매액', Sum(Account) as '총 판매수량' ";
                }
                ltQuery = " Group by [RegiNum]";
                ltQuery3 = " Group by [RegiNum],[State]";
                ftQuery3 = "Select RegiNum,Sum(Account * OutPrice),Sum(Account),[State] ";
            }
            else if (cbPr.Checked)
            {
                if (rbCompany.Checked)
                {
                    ftQuery = "Select [Id],Sum(Account * InPrice) as 매입총액,Sum(Account) as 수량 ";
                    ftQuery2 = "Select [Id],Sum(Account * -OutPrice) as 매출총액,Sum(-Account) as 수량 ";
                }
                else
                {
                    ftQuery = "Select [Id],Sum(Account * Price) as '총 매입액', Sum(Account) as '총 매입수량' ";
                    ftQuery2 = "Select [Name],Sum(Account * Price) as '총 판매액', Sum(Account) as '총 판매수량' ";
                    ltQuery2 = "Group by [Name]";
                }
                ltQuery = " Group by [Id]";
                ltQuery3 = " Group by [Id],[State]";
                ftQuery3 = "Select [Id],Sum(Account * OutPrice) as 반품총액,Sum(Account) as 수량,[State] ";
            }
        }

        private void Top5Load()
        {
            while (Run)
            {
                lock (obj)
                {
                    Comm2.CommandText = "Select Top(5)[Name],Sum(Account) as 판매량 From[SellProduct] Group by[Name]";

                    var myRead2 = Comm2.ExecuteReader();

                    if (Top5ListVIew.InvokeRequired)
                    {
                        Top5ListVIew.Invoke(new MethodInvoker(delegate { Top5ListVIew.Items.Clear(); }));
                    }
                    else
                    {
                        Top5ListVIew.Items.Clear();
                    }

                    while (myRead2.Read())
                    {
                        ListViewItem lvi;

                        lvi = new ListViewItem(new string[] { myRead2[0].ToString(),
                    myRead2[1].ToString() });

                        if (Top5ListVIew.InvokeRequired)
                        {
                            Top5ListVIew.Invoke(new MethodInvoker(delegate { Top5ListVIew.Items.Add(lvi); }));
                        }
                        else
                        {
                            Top5ListVIew.Items.Add(lvi);
                        }

                        //Calc(Convert.ToInt32(myRead[4].ToString()), Convert.ToInt32(myRead[5].ToString()));
                    }

                    myRead2.Close();

                    //label2.Text = "총 매출 : " + TotalOut.ToString();
                    Thread.Sleep(10000);
                }
            }
        }

        private void Faulty()
        {
            //가맹점            
            foreach (ListViewItem item in ListViews[1].Items)
            {
                int PrOut = 0;
                int PrFaulty = 0;
                string regiNum = string.Empty;
                PrOut += Convert.ToInt32(item.SubItems[3].Text);
                regiNum = item.SubItems[0].Text;
                foreach (ListViewItem item2 in ListViews[2].Items)
                {
                    if (item2.SubItems[0].Text == regiNum)
                    {
                        if (item2.SubItems[4].Text.Contains("불량"))
                        {
                            PrFaulty += Convert.ToInt32(item2.SubItems[3].Text);
                        }
                    }
                }
                ListViewItem lvi;
                double val = (double)PrFaulty / PrOut;

                lvi = new ListViewItem(new string[] { regiNum ,PrOut.ToString(),
                            PrFaulty.ToString(), val.ToString("00%") });

                ListViews[3].Items.Add(lvi);
            }
        }

        private void Faulty2()
        {
            //제품
            foreach (ListViewItem item in ListViews[1].Items)
            {
                int PrOut = 0;
                int PrFaulty = 0;
                string PCode = string.Empty;
                PrOut += Convert.ToInt32(item.SubItems[2].Text);
                PCode = item.SubItems[0].Text;
                foreach (ListViewItem item2 in ListViews[2].Items)
                {
                    if (item2.SubItems[0].Text == PCode)
                    {
                        if (item2.SubItems[3].Text.Contains("불량"))
                        {
                            PrFaulty += Convert.ToInt32(item2.SubItems[2].Text);
                        }
                    }
                }
                ListViewItem lvi;
                double val = (double)PrFaulty / PrOut;

                lvi = new ListViewItem(new string[] { PCode ,PrOut.ToString(),
                            PrFaulty.ToString(), val.ToString("00%") });

                ListViews[3].Items.Add(lvi);
            }
        }

        private void Faulty3()
        {
            //본사
            int PrOut = 0;
            int PrFaulty = 0;
            foreach (ListViewItem item in ListViews[1].Items)
            {
                PrOut += Convert.ToInt32(item.SubItems[5].Text);
            }
            foreach (ListViewItem item in ListViews[2].Items)
            {
                if (item.SubItems[7].Text.Contains("불량"))
                {
                    PrFaulty += Convert.ToInt32(item.SubItems[6].Text);
                }
            }

            ListViewItem lvi;
            double val = (double)PrFaulty / PrOut;

            lvi = new ListViewItem(new string[] { "",PrOut.ToString(),
                    PrFaulty.ToString(), val.ToString("00%") });

            ListViews[3].Items.Add(lvi);
        }

        private void FrFaulty()
        {
            //가맹점            
            foreach (ListViewItem item in ListViews[0].Items)
            {
                int PrOut = 0;
                int PrFaulty = 0;
                string regiNum = string.Empty;
                PrOut += Convert.ToInt32(item.SubItems[2].Text);
                regiNum = item.SubItems[0].Text;
                foreach (ListViewItem item2 in ListViews[2].Items)
                {
                    if (item2.SubItems[0].Text == regiNum)
                    {
                        if (item2.SubItems[4].Text.Contains("불량"))
                        {
                            PrFaulty += Convert.ToInt32(item2.SubItems[3].Text);
                        }
                    }
                }
                ListViewItem lvi;
                double val = (double)PrFaulty / PrOut;

                lvi = new ListViewItem(new string[] { regiNum ,PrOut.ToString(),
                            PrFaulty.ToString(), val.ToString("00%") });

                ListViews[3].Items.Add(lvi);
            }
        }

        private void FrFaulty2()
        {
            //제품
            foreach (ListViewItem item in ListViews[0].Items)
            {
                int PrOut = 0;
                int PrFaulty = 0;
                string PCode = string.Empty;
                PrOut += Convert.ToInt32(item.SubItems[2].Text);
                PCode = item.SubItems[0].Text;
                foreach (ListViewItem item2 in ListViews[2].Items)
                {
                    if (item2.SubItems[0].Text == PCode)
                    {
                        if (item2.SubItems[3].Text.Contains("불량"))
                        {
                            PrFaulty += Convert.ToInt32(item2.SubItems[2].Text);
                        }
                    }
                }
                ListViewItem lvi;
                double val = (double)PrFaulty / PrOut;

                lvi = new ListViewItem(new string[] { PCode ,PrOut.ToString(),
                            PrFaulty.ToString(), val.ToString("00%") });

                ListViews[3].Items.Add(lvi);
            }
        }

        private void FrFaulty3()
        {
            //본사
            int PrOut = 0;
            int PrFaulty = 0;
            foreach (ListViewItem item in ListViews[0].Items)
            {
                PrOut += Convert.ToInt32(item.SubItems[4].Text);
            }
            foreach (ListViewItem item in ListViews[2].Items)
            {
                if (item.SubItems[7].Text.Contains("불량"))
                {
                    PrFaulty += Convert.ToInt32(item.SubItems[6].Text);
                }
            }

            ListViewItem lvi;
            double val = (double)PrFaulty / PrOut;

            lvi = new ListViewItem(new string[] { "",PrOut.ToString(),
                    PrFaulty.ToString(), val.ToString("00%") });

            ListViews[3].Items.Add(lvi);
        }
    }
}
