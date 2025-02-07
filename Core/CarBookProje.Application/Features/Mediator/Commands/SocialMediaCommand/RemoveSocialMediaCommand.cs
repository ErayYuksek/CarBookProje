using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.SocialMediaCommand
{
    public class RemoveSocialMediaCommand:IRequest<Unit>
    {
        public RemoveSocialMediaCommand(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
