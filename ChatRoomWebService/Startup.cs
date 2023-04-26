using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(ChatRoomWebService.Startup))]

namespace ChatRoomWebService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", m =>
            {
                m.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration();
                m.RunSignalR(hubConfiguration);
            });
        }
    }
}
