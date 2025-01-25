using CarBookProje.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProje.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, Unit>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            // Feature'i ID'ye göre al
            var feature = await _repository.GetByIdAsync(request.FeatureID);

            if (feature == null)
            {
                throw new KeyNotFoundException("Feature not found.");
            }

            // Güncellemeyi gerçekleştir
            feature.Name = request.Name;
            await _repository.UpdateAsync(feature);

            // İşlem başarılı olduğunda Unit döndür
            return Unit.Value;
        }
    }
}
