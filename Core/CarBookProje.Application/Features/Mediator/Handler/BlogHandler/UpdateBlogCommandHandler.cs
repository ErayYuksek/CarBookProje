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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Unit>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.BlogID = request.Id;
            values.Title = request.Title;
            values.AuthorID = request.AuthorID;
            values.CoverImageUrl = request.CoverImageUrl;
            values.CreatedDate = request.CreatedDate;
            values.CategoryID = request.CategoryID;
            await _repository.UpdateAsync(values);
            return Unit.Value;
        }
    }
}


//Kullanıcı bir blogun başlığını, yazarını veya kapak görselini değiştirmek ister.
//Yeni bilgiler API'ye gönderilir.
//Bu komut çalıştırılır, mevcut blog bilgileri alınır ve güncellenir.

