using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crowdience.Models;


namespace Crowndience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return _context.Games.OrderByDescending(i => i.Id).ToList();
        }

        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<Game> GetById(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<Game>> SaveGame(Game item)
        {
            _context.Games.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = item.Id}, item);
        }
    }
}