using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.TestimonialCommand
{
    public class RemoveTestimonialCommand:IRequest<Unit>
    {
        public RemoveTestimonialCommand(int ıd)
        {
            Id = ıd;
        }

        public  int Id{ get; set; }
    }
}
