using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStoreWeb.Models
{
    [Serializable]
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
    }
}