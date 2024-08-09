using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;
using TaskManagementSystem.DAL.Interfaces;

namespace TaskManagementSystem.DAL.Repository
{
    public class TaskDetailsRepository : ITaskDetailsRepository
    {
        readonly DataContext _context;
        public TaskDetailsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddTask(TaskDetail taskDetail)
        {
            await _context.AddAsync(taskDetail);
            await _context.SaveChangesAsync();
        }
        public async Task<TaskDetail> UpdateTask(TaskDetail taskDetail)
        {
            _context.Update(taskDetail);
            await  _context.SaveChangesAsync();
            return taskDetail;
        }
        public async Task<TaskDetail> GetTaskById(int id)
        {
           var result = await _context.TaskDetails.FindAsync(id);
           return result;

        }
        public  IEnumerable<TaskDetail> GetAllTask()
        {
            return _context.Set<TaskDetail>().ToList();
        }

         public async Task<TaskDetail> DeleteTask(int id)
         {
            var task = await _context.TaskDetails.FindAsync(id);
            _context.Remove(task);
            await _context.SaveChangesAsync();
            return task;
         }
    }

    
}
