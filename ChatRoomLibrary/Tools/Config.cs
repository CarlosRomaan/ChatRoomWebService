using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Tools
{
    public class Config
    {
        public static string Url
        {
            get
            {
                return "http://localhost:52709/";
            }
        }

        public static string UrlSignalR
        {
            get
            {
                return "http://localhost:52709/signalr/";
            }
        }

        public static string UrlSignalRHubs
        {
            get
            {
                return "http://localhost:52709/signalr/hubs";
            }
        }
    }
}
