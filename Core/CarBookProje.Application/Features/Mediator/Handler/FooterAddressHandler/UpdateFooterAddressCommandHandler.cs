using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
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
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand, Unit>
    {

        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.FooterAddressID);
            
            if (values == null)
            {
                throw new KeyNotFoundException("Footer Address Not Found ");
            }
            values.Phone = request.Phone;
            values.Email = request.Email;
            values.Adress = request.Address;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);

            // İşlem başarılı olduğunda Unit döndür

            return Unit.Value;

        }
    }
}
