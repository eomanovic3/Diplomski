using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using codeApp.Models;
using Microsoft.AspNet.Identity.Owin;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace codeApp.Controllers
{
    public class JobApplicationsController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: JobApplications

        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

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
        public FileResult DownLoadFile(int id, string idUser)
        {

            var UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userDownload = UserManager.FindById(idUser);
            List<UserEdit> ObjFiles = GetFileList();
            return File(userDownload.FileContent, "application/pdf", userDownload.FileName);
        }



        public async Task<ActionResult> Index(int id)
        {  
           
            return View(await db.Applications.Where(x => x.ID == id).ToListAsync());
        }
        // GET: JobApplications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplications jobApplications = await db.Applications.FindAsync(id);
            if (jobApplications == null)
            {
                return HttpNotFound();
            }
            return View(jobApplications);
        }

        // GET: JobApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdJob,UserId,ID")] JobApplications jobApplications)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(jobApplications);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobApplications);
        }

        // GET: JobApplications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplications jobApplications = await db.Applications.FindAsync(id);
            if (jobApplications == null)
            {
                return HttpNotFound();
            }
            return View(jobApplications);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdJob,UserId,ID")] JobApplications jobApplications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobApplications).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobApplications);
        }

        // GET: JobApplications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApplications jobApplications = await db.Applications.FindAsync(id);
            if (jobApplications == null)
            {
                return HttpNotFound();
            }
            return View(jobApplications);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JobApplications jobApplications = await db.Applications.FindAsync(id);
            db.Applications.Remove(jobApplications);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
