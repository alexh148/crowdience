using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json.Linq;
using crowdience.Models;

namespace crowdience.Pages
{
    public class HostEndOfRoundModel : PageModel
    {
        private Question question { get; set; }
        private Game game { get; set; }
        private readonly CrowdienceContext _context;

        public HostEndOfRoundModel(CrowdienceContext context)
        {
            _context = context;
        }

        public void GetQuestion()
        {
            int round = Convert.ToInt32(Request.Query["round"]);
            question = _context.Questions.Find(round);
            Console.WriteLine(question);
        }

        public void GetGame()
        {
            int round = Convert.ToInt32(Request.Query["round"]);
            game = _context.Games.Find(1);
        }
        public void OnGet()
        {
            GetQuestion();
            GetGame();
            SetVariables();
            AudienceLogic();
        }
        public void OnPost()
        {
            // Navigate to next round
            var qNumber = Convert.ToInt32(Request.Query["round"]);
            Response.Redirect($"/Host/Results?Round={qNumber + 1}");
        }
        public void SetVariables()
        {
            ViewData["question"] = question.QuestionTitle;
            ViewData["answerOne"] = "answerOne";
            ViewData["answerTwo"] = "answerTwo";
            ViewData["answerOneCounters"] = question.VoteOneTotal;
            ViewData["answerTwoCounters"] = question.VoteTwoTotal;
            ViewData["groomAnswer"] = question.CoupleOneVote;
            ViewData["brideAnswer"] = question.CoupleTwoVote;
            ViewData["groom"] = game.coupleOneName;
            ViewData["bride"] = game.coupleTwoName;
        }
        public void AudienceLogic()
        {
            if (question.CoupleOneVote == question.CoupleTwoVote)
            {
                ViewData["audience"] = "Couple agree!";
            }
            else
            {
                ViewData["audience"] = "Couple couldn't agree!";
            }
        }
    }
}