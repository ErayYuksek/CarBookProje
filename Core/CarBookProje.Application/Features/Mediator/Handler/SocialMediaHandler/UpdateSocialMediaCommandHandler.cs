using CarBookProje.Application.Features.Mediator.Commands.SocialMediaCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.SocialMediaHandler
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, Unit>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.SocialMediaID);
            values.Url = request.Url;
            values.Icon = request.Icon;
            values.Name = request.Name;
            await _repository.UpdateAsync(values);     
            return Unit.Value;
        }

    }
}
