using CarBookProje.Application.Features.Mediator.Commands.BlogCommand;
using CarBookProje.Application.Features.Mediator.Commands.ServiceCommand;
using CarBookProje.Application.Features.Mediator.Handler.BlogHandler;
using CarBookProje.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProje.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BlogList()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var values = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult>BlogService(UpdateBlogCommand command)
        {
            
            await _mediator.Send(command);
            return Ok("Blog başarıyla güncellendi.");
        }

        [HttpGet("GetLast3BlogsWithAuthorsList")]
        public async Task<IActionResult> GetLast3BlogsWithAuthors()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(values);
        }


		[HttpGet("GetAllBlogWithAuthorQueryResult")]
		public async Task<IActionResult> GetAllBlogWithAuthorQueryResult()
		{
			var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
			return Ok(values);
		}



        [HttpGet("GetBlogByAuthorId")]
        public async Task<IActionResult> GetBlogByAuthorId(int id)
        {
            var values = await _mediator.Send(new GetBlogByAuthorIdQuery(id));
            return Ok(values);
        }
    }
}
