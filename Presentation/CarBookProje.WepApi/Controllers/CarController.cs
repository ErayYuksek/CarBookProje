using CarBookProje.Application.Features.CQRS.Commands.CarCommands;
using CarBookProje.Application.Features.CQRS.Handlers.CarHandler;
using CarBookProje.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;   
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;  
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

        public CarController(GetCarQueryHandler getCarQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler)
        {
            _getCarQueryHandler = getCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }

        [HttpGet]
         
        public async Task<IActionResult> Carlist()
        {
            var value = await _getCarQueryHandler.Handle();
            return Ok(value);   
        }

        [HttpGet("{id}")]


        public async Task<IActionResult> GetCar(int id)
        {
           var values= await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(values);
        }


        [HttpPost]

        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car Bilgisi Eklendi");

        }


        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("car Bilgisi Siilindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car Bilgisi Güncellendi");
        }


        [HttpGet("GetCarWithBrand")]
        public  IActionResult GetCarWithBrand()
        {
            
            var values =  _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
