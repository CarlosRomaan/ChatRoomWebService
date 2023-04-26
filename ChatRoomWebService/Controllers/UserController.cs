using ChatRoomWebService.Models.ViewModel;
using ChatRoomWebService.Models.Request;
using ChatRoomWebService.Models;
using ChatRoomLibrary.Models.WS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ChatRoomWebService.Controllers
{
    public class UserController : ApiController
    {
        /*[HttpGet]
        public Reply Get()
        {
            Reply oReply = new Reply();
            using (var db = new Models.ChatRoomDBEntities())
            {
                List<UserViewModel> lstUsers = (from d in db.ChatUser
                                               select new UserViewModel
                                               {
                                                   Name = d.Name,
                                                   Country = d.Country
                                               }).ToList();
                oReply.Result = 1;
                oReply.Data = lstUsers;
            }
            return oReply;
        }*/

        [HttpPost]
        public Reply Register([FromBody] UserRequest model)
        {
            Reply oReply = new Reply();

            try
            {
                using (var db = new ChatRoomDBEntities())
                {
                    ChatUser chatUser = new ChatUser();
                    chatUser.Email = model.Email;
                    chatUser.Password = model.Password;
                    chatUser.Name = model.Name;
                    chatUser.Country = model.Country;
                    chatUser.DateCreated = DateTime.Now;
                    chatUser.IdState = 1;

                    db.ChatUser.Add(chatUser);
                    db.SaveChanges();

                    oReply.Result = 1;
                }
            }
            catch(Exception ex)
            {
                oReply.Result = 0;
                oReply.Message = "Prueba intentando de nuevo";
            }
            return oReply;
        }
    }
}
