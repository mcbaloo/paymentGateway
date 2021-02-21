using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Domain.IServices;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace filedAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IProcessPayment _payment;
        public PaymentController(IProcessPayment payment)
        {
            _payment = payment;
        }
        // POST: api/Payment
        [HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var payment = await _payment.MakePayment(model);
            if (payment < 1)
                return StatusCode(500);
            
           
           
                return StatusCode(200);
            
            
            
        }
    }
}
