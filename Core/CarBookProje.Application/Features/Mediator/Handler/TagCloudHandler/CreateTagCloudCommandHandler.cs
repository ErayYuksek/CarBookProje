using CarBookProje.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TagCloudHandler
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand, Unit>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud
            {
                Title= request.Title,
                BlogID = request.BlodID
            });
            return Unit.Value;
        }
    }
}
