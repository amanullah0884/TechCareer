using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.SiteSettings.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
   public interface IJobSeekerEducationRepo : IGenericRepo<JobSeekerEducation>
   {

   }
   public class JobSeekerEducationRepo : GenericRepo<JobSeekerEducation>, IJobSeekerEducationRepo
   {
      public JobSeekerEducationRepo(JobContext context) : base(context)
      {
         
      }
   }
}

