using CarBookProje.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProje.Application.Features.Mediator.Commands.FooterAddressCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.FooterAddressHandler
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand, Unit>
    {
        private readonly IRepository<FooterAddress> _repository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new FooterAddress
            {
                Adress = request.Address,
                Description = request.Description,
                Email = request.Email,
                Phone = request.Phone

            });
            return Unit.Value;
        }
    }
}
