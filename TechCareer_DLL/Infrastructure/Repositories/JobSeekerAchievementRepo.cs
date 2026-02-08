using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IJobSeekerAchievementRepo : IGenericRepo<JobSeekerAchievement>
    {
    }
    public class JobSeekerAchievementRepo : GenericRepo<JobSeekerAchievement>, IJobSeekerAchievementRepo
    {
        public JobSeekerAchievementRepo(JobContext context) : base(context)
        {
        }
    }
}
