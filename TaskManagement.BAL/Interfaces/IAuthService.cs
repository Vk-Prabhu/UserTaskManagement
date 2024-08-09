using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.BAL.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(UserDetailModel user);
    }
}
