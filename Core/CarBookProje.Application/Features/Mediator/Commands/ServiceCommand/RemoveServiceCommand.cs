using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.ServiceCommand
{
    public class RemoveServiceCommand:IRequest<Unit>
    {
        public RemoveServiceCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
