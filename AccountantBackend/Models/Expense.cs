using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AccountantBackend.Models
{
    public enum ExpenseCategory
    {
        House,
        Work,
        Food,
        Clothing
    }

    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        public string ExpenseTitle { get; set; }
        public ExpenseCategory Category { get; set; }
        public ICollection<double> Amounts { get; set; }
        public double Total { get; set; }
        public double VatAmount { get; set; }
        public double AfterVat { get; set; }
        public DateTime Date { get; set; }
    }
}