using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;
using TaskManagementSystem.DAL.Interface;

namespace TaskManagementSystem.DAL.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        DataContext _context;
        public UserDetailRepository(DataContext context)
        {
            _context = context;   
        }

        public async Task AddUser(TaskUser userDetail)
        {
            await _context.AddAsync(userDetail);
            await _context.SaveChangesAsync();

        }

        public async Task<TaskUser> UpdateUser(TaskUser taskUser)
        {
            _context.Update(taskUser);
            await _context.SaveChangesAsync();
            return taskUser;
        }

        public IEnumerable <TaskUser> GetAllUsers()
        {
           return _context.Set<TaskUser>().ToList();
        }

        public async Task<TaskUser> GetUserById(int id)
        {
            var result = await _context.TaskUsers.FindAsync(id);
            return result;
        }

        public async Task<TaskUser> DeleteUser(int id)
        {
            var result = await _context.TaskUsers.FindAsync(id);
            _context.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
        public async Task<TaskUser> GetByUserName(string username)
        {
            var user =  _context.TaskUsers.FirstOrDefault(u => u.UserName == username);
            return user;
        }
    }
}
