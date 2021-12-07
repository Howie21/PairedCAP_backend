using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eCommerceStarterCode.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/shoppingcart
        [HttpGet]
        public IActionResult Get()
        {
            var shoppingCarts = _context.ShoppingCarts.Include(u => u.User).Include(sc => sc.VideoGame);
            return Ok(shoppingCarts);
        }

        // GET api/shoppingcart/all
        [HttpGet("{type}")]
        public IActionResult Get(string all, [FromBody] ShoppingCart value)
        {
            var user = _context.Users.Where(u => u.Id == value.UserId).FirstOrDefault();
            var shoppingCart = _context.ShoppingCarts.Where(sc => sc.UserId == user.Id).Include(u => u.User).Include(p => p.VideoGame);
            return Ok(shoppingCart);
        }

        // POST api/shoppingcart
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/shoppingcart
        [HttpPut]
        public IActionResult Put([FromBody] ShoppingCart value)
        {

            _context.ShoppingCarts.Update(value);

            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/shoppingcart/[UniqueShoppingCartID]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shoppingCartItem = _context.ShoppingCarts.Where(sc => sc.Id == id).Include(u => u.User).Include(p => p.VideoGame).SingleOrDefault();

            _context.ShoppingCarts.Remove(shoppingCartItem);
            _context.SaveChanges();
            return StatusCode(200, shoppingCartItem);
        }
    }
}
