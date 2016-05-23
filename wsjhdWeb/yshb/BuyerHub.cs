using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using WXEF;
using System.Threading.Tasks;

namespace NewInfoWeb.yshb
{
    [HubName("buyer")]
    public class BuyerHub : Hub
    {
        private const int TakeCount = 50;

        public List<Oders> GetNeastBuyerInfo()
        {
            using (var db = new WXDBEntities())//Ef code first
            {
                var list = db.Oders.Where(s => s.Extent1.Equals("61")).OrderByDescending(c => c.AddTime).Take(TakeCount)
                      .OrderBy(c => c.Id).ToList();
                return list;
            }
        }
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
        public void Bind(string userKey)
        {
        }
        public override Task OnConnected()
        {
            var id = Context.ConnectionId;
            var c = Clients.Caller;
            return base.OnConnected();
        }
    }
}