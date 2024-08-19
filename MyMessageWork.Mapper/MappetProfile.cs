using AutoMapper;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;
using System.Reflection.Metadata;

namespace MyMessageWork.Mapper
{
    public class MappetProfile: Profile
    {
        public MappetProfile()
        {
            CreateMap<User, UserEntity>();
        }
    }
}
