using System;
using System.Collections.Generic;

namespace CT.DB.Models
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Pwd { get; set; }
    }
}
