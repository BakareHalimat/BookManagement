using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Model
{
    public class Publisher
    {
     [Key]
        public string Id { get; set; }
        
        [Required(ErrorMessage="Please Insert your full name....")]
        public string FullName { get; set; }
        public List<Book> Books {get; set;}
    }
}