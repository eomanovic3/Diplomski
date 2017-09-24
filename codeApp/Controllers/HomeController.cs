using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data;
using Microsoft.AspNet.Identity;

using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Net.Mime;
using codeApp.Models;
using System.Data.Entity;

namespace codeApp.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your applicedation description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult FileUpload()
        {
            return View();
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<ActionResult> DetailsOfUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var UserManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user1 = UserManager.FindByIdAsync(id);
            if (user1 == null)
            {
                return HttpNotFound();
            }
            return View(await user1);
        }

        

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase files)
        {
            if (User.Identity.IsAuthenticated)
            {
                String FileExt = Path.GetExtension(files.FileName).ToUpper();

                if (FileExt == ".PDF" || FileExt == ".pdf")
                {
                    Stream str = files.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    UserEdit Fd = new Models.UserEdit();
                    Fd.FileName = files.FileName;
                    Fd.FileContent = FileDet;
                    SaveFileDetails(Fd);
                    return RedirectToAction("FileUpload", "Home");
                }
                else
                {

                    ViewBag.FileStatus = "Invalid file format.";
                    return RedirectToAction("FileUpload", "Home");

                }
            }
            else return RedirectToAction("FileUpload", "Home");
        }
        [HttpGet]
        public ActionResult DeleteFile(int Id)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@Id", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            con.Execute("DeleteFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            return RedirectToAction("FileUpload", "Home");
        }

        [HttpGet]
        public FileResult DownLoadFile(int id)
        {

            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userDownload = UserManager.FindById(User.Identity.GetUserId());


            List<UserEdit> ObjFiles = GetFileList();

            /*var FileById = (from FC in ObjFiles
                            where FC.FileId.Equals(id)
                            select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
*/
            return File(userDownload.FileContent, "application/pdf", userDownload.FileName);
        }

      

        private List<UserEdit> GetFileList()
        {
            List<UserEdit> DetList = new List<UserEdit>();
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@Id", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<UserEdit>(con, "GetFileDetails", commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
        }
      
        [HttpGet]
        public PartialViewResult FileDetails()
        {
            List<UserEdit> DetList = GetFileList();

            return PartialView("FileDetails", DetList);
        }
        #region Database related operations  
        private void SaveFileDetails(UserEdit objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@Id", User.Identity.GetUserId());
            Parm.Add("@FileContent", objDet.FileContent);
            DbConnection();
            con.Open();
            con.Execute("AddFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }

        public ActionResult ImageFileUpload()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ImageFileUpload(HttpPostedFileBase Imagefiles)
        {
            if (User.Identity.IsAuthenticated)
            {
                String FileExt = Path.GetExtension(Imagefiles.FileName).ToUpper();

                if (FileExt == ".JPG" ||FileExt==".PNG")
                {
                    Stream str = Imagefiles.InputStream;
                    BinaryReader Br = new BinaryReader(str);
                    Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

                    ImageEdit Fd = new Models.ImageEdit();
                    Fd.ImageFileName = Imagefiles.FileName;
                    Fd.ImageFileContent = FileDet;
                    SaveImageFileDetails(Fd);
                    return RedirectToAction("ImageFileUpload", "Home");
                }
                else
                {

                    ViewBag.FileStatus = "Invalid file format.";
                    return RedirectToAction("ImageFileUpload", "Home");

                }
            }
            else return RedirectToAction("ImageFileUpload", "Home");
        }
        [HttpGet]
        public ActionResult ImageDeleteFile(int Id)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@Id", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            con.Execute("DeleteImageFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            return RedirectToAction("ImageFileUpload", "Home");
        }


        private List<ImageEdit> GetImageFileList()
        {
            List<ImageEdit> DetList = new List<ImageEdit>();
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@Id", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<ImageEdit>(con, "GetImageFileDetails", commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
        }
        [HttpGet]
        public PartialViewResult ImageFileDetails()
        {
            List<ImageEdit> DetList = GetImageFileList();

            return PartialView("ImageFileDetails", DetList);


        }
        private void SaveImageFileDetails(ImageEdit objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@ImageFileName", objDet.ImageFileName);
            Parm.Add("@Id", User.Identity.GetUserId());
            Parm.Add("@ImageFileContent", objDet.ImageFileContent);
            DbConnection();
            con.Open();
            con.Execute("AddImageFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }





        private void SaveUsersDetails(UserEdit objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FirstName", objDet.FirstName);
            Parm.Add("@LastName", objDet.LastName);
            Parm.Add("@PhoneNumber", objDet.PhoneNumber);
            Parm.Add("@Address", objDet.Address);
            Parm.Add("@City", objDet.City);
            Parm.Add("@CompanyName", objDet.CompanyName);
            Parm.Add("@CompanyDescription", objDet.CompanyDescription);
            Parm.Add("@CompanyAddress", objDet.CompanyAddress);
            Parm.Add("@Id", User.Identity.GetUserId());
            //   Parm.Add("@Categories",objDet.CategoriesOfJobs.CategorieId);
            DbConnection();
            con.Open();
            con.Execute("UpdateUsersDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
    
        public int CheckUserFollowings(string id)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@UserId", User.Identity.GetUserId());
            Parm.Add("@FollowerId", id);
            Parm.Add("@IsExists", dbType: DbType.Int32, direction: ParameterDirection.Output);
 
            DbConnection();
            con.Open();
            con.Execute("CheckUserFollowings", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            int _count = Parm.Get<int>("@IsExists");
            return _count;

        }
        public int CheckOffers(string UserFk)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@UserFK", UserFk);
            Parm.Add("@offers", dbType: DbType.Int32, direction: ParameterDirection.Output);

            DbConnection();
            con.Open();
            con.Execute("CheckOffers", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            int _count = Parm.Get<int>("@offers");
            return _count;
        }
        public void SaveFollowingsDetails(string id)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FollowerId", id);
            Parm.Add("@UserId", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            con.Execute("AddFollowingsDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
        public void DeleteUserFollowings(string id)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FollowerId", id);
            Parm.Add("@UserId", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            con.Execute("DeleteUserFollowings", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

        }
        private ApplicationDbContext context = new ApplicationDbContext();
        // To view the List of User 
        [Authorize]
        public ActionResult ListUser()
        {
            List<UserEdit> DetList = GetFileList();

            return View(context.Users.ToList());
        }
        public ActionResult ListOfUsers()
        {
            return View(context.Users.ToList());
        }
        public ActionResult Companies()
        {
            return View(context.Users.ToList());
        }
        [Authorize]
        public ActionResult EditUser()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditUser(UserEdit model)
        {            
            UserEdit Fd = new Models.UserEdit();
            Fd.FirstName = model.FirstName;
            Fd.LastName = model.LastName;
            Fd.PhoneNumber = model.PhoneNumber;
            Fd.Address = model.Address;
            Fd.City = model.City;
            Fd.CompanyAddress = model.CompanyAddress;
            Fd.CompanyDescription = model.CompanyDescription;
            Fd.CompanyName = model.CompanyName;
            SaveUsersDetails(Fd);
            return RedirectToAction("ListUser");
        }
       
    }
    #endregion
}
