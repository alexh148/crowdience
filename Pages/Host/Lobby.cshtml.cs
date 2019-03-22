using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace crowdience.Pages
{
    public class HostLobbyModel : PageModel
    {
        public void OnGet()
        {
            ViewData["LobbyTitle"] = "Mega Lobby!";
        }
         public void OnPost()
        {
            Response.Redirect($"/Host/Results?Round=1");
        }
    }
}