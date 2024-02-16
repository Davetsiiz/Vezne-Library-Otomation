using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vezne24Library.Models.BookModels
{
    public class BookEditViewModel
    {
        public Book Books;
        public List<Author> Authors;
        public List<Publisher> Publishers;
    }
}