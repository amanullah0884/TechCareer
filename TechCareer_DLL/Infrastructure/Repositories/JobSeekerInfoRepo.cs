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
   public interface IJobSeekerInfoRepo : IGenericRepo<JobSeekerInformation>
   {

   }
   public class JobSeekerInfoRepo : GenericRepo<JobSeekerInformation>, IJobSeekerInfoRepo
   {
      public JobSeekerInfoRepo(JobContext context) : base(context) 
      {
         
      }
   }
}
