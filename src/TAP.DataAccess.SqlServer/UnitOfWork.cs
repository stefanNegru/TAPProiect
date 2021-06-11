using System.Transactions;

namespace TAP.DataAccess.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TAPContext dataContext;

        public UnitOfWork(TAPContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Commit()
        {
            using (var scope = new TransactionScope())
            {
                dataContext.SaveChanges();
                scope.Complete();
            }
        }
    }
}