using CarBookProje.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.BannerHandler
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerID);
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;
            value.Title = command.Title;
            value.Description = command.Description;
            await _repository.UpdateAsync(value);

        }
    }
}
