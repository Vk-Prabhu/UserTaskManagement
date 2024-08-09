using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.DAL.Interfaces
{
    public interface ITaskDetailsRepository 
    {
        Task AddTask(TaskDetail taskDetail);
        Task<TaskDetail> GetTaskById(int Id);
        Task<TaskDetail> UpdateTask(TaskDetail taskDetail);
        IEnumerable<TaskDetail> GetAllTask();
        Task<TaskDetail> DeleteTask(int id);
    }
}
