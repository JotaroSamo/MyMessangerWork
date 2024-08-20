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
    public class ChatRepository 
    {
        private readonly MessagerDbContext _messagerDbContext;

        public ChatRepository(MessagerDbContext messagerDbContext)
        {
           _messagerDbContext = messagerDbContext;
        }
     
    }
}
