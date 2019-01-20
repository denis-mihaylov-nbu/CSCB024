using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCalculator.Models;

namespace CreditCalculator.Services
{
    public interface ICreditCalculatorServices
    {
        CreditCalculatorResponse Calculate(CreditCalculatorRequest request);
    }
}
