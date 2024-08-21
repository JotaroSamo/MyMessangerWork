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
    public class MapperCoreDB: Profile
    {
        public MapperCoreDB()
        {
            CreateMap<UserEntity, User>()
                 .ForMember(dest => dest.ChatUsers, opt => opt.MapFrom(src => src.ChatUsers.ToList()));

            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.ChatUsers, opt => opt.MapFrom(src => src.ChatUsers.ToList()));
            CreateMap<ChatEntity, Chat>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => User.Create(u.Id, u.Name, u.Email, u.HashPassword, u.PictureUserPath, null)).ToList()))
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select(m => new Message(m.Id, m.DateCreated, m.MessageType, m.Text, m.UserId, m.ChatId)).ToList()));

            CreateMap<Chat, ChatEntity>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users.Select(u => new UserEntity
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    HashPassword = u.HashPassword,
                    PictureUserPath = u.PictureUserPath
                }).ToList()))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Select(m => new MessageEntity
                {
                    Id = m.Id,
                    DateCreated = m.DateCreated,
                    MessageType = m.Type,
                    Text = m.Text,
                    UserId = m.UserId,
                    ChatId = m.ChatId
                }).ToList())); 
            //CreateMap<ChatUserEntity, ChatUser>()
            //.ForMember(dest => dest.Chat, opt => opt.MapFrom(src => Chat.Create(src.Chat.Id, src.Chat.Name, src.Chat.Hub, null, src.Chat.CreatedAt, src.Chat.UpdatedAt, null, src.Chat.PictureChatPath)))
            //.ForMember(dest => dest.User, opt => opt.MapFrom(src => User.Create(src.User.Id, src.User.Name, src.User.Email, src.User.HashPassword, src.User.PictureUserPath, null)));

            //CreateMap<ChatUser, ChatUserEntity>()
            //    .ForMember(dest => dest.Chat, opt => opt.MapFrom(src => new ChatEntity
            //    {
            //        Id = src.ChatId,
            //        Name = src.Chat.Name,
            //        Hub = src.Chat.Hub,
            //        CreatedAt = src.Chat.CreatedAt,
            //        UpdatedAt = src.Chat.UpdatedAt,
            //        PictureChatPath = src.Chat.PictureChatPath
            //    }))
            //    .ForMember(dest => dest.User, opt => opt.MapFrom(src => new UserEntity
            //    {
            //        Id = src.UserId,
            //        Name = src.User.Name,
            //        Email = src.User.Email,
            //        HashPassword = src.User.HashPassword,
            //        PictureUserPath = src.User.PictureUserPath
            //    }));
            CreateMap<MessageEntity, Message>();
            CreateMap<Message, MessageEntity>();
        }
    }
    
}
