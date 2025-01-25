using UCarBook.Domain.Entities;
using MediatR;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Features.Mediator.Commands.FeatureCommands;

namespace CarBookProje.Application.Features.Mediator.Handler.FeatureHandler
{
   

    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, Unit>
    {
        private readonly IRepository<Feature> _repository;

        public CreateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Feature
            {
                Name = request.Name
            });

            return Unit.Value; // Unit döndürülmelidir
        }
    }
}
