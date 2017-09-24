using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using codeApp.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace codeApp.Controllers
{
    public class JobOffersController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: JobOffers

        public async Task<ActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
           // ViewBag.DateSortParm = sortOrder == "Edukacija" ? "Proba" : "Edukacija";
            var students = from s in db.JobOffers.Include(j => j.ApplicationUser)
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Name.Contains(searchString)
                                       || (s.Health == true && ("Health").Equals(searchString)) || (s.IT == true && ("IT").Equals(searchString)));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    break;
                case "Edukacija":
                    students = students.OrderBy(s => s.Education).Where(s => s.Education == true);
                    break;
                case "Proba":
                    students = students.OrderByDescending(s => s.Health).Where(s => s.Health == true);
                    break;
                default:
                    students = students.OrderBy(s => s.Name);
                    break;
            }

            return View(await students.ToListAsync());
        }
        public async Task<ActionResult> JobApplications(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = await db.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = await db.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Create
        public ActionResult Create()
        {
            ViewBag.Userfk = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: JobOffers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Description,MailForApplication,NumberOfPositions,Location,EndDate,Hardware,Software,Education,IT,Architecture,Banking,Construction,MechanicalEngineering,RealEstate,Health,Marketing,Law,Turism,Government,Accounting,Engineering,Insurance,Fun,Administrative,Others")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                jobOffer.PublishingDate = DateTime.Now;
                jobOffer.Userfk = User.Identity.GetUserId();
                db.JobOffers.Add(jobOffer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobOffer);
        }

        // GET: JobOffers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = await db.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Userfk = new SelectList(db.Users, "Id", "Email", jobOffer.Userfk);
            return View(jobOffer);
        }

        // POST: JobOffers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Description,MailForApplication,NumberOfPositions,Location,PublishingDate,EndDate,Hardware,Software,Education,IT,Architecture,Banking,Construction,MechanicalEngineering,RealEstate,Health,Marketing,Law,Turism,Government,Accounting,Engineering,Insurance,Fun,Administrative,Others")] JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                jobOffer.Userfk = User.Identity.GetUserId();
                db.Entry(jobOffer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobOffer);
        }

        // GET: JobOffers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobOffer jobOffer = await db.JobOffers.FindAsync(id);
            if (jobOffer == null)
            {
                return HttpNotFound();
            }
            return View(jobOffer);
        }

        // POST: JobOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JobOffer jobOffer = await db.JobOffers.FindAsync(id);
            db.JobOffers.Remove(jobOffer);
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
        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

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
        public int CheckArticles(string UserFk)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@UserFK", UserFk);
            Parm.Add("@news", dbType: DbType.Int32, direction: ParameterDirection.Output);

            DbConnection();
            con.Open();
            con.Execute("CheckNews", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            int _count = Parm.Get<int>("@news");
            return _count;
        }
        public void DeleteOffer(int id)
        {
            JobOffer offer = db.JobOffers.Find(id);
            db.JobOffers.Remove(offer);
            db.SaveChanges();
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

        public void SaveJobApplications(int id)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@ID", id);
            Parm.Add("@UserId", User.Identity.GetUserId());
            DbConnection();
            con.Open();
            con.Execute("AddJobApplications", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
        public int CheckJobApplications(int id)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@UserId", User.Identity.GetUserId());
            Parm.Add("@ID", id);
            Parm.Add("@IsExists", dbType: DbType.Int32, direction: ParameterDirection.Output);

            DbConnection();
            con.Open();
            con.Execute("CheckJobApplications", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
            int _count = Parm.Get<int>("@IsExists");
            return _count;

        }
    }
}
