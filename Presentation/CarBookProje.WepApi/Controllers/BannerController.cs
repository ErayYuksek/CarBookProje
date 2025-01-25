using CarBookProje.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProje.Application.Features.CQRS.Handlers.BannerHandler;
using CarBookProje.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;

        public BannerController(GetBannerQueryHandler getBannerQueryHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler)
        {
            _getBannerQueryHandler = getBannerQueryHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
        }

        [HttpGet]

        public async Task<IActionResult> BannerList()
        {
            var value = await _getBannerQueryHandler.Handle();
            return Ok(value);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBanner(int id)
        {
            var values = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi eklendi.");
        }

        [HttpDelete]

        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner Bilgisi Silindi");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner Bilgisi Güncellendi");
        }

    }
}
