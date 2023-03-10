using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetGestionHotel1.Models;

namespace ProjetGestionHotel1.Controllers
{
    public class reservationsController : Controller
    {
        private gestion_hotelEntities db = new gestion_hotelEntities();

        // GET: reservations
        public ActionResult Index()
        {
            var reservation = db.reservation.Include(r => r.chambre).Include(r => r.client);
            return View(reservation.ToList());
        }

        // GET: reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: reservations/Create
        public ActionResult Create()
        {
            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite");
            ViewBag.id_client = new SelectList(db.client, "id_client", "nom_client");
            return View();
        }

        // POST: reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reservation,id_chambre,id_client,debut_reservation,fin_reservation,statut,nbr_personne")] reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservation.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", reservation.id_chambre);
            ViewBag.id_client = new SelectList(db.client, "id_client", "nom_client", reservation.id_client);
            return View(reservation);
        }

        // GET: reservations/Edit/5
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            else
            {
                reservation.statut = "Accepted";
                db.SaveChanges();
                ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", reservation.id_chambre);
                ViewBag.id_client = new SelectList(db.client, "id_client", "nom_client", reservation.id_client);
                return RedirectToAction("Index","administrateurs");
            }
        }

       
        

        // GET: reservations/Delete/5
        public ActionResult Reject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservation reservation = db.reservation.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            else
            {
                reservation.statut = "Rejected";
                db.SaveChanges();
                ViewBag.id_chambre = new SelectList(db.chambre, "id_chambre", "disponibilite", reservation.id_chambre);
                ViewBag.id_client = new SelectList(db.client, "id_client", "nom_client", reservation.id_client);
                return RedirectToAction("Index", "administrateurs");

            }
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
