using Microsoft.AspNetCore.Mvc;
using RentalVideoWebAPI.Data;
using RentalVideoWebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace RentalVideoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly RentalAPIDbContext dbContext;

        public RentalController(RentalAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetRentals()
        {
            return Ok(await dbContext.Rentals.ToListAsync());
        }

        [HttpGet("{RentalId}")]
        public async Task<ActionResult> GetRentalById(Guid RentalId)
        {
            var rental = await dbContext.Rentals.FindAsync(RentalId);
            if (rental != null)
            {
                return Ok(rental);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddRental(AddRentalRequest addRentalRequest)
        {
            var rental = new Rental
            {
                RentalId = addRentalRequest.RentalId,
                MovieId = addRentalRequest.MovieId,
                CustomerId = addRentalRequest.CustomerId,
                RentalDate = addRentalRequest.RentalDate,
                ReturnDate = addRentalRequest.ReturnDate
            };
            await dbContext.Rentals.AddAsync(rental);
            await dbContext.SaveChangesAsync();
            return Ok(rental);
        }

        [HttpPut("{RentalId}")]
        public async Task<ActionResult> UpdateRental(Guid RentalId, UpdateRentalRequest updateRentalRequest)
        {
            var rental = await dbContext.Rentals.FindAsync(RentalId);
            if (rental != null)
            {
                rental.RentalId = updateRentalRequest.RentalId;
                rental.MovieId = updateRentalRequest.MovieId;
                rental.CustomerId = updateRentalRequest.CustomerId;
                rental.RentalDate = updateRentalRequest.RentalDate;
                rental.ReturnDate = updateRentalRequest.ReturnDate;
                await dbContext.SaveChangesAsync();
                return Ok(rental);
            }
            return NotFound();
        }

        [HttpDelete("{RentalId}")]
        public async Task<ActionResult> DeleteRental(Guid RentalId)
        {
            var rental = await dbContext.Rentals.FindAsync(RentalId);
            if (rental != null)
            {
                dbContext.Rentals.Remove(rental);
                await dbContext.SaveChangesAsync();
                return Ok(rental);
            }
            return NotFound();
        }
    }
}

