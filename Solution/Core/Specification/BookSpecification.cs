using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification;

public class BookSpecification:BaseSpecification<Book>
{

public BookSpecification(string productName)
       : base(p => p.Title.ToLower().Contains(productName.ToLower()))
{
    AddInclude(p => p.Author);
}

public BookSpecification() : base()
    {
        AddInclude(p => p.Author);
     }
}