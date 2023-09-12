using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Franchise
{
    public partial class Product : Form
    {
        private string temp;
        private string ProductId;
        private string CategoryCode;
        private SqlConnection Conn;
        private SqlCommand Comm;
        private ProductManagement Wf;

        /*---------------------------------------------------------------------
        메서드명: Product 

        기능 : 제품등록 창 생성자

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public Product(ProductManagement wf)
        {
            InitializeComponent();
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
            Conn.Open();
            Comm = new SqlCommand();
            Comm.Connection = Conn;
            temp = String.Empty;
            CategoryCode = String.Empty;
            Wf = wf;
        }

        /*---------------------------------------------------------------------
        메서드명: Product_Load : void 

        기능 : 제품등록 창 로드시 DB 데이터를 불러오는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Product_Load(object sender, EventArgs e)
        {
            DataLoad();
            CategoryLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: CategoryLoad : void 

        기능 : 카테고리 정보를 가져와 텍스트박스에 적용하는 기능

        만든날짜: 2023-04-04

        수정날짜 : 2023-05-11
        기타사항 : 카테고리 변경으로 수정
        연관함수 : X
        -----------------------------------------------------------------------*/
        //MVC 변경하면서 모델에 카테고리를 담아서 이용해먹어야함
        private void CategoryLoad()
        {
            CategoryTree.Nodes.Clear();

            Comm.CommandText = "Select * From Category";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                if (myRead[2].ToString() == "0")
                {
                    CategoryTree.Nodes.Add(myRead[1].ToString() + "(" + myRead[0].ToString() + ")");
                }
                else if (myRead[2].ToString() == "1")
                {
                    for (int i = 0; i < CategoryTree.Nodes.Count; i++)
                    {
                        if (CategoryTree.Nodes[i].Text == myRead[3].ToString())
                        {
                            CategoryTree.Nodes[i].Nodes.Add(myRead[1].ToString() + "(" + myRead[0].ToString() + ")");
                        }
                    }
                }
                else if (myRead[2].ToString() == "2")
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
        메서드명: DataLoad : void 

        기능 : 제품 정보를 DB에서 가져와서 리스트뷰에 담는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void DataLoad()
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select * From Product";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                       myRead[2].ToString(), myRead[3].ToString() });
                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();

            SetCategoryName();
        }

        private void SetCategoryName()
        {
            Comm.CommandText = "Select [Id],[Name] From [Category]";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                foreach (ListViewItem item in ProductListView.Items)
                {
                    if(item.SubItems[2].Text == myRead[0].ToString())
                    {
                        item.SubItems[2].Text = myRead[1].ToString();
                    }                   
                }
            }

            myRead.Close();
            
        }

        /*---------------------------------------------------------------------
        메서드명: ProductListView_SelectedIndexChanged : void 

        기능 : 리스트뷰의 리스트 선택 시 정보를 텍스트박스에 담는 기능

        만든날짜: 2023-04-04

        수정날짜 : 2023-05-11
        기타사항 : 카테고리 변경으로 수정
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void ProductListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductListView.SelectedItems.Count > 0)
            {
                int index = this.ProductListView.SelectedItems[0].Index;

                temp = this.ProductListView.Items[index].SubItems[0].Text;
                this.txtName.Text = this.ProductListView.Items[index].SubItems[1].Text;
                this.txtCategory.Text = this.ProductListView.Items[index].SubItems[2].Text;
                this.txtPrice.Text = this.ProductListView.Items[index].SubItems[3].Text;
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnCreate_Click : void 

        기능 : 제품 등록버튼 클릭 시 DB 와 리스트뷰에 저장하는 기능

        만든날짜: 2023-04-04

        수정날짜 : 2023-05-11
        기타사항 : 카테고리 변경으로 수정
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.ProductListView.Items.Count; i++)
                {
                    if(this.txtName.Text == this.ProductListView.Items[i].SubItems[1].Text)
                    {
                        throw new Exception("이미 있는 제품명입니다.");
                    }
                }
                if (this.txtName.Text == "" || this.txtCategory.Text == ""
                        || this.txtPrice.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");
                AutoCode(CategoryCode);
                if (ProductId == String.Empty) throw new Exception("문제발생");
                Comm.CommandText = "INSERT INTO Product Values('" + 
                     ProductId + "','" + this.txtName.Text + "','" + 
                     CategoryCode + "','" + txtPrice.Text + "')";

                Comm.ExecuteNonQuery();

                DataLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        /*---------------------------------------------------------------------
        메서드명: GetCategoryCode : string 

        기능 : 카테고리DB 테이블에서 Id 정보를 가져오는 기능

        만든날짜: 2023-04-04

        수정날짜 : 2023-05-11
        기타사항 : 카테고리 정보를 트리뷰에서 한꺼번에 가져올 수 있게함 
                    또한 카테고리 코드를 DB에 등록하므로 카테고리명이 필요해짐
        연관함수 : X
        -----------------------------------------------------------------------*/
        /*private string GetCategoryCode()
        {
            Comm.CommandText = "Select * From Category";

            string Code = String.Empty;
            
            var myRead = Comm.ExecuteReader();
            try
            { 
                while (myRead.Read())
                {
                    if (myRead[1].ToString() == txtCategory.Text)
                    {
                        Code = myRead[0].ToString();
                    }
                }

                myRead.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
                myRead.Close();
            }

            return Code;
        }*/

        /*---------------------------------------------------------------------
        메서드명: AutoCode : void 

        기능 : 제품코드를 자동생성 하는 기능 (ex.카테고리Id+위치+일련번호)

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void AutoCode(string CategoryCode)
        {
            Comm.CommandText = "Select * From Product";

            ProductId = String.Empty;

            var myRead = Comm.ExecuteReader();
            int cnt = 0;
            int Ascii = 65;
            try
            {
                while (myRead.Read())
                {
                    if (myRead[0].ToString().Substring(0, CategoryCode.Length) == CategoryCode)
                    {
                        cnt++;
                    }
                }

                ProductId += Convert.ToString(cnt);
                while (ProductId.Length != 3)
                {
                    ProductId = "0" + ProductId;
                }

                ProductId = CategoryCode + Convert.ToChar(Ascii + cnt / 100) + ProductId;

                myRead.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
                myRead.Close();
            }
        }

        /*---------------------------------------------------------------------
        메서드명: btnModify_Click : void 

        기능 : 수정버튼 클릭 시 제품 정보를 수정하는 기능

        만든날짜: 2023-04-04

        수정날짜 : 2023-05-11
        기타사항 : 카테고리 변경
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.ProductListView.Items.Count; i++)
                {
                    if (temp == this.ProductListView.Items[i].SubItems[0].Text) continue;
                    if (this.txtName.Text == this.ProductListView.Items[i].SubItems[1].Text)
                    {
                        throw new Exception("이미 있는 제품명입니다.");
                    }
                }
                if (temp == String.Empty) throw new Exception("수정할 제품을 리스트에서 선택하세요.");
                if (this.txtName.Text == "" || this.txtCategory.Text == ""
                        || this.txtPrice.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");

                Comm.CommandText = "UPDATE Product Set [Name] = '" + 
                    this.txtName.Text + "', [Price] = '" + this.txtPrice.Text + 
                    "', [Category] = '" + CategoryCode + "' Where [Id] = '" + temp + "'";
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

        기능 : 삭제버튼 클릭 시 제품 정보를 삭제하는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (temp == String.Empty) throw new Exception("삭제할 제품을 리스트에서 선택하세요.");
                if (this.txtName.Text == "" || this.txtPrice.Text == ""
                        || this.txtCategory.Text == "")
                    throw new Exception("빈칸을 전부 입력하세요.");

                Comm.CommandText = "Delete From Product Where [Id] = '" + temp + "'";

                if (MessageBox.Show("정말로 삭제하시겠습니까?", "알림", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
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

        기능 : 종료 버튼 클릭시 제품 관리 창을 닫는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnSearch_Click : void 

        기능 : 조회 버튼 클릭시 해당하는 정보에 맞는 제품리스트를 나열

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.ProductListView.Items.Clear();

            Comm.CommandText = "Select * From Product Where [Name] = '"
                + txtSearchName.Text + "'";

            var myRead = Comm.ExecuteReader();

            while (myRead.Read())
            {
                ListViewItem lvi;
                lvi = new ListViewItem(new string[] { myRead[0].ToString(), myRead[1].ToString(),
                    myRead[2].ToString(), myRead[3].ToString() });
                this.ProductListView.Items.Add(lvi);
            }

            myRead.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: btnReset_Click : void 

        기능 : 전체 리스트를 다시 보여주는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void btnReset_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        /*---------------------------------------------------------------------
        메서드명: Product_FormClosed : void 

        기능 : 현재 폼 닫은 후 이전 폼을 띄우는 기능

        만든날짜: 2023-04-04

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            Wf.Show();
        }

        /*---------------------------------------------------------------------
        메서드명: GetCategoryName : string 

        기능 : 카테고리명을 DB에서 가져오는 기능

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private string GetCategoryName(string code)
        {
            string name = String.Empty;
            Comm.CommandText = "Select [Name] From Category Where [Id] = '"
                + code + "'";

            var myRead = Comm.ExecuteReader();

            if (myRead.Read())
            {
                name = myRead[0].ToString();
            }

            myRead.Close();

            return name;
        }

        /*---------------------------------------------------------------------
        메서드명: CategoryTree_AfterSelect_1 : void 

        기능 : 트리뷰에서 선택한 노드의 값을 가져와 이름과 코드명을 분리하는 기능

        만든날짜: 2023-05-11

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        private void CategoryTree_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < CategoryTree.SelectedNode.Text.Length; i++)
            {
                if (CategoryTree.SelectedNode.Text[i] == '(')
                {
                    txtCategory.Text = CategoryTree.SelectedNode.Text;
                    CategoryCode = CategoryTree.SelectedNode.Text.Substring(i + 1, CategoryTree.SelectedNode.Text.Length - i - 2);
                    break;
                }
            }
        }
    }
}
