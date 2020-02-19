using ProjectX.Persistence;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectX.Configuration;
using ProjectX.Services;
using ProjectX.Services.ShardServices;

namespace ProjectX.Controllers
{
    public class TestMeController : Controller
    {
        private ShardDbContext db = new ShardDbContext();

        private readonly CategoryService _categoryService;
        private readonly IProjectXConfigurationManager _shardConfigurationManager;

        public TestMeController(ServiceFactory serviceFactory, IProjectXConfigurationManager configurationManager)
        {
            _categoryService = serviceFactory.GetCategoryService();
            _shardConfigurationManager = configurationManager;
        }

        // GET: TestMe
        public async Task<ActionResult> Index()
        {
            var sum = _categoryService.Sum(1, 2);
            var conString = _shardConfigurationManager.GetShardDbConnectionString();
            var masString = _shardConfigurationManager.GetMasterDbConnectionString();

            var result = await db.TestMes.ToListAsync();
            return View(result);
        }

        // GET: TestMe/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMe testMe = await db.TestMes.FindAsync(id);
            if (testMe == null)
            {
                return HttpNotFound();
            }
            return View(testMe);
        }

        // GET: TestMe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestMe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName")] TestMe testMe)
        {
            if (ModelState.IsValid)
            {
                db.TestMes.Add(testMe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testMe);
        }

        // GET: TestMe/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMe testMe = await db.TestMes.FindAsync(id);
            if (testMe == null)
            {
                return HttpNotFound();
            }
            return View(testMe);
        }

        // POST: TestMe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName")] TestMe testMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testMe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testMe);
        }

        // GET: TestMe/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestMe testMe = await db.TestMes.FindAsync(id);
            if (testMe == null)
            {
                return HttpNotFound();
            }
            return View(testMe);
        }

        // POST: TestMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestMe testMe = await db.TestMes.FindAsync(id);
            db.TestMes.Remove(testMe);
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
