using CarBookProje.Application.Features.Mediator.Commands.SocialMediaCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.SocialMediaHandler
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, Unit>
    {
        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocialMedia
            {
                Name = request.Name,
                Url = request.Url,
                Icon = request.Icon,
            }
           );
            return Unit.Value;
        }
    }
}
