using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public class Client
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}