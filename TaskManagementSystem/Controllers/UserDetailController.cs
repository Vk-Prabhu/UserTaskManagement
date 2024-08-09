using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;
using TaskManagementSystem.BAL.Services;

namespace TaskManagementSystem.API.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        IUserDetailService _userDetail;
        public UserDetailController(IUserDetailService userDetail)
        {
            _userDetail = userDetail;
        }

        [HttpPost("{Register}")]
        public async Task<IActionResult> AddUser([FromBody] UserDetailModel model)
        {
            var result = await _userDetail.AddUserDetails(model);
            return Ok(result);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(UserDetailModel model, int Id)
        {
            await _userDetail.UpdateUser(model, Id);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await _userDetail.GetUserById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var result = _userDetail.GetAllUsers();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userDetail.DeleteUser(id);
            return Ok();
        }
        [HttpPost("{login}")]

        public async Task<IActionResult> UserLogin(string username, string password)
        {
            await _userDetail.LoginUser(username, password);
            return Ok();
        }
    }
}
