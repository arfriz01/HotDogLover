using HotDogLover.Models;
using HotDogLover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotDogLover.Controllers
{
    public class ProfileController : Controller
    {
        ProfileService profileService = new ProfileService();

       
        public ActionResult Index()
        {
            return View(profileService.ListAll());
        }

        
        public ActionResult Details(int id)
        {
            HotDogLover.Models.Profile profile = profileService.Get(id);
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
      
        public ActionResult Edit([Bind(Include="ProfileID, Name,Bio,Picture")]Profile profile)
        {
            if (!ModelState.IsValid) {
                return RedirectToAction("Edit", new {id=profile.ProfileID }); 
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
        
        public ActionResult AddDog(int profileID, [Bind(Include = "HotDogName,LastTimeAte,LastPlaceAte,Rating")]HotDog dog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Please check your form and resubmit";
                return RedirectToAction("CreateDog");
            }
            try
            {
                profileService.AddDog(new Profile() { ProfileID = profileID }, dog);
                return RedirectToAction("Details", new { id = profileID });
            }
            catch
            {
                return View();
            }
        }

     
    }
}
