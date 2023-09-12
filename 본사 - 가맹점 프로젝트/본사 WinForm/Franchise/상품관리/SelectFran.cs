using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Franchise
{
    public partial class SelectFran : Form
    {

        private SqlConnection Conn;
        private SqlCommand Comm;
        public delegate void SendFranHandler(object obj);
        public event SendFranHandler SendFranEvent;
        string RegiNum = string.Empty;

        /*---------------------------------------------------------------------
        메서드명: SelectFran

        기능 : SelectFran 클래스의 생성자

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public SelectFran()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: SelectFran_Load : void

        기능 : 가맹점 선택 창 로드 시 발생하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void SelectFran_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 가맹점정보를 DB에서 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.FranListView.Items.Clear();

            Comm.CommandText = "Select * From FranchiseInfo";
            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[3].ToString() ,myRead[5].ToString() });

                this.FranListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_SelectedIndexChanged : void

        기능 : 리스트 뷰에 선택한 인덱스의 정보를 가져오는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FranListView.SelectedItems.Count > 0)
            {
                int index = this.FranListView.SelectedItems[0].Index;

                RegiNum = this.FranListView.Items[index].SubItems[2].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: SelectFran_FormClosing : void

        기능 : 가맹점 선택 창 종료 중 발생하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void SelectFran_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnIn_Click : void

        기능 : 가맹점 선택 시 가맹점 정보를 이전 창에 전달하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (RegiNum != string.Empty)
                {
                    SendFranEvent(RegiNum);
                    this.Close();
                }
                else
                {
                    throw new Exception("가맹점을 선택해주세요.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 종료 버튼 클릭시 해당 창 종료하는 기능

        만든날짜: 2023-04-08

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
