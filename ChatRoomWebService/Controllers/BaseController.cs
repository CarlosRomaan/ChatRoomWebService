using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.WS;
using ChatRoomWebService.Models;

namespace ChatRoomWebService.Controllers
{
    public class BaseController : ApiController
    {
        public UserResponse userSession;
        
        protected bool VerifyToken(SecurityRequest model)
        {
            using (var db = new ChatRoomDBEntities())
            {
                var oUser = db.ChatUser.Where(d => d.Token == model.AccessToken).FirstOrDefault();

                if(oUser != null)
                {
                    userSession = new UserResponse();
                    userSession.AccessToken = oUser.Token;
                    userSession.Name = oUser.Name;
                    userSession.Id = oUser.Id;
                    userSession.Country = oUser.Country;
                    return true;
                }
            }

            return false;
        }
    }
}
