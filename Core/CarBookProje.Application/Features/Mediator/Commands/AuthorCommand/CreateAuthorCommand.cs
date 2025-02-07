using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.AuthorCommand
{
    public class CreateAuthorCommand:IRequest<Unit>
    {
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
