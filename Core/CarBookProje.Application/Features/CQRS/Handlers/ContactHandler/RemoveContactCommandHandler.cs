using CarBookProje.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.ContactHandler
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ID);
            await _repository.RemoveAsync(value);
        }

    }
}
