using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Franchise
{
    public partial class ProductManagement : Form
    {
        private MainMenu Wf;


        public ProductManagement(MainMenu wf)
        {
            InitializeComponent();
            Wf = wf;
        }

        /*---------------------------------------------------------------------
        메서드명: button1_Click

        기능 : 카테고리 관리 창 띄우는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button1_Click(object sender, EventArgs e)
        {
            Category wf = new Category(this);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: button2_Click : void

        기능 : 입출고 관리 창 띄우는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button2_Click(object sender, EventArgs e)
        {
            StoreOrRelease wf = new StoreOrRelease(this);

            this.Hide();
            wf.ShowDialog();
        }

        /*---------------------------------------------------------------------
        메서드명: button3_Click 

        기능 : 제품 등록 창 띄우는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void button3_Click(object sender, EventArgs e)
        {
            Product wf = new Product(this);

            this.Hide();
            wf.ShowDialog();
        }

        private void ProductManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wf.Show();
        }
    }
}
