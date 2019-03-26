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
    public class CoupleLobbyModel : PageModel
    {
        private Game TheGame { get; set; }
        private readonly CrowdienceContext _context;
        public CoupleLobbyModel(CrowdienceContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            GetGame();
            SaveCoupleNameToDb();
        }
        public void GetGame()
        {
            TheGame = _context.Games.Find(1);
        }

        public void SaveCoupleNameToDb()
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