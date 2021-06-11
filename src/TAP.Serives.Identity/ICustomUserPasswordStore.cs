using Microsoft.AspNetCore.Identity;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TAP.Core.Entities;

namespace TAP.Services.Identity
{
    public interface ICustomUserPasswordStore : IUserPasswordStore<User>
    {
        public Task<User> FindByIdAndInclude<TInclude>(Expression<Func<User, TInclude>> expression, string userId, CancellationToken cancellationToken);
    }
}