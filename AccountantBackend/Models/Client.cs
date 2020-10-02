using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountantBackend.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string IdCard { get; set; }
        public int BirthYear { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GreenUsername { get; set; }
        public string GreenPassword { get; set; }
        public DateTime LastUpdate { get; set; }

        public ICollection<Vat> Vats { get; set; }
    }
}