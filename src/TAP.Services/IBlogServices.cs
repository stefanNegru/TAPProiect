using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TAP.Core.Entities;

namespace TAP.Services
{
    public interface IBlogServices
    {
        void CreateBlog(Blog blog);

        void DeleteBlog(Blog blog);

        void DeleteBlog(Guid blogId);

        void EditBlog(Blog blog);


    }
}
