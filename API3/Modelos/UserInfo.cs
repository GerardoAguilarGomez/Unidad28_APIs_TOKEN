using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API3
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
