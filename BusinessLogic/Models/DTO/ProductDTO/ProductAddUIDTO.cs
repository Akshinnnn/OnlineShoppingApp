using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.DTO.ProductDTO
{
    public class ProductAddUIDTO
    {
        [MinLength(4, ErrorMessage = "Product length is not valid")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [Range(1, 200, ErrorMessage = "Quantity length is not valid")]
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string ColorInfo { get; set; }
    }
}
