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
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;


namespace crowdience.Pages
{
    public class HostResultsModel : PageModel
    {
        private readonly CrowdienceContext _context;
        private String question { get; set; }

        public HostResultsModel(CrowdienceContext context)
        {
            _context = context;
        }

        public void GetQuestion()
        {
            int round = Convert.ToInt32(Request.Query["round"]);
            Question questionFromDb = _context.Questions.Find(round);
            question = questionFromDb.QuestionTitle;
        }

        public bool CheckEndOfGame(string round)
        {
            if (Convert.ToInt32(round) > 5) { return true; }
            else { return false; }

        }

        public void OnGet()
        {
            if (CheckEndOfGame(Request.Query["round"]))
            {
                Response.Redirect("/Host/GameOver");
            }
            else
            {
                // Get Request for CURRENT question
                GetQuestion();
                ViewData["question"] = question;
                ViewData["answerOne"] = "Answer One: <N>";
                ViewData["answerTwo"] = "Answer Two: <N>";
                // Counters Set to 0.
                ViewData["answerOneCounter"] = 0;
                ViewData["answerTwoCounter"] = 0;
            }
        }
        public void OnPost()
        {
            SaveResultsToDb(); 
            // Need A Patch Request for Results
            Response.Redirect($"/Host/EndOfRound?Round={Request.Query["round"]}");
        }

        public void SaveResultsToDb()
        {
            int round = Convert.ToInt32(Request.Query["round"]);
            int answerOneTotal = Convert.ToInt32(Request.Form["answerOneFormCounter"]);
            int answerTwoTotal = Convert.ToInt32(Request.Form["answerTwoFormCounter"]);
            var question = _context.Questions.Find(round);

            question.VoteOneTotal = answerOneTotal;
            question.VoteTwoTotal = answerTwoTotal;

            _context.SaveChanges();
        }

    }
}