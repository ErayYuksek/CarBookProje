using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.FooterAddressCommand
{
    public class RemoveFooterAddressCommand:IRequest<Unit>
    {
        public RemoveFooterAddressCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
