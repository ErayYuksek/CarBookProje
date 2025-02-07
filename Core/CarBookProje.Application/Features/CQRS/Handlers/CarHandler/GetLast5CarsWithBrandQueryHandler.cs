using CarBookProje.Application.Features.CQRS.Results.CarResults;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Interfaces.Carİnterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.CarHandler
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.BrandName,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
//Veritabanından Car nesnelerini alır (örneğin, araç bilgileri).
//Bu Car nesnelerini GetCarWithBrandQueryResult adında bir format ya da modele dönüştürür.
//Dönüştürülmüş bu veriyi bir liste olarak döndürür (örneğin, bir API'ye ya da kullanıcıya gösterilmek için).