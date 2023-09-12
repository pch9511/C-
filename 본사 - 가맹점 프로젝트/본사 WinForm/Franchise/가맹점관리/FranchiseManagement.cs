using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Franchise
{
    public partial class FranchiseManagement : Form
    {
        private string temp;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private MainMenu Wf;
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;

        /*---------------------------------------------------------------------
        메서드명: FranchiseManagement : void

        기능 : 가맹점관리창 생성자 메서드

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public FranchiseManagement(MainMenu wf)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            temp = String.Empty;
            Wf = wf;
        }

        /*---------------------------------------------------------------------
        메서드명: FranchiseManagement_Load : void

        기능 : 창 로드 시 메서드 실행하는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranchiseManagement_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : SQL에 있는 FranchiseInfo 테이블의 정보를 FranListView에 불러오는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.FranListView.Items.Clear();

            Comm.CommandText = "Select * From FranchiseInfo";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString()
                    , myRead[2].ToString() ,myRead[3].ToString(),myRead[4].ToString()
                    ,myRead[5].ToString() ,myRead[6].ToString()});

                this.FranListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: FranListView_SelectedIndexChanged : void

        기능 : FranListView의 아이템을 선택 시 해당 아이템의 칼럼들의 정보를 
        가맹점 정보 텍스트박스에 담는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FranListView.SelectedItems.Count > 0)
            {
                int index = this.FranListView.SelectedItems[0].Index;

                this.txtFranName.Text = this.FranListView.Items[index].SubItems[0].Text;
                this.txtOwnerName.Text = this.FranListView.Items[index].SubItems[1].Text;
                this.txtOwnerNumber.Text = this.FranListView.Items[index].SubItems[2].Text;
                this.txtRegiNumber.Text = this.FranListView.Items[index].SubItems[3].Text;
                this.txtContactNumber.Text = this.FranListView.Items[index].SubItems[4].Text;
                this.txtAddress.Text = this.FranListView.Items[index].SubItems[5].Text;
                temp = this.txtRegiNumber.Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 조회버튼 클릭시 txtRegiNumberSearch(사업자등록번호) 텍스트박스의 
        값에 따라서 SQL에 조회하여 해당 가맹점을 보여주는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Comm.CommandText = "Select * From FranchiseInfo Where RegistrationNumber = '"
                + txtRegiNumberSearch.Text + "'";

            var myRead = Comm.ExecuteReader();
            this.FranListView.Items.Clear();
            if (myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString() , myRead[2].ToString()
                    ,myRead[3].ToString(),myRead[4].ToString(),myRead[5].ToString()
                    ,myRead[6].ToString()});

                this.FranListView.Items.Add(lvi);
            }

            myRead.Close();

        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 특정 가맹점 조회 후 다시 전체보기로 돌릴때 쓰는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: btnCreate_Click : void

        기능 : 가맹점 정보를 입력하여 새로운 가맹점을 등록할 때 쓰는 기능

        만든날짜: 2023-02-28

        수정날짜 : 2023-03-06
        기타사항 : 임시로그인 정보를 저장하는 기능을 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtFranName.Text == "" || this.txtOwnerName.Text == "" || this.txtOwnerNumber.Text == ""
                    || this.txtRegiNumber.Text == "" || this.txtContactNumber.Text == "" || this.txtAddress.Text == "")
                    throw  new Exception("빈칸을 전부 입력하세요.");
                if (txtOwnerNumber.Text.Length != 11)
                {
                    txtOwnerNumber.Focus();
                    throw new Exception("핸드폰 번호가 올바르지 않습니다. 핸드폰번호 11자리를 입력해주세요.");
                }
                if (txtRegiNumber.Text.Length != 10)
                {
                    txtRegiNumber.Focus();
                    throw new Exception("사업자등록번호가 올바르지 않습니다. 사업자등록번호 10자리를 입력해주세요.");
                }

                Comm.CommandText = "INSERT INTO FranchiseInfo Values('" +
                this.txtFranName.Text + "','" + this.txtOwnerName.Text + "','" + this.txtOwnerNumber.Text + "','"
                + this.txtRegiNumber.Text + "','" + this.txtContactNumber.Text + "','" + this.txtAddress.Text + "',GETDATE())"
                + "INSERT INTO [LOGIN] VALUES('" +
                    this.txtRegiNumber.Text + "','" + this.txtOwnerNumber.Text + "','" +
                    this.txtRegiNumber.Text + "','false')";

                Comm.ExecuteNonQuery();

                DataLoad();
                txtClear();
                MessageBox.Show("생성 완료");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void

        기능 : 기존 가맹점의 정보를 수정하는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtFranName.Text == "" || this.txtOwnerName.Text == "" || this.txtOwnerNumber.Text == ""
                    || this.txtRegiNumber.Text == "" || this.txtContactNumber.Text == "" || this.txtAddress.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");
                if (txtOwnerNumber.Text.Length != 11)
                {
                    txtOwnerNumber.Focus();
                    throw new Exception("핸드폰 번호가 올바르지 않습니다. 핸드폰번호 11자리를 입력해주세요.");
                }
                if (txtRegiNumber.Text.Length != 10)
                {
                    txtRegiNumber.Focus();
                    throw new Exception("사업자등록번호가 올바르지 않습니다. 사업자등록번호 10자리를 입력해주세요.");
                }

                Comm.CommandText = "UPDATE FranchiseInfo SET Name = '" +
                this.txtFranName.Text + "', OwnerName = '" + this.txtOwnerName.Text +
                "', OwnerPhoneNumber = '" + this.txtOwnerNumber.Text + "', ContactNumber = '" +
                this.txtContactNumber.Text + "', Address = '" + this.txtAddress.Text +
                "' WHERE RegistrationNumber = '" + temp + "'";

                Comm.ExecuteNonQuery();
                DataLoad();
                txtClear();
                MessageBox.Show("수정 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 해당 가맹점관리 창을 닫는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnDelete_Click : void

        기능 : 해당 가맹점관리 창을 닫는 기능

        만든날짜: 2023-02-28

        수정날짜 : 2023-03-06
        기타사항 : 가맹점의 로그인정보를 삭제하는 기능 추가
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtRegiNumber.Text == "")
                    throw new Exception("삭제할 사업자등록번호를 입력하세요.");

                Comm.CommandText = "DELETE FROM Login WHERE RegiNum = '" + this.txtRegiNumber.Text + "'"
                + "DELETE FROM FranchiseInfo Where RegistrationNumber = '" +
                    this.txtRegiNumber.Text + "'";

                Comm.ExecuteNonQuery();
                DataLoad();
                txtClear();
                MessageBox.Show("삭제 완료");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: FranchiseManagement_FormClosing : void

        기능 : 가맹점 관리 창 종료시 DB 연결을 끊는 기능

        만든날짜: 2023-02-28

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void FranchiseManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
            //Wf.Show();
            FormCloseEvent();
        }

        private void txtRegiNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))     
            {
                e.Handled = true;
            }
        }

        private void txtOwnerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtClear()
        {
            this.txtFranName.Clear();
            this.txtOwnerName.Clear();
            this.txtOwnerNumber.Clear();
            this.txtRegiNumber.Clear();
            this.txtContactNumber.Clear();
            this.txtAddress.Clear();
        }


        /*---------------------------------------------------------------------
        메서드명: GetRegiNumber : bool

        기능 : 해당 가맹점이 회원가입을 했다면 True 하지 않았다면 False를 반환하는 기능

        만든날짜: 2023-03-06

        수정날짜 : X
        기타사항 : 사업자등록번호 등록시 규칙으로 만들어가게끔 할 예정이므로 
                   등록 후 수정이 불가하게끔 할 계획이기 때문에 수정 시 필요한 함수이므로 삭제 
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private bool GetRegiNumber()
        {
            var Conn = new SqlConnection(Constr);
            Conn.Open();
                
            var myCom = new SqlCommand("SELECT [Check] FROM Login Where RegiNum = '" +
                this.txtRegiNumber.Text + "'", Conn);
            var myRead = myCom.ExecuteReader();

            if (myRead.Read())
            {
                Conn.Close();
                return myRead[0].Equals(true);
            }
            return false;
        }*/
    }
}
