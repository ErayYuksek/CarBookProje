using CarBookProje.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProje.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBookProje.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;

        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        }

        [HttpGet]

        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]


        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Category Bilgisi Eklendi");

        }

        [HttpDelete]


        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category Bilgisi Silindi");    
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Category Bilgisi Güncellendi");

        }
    }
}





















