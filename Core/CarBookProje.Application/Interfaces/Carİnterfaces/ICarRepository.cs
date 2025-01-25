using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCarBook.Domain.Entities;

namespace CarBookProje.Application.Interfaces.Carİnterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsListWithBrands();
    }
}
