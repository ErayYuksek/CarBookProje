using CarBookProje.Application.Interfaces.Carİnterfaces;
using CarBookProje.Application.Interfaces.CarPricingInterfaces;
using CarBookProje.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Persistence.Repositories.CarPricingRepository
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public List<CarPricing> GetCarsPricingWithCars()
		{
			var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(z=>z.PricingID==3).ToList();

			return values;

		}
	}
}
