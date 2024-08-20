using Microsoft.EntityFrameworkCore;
using MyMessagerWork.DataAcess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Repositories
{
    public class MessageRepository 
    {
        private readonly MessagerDbContext _messagerDbContext;

        public MessageRepository(MessagerDbContext messagerDbContext)
        {
            _messagerDbContext = messagerDbContext;
        }
   
    }
}
