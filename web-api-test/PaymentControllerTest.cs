using filedAssessment.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Moq;
using Xunit;
using Domain.IServices;
using Domain.ViewModels;
using System.Threading.Tasks;
using Domain.Entities;
using DataAccess.Services;

namespace web_api_test
{
    public class PaymentControllerTest
    {
        public PaymentControllerTest()
        {
           
        }
        [Fact]
        public async Task Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var missingCardHolder = new PaymentModel
            {
                Amount = 200.00M,
                CreditCardNumber = "123456789034566",
                ExpirationDate = Convert.ToDateTime("2021/12/11"),
                SecurityCode = ""
            };
            var mock = new Mock<IProcessPayment>();
            mock.Setup(p => p.MakePayment(missingCardHolder));
            PaymentController paymentController = new PaymentController(mock.Object);
            paymentController.ModelState.AddModelError("CardHolder", "Required");
            // Act
            var badResponse = await paymentController.ProcessPayment(missingCardHolder);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public async Task Add_ValidObjectPassed_ReturnsStatusCode()
        {
            // Arrange
            var payment = new PaymentModel
            {
                Amount = 20.00M,
                CreditCardNumber = "123456789034566",
                ExpirationDate = Convert.ToDateTime("2021/12/11"),
                CardHolder = "Balogun Micheal",
                SecurityCode = "",
            };
            var mock = new Mock<IProcessPayment>();
            PaymentController paymentController = new PaymentController(mock.Object);
           mock.Setup(p => p.MakePayment(payment));
            // Act
            IActionResult response = await paymentController.ProcessPayment(payment);

            // Assert
            StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(response);
        }
        [Fact]
        public async Task PaymentStatusReturnsValidPaymentStatus()
        {
            //Arrange
           // CheapPaymentGateway 
            var mockGateway = new Mock<ICheapPaymentGateway>();

            var ode = mockGateway.Setup(p => p.ProcessPayment());          
           CheapPaymentGateway process = new CheapPaymentGateway();
            var respose = process.ProcessPayment();
            //Asert
            Assert.True(respose is PaymentState);
        }
    }
}
