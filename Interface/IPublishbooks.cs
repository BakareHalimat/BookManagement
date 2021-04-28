using System.Collections.Generic;
using BookManagement.Model;

namespace BookManagement.Interface
{
    public interface IPublishbooks
    {
         
        List<Publisher> GetAllPublisher();
        Publisher GetOnePublisher(string id);
        Publisher AddPublisher(Publisher model);
        Publisher UpdatePutPublisher(string id, Publisher model);
        Publisher UpdatePatchPublisher(string id, Publisher model);
        Publisher DeletePublisher(string id);
    }
}