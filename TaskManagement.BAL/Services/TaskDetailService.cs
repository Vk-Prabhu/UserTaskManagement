using AutoMapper;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;
using TaskManagementSystem.DAL.Entities;
using TaskManagementSystem.DAL.Interfaces;

namespace TaskManagementSystem.BAL.Services
{
    public class TaskDetailService : ITaskDetailService
    {
        readonly IMapper _mapper;
        ITaskDetailsRepository _taskDetailsRepository;
        public TaskDetailService(IMapper mapper,ITaskDetailsRepository taskDetailsRepository)
        {
            _mapper = mapper;
            _taskDetailsRepository = taskDetailsRepository;
        }

        public async Task<TaskDetailModel> AddTask(TaskDetailModel model)
        {
            DateTime dueDate = model.DueDate.ToUniversalTime();
             TaskDetail task = new TaskDetail()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = dueDate,
                IsCompleted = false,
                CreatedOn = DateTime.UtcNow,
                TaskUserId = model.TaskUserId
                
            };
            await _taskDetailsRepository.AddTask(task);
            return model;
        }

        public async Task<TaskDetailModel> UpdateTask(TaskDetailModel model,int id)
        {
            DateTime dueDate = model.DueDate.ToUniversalTime();
            var task = await _taskDetailsRepository.GetTaskById(id);
            if(task == null)
            {
                throw new Exception("User not found");
            }
            task.Title = model.Title;
            task.Description = model.Description;
            task.DueDate = dueDate;
            task.IsCompleted = false;
            task.UpdatedOn = DateTime.UtcNow;           
            await _taskDetailsRepository.UpdateTask(task);
            return _mapper.Map<TaskDetailModel>(task);
        }

        public List<TaskDetailModel> GetAllTasks()
        {
            var task = _taskDetailsRepository.GetAllTask();
            var taskList = _mapper.Map<List<TaskDetailModel>>(task);
            return taskList;
        }

        public async Task<TaskDetailModel> GetTaskById(int id)
        {
            var tasks = await _taskDetailsRepository.GetTaskById(id);
            if(tasks == null)
            {
                throw new Exception("Task Not Found,Enter a valid Id");
            }
            return _mapper.Map<TaskDetailModel>(tasks);
        }
        public async Task<TaskDetailModel> DeleteTask(int id)
        {
            var task = await _taskDetailsRepository.GetTaskById(id);
            if (task == null)
            {
                throw new Exception("Task Not Found,Please enter a valid Id");
            }
            await _taskDetailsRepository.DeleteTask(id);
            return _mapper.Map<TaskDetailModel>(task);
        }
    }
}
