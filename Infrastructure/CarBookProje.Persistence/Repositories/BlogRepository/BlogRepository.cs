using CarBookProje.Application.Interfaces.BlogInterfaces;
using CarBookProje.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Persistence.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

		public List<Blog> GetAllBlogWithAuthors()
		{
		 var values=_context.Blogs.Include(x => x.Author).ToList(); 
            return values;
		}

        public List<Blog> GetBlogByAuthorId(int id)
        {
          var  values = _context.Blogs.Include(x => x.Author).Where(x => x.BlogID == id).ToList();
            return values;
        }

        //Bu kod Entity Framework Core(EF Core) kullanarak Blog tablosundaki tüm kayıtları yazar bilgileriyle birlikte çekiyor.

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()

        {
            var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();

            return values;
        }


    }
}
