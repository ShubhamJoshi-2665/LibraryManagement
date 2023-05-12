using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Model
{
    class LoginResponseModel
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string role { get; set; }
    }
}
