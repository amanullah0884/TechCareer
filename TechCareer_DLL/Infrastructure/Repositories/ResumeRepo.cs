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
    public interface IResumeRepo : IGenericRepo<Resume>
    {
    }
    public class ResumeRepo : GenericRepo<Resume>, IResumeRepo
    {
        public ResumeRepo(JobContext context) : base(context)
        {
        }
    }
}
