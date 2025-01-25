using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.PricingCommand
{
    public class UpdatePricingCommand:IRequest<Unit>
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
    }
}
