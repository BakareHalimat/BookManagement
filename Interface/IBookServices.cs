using System.Collections.Generic;
using BookManagement.Model;

namespace BookManagement.Interface
{
    public interface IBookServices
    {
         
        List<Book> GetAllBook();
        Book GetOneBook(string id);
        Book AddBook(Book model);
        Book UpdatePutBook(string id, Book model);
        Book UpdatePatchBook(string id, Book model);
        Book DeleteBook(string id);
    }
}