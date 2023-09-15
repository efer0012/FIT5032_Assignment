using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XrayProWebApp.Models;

namespace XrayProWebApp.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Room);
            return View(bookings.ToList());
        }

        // GET: CustomerBookings
        [Authorize]
        public ActionResult CustomerBookings()
        {
            string currentUserId = User.Identity.GetUserId();  // Get the logged-in user's ID
            var bookings = db.Bookings.Where(b => b.CustomerId == currentUserId)  // Filter by user ID
                                      .Include(b => b.Room);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/CustomerViewBooking/5
        public ActionResult CustomerViewBooking(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }



        // GET: Bookings/Create
        [Authorize]
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();
            ViewBag.UserId = currentUserId;
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,CustomerId,Created,Date,Time,XrayType,XrayDescription,ReferralDoctorName,ReferralDoctorPhone")] Booking booking)
        {
            foreach (var modelStateVal in ModelState.Values)
            {
                foreach (var error in modelStateVal.Errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
            }


            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("CustomerBookings");
            }

            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", booking.RoomId);
            return View(booking);
        }

/*        // GET: Bookings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", booking.RoomId);
            return View(booking);
        }*/

        /*// POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,RoomId,Created,Date,Time,XrayType,XrayDescription,ReferralDoctorName,ReferralDoctorPhone,BookingStatus,XrayOutcomeDesc,NurseId,CustomerRatings,CustomerFeedback")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", booking.RoomId);
            return View(booking);
        }*/

        // GET: Bookings/CustomerEditBooking/5
        [Authorize]
        public ActionResult CustomerEditBooking(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", booking.RoomId);
            return View(booking);
        }

        // POST: Bookings/CustomerEditBooking/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult CustomerEditBooking([Bind(Include = "Id,CustomerId,Created,Date,Time,XrayType,XrayDescription,ReferralDoctorName,ReferralDoctorPhone")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerViewBooking", new { id = booking.Id });
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "Number", booking.RoomId);
            return View(booking);
        }

        /*        // GET: Bookings/Delete/5
                public ActionResult Delete(string id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Booking booking = db.Bookings.Find(id);
                    if (booking == null)
                    {
                        return HttpNotFound();
                    }
                    return View(booking);
                }

                // POST: Bookings/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public ActionResult DeleteConfirmed(string id)
                {
                    Booking booking = db.Bookings.Find(id);
                    db.Bookings.Remove(booking);
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
                }*/

        // GET: Bookings/CustomerDeleteBooking/5
        [Authorize]
        public ActionResult CustomerDeleteBooking(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/CustomerDeleteBooking/5
        [HttpPost, ActionName("CustomerDeleteBooking")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(string id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("CustomerBookings");
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
