using CarBookProje.Application.Features.Mediator.Commands.FooterAddressCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.FooterAddressHandler
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand, Unit>
    {
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ID);
            if (values == null)
            {
                throw new KeyNotFoundException("Feature not found.");
            }
            await _repository.RemoveAsync(values);

            // İşlem tamamlandığında MediatR için Unit.Value döndürülür

            return Unit.Value;  
        }
    }
}
