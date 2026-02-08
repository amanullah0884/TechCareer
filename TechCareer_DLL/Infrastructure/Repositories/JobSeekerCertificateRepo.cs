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
    public interface IJobSeekerCertificateRepo : IGenericRepo<JobSeekerCertification>
    {
    }
    public class JobSeekerCerificateRepo : GenericRepo<JobSeekerCertification>, IJobSeekerCertificateRepo
    {
        public JobSeekerCerificateRepo(JobContext context) : base(context)
        {
        }
    }
}
