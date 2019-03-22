using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Diagnostics;
using crowdience.Models;
using crowdience.Controllers;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;


namespace crowdience.Pages
{
    public class HostResultsModel : PageModel
    {
        private String question { get; set; }
        private readonly crowdience.Models.Game _context;

        public HostResultsModel(crowdience.Models.Game context)
        {
            _context = context;
            Console.WriteLine(context);
        }
        // public async ActionResult<List<Question>> GetAll()
        // {
        //     return _context.Questions.ToList();
        // }


        public void OnGet()
        {
            Console.WriteLine(_context);
            var qNumber = Request.Query["round"];
            if (Convert.ToInt32(qNumber) > 10)
            {
                Response.Redirect("/Host/GameOver");
            }
            // Get Request for STARTING Question and Answers
            ViewData["question"] = question;
            ViewData["answerOne"] = "Answer One: <N>";
            ViewData["answerTwo"] = "Answer Two: <N>";
            // Counters Set to 0.
            ViewData["answerOneCounter"] = 0;
            ViewData["answerTwoCounter"] = 0;
        }
        public void OnPost()
        {
            // Patch Request for Results
            Response.Redirect($"/Host/EndOfRound?Round={Request.Query["round"]}");
        }

    }
}