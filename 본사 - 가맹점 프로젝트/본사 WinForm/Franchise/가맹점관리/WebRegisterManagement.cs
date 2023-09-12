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

namespace Franchise
{
    public partial class WebRegisterManagement : Form
    {

        private SqlConnection Conn;
        private SqlCommand Comm;
        private MainMenu Wf;
        private int index;

        /*---------------------------------------------------------------------
        메서드명: WebRegisterManagement : void

        기능 : 회원 승인 창 생성자 

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public WebRegisterManagement(MainMenu wf)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            Wf = wf;

        }

        /*---------------------------------------------------------------------
        메서드명: WebLoginManagement_Load : void

        기능 : 회원 승인 창 로드 시 사용되는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void WebRegisterManagement_Load(object sender, EventArgs e)
        {
            DataLoad();
        }


        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 회원가입 승인 요청한 DB 정보를 불러오는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.WebView.Items.Clear();

            Comm.CommandText = "Select * From Register";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi;
                if (myRead[3].ToString() == "False")
                {
                    lvi =
                        new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString()
                        , myRead[2].ToString() , "X" ,myRead[4].ToString()});
                }
                else
                {
                    lvi =
                        new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString()
                        , myRead[2].ToString() , "O" ,myRead[4].ToString()});
                }

                this.WebView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: WebView_DoubleClick : void

        기능 : 승인요청 리스트 더블클릭시 승인여부를 결정하는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void WebView_DoubleClick(object sender, EventArgs e)
        {
            //더블클릭한 칼럼에게 승인하시겠습니까? 메시지 박스를 띄우서                        
            if (WebView.SelectedItems.Count > 0)
            {
                index = this.WebView.SelectedItems[0].Index;
                WebRegist wf = new WebRegist(this.WebView.Items[index].SubItems[2].Text);
                wf.RegistDeleteEvent += new WebRegist.RegistDeleteHandler(DeleteList);
                wf.ShowDialog();
                /*
                MessageBox.Show(this.WebView.Items[index].SubItems[3].Text);

                if(this.WebView.Items[index].SubItems[3].Text == "X")
                {
                    if(MessageBox.Show("승인", "Test", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        //승인 요청을 허락 시 
                        //아이디 자동 생성 함수 
                        //로그인 ID 변경 및 Check = true 변경
                        string temp = String.Empty;
                        temp = AutoCreateId(WebView.Items[index].SubItems[2].Text);
                        Comm.CommandText = "Update [Register] Set [State] = 'True'" +
                            " Where RegiNum = '" + WebView.Items[index].SubItems[2].Text + "'"
                        + "Insert Into [Mail] Values('" + WebView.Items[index].SubItems[2].Text
                        + "', 'Admin', '회원요청 승인', 'Id = " +
                        temp + " Password = 11223344 입니다.', Default)";
                        
                        Comm.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("이미 승인한 계정입니다. 리스트에서 제거합니다.");
                    Comm.CommandText = "Delete From [Register] Where RegiNum = '" +
                        WebView.Items[index].SubItems[2].Text + "'";

                    Comm.ExecuteNonQuery();
                }*/
                DataLoad();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: WebView_DoubleClick : void

        기능 : 아이디 자동생성 기능 ( 가맹점명 앞 2글자 + 지역코드 
        + 가맹점 번호 뒷자리 4자리)

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private string AutoCreateId(string RegiNum)
        {
            Comm.CommandText = "Select [Name],[ContactNumber] From [FranchiseInfo]"
                + "Where RegistrationNumber = '" + RegiNum + "'";

            var myRead = Comm.ExecuteReader();

            List<string> AutoId = new List<string>();

            if(myRead.Read())
            {
                AutoId.Add(myRead[0].ToString().Substring(0,2));
                AutoId.Add(myRead[1].ToString().Substring(0,3));
                AutoId.Add(myRead[1].ToString().Substring(6,4));
            }

            string temp = String.Empty;
            for(int i=0; i<AutoId.Count; i++)
            {
                temp += AutoId[i];
            }

            myRead.Close();

            return temp;

        }*/

        /*---------------------------------------------------------------------
        메서드명: WebLoginManagement_FormClosing : void

        기능 : 회원 관리 창 닫을때 발생하는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void WebRegisterManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            Wf.Show();
        }

        private void DeleteList()
        {
            Comm.CommandText = "Delete From [Register] Where RegiNum = '" +
                WebView.Items[index].SubItems[2].Text + "'";

            Comm.ExecuteNonQuery();
        }
    }
}
