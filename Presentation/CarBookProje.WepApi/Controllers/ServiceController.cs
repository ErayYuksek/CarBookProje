using CarBookProje.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProje.Application.Features.Mediator.Queries.ServiceQueries;
using CarBookProje.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var values = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Hizmet başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet başarıyla güncellendi.");
        }
    }
}
