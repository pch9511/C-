using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Franchise.Web.Models
{
    public class OrderRepository : IOrderRepository
    {
        private IConfiguration _config;
        private SqlConnection con;
        private ILogger<OrderRepository> _logger;


        /// <summary>
        /// 환경변수와 로그 개체 주입
        /// </summary>
        public OrderRepository(
        IConfiguration config, ILogger<OrderRepository> logger)
        {
            _config = config;
            con = new SqlConnection(
                _config.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
            _logger = logger;
        }

        /// <summary>
        /// 해당 아이디의 주문내역을 불러옴
        /// </summary>
        public List<Order> GetAll(string regiNum)
        {
            try
            {
                string sql = string.Empty;
                if (regiNum == "Admin")
                {
                    sql = "SELECT * From [Order]";
                }
                else
                {
                    sql = "SELECT * From [Order] Where [RegiNum] = @RegiNum";
                }
                return con.Query<Order>(sql, new { RegiNum = regiNum }).ToList();
            }
            catch(System.Exception ex)
            {
                _logger.LogError("데이터 출력 에러: " + ex);
                return null;
            }
        }
    }
}
