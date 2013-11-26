using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ChessService.Models
{
    public interface IUsersRepository
    {
        Guid UserRegister(Users user);
        Guid UserUpdate(Users user);
        IEnumerable<Users> GetUsers();
        Users GetUser(Guid UserId);
        Users GetUser(string login, string password);
    }
}
