using BCrypt.Net;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapToolSystem.BLL
{
    public class User_PermitionService
    {
        private readonly MapToolContext _context;

        public User_PermitionService(MapToolContext regcontext)
        {
            _context = regcontext;
        }
        public async Task<User_Permition> UserPermition_GetByNameAndPassword(string userName, string password)
        {
            bool isValidPassword = false;

            User_Permition user = await _context.UserPermitions
                              .FirstOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (user.UserName == userName && isValidPassword)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
