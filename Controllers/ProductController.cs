using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.DbConnector;
using Northwind.DTOs;
using Northwind.Services;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Variable
        private readonly ProductService _productService;
        //Constructor
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }


        //Try catch Mark the code -> righ click -> snippet -> surround code -> Search for 'try catch'
        //Get all products
        [EnableCors("AllowOrigin")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _productService.GetAllProducts();
                if (products.Count == 0)
                {
                    return NotFound("Products not available");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //Get a product by the ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product details not found with id {id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult Post(ProductDTO model)
        {
            try
            {
                var product = _productService.AddProduct(model);
                return Ok("Product created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        public IActionResult Put(ProductDTO model)
        {
            if (model == null || model.ProductId == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.ProductId == 0)
                {
                    return BadRequest($"Product Id {model.ProductId} is invalid");

                }

            }
            var UpdatedProduct = _productService.UpdateProduct(model);
            if (UpdatedProduct == null)
            {
                return NotFound($"Product not found with id {model.ProductId}");
            }

            return Ok(UpdatedProduct);
            //return Ok("Product details updated");
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);

                return Ok("Product details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }



}
