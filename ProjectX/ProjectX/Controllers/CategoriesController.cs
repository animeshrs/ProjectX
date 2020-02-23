using AutoMapper;
using ProjectX.Models.ViewModels.Categories;
using ProjectX.Persistence;
using ProjectX.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectX.Caching;
using ProjectX.Caching.Contracts;
using ProjectX.Enums.Cache;

namespace ProjectX.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ShardDbContext _context;
        private readonly IMapper _iMapper;
        private readonly IRedisCacheProvider _iCacheProvider;

        public CategoriesController(ServiceFactory serviceFactory, IMapper iMapper, IRedisCacheProvider iCacheProvider)
        {
            _context = serviceFactory.Context;
            _iMapper = iMapper;
            _iCacheProvider = iCacheProvider;
        }

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryViewModels = _iMapper.Map<List<CategoryViewModel>>(categories).ToList();

            var numDaysInWeek = _iCacheProvider.Get<int>(CacheKeys.NumDaysInWeek);
            if (numDaysInWeek <= 0)
            {
                _iCacheProvider.Set(CacheKeys.NumDaysInWeek, 7, EnumCaching.ShortTimeOut);
            }

            return View(categoryViewModels);
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryVmFromCache = _iCacheProvider.Get<CategoryViewModel>(CacheKeys.CategoryName(id.Value));
            if (categoryVmFromCache != null) 
                return View(category);

            var categoryViewModel = _iMapper.Map<CategoryViewModel>(category);
            _iCacheProvider.Set(CacheKeys.CategoryName(id.Value), categoryViewModel, EnumCaching.ShortTimeOut);

            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
