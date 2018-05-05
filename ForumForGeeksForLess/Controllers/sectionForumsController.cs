using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ForumForGeeksForLess.Models.DBModel;

namespace ForumForGeeksForLess.Controllers
{
    public class sectionForumsController : Controller
    {
        private ForumForGeeksForLessBD db = new ForumForGeeksForLessBD();

        // GET: sectionForums
        public async Task<ActionResult> Index()
        {
            return View(await db.sectionForum.ToListAsync());
        }

        // GET: sectionForums/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sectionForum sectionForum = await db.sectionForum.FindAsync(id);
            if (sectionForum == null)
            {
                return HttpNotFound();
            }
            return View(sectionForum);
        }

        // GET: sectionForums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sectionForums/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name")] sectionForum sectionForum)
        {
            if (ModelState.IsValid)
            {
                db.sectionForum.Add(sectionForum);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sectionForum);
        }

        // GET: sectionForums/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sectionForum sectionForum = await db.sectionForum.FindAsync(id);
            if (sectionForum == null)
            {
                return HttpNotFound();
            }
            return View(sectionForum);
        }

        // POST: sectionForums/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] sectionForum sectionForum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sectionForum).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sectionForum);
        }

        // GET: sectionForums/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sectionForum sectionForum = await db.sectionForum.FindAsync(id);
            if (sectionForum == null)
            {
                return HttpNotFound();
            }
            return View(sectionForum);
        }

        // POST: sectionForums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sectionForum sectionForum = await db.sectionForum.FindAsync(id);
            db.sectionForum.Remove(sectionForum);
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
