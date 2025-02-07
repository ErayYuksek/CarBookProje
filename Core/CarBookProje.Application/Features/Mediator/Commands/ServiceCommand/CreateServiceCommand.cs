using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.ServiceCommand
{
    public class CreateServiceCommand:IRequest<Unit>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
    }
}
