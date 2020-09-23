using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TM.API.Data;
using TM.API.Models;

namespace TM.API.Controllers
{
    [Route("tm.api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataAccessContext _context;
        
        public CustomerController(DataAccessContext context)
        {
            _context = context;
        }

        //get all customers, list ordered
        // tm.api/customer
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Customers.OrderBy(c => c.Id);

            return Ok(data);
        }

        //get single customer
        // tm.api/customer/{id}
        [HttpGet("{id}", Name="GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer == null){
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if(customer == null){
                return BadRequest();
            }

            //TODO have Id be auto-incremented in db to avoid duplicate PK errors
            //custom auto-increment code just for development purposes
            if(_context.Customers.Count() == 0){
                customer.Id = 1;
            }
            else {
                var c = _context.Customers.OrderByDescending(c => c.Id).First();
                customer.Id = c.Id+1;
            }
            //end of custom auto-increment code


            _context.Customers.Add(customer);


            try{
                _context.SaveChanges();
            }catch(DbUpdateException ex){
                return BadRequest("{ \"status\": \"error\", \"message\": \""+ex.Message + "\"}"); //TODO improve this handling
            }

            return CreatedAtRoute("GetCustomer", new {id = customer.Id}, customer);
        }
    }
}