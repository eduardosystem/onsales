using Microsoft.AspNetCore.Http;
using onsales.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onsales.Web.Models
{
    public class CategoryViewModel: Category
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
