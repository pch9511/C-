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
    public partial class ClientModify : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        string ID = string.Empty;

        /*---------------------------------------------------------------------
        메서드명: ClientModify 

        기능 : ClientModify 클래스 생성자

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientModify()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void

        기능 : 수정 버튼 클릭 시 회원 정보 수정하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    txtName.Focus();
                    throw new Exception("이름을 입력해주세요.");
                }
                if (txtPN.Text == "")
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호를 입력해주세요.");
                }
                if (txtPN.TextLength != 11)
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호가 올바르지 않습니다.");
                }
                Modify();
                MessageBox.Show("이름 : " + txtName.Text
                    +"\r\n전화번호 : " + txtPN.Text + "로 변경되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 검색 버튼 클릭 시 해당 정보에 부합하는 회원을 찾는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    txtName.Focus();
                    throw new Exception("이름을 입력해주세요.");
                }
                if (txtPN.Text == "")
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호를 입력해주세요.");
                }
                if (txtPN.TextLength != 11)
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호가 올바르지 않습니다.");
                }
                if (Check())
                {
                    MessageBox.Show("해당하는 회원을 찾았습니다. " +
                        "이름과 전화번호를 수정해주세요.");
                    txtName.Text = "";
                    txtPN.Text = "";
                    btnSearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: ClientModify_FormClosing : void

        기능 : 현재 창을 닫을 때 이전 창을 다시 보여주는 이벤트를 전달하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: txtPN_KeyPress : void

        기능 : 핸드폰 번호 입력 시 숫자만 입력 가능하게 하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void txtPN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ('0' <= e.KeyChar && e.KeyChar <= '9' || e.KeyChar == (char)8) return;
            else
            {
                e.Handled = true;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: Modify : void

        기능 : 수정된 회원 정보를 DB에서 수정하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Modify()
        {
            Comm.CommandText = "Update [Client] Set [Name] = '" + txtName.Text +
                "', [Phone] = '" + txtPN.Text + "' Where [Id] = '" + ID + "'";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: Check : bool

        기능 : 입력한 회원정보가 있는지 체크하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool Check()
        {
            bool check = false;
            Comm.CommandText = "Select [Id],[Name],[Phone] From [Client]";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                if (myRead[1].ToString() == txtName.Text && 
                        myRead[2].ToString() == txtPN.Text)
                {
                    ID = myRead[0].ToString();
                    check = true;
                    break;
                }
            }

            myRead.Close();

            return check;
        }
    }
}
