using AutoMapper;
using TaskManagementSystem.BAL.Models;
using TaskManagementSystem.DAL.Entities;

namespace TaskManagementSystem.UI
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<TaskDetail, TaskDetailModel>().ReverseMap();
            CreateMap<TaskUser, UserDetailModel>().ReverseMap();           
        }

    }
}
