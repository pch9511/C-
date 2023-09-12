using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class StaffModify : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;

        /*---------------------------------------------------------------------
        메서드명: StaffModify  

        기능 : StaffModify 생성자

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StaffModify()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;

        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void  

        기능 : 수정버튼 클릭 시 직원 정보 수정하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtID.Text == "" || txtBeforePW.Text == "" || 
                    txtAfterPW.Text == "" || txtName.Text == "")
                {
                    throw new Exception("빈칸을 전부 채워주세요.");
                }
                if(txtAfterPW.TextLength < 6)
                {
                    throw new Exception("비밀번호는 6자 이상으로 입력해주세요.");
                }
                if(!IdPwCheck())
                {
                    throw new Exception("기존 아이디,패스워드가 일치하지 않습니다.");
                }

                Comm.CommandText = "Update [StaffLogin] SET [PassWord] = '" +
                    txtAfterPW.Text + "', [Name] = '" + txtName.Text +
                    "' Where [Id] = '" + txtID.Text + "'";

                Comm.ExecuteNonQuery();

                MessageBox.Show("수정 완료!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void  

        기능 : 해당 창을 닫는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: IdPwCheck : bool  

        기능 : 기존 ID PW 일치여부를 확인하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool IdPwCheck()
        {
            bool Check = false;
            Comm.CommandText = "Select [Id],[PassWord] From [StaffLogin]";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(myRead[0].ToString() == txtID.Text &&
                    myRead[1].ToString() == txtBeforePW.Text)
                {
                    Check = true;
                    break;
                }
            }

            myRead.Close();

            return Check;
        }

        /*---------------------------------------------------------------------
        메서드명: StaffModify_FormClosing : void  

        기능 : 해당 창 종료 시 DB 연결을 끊는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }
    }
}
