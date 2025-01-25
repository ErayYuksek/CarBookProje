using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.PricingCommand
{
    public class RemovePricingCommand:IRequest<Unit>
    {
        public RemovePricingCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
