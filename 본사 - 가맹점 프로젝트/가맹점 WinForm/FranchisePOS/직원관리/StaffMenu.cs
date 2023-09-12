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
    public partial class StaffMenu : Form
    {
        MainForm mf;
        string id;
        /*---------------------------------------------------------------------
        메서드명: StaffMenu 

        기능 : StaffMenu 클래스 생성자

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public StaffMenu(MainForm Mf,string Id)
        {
            InitializeComponent();
            mf = Mf;
            id = Id;
        }

        /*---------------------------------------------------------------------
        메서드명: StaffMenu_FormClosing : void 

        기능 : 직원 관리 창 종료 시 메인화면 창을 다시 보여주는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void StaffMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.Show();
        }

        /*---------------------------------------------------------------------
        메서드명: btnRegist_Click : void 

        기능 : 직원 등록 버튼 클릭 시 직원 등록 창을 보여주는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnRegist_Click(object sender, EventArgs e)
        {
            StaffRegist wf = new StaffRegist(id);
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnTime_Click : void 

        기능 : 근태 관리 버튼 클릭 시 근태 관리 창을 보여주는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnTime_Click(object sender, EventArgs e)
        {
            TimeAttendance wf = new TimeAttendance(id);
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void 

        기능 : 이전화면으로 돌아가는 기능

        만든날짜: 2023-04-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void 

        기능 : 직원 정보 수정창으로 이동하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            StaffModify wf = new StaffModify();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnDelete_Click : void 

        기능 : 직원 정보 삭제창으로 이동하는 기능

        만든날짜: 2023-04-12

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            StaffDelete wf = new StaffDelete(id);
            wf.ShowDialog();
        }
    }
}
