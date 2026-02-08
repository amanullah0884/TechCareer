using TechCareer_DLL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.PaymentMethod
{
 
    public class PaymentMethod: BaseClass
    {
      //  public int Id { get; set; } // Primary Key
        public PaymentType PaymentType { get; set; } // Enum

        // Navigation properties
        public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; }

    }
}
