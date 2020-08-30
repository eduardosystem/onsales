using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using onsales.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onsales.Web.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Category")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione la categoria...")]
        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
