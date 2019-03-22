using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Diagnostics;

namespace crowdience.Pages
{
    public class HostResultsModel : PageModel
    {
        public void OnGet()
        {
            var qNumber = Request.Query["round"];
            if (Convert.ToInt32(qNumber) > 10) {
                Response.Redirect("/Host/GameOver");
            }
            // Get Request for STARTING Question and Answers
            ViewData["question"] = qNumber;
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