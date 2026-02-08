using TechCareer_DLL.Models.Enums;
using TechCareer_DLL.Models.SiteSettings.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCareer_DLL.Models.Events
{
   public class CareerEvent: BaseClass
    {
      //public int Id { get; set; }

      [Required]
      [StringLength(200)]
      [Display(Name = "Event Name")]
      public string EventName { get; set; } = string.Empty;

      [Required]
      [Display(Name = "Event Type")]
      public EventType EventType { get; set; } // Enum

      [Required]
      [Display(Name = "Event Date")]
      public DateTime EventDate { get; set; } = DateTime.Now;

      [Required]
      [Display(Name = "Location ID")]
      [ForeignKey("Location")]
      public int LocationId { get; set; } // Foreign Key → Location

      // Navigation property
      public virtual Location? Location { get; set; }
   }

}