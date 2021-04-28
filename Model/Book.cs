using System;

namespace BookManagement.Model
{
    public class Book
    {
        public string Id {get; set;}
        public string Title { get; set; }
        public string Descripition { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public DateTime? DateAdded { get; set; }

        public int PublisherId {get; set; }
        public Publisher Publisher{get; set;}


    }
}