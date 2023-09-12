using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Franchise.Web.Models;

namespace Franchise.Web.Models
{
    public class UserRepository : IUserRepository
    {
        private IConfiguration _config;
        private SqlConnection con;
        

        /*---------------------------------------------------------------------
        메서드명: UserRepository : IACtionResult

        기능 : 생성자 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public UserRepository(IConfiguration config)
        {
            _config = config;
            con = new SqlConnection(
                _config.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
        }

        /*---------------------------------------------------------------------
        메서드명: GetUserByRegiNum : UserViewModel

        기능 : 사업자등록번호를 이용한 특정 가맹점의 회원 정보를 얻는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public UserViewModel GetUserByRegiNum(string RegiNum)
        {
            UserViewModel r = new UserViewModel();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * From Login Where RegiNum = @RegiNum";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@RegiNum", RegiNum);

            con.Open();
            IDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                r.Id = dr.GetString(0);
                r.Password = dr.GetString(1);
                r.RegiNum = dr.GetString(2);
                r.Check = dr.GetBoolean(3);
            }
            con.Close();

            return r;
        }

        /*---------------------------------------------------------------------
        메서드명: ModifyUser : void

        기능 : 회원 정보를 수정하는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public void ModifyUser(string password, string RegiNum)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Update Login Set Password = @Password " +
                "Where RegiNum = @RegiNum";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@RegiNum", RegiNum);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: IsCorrectUser : bool

        기능 : 아이디와 암호가 해당 회원의 정보와 동일한지 아닌지를 확인하는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        //아이디와 암호가 동일한 사용자면 참 그렇지 않으면 거짓
        public bool IsCorrectUser(string Id, string password)
        {
            bool result = false;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * From Login "
                    + " Where Id = @Id And Password = @Password";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                result = true;  //아이디와 암호가 맞는 데이터가 있다면
            }
            con.Close();
            return result;
        }

        /*---------------------------------------------------------------------
        메서드명: Register : void

        기능 : 회원가입 요청 시 Register DB에 그 정보를 담는 기능

        만든날짜: 2023-03-07

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public void Register(string Id, string password, string RegiNum)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
          
            cmd.CommandText = "Insert Into Register Values("
                    + "@Id, @Password, @RegiNum, 'false', GetDate())";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@RegiNum", RegiNum);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*---------------------------------------------------------------------
        메서드명: IsCheck : void

        기능 : 임시 로그인인지 아닌지를 판별하는 기능

        만든날짜: 2023-03-22

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public bool IsCheck(string Id)
        {
            bool check = false;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select [Check] From Login Where Id = @Id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);

            IDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                check = dr.GetBoolean(0);
            }
            con.Close();

            return check;
        }

        /*---------------------------------------------------------------------
        메서드명: GetRegiNum : string

        기능 : Id에 해당하는 사업자등록번호 정보를 가져오는 기능

        만든날짜: 2023-03-24

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public string GetRegiNum(string Id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select [RegiNum] From Login Where Id = @Id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);

            IDataReader dr = cmd.ExecuteReader();
            string temp = String.Empty;
            if (dr.Read())
            {
                temp = dr.GetString(0);
            }
            con.Close();

            return temp;
        }

        /*---------------------------------------------------------------------
        메서드명: Regist : void

        기능 : 회원승인 요청한 ID와 PW로 로그인정보를 적용하는 기능

        만든날짜: 2023-03-27

        수정날짜 : X
        기타사항 : X
        연관함수 : X
        -----------------------------------------------------------------------*/
        public void Regist(string RegiNum)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select [Id],[Password] From [Register] Where [RegiNum] = @RegiNum";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@RegiNum", RegiNum);

            IDataReader dr = cmd.ExecuteReader();
            string Id = String.Empty;
            string Pw = String.Empty;
            if (dr.Read())
            {
                Id = dr.GetString(0);
                Pw = dr.GetString(1);
            }

            dr.Close();

            con.Close();
            con.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandText = "Update Login Set [Id] = @Id, [Password] = @Password, [Check] = 'true' Where RegiNum = @RegiNum";
            cmd2.CommandType = CommandType.Text;

            cmd2.Parameters.AddWithValue("@Id", Id);
            cmd2.Parameters.AddWithValue("@Password", Pw);
            cmd2.Parameters.AddWithValue("@RegiNum", RegiNum);
            cmd2.ExecuteNonQuery();

            con.Close();

        }

        public void Log(string Id,string Log)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert Into [LoginLog] Values("
                + "@Id,@Log,GetDate())";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Log", Log);
            cmd.ExecuteNonQuery();
            con.Close();

            if(Log == "로그아웃")
            {
                con.Open();

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "Update [LoginLog] Set [Log] = '로그인' Where Id = @Id";
                cmd2.CommandType = CommandType.Text;

                cmd2.Parameters.AddWithValue("@Id", Id);
                cmd2.ExecuteNonQuery();

                con.Close();
            }

        }

        public bool MailNotice(string Id)
        {
            string RegiNum = GetRegiNum(Id);
            /*con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select [Time] From [LoginLog] Where [Id] = @Id AND [Time] IN (Select MAX([Time]) From [LoginLog] Where [Log] = '로그인')";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@Id", Id);

            IDataReader dr = cmd.ExecuteReader();
            DateTime LoginTime = new DateTime();
            if (dr.Read())
            {
                LoginTime = dr.GetDateTime(0);
            }

            dr.Close();
            con.Close();*/
            con.Open();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            /*AND[Date] IN(Select MAX([Date]) From[Mail])*/
            cmd2.CommandText = "Select [Read] From [Mail] Where [RegiNum] = @RegiNum";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.AddWithValue("@RegiNum", RegiNum);

            IDataReader dr = cmd2.ExecuteReader();
            bool Read = false;
            while(dr.Read())
            {
                Read = dr.GetBoolean(0);
                if (Read == true) break;
            }

            dr.Close();
            if (!Read)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
