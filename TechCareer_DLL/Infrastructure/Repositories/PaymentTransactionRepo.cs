using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.PaymentMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IPaymentTransactionRepo:IGenericRepo<PaymentTransaction>
    {
    }
    public class PaymentTransactionRepo : GenericRepo<PaymentTransaction>, IPaymentTransactionRepo
    {
        public PaymentTransactionRepo(JobContext context) : base(context) { }
    }
}
