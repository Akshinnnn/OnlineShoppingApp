using BusinessLogic.Logics.ProductLogic;
using BusinessLogic.Models.DTO.ProductDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static BusinessLogic.Logics.ProductLogic.ProductLogic;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        public ProductLogic _productLogic { get; }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productLogic.GetProducts();   
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddUIDTO productDTO)
        {
            if (await _productLogic.AddProduct(productDTO))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateUIDTO productDTO)
        {
            if (await _productLogic.UpdateProduct(productDTO))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(ProductDeleteUIDTO productDTO)
        {
            if (await _productLogic.DeleteProduct(productDTO))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
