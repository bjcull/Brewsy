using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Brewsy.Data;
using Brewsy.Domain.Entities;

namespace Brewsy.Web.Controllers
{
    public class PurchasesController : Controller
    {
        private BrewsyContext _context;

        public PurchasesController(BrewsyContext context)
        {
            _context = context;    
        }

        // GET: Purchases
        public IActionResult Index()
        {
            return View(_context.Purchases.ToList());
        }

        // GET: Purchases/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchases.Single(m => m.Id == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }

            return View(purchase);
        }

        // GET: Purchases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Purchases/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Purchases.Add(purchase);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchases.Single(m => m.Id == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                _context.Update(purchase);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Purchase purchase = _context.Purchases.Single(m => m.Id == id);
            if (purchase == null)
            {
                return HttpNotFound();
            }

            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = _context.Purchases.Single(m => m.Id == id);
            _context.Purchases.Remove(purchase);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
