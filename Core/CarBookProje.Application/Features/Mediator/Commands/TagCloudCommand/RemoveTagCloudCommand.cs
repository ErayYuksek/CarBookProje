using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.TagCloudCommand
{
    public class RemoveTagCloudCommand : IRequest<Unit>
    {
        public RemoveTagCloudCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
