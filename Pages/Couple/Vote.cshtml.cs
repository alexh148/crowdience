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
    public class CoupleVoteModel : PageModel
    {
        private readonly CrowdienceContext _context;
        public CoupleVoteModel(CrowdienceContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
        }
    }
}