using CarBookProje.Application.Features.Mediator.Commands.PricingCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.PricingHandler
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand, Unit>
    {
        private readonly IRepository<Pricing> _repository;

        public RemovePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
            return Unit.Value;
        }
    }
}
