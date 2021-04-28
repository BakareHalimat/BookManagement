using System;
using BookManagement.Interface;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class PublisherController : ControllerBase
    {
        
        private IPublishbooks _repo;

        public PublisherController(
            IPublishbooks repo
        )
        {
            _repo = repo;
        }
        [HttpGet("/publisher")]
        public IActionResult Get()
        {
            var publisher = _repo.GetAllPublisher();
            return Ok(publisher);
        }
        [HttpPost("/publisher")]
        public IActionResult Post(Publisher model)
        {
            try
            {
                var publisher = _repo.AddPublisher(model);
                return new CreatedResult("/publisher/", new {Id = publisher.Id, message = "Publisher created succesfully"});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPatch("/publisher/{id}")]
        public IActionResult Patch(string id, Publisher model)
        {
            try
            {
                var publisher = _repo.UpdatePatchPublisher(id, model);
                return new OkObjectResult(new{ message =" Publisher updated successfully ", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPut("/publisher/{id}")]
        public IActionResult Put(string id, Publisher model)
        {
            try
            {
                var publisher = _repo.UpdatePutPublisher(id, model);
                return new OkObjectResult(new{message = "Publisher updated succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        [HttpDelete("/publisher/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var publisher = _repo.DeletePublisher(id);
                return new OkObjectResult(new{message = "Publisher deleted succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        
        /*[HttpPost("/publisher")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            return Ok();
        }*/
    }
}