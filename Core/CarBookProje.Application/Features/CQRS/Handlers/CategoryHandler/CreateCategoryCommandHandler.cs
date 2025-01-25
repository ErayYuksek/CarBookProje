using CarBookProje.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProje.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.CategoryHandler
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public CreateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new Category
            {
                Name = command.Name

            });
        }
    }
}
