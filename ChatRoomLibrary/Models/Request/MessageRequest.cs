using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.Request
{
    public class MessageRequest : SecurityRequest
    {
        public int IdRoom { get; set; }
    }
}
