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
    public partial class StaffDelete : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        string id;
        string staffId = string.Empty;

        /*---------------------------------------------------------------------
        메서드명: StaffDelete 

        기능 : StaffDelete 클래스 생성자

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StaffDelete(string Id)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: StaffDelete_Load : void

        기능 : 직원 삭제 창 띄워질때 발생하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffDelete_Load(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : 해당하는 가맹점의 직원 리스트를 DB에서 받아와 
                리스트뷰에 보여주는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            Comm.CommandText = "Select [Id],[Name] From StaffLogin Where [RegiNum] = '"
                + getRegiNum() + "'";

            var myRead = Comm.ExecuteReader();

            this.StaffListView.Items.Clear();

            while(myRead.Read())
            {
                ListViewItem lvi =
                    new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString() });

                this.StaffListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: getRegiNum : string

        기능 : 가맹점을 식별할 사업자등록번호를 가져오는 기능

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

            if (myRead.Read())
            {
                RegiNum = myRead[0].ToString();
            }

            myRead.Close();

            return RegiNum;
        }

        /*---------------------------------------------------------------------
        메서드명: StaffListView_SelectedIndexChanged : void

        기능 : 리스트뷰에서 직원선택 시 직원의 Id를 가져오는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StaffListView.SelectedItems.Count > 0)
            {
                int index = this.StaffListView.SelectedItems[0].Index;
                staffId = StaffListView.Items[index].SubItems[0].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnDelete_Click : void

        기능 : 삭제 버튼 클릭 시 리스트뷰에서 선택한 해당 직원 삭제

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(staffId == string.Empty)
                {
                    throw new Exception("삭제할 스태프를 선택해주세요.");
                }
                if (MessageBox.Show("선택한 직원을 정말로 삭제하시겠습니까?"
                    , "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Comm.CommandText = "Delete From [StaffLogin] Where [Id] = '"
                        + staffId + "'";

                    Comm.ExecuteNonQuery();

                    DataLoad();

                    MessageBox.Show("삭제 완료!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCancel_Click : void

        기능 : 취소 버튼 클릭 시 창을 닫는 기능

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
        메서드명: StaffDelete_FormClosing : void

        기능 : 창이 닫힐 때 DB의 연결을 끊는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffDelete_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }
    }
}
