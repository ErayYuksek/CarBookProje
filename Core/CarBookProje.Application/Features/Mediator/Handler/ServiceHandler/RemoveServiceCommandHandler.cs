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
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand, Unit>
    {
        private readonly IRepository<Service> _repository;

        public RemoveServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
           var values= await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
            return Unit.Value;
        }
    }
}
