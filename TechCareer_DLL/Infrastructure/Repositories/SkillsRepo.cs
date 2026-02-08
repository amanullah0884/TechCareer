using TechCareer_DLL.Context;
using TechCareer_DLL.Infrastructure.Base;
using TechCareer_DLL.Models.SiteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Infrastructure.Repositories
{
    public interface ISkillsRepo : IGenericRepo<Skill>
    {

    }
    public class SkillsRepo : GenericRepo<Skill>, ISkillsRepo
    {
        public SkillsRepo(JobContext context) : base(context)   
        {

        }
    }
}
