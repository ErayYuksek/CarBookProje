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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Unit>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                AuthorID = request.AuthorID,
                Title = request.Title,
                CategoryID = request.CategoryID,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = DateTime.Now,
            });
            return  Unit.Value;
        }
    }
}
