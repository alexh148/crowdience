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

namespace crowdience.Pages
{
    public class HostGameOverModel : PageModel
    {
        private readonly CrowdienceContext _context;
        private Question QuestionOne { get; set; }
        private Question QuestionTwo { get; set; }
        private Question QuestionThree { get; set; }
        private Question QuestionFour { get; set; }
        private Question QuestionFive { get; set; }

        public HostGameOverModel(CrowdienceContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            SetQuestions();
            SetViews();
        }

        public void OnPost()
        {
        }

        public Question GetQuestion(int questionNumber)
        {
            return _context.Questions.Find(questionNumber);
        }

        public void SetQuestions()
        {
            QuestionOne = GetQuestion(1);
            QuestionTwo = GetQuestion(2);
            QuestionThree = GetQuestion(3);
            QuestionFour = GetQuestion(4);
            QuestionFive = GetQuestion(5);
        }

        public void SetViews()
        {
            // Question 1
            ViewData["q1Title"] = QuestionOne.QuestionTitle;
            ViewData["q1a1"] = QuestionOne.VoteOneTotal;
            ViewData["q1a2"] = QuestionOne.VoteTwoTotal;
            // Question 2
            ViewData["q2Title"] = QuestionTwo.QuestionTitle;
            ViewData["q2a1"] = QuestionTwo.VoteOneTotal;
            ViewData["q2a2"] = QuestionTwo.VoteTwoTotal;
            // Question 3
            ViewData["q3Title"] = QuestionThree.QuestionTitle;
            ViewData["q3a1"] = QuestionThree.VoteOneTotal;
            ViewData["q3a2"] = QuestionThree.VoteTwoTotal;
            // Question 4
            ViewData["q4Title"] = QuestionFour.QuestionTitle;
            ViewData["q4a1"] = QuestionFour.VoteOneTotal;
            ViewData["q4a2"] = QuestionFour.VoteTwoTotal;
            // Question 5
            ViewData["q5Title"] = QuestionFive.QuestionTitle;
            ViewData["q5a1"] = QuestionFive.VoteOneTotal;
            ViewData["q5a2"] = QuestionFive.VoteTwoTotal;
        }
    }
}