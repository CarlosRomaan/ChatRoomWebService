using ChatRoomLibrary.Models;
using ChatRoomLibrary.Models.WS;
using ChatRoomLibrary.Models.Request;
using ChatRoomWebService.Models;
using ChatRoomWebService.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoomWebService.Controllers
{
    public class AccessController : ApiController
    {
        [HttpPost]
        public Reply Login(AccessRequest model)
        {
            Reply oReply = new Reply();
            oReply.Result = 0;

            using (var db = new ChatRoomDBEntities())
            {
                var chatUser = (from d in db.ChatUser
                                where d.Email == model.Email && d.Password == model.Password
                                select d).FirstOrDefault();
                if(chatUser != null)
                {
                    string accessToken = Guid.NewGuid().ToString();
                    chatUser.Token = accessToken;
                    db.Entry(chatUser).State = EntityState.Modified;
                    db.SaveChanges();

                    UserResponse userResponse = new UserResponse();
                    userResponse.AccessToken = accessToken;
                    userResponse.Name = chatUser.Name;
                    userResponse.Country = chatUser.Country;

                    oReply.Result = 1;
                    oReply.Data = userResponse;
                }
                else
                {
                    oReply.Message = "Datos incorrectos";
                }
            }

            return oReply;
        }
    }
}
