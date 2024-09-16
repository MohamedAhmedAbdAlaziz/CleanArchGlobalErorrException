using Core.Models;

namespace Application.Services
{
    public interface IBookServices
    {
        Task<List<Book>> GetBooks();
    }
}