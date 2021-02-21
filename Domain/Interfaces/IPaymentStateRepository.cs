using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
     public interface IPaymentStateRepository  : IGenericRepository<PaymentState>
    {
        Task<int> Add(PaymentState entity);
    }
}
