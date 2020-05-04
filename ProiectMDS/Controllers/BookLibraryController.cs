using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.BookLibraryRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLibraryController : ControllerBase
    {
        // GET: api/BookLibrary

        public IBookLibraryRepository IBookLibraryRepository { get; set; }

        public BookLibraryController(IBookLibraryRepository repository)
        {
            IBookLibraryRepository = repository;
        }
        // GET: api/BookLibrary
        [HttpGet]
        public ActionResult<IEnumerable<BookLibrary>> Get()
        {
            return IBookLibraryRepository.GetAll();
        }



        // GET: api/BookLibrary/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<BookLibrary> Get(int id)
        {
            return IBookLibraryRepository.Get(id);
        }



        // POST: api/BookLibrary                    adica CREATE
        [HttpPost]
        public BookLibrary Post(BookLibraryDTO value)
        {
            BookLibrary model = new BookLibrary()
            {
                BookId = value.BookId,
                LibraryId = value.LibraryId
            };
            return IBookLibraryRepository.Create(model);
        }




        // PUT: api/BookLibrary/5           adica UPDATE
        [HttpPut("{id}")]
        public BookLibrary Put(int id, BookLibraryDTO value)
        {
            BookLibrary model = IBookLibraryRepository.Get(id);
            if (value.BookId != 0)
            {
                model.BookId = value.BookId;
            }
            if (value.LibraryId != 0)
            {
                model.LibraryId = value.LibraryId;
            }
            return IBookLibraryRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public BookLibrary Delete(int id)
        {
            BookLibrary BookLibrary = IBookLibraryRepository.Get(id);
            return IBookLibraryRepository.Delete(BookLibrary);
        }
    }
}
