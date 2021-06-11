using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TAP.Core.Entities;
using TAP.DataAccess.Repositories;

namespace TAP.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly IDataRepository dataRepository;

        public BlogServices(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        public void CreateBlog(Blog blog)
        {
            dataRepository.Insert(blog);
        }

        public void DeleteBlog(Blog blog)
        {
            dataRepository.Delete(blog);
        }

        public void EditBlog(Blog blog)
        {
            dataRepository.Update(blog);
        }
       
        public void DeleteBlog(Guid blogId)
        {
            var result = dataRepository.Query<Blog>().FirstOrDefault(_ => _.Id == blogId);
            dataRepository.Delete(result);
        }
    }
}
