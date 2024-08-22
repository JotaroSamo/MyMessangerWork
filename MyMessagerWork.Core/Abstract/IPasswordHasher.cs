using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Core.Abstract
{
    public interface IPasswordHasher
    {
        string  Generate(string password);
        bool Verify(string password, string hashedpassword);
    }
}
