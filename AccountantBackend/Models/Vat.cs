using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public enum MonthEnum
    {
        JanFeb,
        MarApr,
        MayJun,
        JulAug,
        SepOct,
        NovDec
    }

    public class Vat
    {
        [Key]
        public int VatId { get; set; }
        public MonthEnum Month { get; set; }

        public ICollection<Expense> Expenses { get; set; }
    }
}