using CarBookProje.Application.Features.Mediator.Commands.LocationCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.LocationHandler
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
    {
        private readonly IRepository<Location> _repository;

        public UpdateLocationCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.LocationID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);

            // İşlem başarılı olduğunda Unit döndür

            return Unit.Value;
        }
    }
}
