using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.BookWriterRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookWriterController : ControllerBase
    {
        // GET: api/BookWriter

        public IBookWriterRepository IBookWriterRepository { get; set; }

        public BookWriterController(IBookWriterRepository repository)
        {
            IBookWriterRepository = repository;
        }
        // GET: api/BookWriter
        [HttpGet]
        public ActionResult<IEnumerable<BookWriter>> Get()
        {
            return IBookWriterRepository.GetAll();
        }



        // GET: api/BookWriter/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<BookWriter> Get(int id)
        {
            return IBookWriterRepository.Get(id);
        }



        // POST: api/BookWriter                    adica CREATE
        [HttpPost]
        public BookWriter Post(BookWriterDTO value)
        {
            BookWriter model = new BookWriter()
            {
                BookId = value.BookId,
                WriterId = value.WriterId
            };
            return IBookWriterRepository.Create(model);
        }




        // PUT: api/BookWriter/5           adica UPDATE
        [HttpPut("{id}")]
        public BookWriter Put(int id, BookWriterDTO value)
        {
            BookWriter model = IBookWriterRepository.Get(id);
            if (value.BookId != 0)
            {
                model.BookId = value.BookId;
            }
            if (value.WriterId != 0)
            {
                model.WriterId = value.WriterId;
            }
            
            return IBookWriterRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public BookWriter Delete(int id)
        {
            BookWriter BookWriter = IBookWriterRepository.Get(id);
            return IBookWriterRepository.Delete(BookWriter);
        }
    }
}
