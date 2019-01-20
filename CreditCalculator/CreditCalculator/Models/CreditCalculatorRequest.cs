using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCalculator.Models
{
    public class CreditCalculatorRequest
    {

        public double Size { get; set; }

        public int Term { get; set; }

        public double Interest { get; set; }
  
        public int PaymentType { get; set; }

        public int PromTerm { get; set; }

        public int PromInterest { get; set; }

        public int PromGratisPeriod { get; set; }

        public double FeeApplication { get; set; }

        public double FeeProcessing { get; set; }

        public double FeeOther { get; set; }

        public double FeeAnnualManagement { get; set; }

        public double FeeAnnualOther { get; set; }

        public double FeeMonthlyManagement { get; set; }

        public double FeeMonthlyOther { get; set; }
    }
}
