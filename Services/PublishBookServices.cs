using System;
using System.Collections.Generic;
using System.Linq;
using BookManagement.DatabaseContext;
using BookManagement.Interface;
using BookManagement.Model;

namespace BookManagement.Services
{
    public class PublishBookServices : IPublishbooks
    {
        private ApplicationDbContext _context;

        public PublishBookServices(
           ApplicationDbContext context
       )
       {
           _context = context;
       } 
       public List<Publisher> GetAllPublisher()
       {
           return _context.Publisher.ToList();
       }
       public Publisher GetOnePublisher(string id)
       {
           return _context.Publisher.FirstOrDefault(PID => PID.Id == id);
       }
       public Publisher AddPublisher(Publisher model)
       {
           if (model is null) throw new ArgumentNullException(message: "Publisher cannot be null", null);

           var publisher = new Publisher
           {
               Id = Guid.NewGuid().ToString(),
               FullName = model.FullName
           };
           _context.Publisher.Add(publisher);
           _context.SaveChanges();
           return publisher;
       }

       public Publisher UpdatePutPublisher(string id, Publisher model)
       { 
            var Publisher = GetOnePublisher(id);
            if (Publisher is null) throw new ArgumentOutOfRangeException(message: "No Publisher with this Id found", null);

            Publisher.FullName = model.FullName;
                 
            _context.Publisher.Update(Publisher);
            _context.SaveChanges();
            return Publisher;
       }
       
      
       
       public Publisher UpdatePatchPublisher(string id, Publisher model)
       {
           
            var Publisher = GetOnePublisher(id);
            
            if (Publisher is null) throw new ArgumentOutOfRangeException(message: "No Publisher with this Id found", null);
            if (!string.IsNullOrWhiteSpace(model.FullName))
            {
                Publisher.FullName = model.FullName;
            }
            
            _context.Publisher.Update(Publisher);
            _context.SaveChanges();
            return Publisher;
       }

       
       public Publisher DeletePublisher(string id)
       {
           
            var Publisher = GetOnePublisher(id);
            
            if (Publisher is null) throw new ArgumentOutOfRangeException(message: "No Publisher with this Id found", null);
            
            _context.Publisher.Remove(Publisher);
            _context.SaveChanges();
            return Publisher;
       }
    }
}