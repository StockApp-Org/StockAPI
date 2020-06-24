using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAPI.Models;

namespace StockAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        public readonly StockAppDbContext _context;

        public IndustryController(StockAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Industry>> Get()
        {
            return await _context.Industry.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Industry> Get(int id)
        {
            return await _context.Industry.FirstOrDefaultAsync(i => i.IndustryId == id);
        }
    }
}