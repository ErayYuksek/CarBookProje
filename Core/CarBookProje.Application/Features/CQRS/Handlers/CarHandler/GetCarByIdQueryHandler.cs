using CarBookProje.Application.Features.CQRS.Queries.CarQueries;
using CarBookProje.Application.Features.CQRS.Results.CarResults;
using CarBookProje.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Features.CQRS.Handlers.CarHandler
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResults> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResults
            {
                BrandID = values.BrandID,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Model = values.Model,
                Luggage = values.Luggage,
                Km = values.Km,
                Fuel = values.Fuel,
                CoverImageUrl = values.CoverImageUrl,
                BigImageUrl = values.BigImageUrl,
                CarID = values.CarID



            };
        }
    }
}
