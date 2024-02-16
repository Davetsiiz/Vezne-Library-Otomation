using EntityLayer.Concrete;
using System.Collections.Generic;

namespace Vezne24Library.Models.BorrowModels
{
    public class BorrowViewModel
    {
        public List<Borrow> Borrows;
        public List<Member> Members;
        public List<Book> Books;
    }
}