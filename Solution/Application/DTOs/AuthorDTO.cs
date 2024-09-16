using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AuthorDTO:BaseEntityDTO
    {
        public string Name { get; set; }
        public List<BookDTO> Books { get; set; } // Navigation property    

    }
}
