using CarBookProje.Application.Features.CQRS.Commands.CarCommands;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.CarHandler
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarCommand command)
        {
            await _repository.CreateAsync(new Car
            {
                BrandID = command.BrandID,
                BigImageUrl = command.BigImageUrl,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Km = command.Km,
                Luggage = command.Luggage,
                Model = command.Model,
                Seat = command.Seat,
                Transmission = command.Transmission,
            });
        }
    }
}


//CreateCarCommand: Kullanıcıdan gelen bilgileri alıyor.
//Car: Bu bilgilerle bir araba nesnesi oluşturuluyor.
//Veritabanı: Car nesnesi, _repository.CreateAsync ile veritabanına kaydediliyor.
//Yani, bu kodun amacı komuttan gelen bilgileri bir Car nesnesine çevirmek ve bunu veritabanına eklemek. 😊