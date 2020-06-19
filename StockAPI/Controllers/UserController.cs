using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using StockAPI.Models;
using StockAPI.Util;
using System.Security.Policy;
using System.Data.Entity.Validation;

namespace StockAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly StockAppDbContext _context;

        public UserController(StockAppDbContext context)
        {
            _context = context;
            _context.Users
                .Include(user => user.UserAddress)
                .Include(user => user.UserShares)
                .ToList();
        }

        [HttpGet]
        public async Task<List<Users>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Users> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            return user;
        }

        [HttpPost]
        public async Task<Users> Post([FromForm] Users user)
        {
            var newUser = user;

            PasswordHasher hasher = new PasswordHasher();
            newUser.PasswordSalt = hasher.RandomSalt;
            newUser.Password = hasher.GenerateSaltedHash(newUser.Password);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<Users> SignIn([FromForm] Users user)
        {
            PasswordHasher hasher = new PasswordHasher();
            string submittedEmail = user.Email;
            string submittedPassword = user.Password;

            Users dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == submittedEmail);

            if (dbUser == null)
            {
                return null;
            }
            if (hasher.VerifyHash(submittedPassword, dbUser.PasswordSalt, dbUser.Password))
            {
                return dbUser;
            }
            return null;
        }

        [HttpPatch]
        public async Task<Users> Update([FromForm] Users user)
        {

            var updatedUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (updatedUser != null)
            {
                updatedUser.FirstName = user.FirstName;
                updatedUser.LastName = user.LastName;
                updatedUser.PersonNr = user.PersonNr;
                updatedUser.PhoneNumber = user.PhoneNumber;
                updatedUser.Email = user.Email;
                await _context.SaveChangesAsync();
                return updatedUser;
            }
            else
            {
                return null;
            }
        }

        [HttpPatch]
        [Route("address")]
        public async Task<UserAddress> UpdateAddress([FromForm] UserAddress user)
        {

            var updatedUser = await _context.UserAddress.FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (updatedUser != null) // Update address
            {
                updatedUser.AddressRow1 = user.AddressRow1;
                updatedUser.City = user.City;
                updatedUser.ZipCode = user.ZipCode;
                await _context.SaveChangesAsync();
                return updatedUser;
            }
            else // If no address then create new address record.
            {

                _context.Update(user);
                await _context.SaveChangesAsync();
                return null;
            }
        }

        [HttpPatch]
        [Route("changePassword")]
        public async Task<Users> ChangePassword([FromForm] Users user)
        {
            PasswordHasher hasher = new PasswordHasher();

            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (dbUser == null)
            {
                return null;
            }
            dbUser.PasswordSalt = hasher.RandomSalt;
            dbUser.Password = hasher.GenerateSaltedHash(user.Password);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
