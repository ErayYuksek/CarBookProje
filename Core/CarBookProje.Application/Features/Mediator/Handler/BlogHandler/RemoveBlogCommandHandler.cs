using CarBookProje.Application.Features.Mediator.Commands.BlogCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.BlogHandler
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand, Unit>
    {

        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public  async Task<Unit> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
           
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(values);
            return Unit.Value;
        }
    }
}
