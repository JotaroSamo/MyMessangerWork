using AutoMapper;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Mapper
{
    public class MapperCoreDB: Profile
    {
        public MapperCoreDB()
        {
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
