using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.LocationCommand
{
    public class RemoveLocationCommand:IRequest<Unit>
    {
        public RemoveLocationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
