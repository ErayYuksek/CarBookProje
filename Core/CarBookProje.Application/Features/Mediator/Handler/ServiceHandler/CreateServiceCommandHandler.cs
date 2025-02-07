using CarBookProje.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.ServiceHandler
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Unit>
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {

            await _repository.CreateAsync(new Service
            {
                Desciription =request.Description,
                Title=request.Title,
                IconUrl=request.IconUrl

            });
            return Unit.Value;

        }
    }
}
