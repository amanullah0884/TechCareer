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


   public interface IJobNatureRepo : IGenericRepo<JobNature>
   {
      //Task Add(Models.Enums.JobNature jobNature);
      //Task AddAsync(JobNature jobNature);
      //Task GetAllAsync();
      //Task GetByIdAsync(int id);
      //Task UpdateAsync(object existing);
   }
   public class JobNatureRepo : GenericRepo<JobNature>, IJobNatureRepo
    {
        public JobNatureRepo(JobContext context) : base(context)
        {
        }

      //public Task Add(Models.Enums.JobNature jobNature)
      //{
      //   return Task.CompletedTask;
      //}

      //public Task AddAsync(JobNature jobNature)
      //{
      //   return Task.CompletedTask;
      //}

      //public Task GetAllAsync()
      //{
      //   return Task.FromResult(Enumerable.Empty<Models.Enums.JobNature>());
      //}

      //Task IJobNatureRepo.GetByIdAsync(int id)
      //{
      //   return GetByIdAsync(id);
      //}
   }
}
