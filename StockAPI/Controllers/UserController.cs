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
using System.IO;

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

        [HttpGet("Download/{id}")]
        [Produces("application/octet-stream")]
        public async Task<FileContentResult> DownloadData(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            }
                ));
            var output = new FileContentResult(bytes, "application/octet-stream");
            output.FileDownloadName = user.FirstName + user.LastName + ".json";

            return output;
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

        [HttpDelete]
        [Route("delete")]
        public async Task<Users> Delete([FromForm] Users user)
        {
            var userAddressId = -1;




            int.TryParse(user.PasswordSalt, out userAddressId);

            PasswordHasher hasher = new PasswordHasher();

            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == user.UserId);


            var dbUserAddress = await _context.UserAddress.FirstOrDefaultAsync(u => u.UserId == userAddressId);

            string submittedPassword = user.Password;
            if (dbUser == null)
            {
                return null;
            }

            if (hasher.VerifyHash(submittedPassword, dbUser.PasswordSalt, dbUser.Password))
            {
                if (dbUserAddress != null)
                {
                    _context.UserAddress.Remove(dbUserAddress);
                }
                _context.Users.Remove(dbUser);
            }

            else
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
