using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly MessagerDbContext _messagerDbContext;

        private readonly IMapper _mapper;
        public MessageRepository(MessagerDbContext messagerDbContext, IMapper mapper)
        {
            _messagerDbContext = messagerDbContext;
            _mapper = mapper;
        }


        public async Task<Guid> AddAsync(Message entity)
        {
            var messageEntity = _mapper.Map<MessageEntity>(entity);
            await _messagerDbContext.Messages.AddAsync(messageEntity);
            await _messagerDbContext.SaveChangesAsync();
            return messageEntity.Id;
        }
        public async Task<List<Message>> GetByChatId(Guid chatid)
        {
            var messageEntity = _messagerDbContext.Messages.
                AsQueryable()
                .Include(a => a.Attachments).Where(i => i.ChatId == chatid).ToListAsync();
            var message = _mapper.Map<List<Message>>(messageEntity);
            return message;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _messagerDbContext.Messages.Where(i => i.Id == id).ExecuteDeleteAsync();
            await _messagerDbContext.SaveChangesAsync();
            return id;

        }
        public async Task SaveAsync()
        {
            await _messagerDbContext.SaveChangesAsync();
        }

    }
}
