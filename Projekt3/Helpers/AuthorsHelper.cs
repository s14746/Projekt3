using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt3.Data;
using Projekt3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt3.Helpers
{
    public class AuthorsHelper
    {
        public SelectList ToSelectList(List<Author> authors)
        {
            return new SelectList(authors, "authorId", "FullName");
        }

        public SelectList ToSelectList(List<Author> authors, Object selectedValue)
        {
            return new SelectList(authors, "authorId", "FullName", selectedValue);
        }
    }
}
