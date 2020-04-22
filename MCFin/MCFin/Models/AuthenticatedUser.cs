using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public class AuthenticatedUser
    {
        public string  Access_Token { get; set; }
        public string UserName { get; set; }
    }
    public class UserInfo
    {
        public string GuidId { get; set; }
        public int HouseId { get; set; }
    }
}
