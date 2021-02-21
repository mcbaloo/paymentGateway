using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPaymentRepository payments { get; }
        IPaymentStateRepository paymentStates { get; }
        int Save();
    }
}
