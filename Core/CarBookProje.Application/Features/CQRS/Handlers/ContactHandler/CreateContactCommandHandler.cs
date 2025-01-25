using CarBookProje.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Interfaces.Carİnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.ContactHandler
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            await _repository.CreateAsync(new Contact
            {
                Name = command.Name,
                Email = command.Email,
                Message = command.Message,
                SendDate = DateTime.Now,
                Subject = command.Subject
            });
        }
    }
}
