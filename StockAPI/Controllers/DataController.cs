using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockAPI.Models;
using StockAPI.Models.Views;

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

        [HttpGet]
        [Route("User/{userId}")]
        public async Task<List<UserShareView>> GetUserShares(int userId)
        {
            return await _context.UserShareView.Where(u => u.UserId == userId).ToListAsync();
        }

        [HttpGet]
        [Route("Company/{companyId}")]
        public async Task<CompanyShareView> GetCompanyShares(int companyId)
        {
            return await _context.CompanyShareView.FirstOrDefaultAsync(c => c.CompanyId == companyId);
        }

        [HttpGet]
        [Route("Industry/{industryId}")]
        public async Task<List<CompanyShareView>> GetIndustryShares(int industryId)
        {
            return await _context.CompanyShareView.Where(i => i.IndustryId == industryId).ToListAsync();
        }

    }
}