using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TechCareer_DLL.Models.Events;

using TechCareer_DLL.Models.JobSeekers;
using TechCareer_DLL.Models.BillingInformation;
using TechCareer_DLL.Models.PaymentMethod;
 
using TechCareer_DLL.Models.Recruiters;
using TechCareer_DLL.Models.Security;
using TechCareer_DLL.Models.SiteSettings;
using TechCareer_DLL.Models.SiteSettings.Education;
using TechCareer_DLL.Models.SiteSettings.JobModule;
using TechCareer_DLL.Models.SiteSettings.Location;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DegreeOrExam = TechCareer_DLL.Models.JobSeekers.DegreeOrExam;

namespace TechCareer_DLL.Context
{
 public   class JobContext:IdentityDbContext<ApplicationUser,IdentityRole,string>
    {
        public JobContext(DbContextOptions<JobContext>options):base(options)
        {
            
        }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Ignore<System.Transactions.Transaction>();
      }
      public DbSet<JobSeekerExperience> JobSeekerExperiences { get; set; }
      public DbSet<JobSeekerInformation> JobSeekerInformations { get; set; }
      public DbSet<JobSeekersKeyword> JobSeekersKeywords { get; set; }
      public DbSet<JobSeekersSocialMedia> JobSeekersSocialMedias { get; set; }
     public DbSet<LevelOfEducation> LevelOfEducations { get; set; }
      public DbSet<JobSeekerSkill> JobSeekerSkills { get; set; }
      public DbSet<JobSeekerTraining> JobSeekerTrainings { get; set; }
      public DbSet<PersonalInformation> PersonalInformations { get; set; }
      public DbSet<PreferredJobInformation> PreferredJobInformations { get; set; }
      public DbSet<Resume> Resumes { get; set; }
      public DbSet<SavedJobs> SavedJobs { get; set; }
      public DbSet<SocialMedia> SocialMedias { get; set; }



        //DbSet Recruiters
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        //billing Information
        public DbSet<RecruiterSubscription> RecruiterSubscriptions { get; set; }
        public DbSet<RecruiterPackage> RecruiterPackages { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        //DbSet JobSeekers
        public DbSet<CareerEvent> CareerEvents { get; set; }
        public DbSet<CareerInformation> CareerInformations { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<DegreeOrExam> DegreeOrExams { get; set; }

        //public DbSet<Institute> Institutes { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobSeeker> JobSeekers { get; set; }
        public DbSet<JobSeekerAchievement> JobSeekerAchievements { get; set; }
        public DbSet<JobSeekerCertification> JobSeekerCertifications { get; set; }
        public DbSet<JobSeekerEducation> JobSeekerEducations { get; set; }
      //DbSet Recruiters
     // public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<CompanyOwnership> CompanyOwnerships { get; set; }
        public DbSet<JobNature> JobNatures { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobRequiredSkills> JobRequiredSkills { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }

        //DbSet SiteSettings
        //DbSet Job Module
        public DbSet<JobCategory> JobCategories { get; set; }
        //DbSet Education Or JobSeekers
        //public DbSet<LevelOfEducation> LevelOfEducations { get; set; }
        //public DbSet<DegreeOrExam> DegreeOrExams { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        //DbSet Location
        
        public DbSet<Area> Areas { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Notification> Notifications { get; set; }


     
   }
    public class DbJobContextFactory : IDesignTimeDbContextFactory<JobContext>
    {
        public JobContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JobContext>();
            optionsBuilder.UseSqlServer("Data Source=. ;database=JobSolutionsDb; Trusted_Connection=True;MultipleActiveResultSets=True;trustservercertificate=true;");

            return new JobContext(optionsBuilder.Options);
        }
    }
}
