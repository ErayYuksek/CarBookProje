using CarBookProje.Application.Features.Mediator.Commands.AuthorCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.AuthorHandler
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, Unit>
    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
            return Unit.Value;

        }
    }
}
