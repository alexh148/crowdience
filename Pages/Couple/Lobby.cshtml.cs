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
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;

namespace crowdience.Pages
{
    public class CoupleLobbyModel : PageModel
    {
        public void OnGet()
        {
            
            //ViewData["LobbyTitle"] = "Mega Lobby!";
        }
         public void OnPost()
        {
            // NameValueCollection nvc = Request.Form;
            // string uid = nvc["uid"];
            Console.WriteLine("lala");
            
           // Response.Redirect($"/Couple/Vote");
        }

     
    }
}








   // public void CheckCouple()
        // {
        //    if()
        //    {
        //        //fill in couple 1 column
        //    }
        //    else
        //    {
        //        //fill in couple2 columnt
        //    }
        //     //checks if couple one is filled in
        // }

        // public void InsertByUid(){
          
        // }