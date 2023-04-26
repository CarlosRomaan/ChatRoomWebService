using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatRoomWebService.Models.Request
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
    }
}