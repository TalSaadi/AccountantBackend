using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public class Profit
    {
        [Key]
        public int ProfitId { get; set; }
        public string ProfitTitle { get; set; }
        public ICollection<double> Amounts { get; set; }
        public double Total { get; set; }
        public double DealsVat { get; set; }
        public double AfterVat { get; set; }
    }
}