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
    public class DataController : ControllerBase
    {
        private readonly StockAppDbContext _context;

        public DataController(StockAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<List<UserShares>> GetUserShares(int userId)
        {
            return await _context.UserShares.Where(u => u.UserId == userId).ToListAsync();
        }
    }
}