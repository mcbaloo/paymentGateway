using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly ApplicationDbContext _Dbcontext;
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
            _Dbcontext = context;
        }

        public async Task<int> Add(Payment entity)
        {
            await _Dbcontext.payments.AddAsync(entity);
            return 1;
        }
    }
}
