using CarBookProje.Application.Features.CQRS.Queries.ContactQueries;
using CarBookProje.Application.Features.CQRS.Results.ContactResults;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.ContactHandler
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.ID);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email = values.Email,
                Message = values.Message,
                SendDate = values.SendDate,
                Subject = values.Subject
            };
        }
    }
}
