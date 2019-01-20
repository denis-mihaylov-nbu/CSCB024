using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class Payment
    {
        public Payment()
        {

        }

        public DateTime Date { get; set; }

        public double MonthlyPayment { get; set; }

        public double PrincipalPayment { get; set; }

        public double InterestPayment { get; set; }

        public double PrincipalLeft { get; set; }

        public double FeesAndcommissions { get; set; }

        public double CashFlow { get; set; }

    }
}
