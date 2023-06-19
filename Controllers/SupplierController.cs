using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.DTOs;
using Northwind.Services;

namespace Northwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        //variable
        private readonly SupplierService _supplierService;
        //Constructor
        public SupplierController(SupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var suppliers = _supplierService.GetAllSuppliers();
                if (suppliers == null)
                {
                    return NotFound("Suppliers not available");
                }
                return Ok(suppliers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult Post(SupplierDTO model)
        {
            try
            {
                var supplier = _supplierService.AddSupplier(model);
                return Ok("supplier created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _supplierService.DeleteSupplier(id);

                return Ok("Supplier details deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
