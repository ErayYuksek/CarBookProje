using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.LocationCommand
{
    public class UpdateLocationCommand:IRequest<Unit>
    {
        public int LocationID { get; set; }
        public string? Name { get; set; }
    }
}
