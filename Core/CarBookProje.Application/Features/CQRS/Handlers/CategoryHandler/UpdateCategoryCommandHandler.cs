using CarBookProje.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.CategoryHandler
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CategoryID);

            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}

//GetByIdAsync(command.CategoryID):
//CategoryID'ye göre, repository'den ilgili kategori verisini çekiyor.

//command.Name:
//Çekilen kategori nesnesinin (values) Name alanını, command.Name ile güncelliyor. Yani, UpdateCategoryCommand içindeki yeni bir isim bilgisi alınıyor.

//UpdateAsync(values):
//Güncellenen kategori nesnesini (values), repository üzerinden veri tabanına geri gönderip kaydediyor.

//Sonuç olarak, bu kod, CategoryID ile seçtiği kategoriyi alıyor ve o kategoriye yeni bir isim atanarak güncelleniyor. UpdateCategoryCommand ise bu işlem sırasında yeni bilgiyi (Name) sağlayan bir veri yapısıdır.