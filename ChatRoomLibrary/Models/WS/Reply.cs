using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoomLibrary.Models.WS
{
    public class Reply
    {
        public int Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
