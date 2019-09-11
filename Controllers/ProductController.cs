using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PicknPayAspNetCoreWebApi.Models;
using PicknPayAspNetCoreWebApi.Models.Repository;

namespace PicknPayAspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDataRepository<Product> _dataRepository;

        public ProductController(IDataRepository<Product> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _dataRepository.GetAll();
            return Ok(products);
        }
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Product product = _dataRepository.Get(id);

            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]
        public IActionResult Post(Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

             
            _dataRepository.Add(product);
            return CreatedAtRoute(
                  "Get",
                  new { Id = product.ProductID },
                  product);
        }

        [HttpPut]
        [Route("UpdateProduct/{id}")]
        public IActionResult Put(long id, Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            Product productToUpdate = _dataRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

             _dataRepository.Update(productToUpdate, product);
            return CreatedAtRoute(
                   "Get",
                   new { Id = product.ProductID },
                   product);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        public IActionResult Delete(long id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            _dataRepository.Delete(product);
            return Ok();
          
        }

    }
}