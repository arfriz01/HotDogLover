using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotDogLover.Models;
using HotDogLover.Services;

namespace HotDogLover.Controllers
{
    public class ProfileController : Controller
    {
    
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Details(int id)
        {
            HotDogLover.Models.Lover profile = profileService.Get(id);
            return View(profile);
        }

        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
      
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(profileService.Get(id));
        }

        [HttpPost]
      
        public ActionResult Edit([Bind(Include = "LoverID, Name, Biography,Image")]Lover profile)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = profile.LoverID });
            }
            try
            {
                profileService.Update(profile);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
        public ActionResult CreateDog(int id)
        {
            ViewBag.profileID = id;
            return View();
        }

      
        [HttpPost]
       
        public ActionResult AddDog(int profileID, [Bind(Include = "Name,LastAte,LastPlaceAte,Rating")]Dog dog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Please check your form and resubmit";
                return RedirectToAction("CreateDog");
            }
            try
            {
                profileService.AddDog(new Lover() { LoverID = profileID }, dog);
                return RedirectToAction("Details", new { id = profileID });
            }
            catch
            {
                return View();
            }
        }
    }
}