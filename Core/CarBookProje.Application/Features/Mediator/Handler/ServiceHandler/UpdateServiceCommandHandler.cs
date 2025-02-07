using CarBookProje.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.ServiceHandler
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Unit>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceID);
            values.Desciription = request.Description;
            values.IconUrl = request.IconUrl;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}
