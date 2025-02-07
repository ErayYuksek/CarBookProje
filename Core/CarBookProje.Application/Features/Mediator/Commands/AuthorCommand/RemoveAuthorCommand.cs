using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.AuthorCommand
{
    public class RemoveAuthorCommand:IRequest<Unit>
    {
        public RemoveAuthorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
