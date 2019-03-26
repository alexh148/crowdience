using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace crowdience.Hubs
{
    public class PollHub : Hub
    {
        public async Task SendCouple(string couple)
        {
            await Clients.All.SendAsync("ReceiveCouple", couple);
        }
        public async Task SendCoupleVote(string couple, string responseID, string responseVal)
        {
            await Clients.All.SendAsync("ReceiveCoupleVote", couple, responseID, responseVal);
        }
        
        public async Task SendUser(string user)
        {
            await Clients.All.SendAsync("ReceiveUser", user);
        }
        public async Task SendMessage(string user, string responseID, string responseVal)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, responseID, responseVal);
        }
        public async Task SendQuestion(string question)
        {
            await Clients.All.SendAsync("ReceiveQuestion", question);
        }

        public async Task SendIconId(string icon1, string icon2)
        {
            await Clients.All.SendAsync("ReceiveIconId", icon1, icon2);
        }

        public async Task StartGame() 
        {
            await Clients.All.SendAsync("GameStarted");
        }

    }
}