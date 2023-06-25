using BusinessLogic.Logics.CategoryLogic;
using BusinessLogic.Models.DTO.CategoryDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public CategoryController(CategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        public CategoryLogic _categoryLogic { get; }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddUIDTO categoryDTO)
        {
            
            if (await _categoryLogic.AddCategory(categoryDTO))
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
