using HotDogLover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Services
{
    public class ProfileService
    {
        private static List<Profile> profiles;
        private static HotDogService hotDogService;
        static ProfileService() {
            reload();
        }

       
        public List<Profile> ListAll() {
            return profiles;
        }
        public Profile Get(int id) {
            Profile foundProfile = new Profile();
            foreach (Profile profile in profiles) {
                if (profile.ProfileID == id) {
                    foundProfile = profile;
                }
            }
            return foundProfile;
        }
        public void Add(Profile profile) {
            if (profile == null)
            {
                return;
            }

            profiles.Add(profile);
        }

        public void AddDog(Profile profile, HotDog dog) {
            Profile p = Get(profile.ProfileID);
            p.HotDogList.Add(dog);
            
        }
        public void Remove(Profile profile)
        {
         
            if (profile == null)
            {
                return;
            }

            Profile profileToRemove = null;
            foreach (Profile p in profiles) {
                if (p.ProfileID == profile.ProfileID) {
                    profileToRemove = p;
                }
            }
            
            if (profileToRemove != null) {
                profiles.Remove(profileToRemove);
            }
        }
        public void Update(Profile profile) {
            Profile profileToUpdate = Get(profile.ProfileID);
          
            profileToUpdate.Name = profile.Name;
            profileToUpdate.Picture = profile.Picture;
            profileToUpdate.Bio = profile.Bio;

            Remove(profile);
            Add(profileToUpdate);
        }
        public static void reload()
        {
            hotDogService = new HotDogService();
            profiles = new List<Profile>();

            List<HotDog> myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(2));
            myFavs.Add(hotDogService.Get(3));

            Profile p1 = new Profile()
            {
                Name = "Oliver Queen",
                Bio = "My name is Oliver Queen. For five years I was stranded on an island with only one goal - survive so that I could find the best Hotdog out there... When I returned to the city, I immediately began working on opening a HotDog Joint. I called it Ollie's Trollie. I experimented with all kinds of dogs and invite suggestions from my loyal customers, but I'm just not sure I have found the best dog. I would have to say the Cheese Filled Dog is the closest to perfection I have found thus far.",
                Picture = "http://img3.wikia.nocookie.net/__cb20121109062657/arrow-france/fr/images/8/8f/Arrow_LesPersonnages_OliverQueen.jpg",
                ProfileID = 1,
                FavoriteHotDog = hotDogService.Get(2),
                HotDogList = myFavs
            };
            profiles.Add(p1);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(3));

            Profile p2 = new Profile()
            {
                Name = "F. Smoak",
                Bio = "Hi, you can call me Fe! I am a totally nerd, but I do appreciate a good dog whenever I can get myself out of the lair. I don't like to leave often so I haven't been able to try many hotdogs yet. So far, I'd say my favorite is the Chilli Cheese Dog!",
                Picture = "https://c2.staticflickr.com/8/7371/13039510383_f865f217f3_b.jpg",
                ProfileID = 2,
                FavoriteHotDog = hotDogService.Get(1),
                HotDogList = myFavs
            };
            profiles.Add(p2);

            myFavs = new List<HotDog>();
            myFavs.Add(hotDogService.Get(2));

            Profile p3 = new Profile()
            {
                Name = "Canary",
                Bio = "I'm just in it for the dogs",
                Picture = "http://img2.wikia.nocookie.net/__cb20131031025638/marvel_dc/images/5/55/Sara_Lance_(Arrow)_002.jpg",
                ProfileID = 3,
                FavoriteHotDog = hotDogService.Get(3),
                HotDogList = myFavs
            };
            profiles.Add(p3);
        }
    }
}