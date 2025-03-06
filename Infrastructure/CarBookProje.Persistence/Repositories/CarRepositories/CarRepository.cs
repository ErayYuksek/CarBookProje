using CarBookProje.Application.Interfaces.Carİnterfaces;
using CarBookProje.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrands()
        {
          var values=_context.Cars.Include(x=>x.Brand).ToList();
            return values;
        }



		public List<Car> GetLast5CarsWithBrands()
        {
         var values=_context.Cars.Include(x => x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }
    }
}

//Amaç: Veritabanından en son eklenen 5 aracı ve onların markalarını getirir.
//Detay:
//Include(x => x.Brand): Araçlarla ilişkili markaları da yükler.
//OrderByDescending(x => x.CarID): Araçları azalan sırada sıralar (yeni eklenenler önce).
//Take(5): İlk 5 kaydı alır.
//ToList(): Sonuçları liste olarak döner.

