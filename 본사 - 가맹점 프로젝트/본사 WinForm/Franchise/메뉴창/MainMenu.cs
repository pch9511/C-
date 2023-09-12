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
using System.Reflection;

namespace Franchise
{
    public partial class MainMenu : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        private Thread Stock;
        private bool show = true;
        private Object obj = new Object();
        /*---------------------------------------------------------------------
        메서드명: Form1 : void

        기능 : 메인화면 생성자 

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : https://jujun.tistory.com/435 자신외의 폼을 닫는 방법
        연관함수 : X
        -----------------------------------------------------------------------*/
        public MainMenu()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;

            List<Form> formsToClose = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                if (form != this)  // 만약 자기 자신 Form도 닫을 경우 if문 생략
                {
                    formsToClose.Add(form);
                }
            }

            formsToClose.ForEach(f => f.Close());
        }


        /*---------------------------------------------------------------------
        메서드명: button1_Click : void

        기능 : 가맹점 관리 창 띄우는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            FranchiseManagement test = new FranchiseManagement(this);
            test.FormCloseEvent += new FranchiseManagement.FormCloseHandler(Event);
            
            this.Hide();
            test.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: button2_Click : void

        기능 : 회원 승인 관리 창 띄우는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button2_Click(object sender, EventArgs e)
        {
            WebRegisterManagement test = new WebRegisterManagement(this);

            this.Hide();
            test.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: button3_Click : void

        기능 : 상품 관리 창 띄우는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button3_Click(object sender, EventArgs e)
        {
            ProductManagement wf = new ProductManagement(this);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: Form1_FormClosed : void

        기능 : 프로그램 완전 종료 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Stock != null)
            {
                Stock.Abort();
            }
            Application.Exit();
        }

        private void Event()
        {
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Request test = new Request();
            test.FormCloseEvent += new Request.FormCloseHandler(Event);

            this.Hide();
            test.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Profit test = new Profit();
            test.FormCloseEvent += new Profit.FormCloseHandler(Event);

            this.Hide();
            test.ShowDialog();
        }


        //2023-06-15
        private void DataLoad()
        {
            while (show)
            {
                if (ProductListView.InvokeRequired)
                {
                    ProductListView.Invoke(new MethodInvoker(delegate { ProductListView.Items.Clear();  }));
                }
                else
                {
                    ProductListView.Items.Clear();
                }

                Comm.CommandText = "Select [Id],[Name],[InPrice] ,sum(Account) as Account From HeadStock Group By [Id],[Name],[InPrice] Order by Account asc";

                var myRead = Comm.ExecuteReader();

                while (myRead.Read())
                {
                    ListViewItem lvi;
                    lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString() });
                    if (Convert.ToInt32(myRead[3].ToString()) < 10)
                    {
                        lvi.ForeColor = Color.Red;
                    }
                    if (ProductListView.InvokeRequired)
                    {
                        ProductListView.Invoke(new MethodInvoker(delegate { ProductListView.Items.Add(lvi); }));
                    }
                    else
                    {
                        ProductListView.Items.Add(lvi);
                    }
                }

                myRead.Close();

                Thread.Sleep(500);             
            }
        }
        //2023-06-15
        private void Form1_Load(object sender, EventArgs e)
        {
            //Stock.IsBackground = true;
        }
        //2023-06-15
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible == false)
            {
                show = false;
                Stock.Abort();
            }
            else
            {
                show = true;
                Stock = new Thread(() => DataLoad());
                Stock.IsBackground = true;
                Stock.Start();
            }
        }
        //2023-06-15
        private void ProductListView_Click(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItems.Count > 0)
            {
                int index = this.ProductListView.SelectedItems[0].Index;

                if (this.ProductListView.Items[index].ForeColor == Color.Red)
                {
                    Store test = new Store();

                    test.ShowDialog();
                }
            }
        }


        //2023-06-20
        private void ProductMade_Click(object sender, EventArgs e) //완제품 등록하는 란 (Menu DB Create)
        { 
           /* FranchiseManagement test = new FranchiseManagement(this);
            test.FormCloseEvent += new FranchiseManagement.FormCloseHandler(Event);

            this.Hide();
            test.ShowDialog();*/
        }

        private void MailReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("메일 알림을 활성화 하시겠습니까?","알림",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Comm.CommandText = "UPDATE Mail SET [Read] = 'false' Where [Read] = 'true'";
                Comm.ExecuteNonQuery();
            }
        }

    }
}
