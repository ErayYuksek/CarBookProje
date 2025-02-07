using CarBookProje.Application.Features.Mediator.Commands.AuthorCommand;
using CarBookProje.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.Mediator.Handler.AuthorHandler
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
       private readonly IRepository<Author> _repository;

        public CreateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
           await _repository.CreateAsync(new Author
            {
               Description = request.Description,
               ImageUrl = request.ImageUrl,
               Name = request.Name
           });

            return Unit.Value; // Unit döndürülmelidir
        }
    }
}
//Bu kod, kullanıcıdan gelen yazar bilgilerini alıp bir yazar nesnesi oluşturmayı ve bunu bir depolama alanına (örneğin, bir veritabanına) kaydetmeyi amaçlıyor.

//Eğer herhangi bir sorunuz varsa ya da bu kodun nasıl geliştirileceği hakkında bilgi isterseniz, sorabilirsiniz! 😊