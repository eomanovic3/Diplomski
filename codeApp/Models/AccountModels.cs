using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using static codeApp.Models.ApplicationUser;
using codeApp.Controllers;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using codeApp.Models;

namespace codeApp.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EnumDataType(typeof(TypesOfUsers))]
        public TypesOfUsers UserType { get; set; }

    }
    public class JobOffer
    {

        [Key]
        public int ID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Userfk { get; set; }

        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string MailForApplication { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Position number must be a positive number")]
        public int NumberOfPositions { get; set; }

        [Required]
        public string Location { get; set; }

        [Display(Name = "Publishing Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishingDate { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]

        [Display(Name = "Informatics-Hardware")]
        public bool Hardware { get; set; }
        [Required]
        [Display(Name = "Informatics-Software")]
        public bool Software { get; set; }
        [Required]
        public bool Education { get; set; }
        [Required]
        public bool IT { get; set; }
        [Required]
        public bool Architecture { get; set; }
        [Required]
        public bool Banking { get; set; }
        [Required]
        [Display(Name = "Construction,tectonics")]
        public bool Construction { get; set; }
        [Required]
        [Display(Name = "Mechanical Engineering")]
        public bool MechanicalEngineering { get; set; }
        [Required]
        [Display(Name = "Real Estates")]
        public bool RealEstate { get; set; }
        [Required]
        [Display(Name = "Health and Care")]
        public bool Health { get; set; }
        [Required]
        [Display(Name = "Marketing-PR")]
        public bool Marketing { get; set; }
        [Required]
        [Display(Name = "Law")]
        public bool Law { get; set; }
        [Required]
        [Display(Name = "Turism")]
        public bool Turism { get; set; }
        [Required]
        public bool Government { get; set; }
        [Required]
        public bool Accounting { get; set; }
        [Required]
        public bool Engineering { get; set; }
        [Required]
        public bool Insurance { get; set; }
        [Required]
        public bool Fun { get; set; }
        [Required]
        [Display(Name = "Administrative and similar services")]
        public bool Administrative { get; set; }
        [Required]
        public bool Others { get; set; }
    }
    public class EmpModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = ".pdf,.PDF", ErrorMessage = "Incorrect file format")]
        [Display(Name = "Select File")]
        public HttpPostedFileBase files { get; set; }

        public bool Empty
        {
            get
            {
                return (files == null);
            }
        }
    }
    public class ImageEmpModel
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase Imagefiles { get; set; }
    }
    public class ImageCompany
    {
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Select File")]
        public HttpPostedFileBase Companyfiles { get; set; }
    }
    public class UserEdit
    {
        [Key]
        public int EditId { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Address")]

        public string Address { get; set; }


        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [EnumDataType(typeof(TypesOfUsers))]
        public TypesOfUsers UserType { get; set; }


        public int FileId { get; set; }
        [Display(Name = "Uploaded File")]
        public String FileName { get; set; }
        public byte[] FileContent { get; set; }
        public String CompanyName { get; set; }
        public String CompanyAddress { get; set; }
        public String CompanyDescription { get; set; }

    }
    public class Contact
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "What would you like to tell us")]
        [DataType(DataType.MultilineText)]
        public string Tell { get; set; }
    }
    public class ArticlesMore{
        [Key]
        public int newsId { get; set; }
        public IList<Articles> artikli;
    }
    public class Articles
    {
        public Articles()
        {
            
        }

        public Articles(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["sources"];
            name = (string)jUser["name"];
            description = (string)jUser["description"];
            url = (string)jUser["url"];
            country = (string)jUser["country"];
        }
        
        [Key]
        public int newsfeedId { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string description { get; set; }
        [DataType(DataType.Url)]
        public string url { get; set; }
    }
    public class ImageEdit
    {
        [Key]
        public string editImageId { get; set; }
        public string Email { get; set; }
        public int ImageFileId { get; set; }
        [Display(Name = "Uploaded Image")]
        public String ImageFileName { get; set; }
        public byte[] ImageFileContent { get; set; }
        
    }
    
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class Followings
    {
        [Key]
        [Index("IdFollow", IsUnique = true)]
        public int Id { get; set; }   
        [MaxLength(128)]
        public string UserId { get; set; }

        [MaxLength(128)]
        public string FollowerId { get; set; }
    }

    public class JobApplications
    {
        [Key]
        [Index("IdJobApplications", IsUnique = true)]
        public int IdJob { get; set; }
        [MaxLength(128)]
        public string UserId { get; set; }
        
        public int ID { get; set; }
    }

}
