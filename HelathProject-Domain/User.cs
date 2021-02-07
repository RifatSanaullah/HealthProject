using System;
using System.Collections.Generic;
using System.Text;

namespace HelathProject_Domain
{
    public class User
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public int ConfirmPassword { get; set; }
        public int is_admin { get; set; }
    }
}
