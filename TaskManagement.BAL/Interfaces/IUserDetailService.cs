using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.BAL.Interfaces
{
    public interface IUserDetailService
    {
        Task<UserDetailModel> AddUserDetails(UserDetailModel userDetail);
        Task<UserDetailModel> UpdateUser(UserDetailModel model, int id);
        List<UserDetailModel> GetAllUsers();
        Task<UserDetailModel> GetUserById(int id);
        Task<UserDetailModel> DeleteUser(int id);
        Task<string> LoginUser(string username, string password);
    }
}
