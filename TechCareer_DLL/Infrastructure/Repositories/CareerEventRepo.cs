using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.Events;
using TechCareer_DLL.Models.Recruiters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface ICareerEventRepo : IGenericRepo<CareerEvent>
    {

    }
    public class CareerEventRepo : GenericRepo<CareerEvent>, ICareerEventRepo
    {
        public CareerEventRepo(JobContext context) : base(context)
        {
        }
    }

}

