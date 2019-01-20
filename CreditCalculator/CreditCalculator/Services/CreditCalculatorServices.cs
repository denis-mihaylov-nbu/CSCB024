using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCalculator.Models;

namespace CreditCalculator.Services
{
    public class CreditCalculatorServices : ICreditCalculatorServices
    {
        public CreditCalculatorServices()
        {
        }

        public CreditCalculatorResponse Calculate(CreditCalculatorRequest request)
        {
            return CreateResponse(request);
        }

        private CreditCalculatorResponse CreateResponse(CreditCalculatorRequest request) {
            CreditCalculatorResponse response = new CreditCalculatorResponse();
            List<Payment> payments = new List<Payment>();
            double Total = request.Size;
            response.PaymentsTotal = 0;
            DateTime date = DateTime.Now;
            for (int i = 0; i < request.Term; i++) {
                if (request.PaymentType == 1)
                {
                    Payment payment = new Payment();
                    double interestPayment = Total * (request.Interest / 100) / 12;
                    double monthlyPayment = calculateMonthlyPayment(request);
                    double principalPayment = round(monthlyPayment, 2) - round(interestPayment, 2);
                    Console.WriteLine(monthlyPayment);
                    Console.WriteLine(interestPayment);
                    if (Total < monthlyPayment)
                    {
                        principalPayment = Total;
                        monthlyPayment = principalPayment + interestPayment;
                    }

                    payment.MonthlyPayment = round(monthlyPayment, 2);
                    payment.InterestPayment = round(interestPayment, 2);
                    payment.PrincipalPayment = round(principalPayment, 2);
                    payment.FeesAndcommissions = request.FeeMonthlyManagement + request.FeeMonthlyOther;
                    payment.PrincipalLeft = round(Total, 2);
                    Total -= principalPayment;
                    payment.CashFlow = -payment.MonthlyPayment;
                    payment.Date = date.Date.AddMonths(i + 1);
                    response.PaymentsTotal += monthlyPayment;
                    payments.Add(payment);
                }
            }
            response.AnnualInterestRate = round(Math.Pow(1 + request.Interest/12/100, 12) - 1, 6) * 100;
            response.FeesAndcommissions = request.FeeAnnualManagement * request.Term / 12 + request.FeeAnnualOther * request.Term / 12 +
                request.FeeMonthlyManagement * request.Term + request.FeeMonthlyOther * request.Term;
            response.PaymentsTotal = round(response.PaymentsTotal, 2);
            response.Total = round( response.FeesAndcommissions + response.PaymentsTotal, 2);
            response.InterestAmount = round(response.PaymentsTotal - request.Size, 2);
            response.payments = payments;
            return response;
        }

        private double calculateMonthlyPayment(CreditCalculatorRequest request) {
            double monthlyPayment = 0.0;
            double K = request.Size;
            double P = request.Interest / 12;
            double Q = 1 + P / 100;
            double Qn = Math.Pow(Q, request.Term);
            monthlyPayment = K * (Qn * (Q - 1)) / (Qn - 1);
            return monthlyPayment;
        }

        private double round(double number, int digits) {
            return Math.Round(number * Math.Pow(10, digits)) / Math.Pow(10, digits);
        }
    }
}
