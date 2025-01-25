using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProje.Application.Features.Mediator.Commands.LocationCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.LocationHandler
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand, Unit>
    {
        private readonly IRepository<Location> _repository;

        public RemoveLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
           var value=await _repository.GetByIdAsync(request.Id);

            await _repository.RemoveAsync(value);

            return Unit.Value;


        }
    }
}
