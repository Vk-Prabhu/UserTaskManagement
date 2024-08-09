using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.UI.Controllers
{
    public class TaskDetailController : Controller
    {
        
        ITaskDetailService _taskDetailService;
        IMapper _mapper;

        public TaskDetailController(ITaskDetailService taskDetailService,IMapper mapper)
        {
            _taskDetailService = taskDetailService;
            _mapper = mapper;
        }

        [HttpGet]

        public IActionResult TaskList()
        {
            var task = _taskDetailService.GetAllTasks();
            return View(task);
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            var model = new TaskDetailModel();
            return View(model);
        }
        [HttpGet]
        public async Task <IActionResult> EditTask(int id)
        {
            var model = new TaskDetailModel();
            if (id > 0)
            {
                var data = await _taskDetailService.GetTaskById(id);
                model = _mapper.Map<TaskDetailModel>(data);
            }
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskDetailModel model)
        {

            await _taskDetailService.AddTask(model);
            TempData["SuccessMessage"] = "Task Added successfully!";
            return RedirectToAction("TaskList");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditTask(TaskDetailModel model,int id)
        {
            
            await _taskDetailService.UpdateTask(model,id);
            TempData["SuccessMessage"] = "Task updated successfully!";
            return RedirectToAction(nameof(TaskList));
        }
        public async Task<IActionResult> DeleteTask(TaskDetailModel model, int id)
        {
            var result = await _taskDetailService.DeleteTask(id);
            TempData["SuccessMessage"] = "Task Deleted successfully!";
            return RedirectToAction(nameof(TaskList));
        }
    }
}
