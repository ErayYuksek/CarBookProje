using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Commands.LocationCommand
{
    public class CreateLocationCommand : IRequest<Unit>
    {
        public string? Name { get; set; }

    }
}

//Veritabanı Tarafında Otomatik Oluşturulma
//Genellikle ID gibi benzersiz anahtarlar, veritabanı tarafından otomatik olarak üretilir. Örneğin:
//SQL Server: ID birincil anahtar olarak tanımlanmışsa ve IDENTITY özelliği verilmişse, her yeni kayıt için benzersiz bir ID üretilir.