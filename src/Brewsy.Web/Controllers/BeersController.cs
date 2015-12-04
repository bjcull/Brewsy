using System.Linq;
using System.Security.Claims;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Brewsy.Data;
using Brewsy.Domain.Entities;
using Brewsy.Web.ViewModels.Sell;
using Microsoft.AspNet.Authorization;

namespace Brewsy.Web.Controllers
{
    [Authorize]
    public class BeersController : Controller
    {
        private BrewsyContext _context;

        public BeersController(BrewsyContext context)
        {
            _context = context;    
        }

        // GET: Beers
        public IActionResult Index()
        {
            var model = new SellIndexVm();
            var user = _context.Users.FirstOrDefault(x => x.Id == User.GetUserId());

            if (!string.IsNullOrEmpty(user.StripeUserId))
            {
                model.HasStripeAccount = true;
                model.Beers = _context.Beers.Include(x => x.User).Where(x => x.UserId == User.GetUserId()).ToList();
            }

            return View(model);
        }

        // GET: Beers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Beer beer = _context.Beers.Single(m => m.Id == id);
            if (beer == null)
            {
                return HttpNotFound();
            }

            return View(beer);
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Beer beer)
        {
            beer.UserId = User.GetUserId();

            if (ModelState.IsValid)
            {
                _context.Beers.Add(beer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beer);
        }

        // GET: Beers/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Beer beer = _context.Beers.Single(m => m.Id == id);
            if (beer == null)
            {
                return HttpNotFound();
            }

            return View(beer);
        }

        // POST: Beers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Update(beer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beer);
        }

        // GET: Beers/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Beer beer = _context.Beers.Single(m => m.Id == id);
            if (beer == null)
            {
                return HttpNotFound();
            }

            return View(beer);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Beer beer = _context.Beers.Single(m => m.Id == id);
            _context.Beers.Remove(beer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
