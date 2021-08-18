using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TechTest1.DAL;
using TechTest1.Models;

namespace TechTest1.Controllers
{
    public class PileController : Controller
    {
        private PilesContext db = new PilesContext();

        // GET: Pile
        public ActionResult Index(string pileNumber, string commodityCode, string locationName, string warehouseName, string sortOrder)
        {
            IQueryable<Pile> piles = from p in db.Piles select p;
            ViewBag.CodeSort = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
           
            if (!string.IsNullOrWhiteSpace(pileNumber)|| !string.IsNullOrWhiteSpace(commodityCode) || !string.IsNullOrWhiteSpace(locationName) || !string.IsNullOrWhiteSpace(warehouseName))
            {
                if(!string.IsNullOrWhiteSpace(pileNumber)) { piles = from p in piles where p.PileNumber == pileNumber select p; }
                if(!string.IsNullOrWhiteSpace(commodityCode))
                {
                    var commodities = from c in db.Commodities where c.CommodityCode == commodityCode select c;

                    piles = from p in piles where p.CommodityID == commodities.FirstOrDefault().CommodityID select p;
                }
                if(!string.IsNullOrWhiteSpace(locationName))
                {
                    var location = from l in db.Locations where l.LocationName == locationName select l;
                    var warehouses = from w in db.Warehouses where w.LocationID == location.FirstOrDefault().LocationID select w; //As commodities in the DB doesn't have a location id, we must first check which warehouses are in that location
                    var warehousesList = warehouses.ToList();
                    var pilesList = new List<Pile>();
                    //ideally this sort of setup would be used across all, as there was no specification that said names/codes couldn't be duplicated e.g. there's towns in America with identical names to their UK counterparts, and as you mentioned having multiple locations in Chicago and the UK it's a possibility
                    foreach (Warehouse w in warehousesList) 
                    {
                        var tempPiles = from p in piles where p.WarehouseID == w.WarehouseID select p;
                        foreach (Pile pile in tempPiles.ToList())
                        {
                            pilesList.Add(pile);
                        }
                    }
                    piles = pilesList.AsQueryable();
                        
                }
                if(!string.IsNullOrWhiteSpace(warehouseName))
                {
                    var warehouse = from w in db.Warehouses where w.WarehouseName == warehouseName select w;
                    piles = from p in piles where p.WarehouseID == warehouse.FirstOrDefault().WarehouseID select p;
                }
                
            }
            switch (sortOrder)
            {
                case "code_desc":
                    piles = piles.OrderByDescending(p => p.CommodityID);
                    break;
                default:
                    piles = piles.OrderBy(p => p.CommodityID);
                    break;
            }
            return View(piles);
        }

        // GET: Pile/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Piles.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            return View(pile);
        }

        // GET: Pile/Create
        public ActionResult Create()
        {
            ViewBag.CommodityID = new SelectList(db.Commodities, "CommodityID", "CommodityCode");
            return View();
        }

        // POST: Pile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PileID,PileNumber,CommodityID,GrossWeight,SingleWeight,WarehouseID")] Pile pile)
        {
            if (ModelState.IsValid)
            {
                db.Piles.Add(pile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommodityID = new SelectList(db.Commodities, "CommodityID", "CommodityCode", pile.CommodityID);
            return View(pile);
        }

        // GET: Pile/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Piles.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommodityID = new SelectList(db.Commodities, "CommodityID", "CommodityCode", pile.CommodityID);
            return View(pile);
        }

        // POST: Pile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PileID,PileNumber,CommodityID,GrossWeight,SingleWeight,WarehouseID")] Pile pile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommodityID = new SelectList(db.Commodities, "CommodityID", "CommodityCode", pile.CommodityID);
            return View(pile);
        }

        // GET: Pile/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pile pile = db.Piles.Find(id);
            if (pile == null)
            {
                return HttpNotFound();
            }
            return View(pile);
        }

        // POST: Pile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pile pile = db.Piles.Find(id);
            db.Piles.Remove(pile);
            db.SaveChanges();
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
