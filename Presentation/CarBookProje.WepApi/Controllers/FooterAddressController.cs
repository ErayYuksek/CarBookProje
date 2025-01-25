using CarBookProje.Application.Features.Mediator.Commands.FooterAddressCommand;
using CarBookProje.Application.Features.Mediator.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var values = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(RemoveFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarıyla Değiştirildi");
        }
    }
}
