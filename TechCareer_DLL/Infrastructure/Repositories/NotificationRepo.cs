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
    public interface INotificationRepo : IGenericRepo<Notification>
    {

    }
    public class NotificationRepo :  GenericRepo<Notification> , INotificationRepo 
    {
        public NotificationRepo(JobContext context) : base(context) { }
    }
}
