using CarBookProje.Application.Features.Mediator.Commands.PricingCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.PricingHandler
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand, Unit>
    {
        private readonly IRepository<Pricing> _repository;

        public CreatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
           await _repository.CreateAsync(new Pricing
            {
                Name = request.Name
            });
            return Unit.Value;
        }
    }
}
