using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;

public class Book:BaseEntity
{

    public string Title { get; set; }
    public int AuthorId { get; set; } // Foreign key
    public Author Author { get; set; } // Navigation property
}