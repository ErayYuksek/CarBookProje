using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.BlogCommand
{
    public class UpdateBlogCommand: IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int AuthorID { get; set; }
        public string? CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
    }
}
