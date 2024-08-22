using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMessagerWork.Core.Model.Message;

namespace MyMessagerWork.Core.Model
{
    public class Attachment
    {
        private Attachment(Guid id, string filePath, MessageType type)
        {
            Id = id;
            FilePath = filePath;
            Type = type;
        }

        public Guid Id { get; }
        public string FilePath { get; }
        public MessageType Type { get; }

        public static Result<Attachment> Create(Guid id, string filePath, MessageType type)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return Result.Failure<Attachment>("FilePath is required.");
            }

            var attachment = new Attachment(id, filePath, type);
            return Result.Success(attachment);
        }
    }

}
