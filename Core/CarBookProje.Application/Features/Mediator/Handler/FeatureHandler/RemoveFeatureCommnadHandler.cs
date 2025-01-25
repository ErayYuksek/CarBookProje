using CarBookProje.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand, Unit>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                throw new KeyNotFoundException("Feature not found.");
            }

            await _repository.RemoveAsync(value);

            // İşlem tamamlandığında MediatR için Unit.Value döndürülür
            return Unit.Value;
        }
    }
}
