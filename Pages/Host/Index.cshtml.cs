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
        private readonly CrowdienceContext _context;

        public HostIndexModel(CrowdienceContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            string question1 = Request.Form["q1"];
            string question2 = Request.Form["q2"];
            string question3 = Request.Form["q3"];
            string question4 = Request.Form["q4"];
            string question5 = Request.Form["q5"];
            
            Question[] questions = new Question[]
            {
                new Question{QuestionTitle=question1,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{QuestionTitle=question2,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{QuestionTitle=question3,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{QuestionTitle=question4,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"},
                new Question{QuestionTitle=question5,GameId=1,VoteOneTotal=0,VoteTwoTotal=0,CoupleOneVote="Pending",CoupleTwoVote="Pending"}
            };

            foreach (Question q in questions)
            {
                _context.Questions.Add(q);
            }
            _context.SaveChanges();
            
        }
     }
}
