using CarBookProje.Application.Features.Mediator.Commands.LocationCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.LocationHandler
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
    {
        private readonly IRepository<Location> _repository;

        public CreateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Location
            {
                Name = request.Name,
            });
            return Unit.Value;
        }
    }
}
