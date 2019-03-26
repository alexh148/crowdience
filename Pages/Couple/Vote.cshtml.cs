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
            FillOutCoupleVotes();
            IsCoupleOne();
            Console.WriteLine(Request.Form["CoupleAnswerOne"]);
        }

        public void GetGame()
        {
            TheGame = _context.Games.Find(1);
        }
        public Question GetQuestion(int questionNumber)
        {
            // Find is working
            return _context.Questions.Find(questionNumber);

        }

        public bool IsCoupleOne()
        {
            String username = Request.Form["username"];
            if (TheGame.coupleOneName == username)
                return true;
            else
                return false;
        }

        public void FillOutCoupleVotes()
        {
            TheQuestion = WhichQuestion();
            Console.WriteLine(TheQuestion.CoupleOneVote);
            Console.WriteLine(TheQuestion.CoupleTwoVote);
            if (TheQuestion.CoupleOneVote == "Pending")
            {
                TheQuestion.CoupleOneVote = "Couple One Voted";
                _context.SaveChanges();
                Console.WriteLine("First Which Question Check");

            }
            else if (TheQuestion.CoupleOneVote != "Pending" && TheQuestion.CoupleTwoVote == "Pending")
            {
                TheQuestion.CoupleTwoVote = "Couple Two Voted";
                _context.SaveChanges();
                Console.WriteLine("Second Which Question Check");
            }
            else
            {
                Console.WriteLine("Third Which Question Check");
            }
        }

        public Question WhichQuestion()
        {
            // Question WhichQuestion = GetQuestion(Counter);
            // Console.WriteLine(Counter);
            // Console.WriteLine(WhichQuestion.QuestionTitle);
            while (Counter <= 5)
            {
                Question WhichQuestion = GetQuestion(Counter);

                if (WhichQuestion.CoupleOneVote == "Pending")
                {
                    Console.WriteLine("Couple One is Empty");
                    return WhichQuestion;

                }
                else if (WhichQuestion.CoupleOneVote != "Pending" && WhichQuestion.CoupleTwoVote == "Pending")
                {
                    Console.WriteLine("Couple Two is Empty");
                    return WhichQuestion;
                }
                Counter++;
            }
            Console.WriteLine("First Question Returned");
            return GetQuestion(5);
        }

        // public void WhichQuestion()
        // {
        //     TheQuestion = GetQuestion(Counter);
        //     Console.WriteLine(TheQuestion.QuestionTitle);
        //     while (Counter <= 5)
        //     {
        //         if (TheQuestion.CoupleOneVote == "pending")
        //         {
        //             TheQuestion.CoupleOneVote = "Couple One Voted";
        //             _context.SaveChanges();

        //         }
        //         else if (TheGame.coupleOneName != "pending" && TheGame.coupleTwoName == "pending")
        //         {
        //             TheQuestion.CoupleTwoVote = "Couple Two Voted";
        //             _context.SaveChanges();

        //         }
        //         else
        //         {
        //             Counter++;
        //         }
        //     }
        // }

        public void SaveVoteToDb()
        {
            string coupleName = Request.Form["username"];

            if (TheGame.coupleOneName == "pending")
                TheGame.coupleOneName = coupleName;
            else if (TheGame.coupleTwoName == "pending")
                TheGame.coupleTwoName = coupleName;
            else
                Console.WriteLine("Table full, truncate it!");
            _context.SaveChanges();
        }
    }
}