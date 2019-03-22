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
        public async Task SendCoupleVote(string couple, string message, string responseID, string responseVal)
        {
            await Clients.All.SendAsync("ReceiveCoupleVote", couple, message, responseID, responseVal);
        }
        
        public async Task SendUser(string user)
        {
            await Clients.All.SendAsync("ReceiveUser", user);
        }
        public async Task SendMessage(string user, string message, string responseID, string responseVal)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, responseID, responseVal);
        }
        public async Task SendQuestion(string question)
        {
            await Clients.All.SendAsync("ReceiveQuestion", question);
        }

        public async Task SendUid(string question)
        {
            await Clients.All.SendAsync("ReceiveUid", question);
        }

    }
}