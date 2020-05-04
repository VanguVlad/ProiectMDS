using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.BookPublisherRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPublisherController : ControllerBase
    {
        // GET: api/BookPublisher

        public IBookPublisherRepository IBookPublisherRepository { get; set; }

        public BookPublisherController(IBookPublisherRepository repository)
        {
            IBookPublisherRepository = repository;
        }
        // GET: api/BookPublisher
        [HttpGet]
        public ActionResult<IEnumerable<BookPublisher>> Get()
        {
            return IBookPublisherRepository.GetAll();
        }



        // GET: api/BookPublisher/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<BookPublisher> Get(int id)
        {
            return IBookPublisherRepository.Get(id);
        }



        // POST: api/BookPublisher                    adica CREATE
        [HttpPost]
        public BookPublisher Post(BookPublisherDTO value)
        {
            BookPublisher model = new BookPublisher()
            {
                BookId = value.BookId,
                PublisherId = value.PublisherId
            };
            return IBookPublisherRepository.Create(model);
        }




        // PUT: api/BookPublisher/5           adica UPDATE
        [HttpPut("{id}")]
        public BookPublisher Put(int id, BookPublisherDTO value)
        {
            BookPublisher model = IBookPublisherRepository.Get(id);
            if (value.BookId != 0)
            {
                model.BookId = value.BookId;
            }
            if (value.PublisherId != 0)
            {
                model.PublisherId = value.PublisherId;
            }
            return IBookPublisherRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public BookPublisher Delete(int id)
        {
            BookPublisher BookPublisher = IBookPublisherRepository.Get(id);
            return IBookPublisherRepository.Delete(BookPublisher);
        }
    }
}
