using Domain.Entities;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IServices
{
    public interface IProcessPayment
    {
        Task<int> MakePayment(PaymentModel model);
        Task<PaymentState> ProcessPaymentState(IPaymentGateway paymentGateway, int id);
    }
}
