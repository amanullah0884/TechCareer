using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IJobSeekersSocialMediaRepo : IGenericRepo<JobSeekersSocialMedia>
    {
    }
    public class JobSeekersSocialMediaRepo : GenericRepo<JobSeekersSocialMedia>, IJobSeekersSocialMediaRepo
    {
        public JobSeekersSocialMediaRepo(JobContext context) : base(context)
        {
        }
    }
}
