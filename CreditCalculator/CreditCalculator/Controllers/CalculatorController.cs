using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCalculator.Models;
using CreditCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICreditCalculatorServices _services;

        public CalculatorController(ICreditCalculatorServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Calculate")]
        public ActionResult<CreditCalculatorResponse> Calculate(CreditCalculatorRequest request)
        {
            var inventoryItems = _services.Calculate(request);
            if (inventoryItems == null)
            {
                return NotFound();
            }
            return inventoryItems;
        }
    }
}