using Livros.Application.DTO;
using Livros.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.API.Controllers.v1
{
    [Authorize]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class LivroController : Controller
    {
        private readonly ILivroAppService _livroAppService;

        public LivroController(
            ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _livroAppService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _livroAppService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivroDTO livroDTO)
        {
            _livroAppService.Register(livroDTO);
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] LivroDTO livroDTO)
        {
            livroDTO.Id = id;
            _livroAppService.Update(livroDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _livroAppService.Remove(id);

            return NoContent();
        }
    }
}