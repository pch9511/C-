using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FranchisePOS
{
    public partial class PointUse : Form
    {
        public delegate void UsePointHandler(string Point);
        public event UsePointHandler UsePoint;
        int PointMax,TotalPrice;

        /*---------------------------------------------------------------------
        메서드명: Modify : void

        기능 : 수정된 회원 정보를 DB에서 수정하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public PointUse(string Point,int Price)
        {
            InitializeComponent();
            txtPoint.Text = Point;
            PointMax = Convert.ToInt32(Point);
            TotalPrice = Price;
        }

        /*---------------------------------------------------------------------
        메서드명: Modify : void

        기능 : 수정된 회원 정보를 DB에서 수정하는 기능

        만든날짜: 2023-04-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnUse_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtPoint.Text) > PointMax)
                {
                    throw new Exception("포인트가 부족합니다.");
                }
                if(Convert.ToInt32(txtPoint.Text) > TotalPrice)
                {
                    throw new Exception(TotalPrice.ToString() +
                        "보다 입력한 포인트가 많습니다.");
                }
             
                UsePoint(txtPoint.Text);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
