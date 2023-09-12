using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FranchisePOS
{
    public partial class StaffRegist : Form
    {

        private SqlConnection Conn;
        private SqlCommand Comm;
        bool Check = false;
        string id;

        /*---------------------------------------------------------------------
        메서드명: StaffRegist

        기능 : StaffRegist 생성자

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StaffRegist(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: btnOverlap_Click : void 

        기능 : Id 중복체크 하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnOverlap_Click(object sender, EventArgs e)
        {

            try
            {
                Comm.CommandText = "Select [Id] From StaffLogin";
                Check = true;
                var myRead = Comm.ExecuteReader();

                while (myRead.Read())
                {
                    if (myRead[0].ToString() == txtID.Text)
                    {
                        Check = false;
                        break;
                    }
                }

                myRead.Close();

                Comm.CommandText = "Select [Id] From Login";

                myRead = Comm.ExecuteReader();

                while (myRead.Read())
                {
                    if (myRead[0].ToString() == txtID.Text)
                    {
                        Check = false;
                        break;
                    }
                }

                myRead.Close();

                if (Check == false)
                    throw new Exception("중복된 ID입니다. 다시 입력해주세요.");
                else
                {
                    Check = true;
                    MessageBox.Show("사용 가능한 ID입니다.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
                txtID.Clear();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnRegist_Click : void 

        기능 : 직원 등록하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtID.Text == "" || txtName.Text == "" ||
                    txtPW.Text == "")
                {
                    throw new Exception("빈칸 모두 채워주세요!");
                }
                if(txtPW.TextLength < 6)
                {
                    throw new Exception("비밀번호를 6자 이상으로 입력해주세요.");
                }
                if (!Check)
                {
                    throw new Exception("ID 중복 체크를 해주세요.");
                }
                Comm.CommandText = "Insert Into [StaffLogin] Values('" +
                    txtID.Text + "','" + txtName.Text + "','" + txtPW.Text + "','" + 
                    getRegiNum() + "')";

                Comm.ExecuteNonQuery();
                MessageBox.Show("등록 성공!");

                txtID.Clear();
                txtName.Clear();
                txtPW.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }

        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void 

        기능 : 취소 버튼 클릭 시 이전창으로 돌아가는 기능

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
        메서드명: StaffRegist_FormClosing : void 

        기능 : 창을 닫을때 DB 연결 끊는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffRegist_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string 

        기능 : 특정 가맹점을 파악하기 위해 사업자등록번호를 가져오는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string getRegiNum()
        {
            Comm.CommandText = "Select [RegiNum] From [Login] Where [Id] = '"
                + id + "'";

            string RegiNum = string.Empty;

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                RegiNum = myRead[0].ToString();
            }

            myRead.Close();

            return RegiNum;
        }
    }
}
