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
    public class PlayerVoteModel : PageModel
    {
        // private String question { get; set; }
        // private String answerOne { get; set; }
        // private String answerTwo { get; set; }

        // public void GetQuestion()
        // {
        //     using (WebClient wc = new WebClient())
        //     {
        //         System.Net.ServicePointManager.ServerCertificateValidationCallback =
        //        delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //        { return true; };
        //         var json = wc.DownloadString($"https://localhost:5001/api/Question/{Request.Query["round"]}");
        //         Console.WriteLine(json);
        //         var questionObject = JObject.Parse(json);
        //         question = questionObject["questionTitle"].ToString();
        //     }
        // }
        public void OnGet()
        {
            // GetQuestion();
            // ViewData["question"] = question;
            // ViewData["answerOne"] = answerOne;
        }
        public void OnPost()
        {
            // var qNumber = Convert.ToInt32(Request.Query["round"]);
            // Response.Redirect($"/Player/Vote?Round={qNumber + 1}");
        }

    }
}