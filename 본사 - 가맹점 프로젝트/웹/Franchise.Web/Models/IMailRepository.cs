using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Franchise.Web.Models
{
    public interface IMailRepository
    {
        List<Mail> GetMail(string RegiNum);
        Mail GetMailDetail(int Num);

        void DeleteMail(int num);
    }
}
