using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Franchise.Web.Models
{
    public class QnARepository : IQnARepository
    {
        private IConfiguration _config;
        private SqlConnection con;
        private ILogger<QnARepository> _logger;

        /// <summary>
        /// 환경변수와 로그 개체 주입
        /// </summary>
        public QnARepository(IConfiguration config, 
            ILogger<QnARepository> logger)
        {
            _config = config;
            con = new SqlConnection(
                _config.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
            _logger = logger;
        }

        public List<QnA> GetAll()
        {
            try
            {
                string sql = "SELECT * From [ChatLog]";
                return con.Query<QnA>(sql).ToList();
            }
            catch (System.Exception ex)
            {
                _logger.LogError("데이터 출력 에러: " + ex);
                return null;
            }
        }
        
        public QnA GetDetail(string question)
        {
            string sql = "SELECT * FROM ChatLog Where Question = @Question";
            return con.Query<QnA>(sql, new { Question = question }).SingleOrDefault();
        }
    }
}
