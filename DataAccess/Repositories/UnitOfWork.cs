using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _Dbcontext;
        public IPaymentRepository payments {get;}
        public IPaymentStateRepository paymentStates { get; set; }
        public UnitOfWork(ApplicationDbContext context, IPaymentRepository paymentRepository, IPaymentStateRepository _paymentState)
        {
            _Dbcontext = context;
            payments = paymentRepository;
            paymentStates = _paymentState;
        }
        public int Save()
        {
            return _Dbcontext.SaveChanges();
        }
        public void Dispose()
        {
            _Dbcontext.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Dbcontext.Dispose();
            }
        }
    }
}
