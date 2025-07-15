using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_webapi8.Dto.Author
{
    public class AuthorCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }

}
