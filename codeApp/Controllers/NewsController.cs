using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using codeApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace codeApp.Controllers
{
    public class NewsController : ApplicationBaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: News
        public async Task<ActionResult> Index()
        {
            var news = db.News.Include(n => n.ApplicationUser);
            return View(await news.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }
        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.Userfk = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NewsId,Status,urlNews")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Userfk = User.Identity.GetUserId();
                db.News.Add(news);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(news);
        }
        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            con = new SqlConnection(constr);

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
        // GET: News/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.Userfk = new SelectList(db.Users, "Id", "FirstName", news.Userfk);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NewsId,Status,urlNews")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Userfk = User.Identity.GetUserId();
                db.Entry(news).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            News news = await db.News.FindAsync(id);
            db.News.Remove(news);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        public  void DeleteNews(int id)
        {
            News news =  db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();            
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public static HttpClient client = new HttpClient();


        public async Task<ActionResult>GetJson1()
        {
            HttpClient client = new HttpClient();
            string responseString = null;
            await Task.Run(async () =>
             {
                 HttpResponseMessage response = await client.GetAsync("https://newsapi.org/v1/sources?category=business");
                 responseString = await response.Content.ReadAsStringAsync();
             });
            var res = JObject.Parse(responseString);
            List<Articles> artikli =new List<Articles>();

            for (int i=0; i< (int)res["sources"].Count();i++)
            {
                var proba = new Articles();
                proba.name = (string)res["sources"][i]["name"];
                proba.url = (string)res["sources"][i]["url"];
                proba.description = (string)res["sources"][i]["description"];
                proba.country = (string)res["sources"][i]["country"];
                artikli.Add(proba);
            }
            return View(artikli);
        }

    }
}
