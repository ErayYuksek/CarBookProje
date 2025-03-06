using CarBookProje.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBookProje.Application.Features.Mediator.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPricingController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarPricingController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetCarPricingWithCarList()
		{
			var values = await _mediator.Send(new GetCarPricingWithCarQuery());
			return Ok(values);
		}
	}
}
