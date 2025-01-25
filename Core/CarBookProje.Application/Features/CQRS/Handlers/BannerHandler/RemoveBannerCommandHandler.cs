using CarBookProje.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProje.Application.Interfaces;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.BannerHandler
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ID);
            await _repository.RemoveAsync(value);
        }
    }
}
