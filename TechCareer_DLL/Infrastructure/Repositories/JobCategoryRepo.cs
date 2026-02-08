using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings.JobModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IJobCategoryRepo : IGenericRepo<JobCategory>
    {
    }
    public class JobCategoryRepo : GenericRepo<JobCategory>, IJobCategoryRepo
    {
        public JobCategoryRepo(JobContext context) : base(context)
        {
        }
    }
}
