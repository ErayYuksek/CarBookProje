using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBookProje.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProje.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetFeatue(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]  
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            var values=await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(RemoveFeatureCommand command)
        {
            var values=await _mediator.Send(command);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            var values= await _mediator.Send(command);
            return Ok("Başarıyla Güncellendi ");
        }

    }
}
