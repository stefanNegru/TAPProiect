using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TAP.Core.Entities;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;

namespace TAP.Services.Identity
{
    public class UserStore : ICustomUserPasswordStore
    {
        private readonly IDataRepository _dataRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            _dataRepository = dataRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            _dataRepository.Insert(user);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            _dataRepository.Delete(user);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(userId, out id);
            var user = _dataRepository.Query<User>()
                .SingleOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<User> FindByIdAndInclude<TInclude>(Expression<Func<User, TInclude>> expression, string userId, CancellationToken cancellationToken)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(userId, out id);
            var result = _dataRepository.Query<User>().Include(expression).SingleOrDefault(_ => _.Id == id);
            return Task.FromResult(result);
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = _dataRepository.Query<User>()
                .SingleOrDefault(u => u.Name == normalizedUserName);

            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name.ToLower());
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Password);
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Name);
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(!String.IsNullOrEmpty(user.Password));
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Name = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            user.Name = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var dbUser = _dataRepository.Query<User>()
                .Single(u => u.Id == user.Id);
            dbUser.Password = user.Password;
            dbUser.Name = user.Name;
            _dataRepository.Update(dbUser);
            _unitOfWork.Commit();
            return Task.FromResult(IdentityResult.Success);
        }
    }
}