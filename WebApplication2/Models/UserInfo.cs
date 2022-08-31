using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserInfo
    {
        public string candidate_account { get; set; }
        public string candidate_name { get; set; }
        public string submit_file { get; set; }
        public int mark { get; set; }
        public DateTime test_date = DateTime.Now;
    }
}