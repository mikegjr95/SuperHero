using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext db;
        public HeroController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Hero
        public ActionResult Index()
        {
            var allHeroes = db.Heroes;
            return View(allHeroes);
        }

        // GET: Hero/Details/5
        public ActionResult Details(int id)
        {
            Hero hero = db.Heroes.Where(h => h.Id == id).Select(h => h).FirstOrDefault();
            return View(hero);
        }

        // GET: Hero/Create
        public ActionResult Create()
        {
            Hero hero = new Hero();
            return View(hero);
        }

        // POST: Hero/Create
        [HttpPost]
        public ActionResult Create(Hero hero)
        {
            try
            {
                db.Heroes.Add(hero);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Edit/5
        public ActionResult Edit(int id)
        {
            Hero hero = db.Heroes.Where(h => h.Id == id).Select(h => h).FirstOrDefault();
            return View(hero);
        }

        // POST: Hero/Edit/5
        [HttpPost]
        public ActionResult Edit(Hero hero)
        {
            try
            {
                // TODO: Add update logic here
                var newHero = db.Heroes.Where(h => h.Id == hero.Id).Select(h => h).Single();
                newHero.firstName = hero.firstName;
                newHero.lastName = hero.lastName;
                newHero.primaryAbility = hero.primaryAbility;
                newHero.secondaryAbility = hero.secondaryAbility;
                newHero.alterEgo = hero.alterEgo;
                newHero.catchphrase = hero.catchphrase;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Hero/Delete/5
        public ActionResult Delete(int id)
        {
            Hero hero = db.Heroes.Where(h => h.Id == id).Select(h => h).FirstOrDefault();
            return View(hero);
        }

        // POST: Hero/Delete/5
        [HttpPost]
        public ActionResult Delete(Hero hero)
        {
            try
            {
                Hero NewHero = db.Heroes.Where(h => h.Id == hero.Id).Select(h => h).FirstOrDefault();
                db.Heroes.Remove(NewHero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
