using MyMessagerWork.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class AttachmentEntity
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public MessageType Type { get; set; }
    }
}
