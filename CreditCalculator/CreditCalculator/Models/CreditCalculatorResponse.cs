using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CreditCalculatorResponse
    {
        public double AnnualInterestRate { get; set; }

        public double Total { get; set; }

        public double FeesAndcommissions { get; set; }

        public double InterestAmount { get; set; }

        public double PaymentsTotal { get; set; }

        public List<Payment> payments { get; set; }


    }
}
