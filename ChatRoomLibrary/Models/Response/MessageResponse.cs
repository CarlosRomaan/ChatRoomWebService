using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.Response
{
    public class MessageResponse
    {
        public int Id { get; set; }
        public int IdChatUser { get; set; }
        public int IdRoom { get; set; }
        public string Message { get; set; }
        public string ChatUser { get; set; }
        public DateTime DateCreated { get; set; }
        public int TypeMessage { get; set; }
    }
}
