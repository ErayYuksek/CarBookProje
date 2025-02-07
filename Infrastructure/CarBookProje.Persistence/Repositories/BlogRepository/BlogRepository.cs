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

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()

        {
            var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();

            return values;
        }


    }
}
