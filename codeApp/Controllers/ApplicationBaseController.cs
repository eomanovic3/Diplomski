using codeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codeApp.Controllers
{
    public class ApplicationBaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);
                   string FirstName = user.FirstName;
                    string LastName = user.LastName;
                    ViewData.Add("FirstNameTry", FirstName);
                    ViewData.Add("LastName", LastName);
                    string Address = user.Address;
                    string PhoneNumber = user.PhoneNumber;
                    string City = user.City;
                    ViewData.Add("Address", Address);
                    ViewData.Add("PhoneNumber", PhoneNumber);
                    ViewData.Add("City", City);
                    string type = user.UserType.ToString();
                    ViewData.Add("UserType", type);
                    string ide = user.Id.ToString();
                    ViewData.Add("Ide",ide);

                    var content = user.ImageFileContent;
                    ViewData.Add("Content", content);

                    var c1 = user.CompanyAddress;
                    ViewData.Add("CompanyAddress", c1);
                    var c2 = user.CompanyDescription;
                    ViewData.Add("CompanyDescription", c2);
                    var c3 = user.CompanyName;
                    ViewData.Add("CompanyName", c3);



                }
            }
            base.OnActionExecuted(filterContext);
        }
        public ApplicationBaseController()
        { }
    }
}