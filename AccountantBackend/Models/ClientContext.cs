using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base("name=ClientContext")
        {
        }

        public System.Data.Entity.DbSet<AccountantBackend.Models.Client> Clients { get; set; }
    }
}
