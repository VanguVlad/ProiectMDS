using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.WriterRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        public IWriterRepository IWriterRepository { get; set; }

        public WriterController(IWriterRepository repository)
        {
            IWriterRepository = repository;
        }
        // GET: api/Writer
        [HttpGet]
        public ActionResult<IEnumerable<Writer>> Get()
        {
            return IWriterRepository.GetAll();
        }



        // GET: api/Writer/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<Writer> Get(int id)
        {
            return IWriterRepository.Get(id);
        }



        // POST: api/Writer                    adica CREATE
        [HttpPost]
        public Writer Post(WriterDTO value)
        {
            Writer model = new Writer()
            {
                Name = value.Name,
                Nationality = value.Nationality
            };
            return IWriterRepository.Create(model);
        }




        // PUT: api/Writer/5           adica UPDATE
        [HttpPut("{id}")]
        public Writer Put(int id, WriterDTO value)
        {
            Writer model = IWriterRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Nationality != null)
            {
                model.Nationality = value.Nationality;
            }
            return IWriterRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public Writer Delete(int id)
        {
            Writer model = IWriterRepository.Get(id);
            return IWriterRepository.Delete(model);
        }
    }
}
