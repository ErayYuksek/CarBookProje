using CarBookProje.Application.Features.Mediator.Commands.PricingCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.PricingHandler
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand, Unit>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.PricingID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
