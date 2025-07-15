using System.Net;
using book_webapi8.Data;
using book_webapi8.Dto.Author;
using book_webapi8.Models;
using Microsoft.EntityFrameworkCore;

namespace book_webapi8.Services.Author
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(AuthorCreateDto authorCreateDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = new AuthorModel()
                {
                    Name = authorCreateDto.Name,
                    Surname = authorCreateDto.Surname
                };

                _context.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor criado com sucesso.";

                return response;
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor);

                if (author == null)
                {
                    response.Message = "Autor removido com sucesso.";
                    return response;
                }

                _context.Remove(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(AuthorEditDto authorEditDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == authorEditDto.Id);

                if (author == null)
                {
                    response.Message = "Nenhum autor encontrado.";
                    return response;
                }

                author.Name = authorEditDto.Name;
                author.Surname = authorEditDto.Surname;

                _context.Update(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor editado com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBook(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(bookBank => bookBank.Id == bookId);
                if (book == null)
                {
                    response.Message = "Nenhum registro encontrado.";
                    return response;
                }

                response.Data = book.Author;
                response.Message = "Livro encontrado.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == authorId);

                if (author == null)
                {
                    response.Message = "Nenhum registro encontrado.";
                    return response;
                }

                response.Data = author;
                response.Message = "Autor encontrado.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> GetAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();

                response.Data = authors;

                response.Message = "Todos os autores foram listados.";
                return response;
                
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
