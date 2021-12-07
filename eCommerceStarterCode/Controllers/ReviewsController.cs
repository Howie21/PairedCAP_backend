using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/reviews
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.Include(u => u.User).Include(vg => vg.VideoGame);
            return Ok(reviews);
        }

        // GET api/reviews/[productID]
        //Gets all Reviews for a Certain ProductID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           var productReviews = _context.Reviews.Where(r => r.Id == id).Include(u => u.User).Include(vg => vg.VideoGame);

            return StatusCode(200, productReviews);
        }

        // POST api/reviews
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok(review);
        }

        // PUT api/reviews
        [HttpPut]
        public IActionResult Put([FromBody] Review review)
        {
            _context.Reviews.Update(review);
            _context.SaveChanges();
            return Ok(review);
        }

        // DELETE api/review
        [HttpDelete]
        public IActionResult Delete([FromBody] Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return Ok(review);
        }
    }
}
