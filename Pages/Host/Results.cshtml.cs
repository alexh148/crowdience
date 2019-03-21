using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;


namespace crowdience.Pages
{
    public class ResultsModel : PageModel
    {
        public void OnGet()
        {
            var qNumber = Request.Query["round"];
            if (Convert.ToInt32(qNumber) > 10) {
                Response.Redirect("/Host/GameOver");
            }
            ViewData["question"] = qNumber;
        }
        public void OnPost()
        {
            Response.Redirect($"/Host/EndOfRound?Round={Request.Query["round"]}");
        }
    }
}