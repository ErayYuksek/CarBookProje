using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProje.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TagCloudHandler
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand, Unit>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
           var value=await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);

            return Unit.Value;


        }
    }
}
