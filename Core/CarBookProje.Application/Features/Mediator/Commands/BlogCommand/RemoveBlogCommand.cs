using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.BlogCommand
{
    public class RemoveBlogCommand:IRequest<Unit>
    {
        public RemoveBlogCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
