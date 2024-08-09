using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;

namespace TaskManagementSystem.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TaskDetailController : ControllerBase
    {
        ITaskDetailService _taskService;
        public TaskDetailController(ITaskDetailService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskDetailModel model)
        {
            var result = await _taskService.AddTask(model);
            return Ok(result);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(TaskDetailModel model, int Id)
        {
            await _taskService.UpdateTask(model, Id);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var result = await _taskService.GetTaskById(id);
            return Ok(result);  
        }

        [HttpGet]
        public IActionResult GetAllTask()
        {
            var result = _taskService.GetAllTasks();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTask(id);
            return Ok();
        }
    }
}
