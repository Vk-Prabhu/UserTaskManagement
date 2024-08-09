using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.DAL.Interface
{
    public interface IUserDetailRepository
    {
      Task AddUser(TaskUser userDetail);
      Task<TaskUser> UpdateUser(TaskUser taskUser);
      IEnumerable<TaskUser> GetAllUsers();
      Task<TaskUser> GetUserById(int id);
      Task<TaskUser> DeleteUser(int id);
        Task<TaskUser> GetByUserName(string username);
    }
}
