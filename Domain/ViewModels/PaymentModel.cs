using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class PaymentModel
    {
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        [CustomDateValidator(ErrorMessage = "Date cannot be past date")]
        public DateTime ExpirationDate { get; set; }
        [SecurityCodeValidator(ErrorMessage = "Security Code should be 3 digits")]
        public string SecurityCode { get; set; }
        [Required]
        [CustomAmountValidator(ErrorMessage = "Enter a positive amount")]
        public decimal Amount { get; set; }
    }
}
