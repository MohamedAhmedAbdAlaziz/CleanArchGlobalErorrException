using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BookDTO:BaseEntityDTO
    {
        public string Title { get; set; }
        public int AuthorId { get; set; } // Foreign key
        public string Author { get; set; } // Navigation property
    }
}
