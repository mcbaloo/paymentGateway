using Domain.Entities;
using Domain.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services
{
    public class ExpensivePaymentGateway : IExpensivePaymentGateway
    {
        public PaymentState ProcessPayment()
        {
            Random rnd = new Random();
            var num = rnd.Next(1, 12);
            if (num % 4 == 0 || num % 6 == 0)
                throw new Exception("Call failed");
            if (num % 3 == 0)
            {
                return new PaymentState() { paymentState = State.failed };
            }
            else
            {
                return new PaymentState() { paymentState = State.processed };
            }
        }
    }
}
