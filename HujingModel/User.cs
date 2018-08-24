using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebHis.Model
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        public int Department { get; set; }

        public string Address { get; set; }

        public int Sex { get; set; }
    }
}