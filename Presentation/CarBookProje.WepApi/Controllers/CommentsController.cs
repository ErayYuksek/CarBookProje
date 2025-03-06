using CarBookProje.Application.Features.RepositoryPattern;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCarBook.Domain.Entities;

namespace CarBookProje.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommentsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var comments = _repository.GetAll();
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment) {
        
            _repository.Create(comment);
            return Ok("Yorum Başarıyla Eklendi");
        }


        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {

            _repository.Update(comment);
            return Ok("Yorum Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {

            var values = _repository.GetById(id);
            return Ok(values);
        }
    }
}
