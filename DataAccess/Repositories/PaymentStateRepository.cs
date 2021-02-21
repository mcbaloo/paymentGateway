using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PaymentStateRepository : GenericRepository<PaymentState>, IPaymentStateRepository
    {
        private readonly ApplicationDbContext _Dbcontext;
        public PaymentStateRepository(ApplicationDbContext context) : base(context)
        {
            _Dbcontext = context;
        }

        public async Task<int> Add(PaymentState entity)
        {
            await _Dbcontext.paymentStates.AddAsync(entity);
            return 1;
        }
    }
}
