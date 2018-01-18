using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using VideoLibrary.BusinessEntities;
using VideoLibrary.BusinessEntities.Models.Model;

namespace VideoLibrary.Controllers
{
    public class ActorsController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Actors
        public async Task<ActionResult> Index()
        {
            return View(await db.Actors.ToListAsync());
        }

        // GET: Actors/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateOfBirth,Gender,Genre")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        // GET: Actors/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateOfBirth,Gender,Genre,IsActive,DateAdded,AddedBy")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        // GET: Actors/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = await db.Actors.FindAsync(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Actor actor = await db.Actors.FindAsync(id);
            db.Actors.Remove(actor);
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
