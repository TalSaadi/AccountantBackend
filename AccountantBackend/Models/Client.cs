using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AccountantBackend.Models
{
    public class Client
    {
        [Key]
        public string Name { get; set; }
        public int Age { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}