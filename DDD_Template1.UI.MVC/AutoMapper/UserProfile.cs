using AutoMapper;
using DDD_Template1.Domain.Entities;
using DDD_Template1.UI.MVC.Models;

namespace DDD_Template1.UI.MVC.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginViewModel, User>().ReverseMap();
        }
    }
}