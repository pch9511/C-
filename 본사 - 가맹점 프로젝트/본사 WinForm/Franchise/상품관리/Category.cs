using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Franchise
{
    public partial class Category : Form
    {
        private string temp;
        private SqlConnection Conn;
        private SqlCommand Comm;
        const string IdPh = "영어문자 1자 이상을 입력해주세요.";
        private ProductManagement Wf;

        /*---------------------------------------------------------------------
        메서드명: Category

        기능 : 카테고리 관리 창 생성자 

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Category(ProductManagement wf)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            temp = String.Empty;
            txtId.Text = IdPh;
            txtId.GotFocus += RemovePlaceholder;
            txtId.LostFocus += SetPlaceholder;
            Wf = wf;
        }

        /*---------------------------------------------------------------------
        메서드명: Category_Load : void

        기능 : 창 로드 시 메서드 실행하는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Category_Load(object sender, EventArgs e)
        {     
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: DataLoad : void

        기능 : DB의 Category 정보를 가져와 리스트뷰에 담는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            CategoryTree.Nodes.Clear();

            Comm.CommandText = "Select * From Category";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                if(myRead[2].ToString() == "0")
                {
                    CategoryTree.Nodes.Add(myRead[1].ToString() + "(" + myRead[0].ToString() + ")");
                }
                else if(myRead[2].ToString() == "1")
                {
                    for(int i=0; i<CategoryTree.Nodes.Count; i++)
                    {
                        if(CategoryTree.Nodes[i].Text == myRead[3].ToString())
                        {
                            CategoryTree.Nodes[i].Nodes.Add(myRead[1].ToString() + "(" + myRead[0].ToString() + ")");
                        }
                    }
                }
                else if(myRead[2].ToString() == "2")
                {
                    for (int i = 0; i < CategoryTree.Nodes.Count; i++)
                    {
                        for (int j = 0; j < CategoryTree.Nodes[i].Nodes.Count; j++)
                        {
                            if (CategoryTree.Nodes[i].Nodes[j].Text == myRead[3].ToString())
                            {
                                CategoryTree.Nodes[i].Nodes[j].Nodes.Add(myRead[1].ToString() + "(" + myRead[0].ToString() + ")");
                            }
                        }
                    }
                }
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnCreate_Click : void

        기능 : 생성 버튼 클릭시 카테고리를 생성하는 기능

        만든날짜: 2023-04-03

        수정날짜 : 2023-05-10
        기타사항 : 트리뷰로 수정
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtId.Text == "" || this.txtName.Text == "")
                    throw  new Exception("빈칸을 전부 입력하세요.");
                char c = this.txtId.Text[0];
                if(CategoryTree.SelectedNode == null)
                {
                    if (Convert.ToInt32(c) < 65 || Convert.ToInt32(c) > 90 || this.txtId.Text.Length > 1)
                        throw new Exception("잘못된 입력입니다. 대문자 영어 1자를 입력해주세요.");

                    Comm.CommandText = "INSERT INTO Category Values('" +
                        this.txtId.Text + "','" + this.txtName.Text + "', 0, NULL)";

                }
                else
                {
                    Comm.CommandText = "INSERT INTO Category Values('" +
                        this.txtId.Text + "','" + this.txtName.Text + "'," + (CategoryTree.SelectedNode.Level + 1) + ",'" 
                        +  CategoryTree.SelectedNode.Text + "')";                    
                }

                Comm.ExecuteNonQuery();

                DataLoad();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void

        기능 : 수정 버튼 클릭시 해당하는 카테고리 정보를 수정하는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (temp == String.Empty) throw new Exception("수정할 카테고리를 리스트에서 선택하세요.");
                if (this.txtId.Text == "" || this.txtName.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");

                Comm.CommandText = "UPDATE Category Set [Id] = '" +
                this.txtId.Text + "', [Name] = '" + this.txtName.Text + "' Where [Id] = '" 
                + temp + "'";
                Comm.ExecuteNonQuery();

                DataLoad();

                temp = String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnDelete_Click : void

        기능 : 삭제 버튼 클릭시 해당하는 카테고리를 삭제하는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtId.Text == "" || this.txtName.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");             

                if (MessageBox.Show("정말로 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if(CategoryTree.SelectedNode.Nodes.Count > 0)
                    {
                        throw new Exception("하위 카테고리가 존재하기때문에 삭제가 불가능합니다.");
                    }
                    if(DeleteCheck())
                    {
                        throw new Exception("삭제할 카테고리 등록된 상품이 있습니다. 해당 상품을 먼저 삭제해주세요.");
                    }

                    Comm.CommandText = "Delete From Category Where [Id] = '" + txtId.Text + "'";
                    Comm.ExecuteNonQuery();

                    DataLoad();

                    temp = String.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnExit_Click : void

        기능 : 종료 버튼 클릭시 카테고리 관리 창 종료하는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*---------------------------------------------------------------------
        메서드명: Category_FormClosing : void

        기능 : 카테고리 관리 창 종료 시 DB 연결 끊는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Category_FormClosing(object sender, FormClosingEventArgs e)
        {
            Conn.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: RemovePlaceholder : void

        기능 : 텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : https://ella-devblog.tistory.com/70 참조
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == IdPh)
            {
                txt.ForeColor = Color.Black;
                txt.Text = string.Empty;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: SetPlaceholder : void

        기능 : 사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기

        만든날짜: 2023-04-03

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
                if (txt == txtId) txt.Text = IdPh;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void

        기능 : 조회 후 전체 리스트로 돌리는 기능

        만든날짜: 2023-04-03

        수정날짜 : 2023-05-10 
        기타사항 : 트리뷰로 바꾸면서 삭제
        연관함수 : X
        -----------------------------------------------------------------------*/

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void

        기능 : 조회 버튼 클릭시 해당 조건에 부합하는 리스트를 보여주는 기능

        만든날짜: 2023-04-03

        수정날짜 : 2023-05-10 
        기타사항 : 트리뷰로 바꾸면서 삭제
        연관함수 : X
        -----------------------------------------------------------------------*/

        /*---------------------------------------------------------------------
        메서드명: Category_FormClosed : void

        기능 : 현재 창이 닫힌 후 이전 창을 보여주는 기능

        만든날짜: 2023-04-03

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Category_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wf.Show();
        }

        private void CategoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for(int i=0; i<CategoryTree.SelectedNode.Text.Length; i++)
            {
                if(CategoryTree.SelectedNode.Text[i] == '(')
                {
                    txtName.Text = CategoryTree.SelectedNode.Text.Substring(0, i);
                    temp = CategoryTree.SelectedNode.Text.Substring(i + 1, CategoryTree.SelectedNode.Text.Length - i - 2);
                    txtId.Text = temp;        
                    txtId.ForeColor = Color.Black;
                    break;
                }
            }


        }

        private bool DeleteCheck()
        {
            bool Check = false;
            Comm.CommandText = "Select [Category] From Product";

            var myRead = Comm.ExecuteReader();

            while(myRead.Read())
            {
                if(myRead[0].ToString() == txtId.Text)
                {
                    Check = true;
                }
            }

            myRead.Close();

            return Check;
        }
    }
}
