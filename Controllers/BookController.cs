using System;
using BookManagement.Interface;
using BookManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BookController : ControllerBase
    {
        private IBookServices _repo;

        public BookController(
            IBookServices repo
        )
        {
            _repo = repo;
        }
        [HttpGet("/book")]
        public IActionResult Get()
        {
            var books = _repo.GetAllBook();
            return Ok(books);
        }
        [HttpPost("/books")]
        public IActionResult Post(Book model)
        {
            try
            {
                var books = _repo.AddBook(model);
                return new CreatedResult("/books/", new {Id = books.Id, message = "Book created succesfully"});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPatch("/books/{id}")]
        public IActionResult Patch(string id, Book model)
        {
            try
            {
                var books = _repo.UpdatePatchBook(id, model);
                return new OkObjectResult(new{ message =" Book updated successfully ", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }
        }
        [HttpPut("/books/{id}")]
        public IActionResult Put(string id, Book model)
        {
            try
            {
                var books = _repo.UpdatePutBook(id, model);
                return new OkObjectResult(new{message = "Book updated succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        [HttpDelete("/books/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var books = _repo.DeleteBook(id);
                return new OkObjectResult(new{message = "Book deleted succesfully", id});
            }
            catch (Exception e)
            {
                return  BadRequest(new {message = e.Message});
            }

        }
        
        /*[HttpPost("/books")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            return Ok();
        }*/
    }
}