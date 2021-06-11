using System;
using System.Linq;
using TAP.Core;
using TAP.Core.Entities;
using TAP.DataAccess;
using TAP.DataAccess.Repositories;
using TAP.DataAccess.SqlServer;
using TAP.DataAccess.SqlServer.Repositories;

namespace TAP
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dataContext = new TAPContext())
            {
                IUnitOfWork unitOfWork = new UnitOfWork(dataContext);
                IDataRepository dataRepo = new DataRepository(dataContext);
                 var newAccount = new User
                 {
                     Name = "qwe123",
                     Password="11sdf",
                     Email="sd123f"
                 };
               /* var newAccount = dataRepo.Query<User>()
                     .SingleOrDefault(args => args.Name == "123");
                System.Console.WriteLine("Name:{0}, Email:{1}", newAccount.Name, newAccount.Email);*/
                dataRepo.Insert(newAccount);
                unitOfWork.Commit();//dataRepo.SaveChanges();
            }
            Console.WriteLine("Hello World!");
        }
    }
}
