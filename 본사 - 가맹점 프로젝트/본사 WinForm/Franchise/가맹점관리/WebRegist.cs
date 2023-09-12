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
    public partial class WebRegist : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        public delegate void RegistDeleteHandler();
        public event RegistDeleteHandler RegistDeleteEvent;
        private string RegiNum;


        /*---------------------------------------------------------------------
        메서드명: WebRegist

        기능 : WebRegist 생성자

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public WebRegist(string reginum)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            RegiNum = reginum;
        }

        /*---------------------------------------------------------------------
        메서드명: WebRegist_Load : void

        기능 : WebRegist 로드시 발생하는 기능

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void WebRegist_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 등록요청한 정보를 DB에서 가져오는 기능

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select [Id],[State],[Date] From Register Where [RegiNum] = '"
                + RegiNum +"'";

            var myRead = Comm.ExecuteReader();

            lblRegi.Text = RegiNum;
            if (myRead.Read())
            {
                lblId.Text += myRead[0].ToString();
                if(myRead[1].ToString() == "1")
                {
                    lblState.Text += "O";
                }
                else
                {
                    lblState.Text += "X";
                }       
                lblDate.Text += myRead[2].ToString();
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnOK_Click : void

        기능 : 승인 버튼 클릭 시 DB를 이용해 메일 전송 및 등록 요청 승인 상태 변경

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("승인하시겠습니까?", "Test", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //승인 요청을 허락 시 
                //아이디 자동 생성 함수 
                //로그인 ID 변경 및 Check = true 변경
                string temp = String.Empty;
                temp = AutoCreateId(RegiNum);
                Comm.CommandText = "Update [Register] Set [State] = 'True'" +
                    " Where RegiNum = '" + RegiNum + "'"  + " Insert Into [Mail] Values('" + RegiNum
                + "', 'Admin', '회원요청 승인', 'Id = " + temp + " Password = 11223344 입니다.','false', Default)";

                Comm.ExecuteNonQuery();

                RegistDeleteEvent();
                this.Close();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void

        기능 : 승인취소 버튼 클릭 시 발생하는 기능

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(RbFail1.Checked)
            {
                Cancel(RbFail1.Text);
            }
            else if(RbFail2.Checked)
            {
                Cancel(RbFail2.Text);
            }
            else if(RbFail3.Checked)
            {
                Cancel(RbFail3.Text);
            }
        }

        /*---------------------------------------------------------------------
        메서드명: Cancel : void

        기능 : 승인 취소 시 사유를 포함하여 해당 회원에게 메일을 전송하는 기능

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Cancel(string reason)
        {
            if (MessageBox.Show(reason + "(으)로 승인을 거부하시겠습니까?", "Test", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //승인 요청을 허락 시 
                //아이디 자동 생성 함수 
                //로그인 ID 변경 및 Check = true 변경
                string temp = String.Empty;
                temp = AutoCreateId(RegiNum);
                Comm.CommandText = "Insert Into [Mail] Values('" + RegiNum
                + "', 'Admin', '회원요청 불가', '취소사유 : " + reason + "입니다. 확인하시고 다시 요청해주세요.', Default)";

                Comm.ExecuteNonQuery();

                RegistDeleteEvent();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: AutoCreateId : string

        기능 : Id 자동 생성 기능

        만든날짜: 2023-05-09

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string AutoCreateId(string RegiNum)
        {
            Comm.CommandText = "Select [Name],[ContactNumber] From [FranchiseInfo]"
                + "Where RegistrationNumber = '" + RegiNum + "'";

            var myRead = Comm.ExecuteReader();

            List<string> AutoId = new List<string>();

            if (myRead.Read())
            {
                AutoId.Add(myRead[0].ToString().Substring(0, 2));
                AutoId.Add(myRead[1].ToString().Substring(0, 3));
                AutoId.Add(myRead[1].ToString().Substring(6, 4));
            }

            string temp = String.Empty;
            for (int i = 0; i < AutoId.Count; i++)
            {
                temp += AutoId[i];
            }

            myRead.Close();

            return temp;

        }
    }
}
