using TechCareer_DLL.Models.BillingInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.PaymentMethod
{
    public class PaymentTransaction: BaseClass
    {
        [ForeignKey(nameof(RecruiterSubscription))]
        public int RecruiterSubscriptionId { get; set; } // Foreign Key -> RecruiterSubscription

        public DateTime TransactionDate { get; set; }

        public int TransactionAmount { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        public int PaymentMethodId { get; set; } // Foreign Key -> PaymentMethod

        // Navigation properties
        public virtual RecruiterSubscription RecruiterSubscription { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }


    }
}
