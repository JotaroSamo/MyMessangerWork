using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.DataAcess.Entity
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public MessageType MessageType { get; set; }
        public string? Text { get; set; }
        public UserEntity User { get; set; }
        public ChatEntity Chat { get; set; }
    }
    public enum MessageType
    {
        Text
        //Img,
        //Video,
        //File
    }
}
