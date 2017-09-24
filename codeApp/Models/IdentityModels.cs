using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public TypesOfUsers UserType { get; set; }
        public enum TypesOfUsers
        {
            Employer = 0,
            Unemployed = 1
        }
 
        public int FileId { get; set; }
        public String FileName { get; set; }
        public byte[] FileContent { get; set; }
        public int ImageFileId { get; set; }

        [Display(Name = "Uploaded Image")]
        public String ImageFileName { get; set; }
        public byte[] ImageFileContent { get; set; }
        public ApplicationUser()
        {
            JobOffer = new List<JobOffer>();
            News = new List<News>();
        }
        public virtual ICollection<JobOffer> JobOffer { get; set; }

        public virtual ICollection<News> News { get; set; }
        
        public String CompanyName { get; set; }
        public String CompanyAddress { get; set; }
        [DataType(DataType.MultilineText)]
        public String CompanyDescription { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>())
        ;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
      
         
       
        public System.Data.Entity.DbSet<codeApp.Models.Followings> Followings { get; set; }

        public System.Data.Entity.DbSet<codeApp.Models.JobOffer> JobOffers { get; set; }

        public System.Data.Entity.DbSet<codeApp.Models.News> News { get; set; }

        public System.Data.Entity.DbSet<codeApp.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<codeApp.Models.Articles> Articles { get; set; }

        public System.Data.Entity.DbSet<codeApp.Models.ArticlesMore> ArticlesMores { get; set; }
        public System.Data.Entity.DbSet<codeApp.Models.JobApplications> Applications { get; set; }

    }
}