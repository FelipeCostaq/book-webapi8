using book_webapi8.Dto.Author;
using book_webapi8.Models;

namespace book_webapi8.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> GetAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthorByBook(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int id);
    }
}
