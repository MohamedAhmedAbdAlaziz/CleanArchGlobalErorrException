using Application.Execptions;
using Core.Interfaces;
using Core.Models;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Application.Services
{
    public class BookServices(IUnitOfWork unitOfWork) : IBookServices
    {


        public async Task<List<Book>> GetBooks()
        {
            throw new BookNotFoundExecption("Mohamed");
         //   throw new NotImplementedException("ffff");    
            BookSpecification bookSpecification = new BookSpecification();
            return await unitOfWork.Repository<Book>().ListAsync(bookSpecification);
        }
    }
}
