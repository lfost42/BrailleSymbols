using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Braille.Data;
using Braille.Data.Models;
using Braille.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Braille.Data.Data;

namespace Braille.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly AppSettings _appSettings;

        public UserRepository(ApplicationDbContext db, IOptions<AppSettings> appsettings)
        {
            _db = db;
            _appSettings = appsettings.Value;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user = _db.AppUsers.SingleOrDefault(x => x.Username == username && x.Password == password);

            //user not found
            if (user == null)
            {
                return null;
            }

            //if user was found generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials
                                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = "";
            return user;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.AppUsers.SingleOrDefault(x => x.Username == username);

            // return null if user not found
            if (user == null)
                return true;

            return false;
        }

        public UserModel Register(string username, string password)
        {
            UserModel userObj = new UserModel()
            {
                Username = username,
                Password = password,
            };

            _db.AppUsers.Add(userObj);
            _db.SaveChanges();
            userObj.Password = "";
            return userObj;
        }
    }
}
