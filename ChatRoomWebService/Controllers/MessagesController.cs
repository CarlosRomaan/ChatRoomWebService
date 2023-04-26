using ChatRoomLibrary.Models.WS;
using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.Response;
using ChatRoomWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using ChatRoomWebService.Models.Request;
//using System.Web.Mvc;

namespace ChatRoomWebService.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpPost]
        public Reply Get([FromBody] MessageRequest model)
        {
            Reply oReply = new Reply();
            oReply.Result = 0;

            if (!VerifyToken(model))
            {
                oReply.Message = "Métedo no permitido";
                return oReply;
            }

            try
            {
                using (var db = new ChatRoomDBEntities())
                {
                    List<MessageResponse> lst = (from d in db.ChatMessage.ToList()
                                                 where d.IdState == 1 && d.IdRoom == model.IdRoom
                                                 orderby d.DateCreated descending
                                                 select new MessageResponse
                                                 {
                                                     Message = d.Message,
                                                     Id = d.Id,
                                                     IdChatUser = d.IdChatUser,
                                                     ChatUser = d.ChatUser.Name,
                                                     DateCreated = d.DateCreated,
                                                     TypeMessage = (
                                                                     new Func<int>(
                                                                         () =>
                                                                         {
                                                                             try
                                                                             {
                                                                                 if (d.IdChatUser == userSession.Id)
                                                                                 {
                                                                                     return 1;
                                                                                 }
                                                                                 else
                                                                                 {
                                                                                     return 2;
                                                                                 }
                                                                             }
                                                                             catch (Exception ex)
                                                                             {
                                                                                 return 2;
                                                                             }
                                                                         }
                                                                         )()
                                                     )
                                                 }).ToList();

                    oReply.Result = 1;
                    oReply.Data = lst;
                }
            }
            catch(Exception ex)
            {
                oReply.Message = "Ocurrió un error.";
            }   
            return oReply;
        }
    }
}
