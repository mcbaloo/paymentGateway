using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IServices
{
    public interface IPaymentGateway
    {
        PaymentState ProcessPayment();
    }
}
