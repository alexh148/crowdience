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
    public class PlayerLobbyModel : PageModel
    {
        private String question { get; set; }
        private String answerOne { get; set; }
        private String answerTwo { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            // Response.Redirect($"/Player/Vote?Round=1");
        }

    }
}