using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.WriterCategoryRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterCategoryController : ControllerBase
    {
        // GET: api/WriterCategory

        public IWriterCategoryRepository IWriterCategoryRepository { get; set; }

        public WriterCategoryController(IWriterCategoryRepository repository)
        {
            IWriterCategoryRepository = repository;
        }
        // GET: api/WriterCategory
        [HttpGet]
        public ActionResult<IEnumerable<WriterCategory>> Get()
        {
            return IWriterCategoryRepository.GetAll();
        }



        // GET: api/WriterCategory/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<WriterCategory> Get(int id)
        {
            return IWriterCategoryRepository.Get(id);
        }



        // POST: api/WriterCategory                    adica CREATE
        [HttpPost]
        public WriterCategory Post(WriterCategoryDTO value)
        {
            WriterCategory model = new WriterCategory()
            {
                WriterId = value.WriterId,
                CategoryId = value.CategoryId
            };
            return IWriterCategoryRepository.Create(model);
        }




        // PUT: api/WriterCategory/5           adica UPDATE
        [HttpPut("{id}")]
        public WriterCategory Put(int id, WriterCategoryDTO value)
        {
            WriterCategory model = IWriterCategoryRepository.Get(id);
            if (value.WriterId != 0)
            {
                model.WriterId = value.WriterId;
            }
            if (value.CategoryId != 0)
            {
                model.CategoryId = value.CategoryId;
            }
            return IWriterCategoryRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public WriterCategory Delete(int id)
        {
            WriterCategory WriterCategory = IWriterCategoryRepository.Get(id);
            return IWriterCategoryRepository.Delete(WriterCategory);
        }
    }
}
