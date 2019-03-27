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
    public class CoupleVoteModel : PageModel
    {
        private Question TheQuestion { get; set; }
        private Game TheGame { get; set; }
        private int Counter { get; set; } = 1;

        private readonly CrowdienceContext _context;
        public CoupleVoteModel(CrowdienceContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            GetGame();
            AddCoupleVotesToDb();
        }

        // Gets the Game from the dB
        public void GetGame()
        {
            TheGame = _context.Games.Find(1);
        }


        // Adds couple vote to db, checks question and which couple is voting
        public void AddCoupleVotesToDb()
        {
            TheQuestion = WhichQuestionToUse();
            String CoupleAnswer = Request.Form["CoupleAnswer"];
            if (IsCoupleOne())
                TheQuestion.CoupleOneVote = CoupleAnswer;

            else
                TheQuestion.CoupleTwoVote = CoupleAnswer;
            _context.SaveChanges();

        }

                
        // HELPER for AddCoupleVotesToDb/WhichQuestioToUse 
        // Gets a Game from the dB, dependent on Id
        public Question GetQuestion(int questionNumber)
        {
            return _context.Questions.Find(questionNumber);
        }

        // HELPER Method for AddCoupleToDb
        // Determines CoupleOne and CoupleTwo
        public bool IsCoupleOne()
        {
            String username = Request.Form["username"];
            if (TheGame.coupleOneName == username)
                return true;
            else
                return false;
        }

        // HELPER Method for AddCoupleToDb
        // Determines which Question to use.
        public Question WhichQuestionToUse()
        {
            while (Counter <= 5)
            {
                Question WhichQuestion = GetQuestion(Counter);
                if (WhichQuestion.CoupleOneVote == "Pending")
                    return WhichQuestion;
                else if (WhichQuestion.CoupleOneVote != "Pending" && WhichQuestion.CoupleTwoVote == "Pending")
                    return WhichQuestion;
                Counter++;
            }
            return GetQuestion(5);
        }
    }
}