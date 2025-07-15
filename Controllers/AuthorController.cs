using book_webapi8.Dto.Author;
using book_webapi8.Models;
using book_webapi8.Services.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_webapi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors()
        {
            var authors = await _authorInterface.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("BuscarAutorPorId/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthorsById(int idAuthor)
        {
            var author = await _authorInterface.GetAuthorById(idAuthor);
            return Ok(author);
        }


        [HttpGet("BuscarAutorPorIdLivro/{idBook}")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthorByBook(int idBook)
        {
            var book = await _authorInterface.GetAuthorById(idBook);
            return Ok(book);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            var authors = await _authorInterface.CreateAuthor(authorCreateDto);
            return Ok(authors);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> EditAuthor(AuthorEditDto authorEditDto)
        {
            var authors = await _authorInterface.EditAuthor(authorEditDto);
            return Ok(authors);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int authorId)
        {
            var authors = await _authorInterface.DeleteAuthor(authorId);
            return Ok(authors);
        }
    }
}
