using System;
using System.Collections.Generic;
using System.Text;

namespace InstallmentsWPF.Model
{
    class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string userName { get; set; }
        public List<string> roles { get; set; }
        public string tokenString { get; set; }
    }
}
