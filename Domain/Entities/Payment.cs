using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
   public  class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        [MinLength(3)]
        [MaxLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public PaymentState PaymentState { get; set; }
    }
}
