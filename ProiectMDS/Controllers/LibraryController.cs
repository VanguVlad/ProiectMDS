using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.LibraryRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public ILibraryRepository ILibraryRepository { get; set; }

        public LibraryController(ILibraryRepository repository)
        {
            ILibraryRepository = repository;
        }
        // GET: api/Library
        [HttpGet]
        public ActionResult<IEnumerable<Library>> Get()
        {
            return ILibraryRepository.GetAll();
        }



        // GET: api/Library/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<Library> Get(int id)
        {
            return ILibraryRepository.Get(id);
        }



        // POST: api/Library                    adica CREATE
        [HttpPost]
        public Library Post(LibraryDTO value)
        {
            Library model = new Library()
            {
                Name = value.Name,
                Location = value.Location
            };
            return ILibraryRepository.Create(model);
        }




        // PUT: api/Library/5           adica UPDATE
        [HttpPut("{id}")]
        public Library Put(int id, LibraryDTO value)
        {
            Library model = ILibraryRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Location != null)
            {
                model.Location = value.Location;
            }
            return ILibraryRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public Library Delete(int id)
        {
            Library model = ILibraryRepository.Get(id);
            return ILibraryRepository.Delete(model);
        }
    }
}
