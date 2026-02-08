using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface IJobRequiredSkillRepo : IGenericRepo<JobRequiredSkills>
    {
    }   
    public class JobRequiredSkillRepo : GenericRepo<JobRequiredSkills>, IJobRequiredSkillRepo
        {
        public JobRequiredSkillRepo(JobContext context) : base(context)
        {
        }
    }
    
}
