using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.BAL.Interfaces
{
    public interface ITaskDetailService
    {
        Task<TaskDetailModel> AddTask(TaskDetailModel model);
        Task<TaskDetailModel> UpdateTask(TaskDetailModel model, int id);
        List<TaskDetailModel> GetAllTasks();
        Task<TaskDetailModel> GetTaskById(int id);
        Task<TaskDetailModel> DeleteTask(int id);
    }
}
