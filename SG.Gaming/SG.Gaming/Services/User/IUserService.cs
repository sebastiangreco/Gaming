using SG.Gaming.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG.Gaming.Services.User
{
    public interface IUserService
    {
        Task<LoginResponse> LoginAsync(string username, string password);        
    }
}
