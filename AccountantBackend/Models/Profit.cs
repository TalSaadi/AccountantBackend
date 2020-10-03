using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public class Profit
    {
        [ForeignKey("Vat")]
        public int ProfitId { get; set; }
        public string ProfitTitle { get; set; }
        public ICollection<double> Amounts { get; set; }
        public double Total { get; set; }
        public double DealsVat { get; set; }
        public double AfterVat { get; set; }

        public virtual Vat Vat { get; set; }
    }
}