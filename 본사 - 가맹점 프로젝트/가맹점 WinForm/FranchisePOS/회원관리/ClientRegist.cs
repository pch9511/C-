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
    public partial class ClientRegist : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;
        private SqlConnection Conn;
        private SqlCommand Comm;
        const string Ph = "ex)01012345678";

        /*---------------------------------------------------------------------
        메서드명: ClientRegist

        기능 : ClientRegist 클래스 생성자

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientRegist()
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            txtPN.Text = Ph;
            txtPN.GotFocus += RemovePlaceholder;
            txtPN.LostFocus += SetPlaceholder;
        }

        /*---------------------------------------------------------------------
        메서드명: btnRegist_Click : void

        기능 : 등록 버튼 클릭 시 회원을 등록하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnRegist_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtName.Text == "")
                {
                    txtName.Focus();
                    throw new Exception("이름을 입력해주세요.");
                }
                if(txtPN.Text == "")
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호를 입력해주세요.");
                }
                if(txtPN.TextLength != 11)
                {
                    txtPN.Focus();
                    throw new Exception("핸드폰 번호가 올바르지 않습니다.");
                }
                if(Check())
                {
                    throw new Exception("핸드폰 번호 중복");
                }
                Regist();
                MessageBox.Show("회원 등록 완료");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void

        기능 : 취소 버튼 클릭 시 현재 창을 닫는 기능

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
        메서드명: ClientRegist_FormClosing : void

        기능 : 현재 창을 닫을 때 이전 창을 보여주는 이벤트를 전달

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientRegist_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: txtPN_KeyPress : void

        기능 : 핸드폰 번호에는 숫자만 입력하게끔 하는 기능

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
        메서드명: RemovePlaceholder : void

        기능 : 텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : https://ella-devblog.tistory.com/70 참조
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == Ph)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: SetPlaceholder : void

        기능 : 사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : https://ella-devblog.tistory.com/70 참조
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                txt.ForeColor = Color.DarkGray;
                if (txt == txtPN) txt.Text = Ph;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: Regist : void

        기능 : 등록한 회원정보를 DB에 저장하는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Regist()
        {
            Comm.CommandText = "Insert Into [Client] Values('"
              + txtName.Text + "','" + txtPN.Text + "',0)";

            Comm.ExecuteNonQuery();
        }

        /*---------------------------------------------------------------------
        메서드명: Check : bool

        기능 : 핸드폰 번호 중복 체크 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private bool Check()
        {
            bool check = false;
            Comm.CommandText = "Select [Phone] From [Client]";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(myRead[0].ToString() == txtPN.Text)
                {
                    check = true;
                    break;
                }
            }

            myRead.Close();

            return check;
        }
    }
}
