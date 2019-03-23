using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crowdience.Models;


namespace crowdience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly GameContext _context;

        public QuestionController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Question>> GetAll()
        {
            return _context.Questions.OrderByDescending(i => i.Id).ToList();
        }

        [HttpGet("{id}", Name = "GetQuestion")]
        public ActionResult<Question> GetById(int id)
        {
            var question = _context.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            return question;
        }
    }
}