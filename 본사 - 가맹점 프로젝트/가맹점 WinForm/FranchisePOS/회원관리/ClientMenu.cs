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
    //2023-04-21
    public partial class ClientMenu : Form
    {
        public delegate void FormCloseHandler();
        public event FormCloseHandler FormCloseEvent;


        /*---------------------------------------------------------------------
        메서드명: ClientMenu 

        기능 : ClientMenu 클래스 생성자

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public ClientMenu()
        {
            InitializeComponent();
        }

        /*---------------------------------------------------------------------
        메서드명: btnRegist_Click : void

        기능 : 회원 등록 창을 띄우는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnRegist_Click(object sender, EventArgs e)
        {
            ClientRegist wf = new ClientRegist();
            wf.FormCloseEvent += new ClientRegist.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void

        기능 : 회원 수정 창을 띄우는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            ClientModify wf = new ClientModify();
            wf.FormCloseEvent += new ClientModify.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnDelete_Click : void

        기능 : 회원 삭제 창을 띄우는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClientDelete wf = new ClientDelete();
            wf.FormCloseEvent += new ClientDelete.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnList_Click : void

        기능 : 회원 내역 창을 띄우는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnList_Click(object sender, EventArgs e)
        {
            ClientList wf = new ClientList();
            wf.FormCloseEvent += new ClientList.FormCloseHandler(ShowEvent);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 현재 창을 닫는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: ClientMenu_FormClosing : void

        기능 : 창을 닫을때 이전 창을 보여주는 이벤트를 전달

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ClientMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormCloseEvent();
        }

        /*---------------------------------------------------------------------
        메서드명: ShowEvent : void

        기능 : 현재 창을 띄우는 기능

        만든날짜: 2023-04-21

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ShowEvent()
        {
            this.Show();
        }
    }
}
