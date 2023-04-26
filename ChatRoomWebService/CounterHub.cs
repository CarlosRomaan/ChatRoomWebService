using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.WS;
using ChatRoomWebService.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatRoomWebService
{
    public class CounterHub : Hub
    {
        public override Task OnConnected()
        {
            Clients.All.enterUser();
            return base.OnConnected();
        }

        public void AddGroup(int idRoom)
        {
            Groups.Add(Context.ConnectionId, idRoom.ToString());
        }

        public void Send(int idRoom, string userName, int idUser, string message, string AccessToken)
        {
            if (VerifyToken(AccessToken))
            {
                string date = DateTime.Now.ToString();

                using (var db = new ChatRoomDBEntities())
                {
                    var msn = new ChatMessage();
                    msn.IdRoom = idRoom;
                    msn.DateCreated = DateTime.Now;
                    msn.IdChatUser = idUser;
                    msn.Message = message;
                    msn.IdState = 1;

                    db.ChatMessage.Add(msn);
                    db.SaveChanges();
                }
                Clients.Group(idRoom.ToString()).sendChat(userName, message, date, idUser);
            }
        }
        protected bool VerifyToken(string AccessToken)
        {
            using (var db = new ChatRoomDBEntities())
            {
                var oUser = db.ChatUser.Where(d => d.Token == AccessToken).FirstOrDefault();

                if (oUser != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}