using CSharpFunctionalExtensions;
using MyMessagerWork.Core.Abstract;
using MyMessagerWork.Core.Model;
using MyMessagerWork.DataAcess.Repositories;
using MyMessagerWork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMessagerWork.Application.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;

        private readonly IJwtProvider _jwtProvider;

        public UserService(IUserRepository repository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<Guid> AddAsyncUser(User entity)
        {
           return await _repository.AddAsync(entity);
          
        }


        public async Task<Guid> DeleteByIdUser(Guid id)
        {
          return  await _repository.DeleteById(id);
            
        }

        public async Task<List<User>> GetAllListUserAsync()
        {
           return await _repository.GetAllListAsync();
        }

        public async Task<User> GetByEmailUser(string email)
        {
           return await _repository.GetByEmail(email);
        }

        public async Task<User> GetByIdUserAsync(Guid id)
        {
          return await _repository.GetByIdAsync(id);
        }

        public async Task SaveAsyncUser()
        {
           await _repository.SaveAsync();
        }
        public async Task<Result<User>> Register(string name, string email, string password)
        {
            var hashedpassword = _passwordHasher.Generate(password);
            var user = MyMessagerWork.Core.Model.User.Create(Guid.NewGuid(), name, email, hashedpassword/*, filePath*/);
            await _repository.AddAsync(user.Value);
            return user;
        }
        public async Task<Result<string>> Login(string email, string password)
        {
            var user = await _repository.GetByEmail(email);
            if (user == null)
            {
                return Result.Failure<string>("User not found!");
            }
            if (!_passwordHasher.Verify(password, user.HashPassword))
            {
                return Result.Failure<string>("Password not correct!");

            }
            var token = _jwtProvider.GenerateToken(user);
            return Result.Success<string>(token);
        }
        public async Task<Guid> UpdateUser(User entity)
        {
           return await _repository.Update(entity);
        }
    }
}
