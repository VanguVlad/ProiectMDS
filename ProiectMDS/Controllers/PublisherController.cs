using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.PublisherRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public IPublisherRepository IPublisherRepository { get; set; }

        public PublisherController(IPublisherRepository repository)
        {
            IPublisherRepository = repository;
        }
        // GET: api/Publisher
        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> Get()
        {
            return IPublisherRepository.GetAll();
        }



        // GET: api/Publisher/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<Publisher> Get(int id)
        {
            return IPublisherRepository.Get(id);
        }



        // POST: api/Publisher                    adica CREATE
        [HttpPost]
        public Publisher Post(PublisherDTO value)
        {
            Publisher model = new Publisher()
            {
                Name = value.Name

            };
            return IPublisherRepository.Create(model);
        }




        // PUT: api/Publisher/5           adica UPDATE
        [HttpPut("{id}")]
        public Publisher Put(int id, PublisherDTO value)
        {
            Publisher model = IPublisherRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            return IPublisherRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public Publisher Delete(int id)
        {
            Publisher model = IPublisherRepository.Get(id);
            return IPublisherRepository.Delete(model);
        }
    }
}
