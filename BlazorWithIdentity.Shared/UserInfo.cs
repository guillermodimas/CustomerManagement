using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWithIdentity.Shared
{
    public class UserInfo
    {
        public string Id { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set;  }

        public string LastName { get; set; }

        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
