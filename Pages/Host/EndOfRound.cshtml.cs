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
    public class EndOfRoundModel : PageModel
    {
        public void OnGet()
        {   
            var qNumber = Request.Query["round"];
            ViewData["question"] = qNumber;
        }
        public void OnPost()
        {
            Console.WriteLine("EndOfRound POST");
            var qNumber = Convert.ToInt32(Request.Query["round"]);
            Response.Redirect($"/Host/Results?Round={qNumber + 1}");
        }
    }
}