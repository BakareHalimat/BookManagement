using System;
using System.Collections.Generic;
using System.Linq;
using BookManagement.DatabaseContext;
using BookManagement.Interface;
using BookManagement.Model;

namespace BookManagement.Services
{
    public class Bookervices : IBookServices
    {
        private ApplicationDbContext _context;

        public Bookervices(
           ApplicationDbContext context
       )
       {
           _context = context;
       } 
       public List<Book> GetAllBook()
       {
           return _context.Book.ToList();
       }
       public Book GetOneBook(string id)
       {
           return _context.Book.FirstOrDefault(PID => PID.Id == id);
       }
       public Book AddBook(Book model)
       {
           if (model is null) throw new ArgumentNullException(message: "Book cannot be null", null);

           var Book = new Book
           {
               Id = Guid.NewGuid().ToString(),
               Title = model.Title,
               Descripition = model.Descripition,
               IsRead = model.IsRead,
               DateRead = model.DateRead,
               Rate = model.Rate,
               Genre = model.Genre,
               Author = model.Author,
               DateAdded = model.DateAdded,
               PublisherId = model.PublisherId,
               Publisher = model.Publisher    
           };
           _context.Book.Add(Book);
           _context.SaveChanges();
           return Book;
       }

       public Book UpdatePutBook(string id, Book model)
       { 
            var Book = GetOneBook(id);
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);

            Book.Title = model.Title;
                 
            _context.Book.Update(Book);
            _context.SaveChanges();
            return Book;
       }
       
      
       
       public Book UpdatePatchBook(string id, Book model)
       {
           
            var Book = GetOneBook(id);
            
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                Book.Title = model.Title;
            }
            
            _context.Book.Update(Book);
            _context.SaveChanges();
            return Book;
       }

       
       public Book DeleteBook(string id)
       {
           
            var Book = GetOneBook(id);
            
            if (Book is null) throw new ArgumentOutOfRangeException(message: "No Book with this Id found", null);
            
            _context.Book.Remove(Book);
            _context.SaveChanges();
            return Book;
       }
    }
}