using BlazorWebAssemblyCrudDotNet8.Data;
using BlazorWebAssemblyCrudDotNet8.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssemblyCrudDotNet8.Controllers
{
    [Route("api/Details")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DataContext _Context;

        public DetailsController(DataContext dataContext)
        {
            _Context = dataContext;
        }

        [HttpGet]

        public async Task<ActionResult<List<Detail>>> GetAllDetailsAsync() 
        { 
            return await _Context.Details.ToListAsync(); 
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Detail>> GetUserByIdAsync(int Id)
        {
            var result = await _Context.Details.FindAsync(Id);
            if(result == null)
                return NotFound("User Not Found");

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUserAsync(int Id)
        {
            var result = await _Context.Details.FindAsync(Id);
            if (result == null)
                return NotFound("User Not Found");

            _Context.Remove(result);
            await _Context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Detail>> UpdateUserAsync(int Id, Detail UpdatedDetail)
        {
            var dbUser = await _Context.Details.FindAsync(Id);
            if (dbUser == null)
                return NotFound("User Not Found");

            dbUser.Name = UpdatedDetail.Name;
            dbUser.Email = UpdatedDetail.Email;
            dbUser.Username = UpdatedDetail.Username;
            dbUser.PasswordHash = UpdatedDetail.PasswordHash;
            dbUser.Photo = UpdatedDetail.Photo;

            await _Context.SaveChangesAsync();

            return Ok(dbUser);
        }

        [HttpPost]
        public async Task<ActionResult<Detail>> CreateUserAsync(Detail newDetail)
        {
            _Context.Add(newDetail);
            await _Context.SaveChangesAsync();

            return Ok(newDetail);
        }
    }


}
