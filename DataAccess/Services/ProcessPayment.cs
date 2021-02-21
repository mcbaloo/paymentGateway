using Domain.Entities;
using Domain.Interfaces;
using Domain.IServices;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
     public class ProcessPayment : IProcessPayment
    {
        private readonly ICheapPaymentGateway _cheapPaymentGateway;
        private readonly IExpensivePaymentGateway _expensivePaymentGateway;
        private readonly IPreniumPaymentService _preniumPaymentService;
        private readonly IUnitOfWork _unitOfWork;
        public ProcessPayment(IUnitOfWork unitOfWork, ICheapPaymentGateway cheapPaymentGateway, IExpensivePaymentGateway expensivePaymentGateway, IPreniumPaymentService preniumPaymentService)
        {
            _unitOfWork = unitOfWork;
            _cheapPaymentGateway = cheapPaymentGateway;
            _expensivePaymentGateway = expensivePaymentGateway;

            _preniumPaymentService = preniumPaymentService;
        }
        public async Task<int> MakePayment(PaymentModel model)
        {
            int result = 0;
            try
            {
                var payment = new Payment
                {
                    CreditCardNumber = model.CreditCardNumber,
                    ExpirationDate = model.ExpirationDate,
                    SecurityCode = model.SecurityCode,
                    Amount = model.Amount,
                    CardHolder = model.CardHolder
                };
                var response = await _unitOfWork.payments.Add(payment);
                if(model.Amount <= 20)
                {
                    var status = await ProcessPaymentState(_cheapPaymentGateway, payment.Id); 
                }else if(model.Amount > 20 && model.Amount <= 500)
                {
                    int retryCount = 0;
                    try
                    {
                            await ProcessPaymentState(_expensivePaymentGateway, payment.Id);
                             retryCount++;
                    }catch(Exception ex)
                    {
                        if(retryCount == 0)
                        {
                          await ProcessPaymentState(_cheapPaymentGateway, payment.Id);
                        }
                    }
                }
                else
                {
                    int retryCount = 0;
                    while (retryCount < 3)
                    {                     
                    try
                    {
                     var processResult = await ProcessPaymentState(_preniumPaymentService, payment.Id);
                            if (processResult.paymentState == State.processed)
                                break;
                        
                    }catch(Exception ex)
                    {

                    }
                    finally
                    {
                        retryCount++;
                    }
                   }
                }
                var saveResponse = _unitOfWork.Save();
                return saveResponse;

            }catch(Exception ex)
            {
                return result;
            }
        }
        public async Task<PaymentState> ProcessPaymentState(IPaymentGateway paymentGateway, int id)
        {
            var State = paymentGateway.ProcessPayment();
            var paymentState = new PaymentState
            {
                paymentState = State.paymentState,
                PaymentId = id
            };
            await _unitOfWork.paymentStates.Add(paymentState);
            return State;
        }
    }
}
