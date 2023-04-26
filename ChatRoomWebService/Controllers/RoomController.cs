using ChatRoomLibrary.Models.Request;
using ChatRoomLibrary.Models.Response;
using ChatRoomLibrary.Models.WS;
using ChatRoomWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoomWebService.Controllers
{
    public class RoomController : BaseController
    {
        [HttpPost]
        public Reply List([FromBody] SecurityRequest model)
        {
            Reply oReply = new Reply();

            oReply.Result = 0;
            if(!VerifyToken(model))
            {
                oReply.Message = "Métedo no permitido";
                return oReply;
            }

            using (var db = new ChatRoomDBEntities())
            {
                List<ListRoomsResponse> lstRooms = (from d in db.Room
                                              where d.IdState == 1
                                              orderby d.Name
                                              select new ListRoomsResponse
                                              {
                                                  Name = d.Name,
                                                  Description = d.Description,
                                                  Id = d.Id
                                              }).ToList();
                oReply.Data = lstRooms;
            }
            oReply.Result = 1;
            return oReply;
        }
    }
}
