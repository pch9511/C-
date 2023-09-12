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
    public partial class ClientCheck : Form
    {
        private SqlConnection Conn;
        private SqlCommand Comm;
        public delegate void UsePointHandler(string Point);
        public event UsePointHandler UsePoint;
        private int TotalPrice;

        /*---------------------------------------------------------------------
        메서드명: ClientCheck

        기능 : ClientCheck 클래스 생성자

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientCheck(int Total)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            TotalPrice = Total;
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 포인트 적립 할 회원 정보를 조회하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Comm.CommandText = "Select [Id],[Point] From [Client] Where [Phone] = '"
                + txtPhone.Text + "'";

            var myRead = Comm.ExecuteReader();

            if(myRead.Read())
            {
                if (Convert.ToInt32(myRead[1].ToString()) != 0)
                {
                    if (MessageBox.Show(myRead[1].ToString() + "포인트가 있습니다." +
                        "포인트를 사용하시겠습니까?", "알림", MessageBoxButtons.YesNo)
                        == DialogResult.Yes)
                    {
                        PointUse wf = new PointUse(myRead[1].ToString(),TotalPrice);

                        wf.UsePoint += new PointUse.UsePointHandler(GetPoint);

                        wf.ShowDialog();

                        this.Close();
                    }
                }
            }
        }

        /*---------------------------------------------------------------------
        메서드명: GetPoint : void

        기능 : 사용할 포인트를 받아오는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void GetPoint(string Point)
        {
            UsePoint(Point);
        }
    }
}
