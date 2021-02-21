using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class PaymentState
    {
        [Key]
        public int Id { get; set; }
        public State paymentState { get; set; }


        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }

    public enum State
    {
        pending,
        processed,
        failed
    }
}
