using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using crowdience.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace crowdience.Pages
{
    public class HostIndexModel : PageModel

    {
        private Question[] Questions { get; set; }
        private Game TheGame { get; set; }

        private readonly CrowdienceContext _context;

        public HostIndexModel(CrowdienceContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            TruncateDatabases();
            StartNewGame();
        }
        public void OnPost()
        {
            SetQuestions();
            PostQuestionsToDatabase();
            Response.Redirect($"/Host/Lobby");
        }
        public void SetQuestions()
        {
            string question1 = Request.Form["q1"];
            string question2 = Request.Form["q2"];
            string question3 = Request.Form["q3"];
            string question4 = Request.Form["q4"];
            string question5 = Request.Form["q5"];

            Questions = new Question[]
            {
                new Question{Id=1,QuestionTitle=question1,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{Id=2,QuestionTitle=question2,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{Id=3,QuestionTitle=question3,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{Id=4,QuestionTitle=question4,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{Id=5,QuestionTitle=question5,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"}
            };
        }

        public void PostQuestionsToDatabase()
        {
            foreach (Question q in Questions)
            {
                _context.Questions.Add(q);
            }
            _context.SaveChanges();
        }

        public void StartNewGame()
        {
            TheGame = new Game { Id = 1, coupleOneName = "pending", coupleTwoName = "pending" };
            _context.Games.Add(TheGame);
            _context.SaveChanges();
        }

        public void TruncateDatabases()
        {
            _context.Questions.RemoveRange(_context.Questions);
            _context.Games.RemoveRange(_context.Games);
        }
    }
}
