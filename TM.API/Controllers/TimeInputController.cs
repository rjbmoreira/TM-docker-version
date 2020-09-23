using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TM.API.Data;
using TM.API.Models;

namespace TM.API.Controllers
{
    [Route("tm.api/[controller]")]
    [ApiController]
    public class TimeInputController : ControllerBase
    {
        private readonly DataAccessContext _context;
        
        public TimeInputController(DataAccessContext context)
        {
            _context = context;
        }

        //get single registration
        // tm.api/timeinput
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.TimeInputs.OrderBy(t => t.Id);
            
            return Ok(data);
        }

        //get all time registrations by project with all info
        //TODO lacks refinement
        //TODO improve performance/memory usage by asking smaller chunks of results (n results)
        // tm.api/timeinput/grouped
        [HttpGet("groupedByProject")]
        public IActionResult GroupedByProject()
        {
            var data = _context.Customers
                    .SelectMany(
                        c => _context.Projects.Where(
                            p => p.CustomerId == c.Id
                        )
                        .Select(
                            p => new
                            {
                                CustomerId = c.Id,
                                CustomerName = c.Name,
                                ProjectId = p.Id,
                                ProjectName = p.Name
                            }
                        ))
                        .SelectMany(
                            p => _context.TimeInputs.Where(
                                ti => ti.ProjectId == p.ProjectId
                            )
                            .Select(
                                ti => new
                                {
                                    CustomerId = p.CustomerId,
                                    CustomerName = p.CustomerName,
                                    ProjectId = p.ProjectId,
                                    ProjectName = p.ProjectName,
                                    TimeSpent = ti.TimeSpent
                                }
                            )
                        )                          
                        .ToList();

            var groupeddata = data
                        .GroupBy(
                            grp => new{ grp.ProjectId, grp.CustomerId }
                        )
                        .ToList()                        
                        .Select(
                            gr => new
                            {
                                ProjectId = gr.Key.ProjectId,
                                CustomerId = gr.Key.CustomerId,
                                CustomerName = gr.Select(x => x.CustomerName).FirstOrDefault(),
                                ProjectName = gr.Select(x => x.ProjectName).FirstOrDefault(),
                                TimeInputs = gr.ToList().Select(x => x.TimeSpent).ToList(),
                                TotalTime = gr.Sum(x => x.TimeSpent)
                            }
                        ).ToList();
            return Ok(groupeddata); 
        }

        //get single registration
        // tm.api/timeinput/{id}
        [HttpGet("{id}", Name="GetTimeInput")]
        public IActionResult Get(int id)
        {
            var timeInput = _context.TimeInputs.Find(id);
            if(timeInput == null){
                return NotFound();
            }
            return Ok(timeInput);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TimeInput timeInput)
        {
            if(timeInput == null){
                return BadRequest();
            }

            //TODO have Id be auto-incremented in db to avoid duplicate PK errors
            //custom auto-increment code just for development purposes
            if(_context.TimeInputs.Count() == 0){
                timeInput.Id = 1;
            }
            else {
                var t = _context.TimeInputs.OrderByDescending(t => t.Id).First();
                timeInput.Id = t.Id+1;
            }
            //end of custom auto-increment code

            _context.TimeInputs.Add(timeInput);
            
            try{
                _context.SaveChanges();
            }catch(DbUpdateException ex){
                return BadRequest("{ \"status\": \"error\", \"message\": \""+ex.Message + "\"}"); //TODO improve this handling
            }

            return CreatedAtRoute("GetTimeInput", new {id = timeInput.Id}, timeInput);
        }
    }
}