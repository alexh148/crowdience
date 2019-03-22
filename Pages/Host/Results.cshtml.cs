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

namespace crowdience.Pages
{
    public class HostResultsModel : PageModel
    {
        private String question { get; set; }
        // private readonly crowdience.Models.GameContext _context;

        // public HostResultsModel(crowdience.Models.GameContext context)
        // {
        //     _context = context;
        // }

        // public ActionResult<List<Question>> GetQuestions()
        // {
        //     return _context.Questions.ToList();
        // }

        // private const string URL = "https://localhost:5000";
        // private string urlParameters = "/api/Question";
        // public void GetQuestions()
        // {
        //     HttpClient client = new HttpClient();
        //     client.BaseAddress = new Uri(URL);
        //     // Add an Accept header for JSON format.
        //     // client.DefaultRequestHeaders.Accept.Add(
        //     // new MediaTypeWithQualityHeaderValue("api/Question"));
        //     // List data response.
        //     HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
        //     if (response.IsSuccessStatusCode)
        //     {
        //         // Parse the response body.
        //         var dataObjects = response.Content.ReadAsAsync<IEnumerable<Question>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
        //         foreach (var d in dataObjects)
        //         {
        //             Console.WriteLine("{0}", d.questionTitle);
        //         }
        //     }
        //     else
        //     {
        //         Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
        //     }
        //     client.Dispose();
        // }
        public void GetQuestions()
        {
            using (WebClient wc = new WebClient())
            {
                //Should Work but doesn't - Saule
                var json = wc.DownloadString("https://localhost:5001/api/Question");
            }
        }

        public void OnGet()
        {
            GetQuestions();
            Console.WriteLine(question);
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