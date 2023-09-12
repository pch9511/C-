using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Franchise.Web.Models
{

    public interface IUserRepository
    {
        UserViewModel GetUserByRegiNum(string RegiNum);
        bool IsCorrectUser(string Id, string password);
        void ModifyUser(string password, string RegiNum);
        void Register(string Id, string password, string RegiNum);

        bool IsCheck(string Id);

        string GetRegiNum(string Id);

        void Regist(string RegiNum);

        void Log(string Id, string Log);

        bool MailNotice(string Id);
    }
}
