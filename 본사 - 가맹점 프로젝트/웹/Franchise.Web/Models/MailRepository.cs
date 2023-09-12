using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Franchise.Web.Models
{
    public class MailRepository : IMailRepository
    {
        private IConfiguration _config;
        private SqlConnection con;

        public MailRepository(IConfiguration config)
        {
            _config = config;
            con = new SqlConnection(
                _config.GetSection("ConnectionStrings")
                .GetSection("DefaultConnection").Value);
        }

        public List<Mail> GetMail(string regiNum)
        {
            try
            {
               return con.Query<Mail>("Select * From Mail Where @RegiNum = RegiNum", new { RegiNum = regiNum }).ToList();
            }
            catch
            {
                return null;
            }
        }

        public Mail GetMailDetail(int num)
        {
            try
            {
                con.Query("Update [Mail] Set [Read] = 'true' Where Num = @Num", new { Num = num });
                return con.Query<Mail>("Select * From Mail Where Num = @Num", new { Num = num }).SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public void DeleteMail(int num)
        {
            con.Query("Delete From Mail Where Num = @Num", new { Num = num });
        }
    }
}
