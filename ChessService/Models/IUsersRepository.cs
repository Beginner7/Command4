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
        Guid UserRegister(User user);
        Guid UserUpdate(User user);
        IEnumerable<User> GetUsers();
        User GetUser(Guid UserId);
        User GetUser(string login, string password);
    }
}
