using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using onsales.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onsales.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.Countries
                .Include(c => c.Departments)
                .ThenInclude(d => d.Cities));
            //.ThenInclude(d => d.Cities));
        }
    }

}
