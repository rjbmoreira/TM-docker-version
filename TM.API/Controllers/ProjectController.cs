using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TM.API.Data;
using TM.API.Models;

namespace TM.API.Controllers
{
    [Route("tm.api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly DataAccessContext _context;
        
        public ProjectController(DataAccessContext context)
        {
            _context = context;
        }

        //get all projects, list ordered
        // tm.api/project
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Projects.OrderBy(p => p.Id);

            return Ok(data);
        }

        //get single project
        // tm.api/project/{id}
        [HttpGet("{id}", Name="GetProject")]
        public IActionResult Get(int id)
        {
            var project = _context.Projects.Find(id);
            if(project == null){
                return NotFound();
            }
            return Ok(project);
        }

        //get project list by customer
        // tm.api/project/bycustomer/{cId}
        [HttpGet("bycustomer/{cId}")]
        public IActionResult ByCustomer(int cId)
        {
            var projects = _context.Projects.Where(c => c.CustomerId == cId).OrderBy(p => p.Id);

            return Ok(projects);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if(project == null){
                return BadRequest();
            }

            //TODO have Id be auto-incremented in db to avoid duplicate PK errors
            //custom auto-increment code just for development purposes
            if(_context.Projects.Count() == 0){
                project.Id = 1;
            }
            else {
                var p = _context.Projects.OrderByDescending(p => p.Id).First();
                project.Id = p.Id+1;
            }
            //end of custom auto-increment code            

            _context.Projects.Add(project);

            try{
                _context.SaveChanges();
            }catch(DbUpdateException ex){
                return BadRequest("{ \"status\": \"error\", \"message\": \""+ex.Message + "\"}"); //TODO improve this handling
            }


            return CreatedAtRoute("GetProject", new {id = project.Id}, project);
        }
    }
}