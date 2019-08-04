using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Loja.WebApi.notification
{
    [HubName("notification")]
    public class NotificationHub : Hub
    {
        public static void SendMessageNew(string mensagem)
        {



            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.add(mensagem);
          
        }

        public static void SendMessageDelete(string mensagem)
        {


            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.delete(mensagem);
        }

        public static void SendMessageUpdate(string mensagem)
        {

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.update(mensagem);
        }

        public static void SendMessageList(string mensagem)
        {

            var hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            hubContext.Clients.All.List(mensagem);
        }
    }
}