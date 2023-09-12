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
    public partial class ChatList : Form
    {
        public ChatList()
        {
            InitializeComponent();
        }


        //2023-05-18
        private void ChatList_Load(object sender, EventArgs e)
        {
            List<Button> ChatRoom = new List<Button>();
            for(int i=0; i<10; i++)
            {
                ChatRoom[i].Click += new EventHandler(btn_ChatClick);
                ChatRoom.Add(new Button());                
                ChatRoom[i].Width = 430;
                ChatRoom[i].Height = 50;
                flowLayoutPanel1.Controls.Add(ChatRoom[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            panel1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChatClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            
        }
    }
}
