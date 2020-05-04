using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.CategoryRepository;

namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryRepository ICategoryRepository { get; set; }

        public CategoryController(ICategoryRepository repository)
        {
            ICategoryRepository = repository;
        }
        // GET: api/Category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return ICategoryRepository.GetAll();
        }



        // GET: api/Category/5                  adica READ
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            return ICategoryRepository.Get(id);
        }



        // POST: api/Category                    adica CREATE
        [HttpPost]
        public Category Post(CategoryDTO value)
        {
            Category model = new Category()
            {
                Name = value.Name,
                Discount = value.Discount
            };
            return ICategoryRepository.Create(model);
        }




        // PUT: api/Category/5           adica UPDATE
        [HttpPut("{id}")]
        public Category Put(int id, CategoryDTO value)
        {
            Category model = ICategoryRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Discount != null)
            {
                model.Discount = value.Discount;
            }
            return ICategoryRepository.Update(model);
        }





        // DELETE: api/ApiWithActions/5              adica REMOVE
        [HttpDelete("{id}")]
        public Category Delete(int id)
        {
            Category model = ICategoryRepository.Get(id);
            return ICategoryRepository.Delete(model);
        }
    }
}
