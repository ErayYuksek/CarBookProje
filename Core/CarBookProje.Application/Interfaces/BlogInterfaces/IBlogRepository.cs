using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetLast3BlogsWithAuthors();
        
        public List<Blog> GetAllBlogWithAuthors();

        public List<Blog> GetBlogByAuthorId(int id);

    }
}
