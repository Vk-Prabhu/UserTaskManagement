using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.BAL.Interfaces;
using TaskManagementSystem.BAL.Models;
using TaskManagementSystem.DAL.Entities;
using TaskManagementSystem.DAL.Interface;

namespace TaskManagementSystem.BAL.Services
{
    public class UserDetailService : IUserDetailService
    {
        IUserDetailRepository _userDetailRepository;
        IMapper _mapper;
        IAuthService _authService;
        public UserDetailService(IUserDetailRepository userDetailRepository,IMapper mapper, IAuthService authService)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<UserDetailModel> AddUserDetails(UserDetailModel userDetail)
        {
            TaskUser user = new TaskUser()
            {
                UserName = userDetail.UserName,
                Password = userDetail.Password,
                ConfirmPassword = userDetail.ConfirmPassword,
                Email = userDetail.Email,
                CreatedOn = DateTime.UtcNow,
               
            };
            await _userDetailRepository.AddUser(user);
            return userDetail;
        }
        public async Task<UserDetailModel> UpdateUser(UserDetailModel model, int id)
        {
            var users = await _userDetailRepository.GetUserById(id);
            if (users == null) 
            {
                throw new Exception("User not found!,");
            }
            users.UserName = model.UserName;
            users.Password = model.Password;
            users.ConfirmPassword = model.ConfirmPassword;
            users.Email = model.Email;
            await _userDetailRepository.UpdateUser(users);
            return _mapper.Map<UserDetailModel>(users);    

        }

        public List<UserDetailModel> GetAllUsers()
        {
            var users =_userDetailRepository.GetAllUsers();
            var usersList = _mapper.Map<List<UserDetailModel>>(users);
            return usersList;
        }

        public async Task<UserDetailModel> GetUserById(int id)
        {
            var users = await _userDetailRepository.GetUserById(id);
            if (users == null)
            {
                throw new Exception("Task Not Found,Enter a valid Id");
            }
            return _mapper.Map<UserDetailModel>(users);
        }
        public async Task<UserDetailModel> DeleteUser(int id)
        {
            var users = await _userDetailRepository.GetUserById(id);
            if (users == null)
            {
                throw new Exception("Task Not Found,Please enter a valid Id");
            }
            await _userDetailRepository.DeleteUser(id);
            return _mapper.Map<UserDetailModel>(users);
        }
        public async Task<string> LoginUser(string username, string password)
        {
            var user = await _userDetailRepository.GetByUserName(username);
            return _authService.GenerateToken(new UserDetailModel { UserName = user.UserName });
        }
    }
}
