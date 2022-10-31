using AutoMapper;
using Dto.Test;
using Dto.User;
using Models.User;
using TestItem = Models.TestItem;

namespace Services.Mapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<Models.Test, TestDto>().ReverseMap();
            CreateMap<TestItem, TestItemDto>().ReverseMap();
        }
    }
}