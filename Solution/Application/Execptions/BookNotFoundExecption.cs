using BuildingBlocks.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Execptions
{
 
    public class BookNotFoundExecption : NotFoundExcetion
    {
        public BookNotFoundExecption(string username) : base("Book", username)
        {
        }
    }
}
