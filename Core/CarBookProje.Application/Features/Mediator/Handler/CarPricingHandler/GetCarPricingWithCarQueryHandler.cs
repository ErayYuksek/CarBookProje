

using CarBookProje.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProje.Application.Features.Mediator.Results.CarPricingResult;
using CarBookProje.Application.Interfaces;
using CarBookProje.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProje.Application.Features.Mediator.Handler.CarPricingHandler
{
	public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithCarQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
		{
		
			var values= _repository.GetCarsPricingWithCars();
			
			return values.Select(x => new GetCarPricingWithCarQueryResult
			{
				Amount= x.Amount,
				CarPricingId= x.CarPricingID,	
				Brand= x.Car.Brand.BrandName,
				Model= x.Car.Model,
				CoverImageUrl= x.Car.CoverImageUrl
			}).ToList();
			
		 
		}
	}
}


//Kısaca ne yapıyor?
//Veritabanından araç fiyatlarını çekiyor, markası, modeli ve görseliyle birlikte liste halinde döndürüp frontend'e servis ediyor.

//CQRS yapısında olduğu için bu sadece okuma işlemi (Query) yapıyor, veri ekleme/güncelleme işine karışmıyor.