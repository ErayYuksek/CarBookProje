using CarBookProje.Application.Features.Mediator.Commands.TagCloudCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.TagCloudHandler
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand, Unit>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TagCloudId);
            values.Title = request.Title;
            values.BlogID = request.BlogID;
            await _repository.UpdateAsync(values);

            // İşlem başarılı olduğunda Unit döndür

            return Unit.Value;
        }
    }
}
