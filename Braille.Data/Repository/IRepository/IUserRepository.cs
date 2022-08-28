using Braille.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        UserModel Authenticate(string username, string password);
        UserModel Register(string username, string password);
    }
}
