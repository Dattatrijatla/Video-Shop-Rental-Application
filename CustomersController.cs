    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RentalVideoWebAPI.Data;
    using RentalVideoWebAPI.Models;
    

namespace RentalVideoWebAPI.Controllers
{

    [Route("api/[controller]")]
        [ApiController]
        public class CustomersController : Controller
        {
            private CustomersAPIDbContext dbContet;

            public CustomersController(CustomersAPIDbContext dbContext)
            {
                this.dbContet = dbContext;
            }
            [HttpGet]
            public async Task<ActionResult> GetCustomers()
            {
                return Ok(await dbContet.Customers.ToListAsync());
            }
            [HttpGet]
            [Route("{CustomerId}")]
            public async Task<ActionResult> GetCustomers([FromRoute] Guid CustomerId)
            {
                var customer = await dbContet.Customers.FindAsync(CustomerId);
                if (customer != null)
                {
                    return Ok(customer);
                }
                return NotFound();
            }
            [HttpPost]
            public async Task<ActionResult> AddContex(AddCustomerRequest addCustomerRequest)
            {
                var customer = new Customers
                {
                    CustomerId = addCustomerRequest.CustomerId,
                    Name = addCustomerRequest.Name,
                    DateOfBirth = addCustomerRequest.DateOfBirth,
                    Address = addCustomerRequest.Address,
                    Email = addCustomerRequest.Email
                };
                await dbContet.Customers.AddAsync(customer);
                await dbContet.SaveChangesAsync();
                return Ok(customer);
            }
            [HttpPut]
            [Route("{CustomerId}")]
            public async Task<ActionResult> UpdateCustomer([FromRoute] Guid CustomerId, UpdateCustomerRequest updateCustomerRequest)
            {
                var costumer = await dbContet.Customers.FindAsync(CustomerId);
                if (costumer != null)
                {
                    costumer.Name = updateCustomerRequest.Name;
                    costumer.Address = updateCustomerRequest.Address;
                    costumer.DateOfBirth = updateCustomerRequest.DateOfBirth;
                    costumer.Email = updateCustomerRequest.Email;
                    await dbContet.SaveChangesAsync();
                    return Ok(costumer);
                }
                return NotFound();
            }
            [HttpDelete]
            [Route("{CustomerId}")]
            public async Task<ActionResult> DeleteCustomers([FromRoute] Guid CustomerId)
            {
                var customer = await dbContet.Customers.FindAsync(CustomerId);
                if (customer != null)
                {
                    dbContet.Customers.Remove(customer);
                    await dbContet.SaveChangesAsync();
                    return Ok(customer);
                }
                return NotFound();
            }
        }

    }

