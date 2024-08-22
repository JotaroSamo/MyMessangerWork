using AutoMapper;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Mapper
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserEntity>()
             .ForMember(dest => dest.ChatUsers, opt => opt.MapFrom(src => src.ChatUsers))
             .ReverseMap()
             .ForMember(dest => dest.ChatUsers, opt => opt.MapFrom(src => src.ChatUsers));

            // Chat mapping
            CreateMap<Chat, ChatEntity>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages))
                .ReverseMap()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages));

            // Message mapping
            CreateMap<Message, MessageEntity>()
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments))
                .ReverseMap()
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachments));

            // Attachment mapping
            CreateMap<Attachment, AttachmentEntity>()
                .ReverseMap();
        }
    }
    
}
