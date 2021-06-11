using System;

namespace TAP.DataAccess
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
