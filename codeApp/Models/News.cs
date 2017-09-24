
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace codeApp.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [Display(Name = "What's new")]
        [DataType(DataType.MultilineText)]
        [MaxLength(200,ErrorMessage ="Max length of a status is 200 characters!")]
        public string Status { get; set; }

        [Display(Name = "Tell us more with a link")]
        [DataType(DataType.Url)]
        public string UrlNews { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Userfk { get; set; }
    }
}