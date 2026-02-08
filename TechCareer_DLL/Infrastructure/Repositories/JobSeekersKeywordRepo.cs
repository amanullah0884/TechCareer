using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.JobSeekers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IJobSeekersKeywordRepo : IGenericRepo<JobSeekersKeyword>
    {

    }
    public class JobSeekersKeywordRepo : GenericRepo<JobSeekersKeyword>, IJobSeekersKeywordRepo
    {
        public JobSeekersKeywordRepo(JobContext context) : base(context)
        {
        }
    }
}
