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

namespace crowdience.Pages
{
    public class HostEndOfRoundModel : PageModel
    {
        private String question { get; set; }
        private String answerOne { get; set; }
        private String answerTwo { get; set; }
        private int answerOneCounters { get; set; }
        private int answerTwoCounters { get; set; }
        private String groom { get; set; }
        private String bride { get; set; }
        private String groomAnswer { get; set; }
        private String brideAnswer { get; set; }

        public void GetQuestions()
        {
            using (WebClient wc = new WebClient())
            {
                //Should Work but doesn't - Saule
                System.Net.ServicePointManager.ServerCertificateValidationCallback =
               delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
               { return true; };
                var json = wc.DownloadString($"https://localhost:5001/api/Question/{Request.Query["round"]}");
                Console.WriteLine(json);
                var questionObject = JObject.Parse(json);
                question = questionObject["questionTitle"].ToString();
                Console.WriteLine(question);
            }
        }
        public void OnGet()
        {
            GetQuestions();
            SetVariables();
            ViewData["question"] = question;
            ViewData["answerOne"] = answerOne;
            ViewData["answerTwo"] = answerTwo;
            ViewData["answerOneCounters"] = answerOneCounters;
            ViewData["answerTwoCounters"] = answerTwoCounters;
            ViewData["groom"] = groom;
            ViewData["bride"] = bride;
            ViewData["groomAnswer"] = groomAnswer;
            ViewData["brideAnswer"] = brideAnswer;
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
            // The Current Round
            var qNumber = Request.Query["round"];
            // Get Request for: Question, Answers, Results and Couple Info
            answerOne = "A1: <N>";
            answerTwo = "A2: <N>";
            answerOneCounters = 25;
            answerTwoCounters = 15;
            groom = "G <N>";
            bride = "B <N>";
            groomAnswer = "A2: <N>";
            brideAnswer = "A2: <N>";
        }
        public void AudienceLogic()
        {
            if (groomAnswer == brideAnswer)
            {
                if ((answerOneCounters > answerTwoCounters && groomAnswer == answerOne)
                    || (answerOneCounters < answerTwoCounters && groomAnswer == answerTwo))
                {
                    ViewData["audience"] = "Correct! :D";
                }
                else
                {
                    ViewData["audience"] = "Wrong! :(";
                }
            }
            else
            {
                if (answerOneCounters == answerTwoCounters)
                {
                    ViewData["audience"] = "Correct! :D";
                }
                else
                {
                    ViewData["audience"] = "Wrong! :(";
                }
            }
        }
    }
}