using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.BillingInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{

    public interface IRecruiterSubscriptionRepo : IGenericRepo<RecruiterSubscription>
    {
    }
    public class RecruiterSubscriptionRepo : GenericRepo<RecruiterSubscription>,IRecruiterSubscriptionRepo
    {
        public RecruiterSubscriptionRepo(JobContext context) : base(context) { }
    }
}
