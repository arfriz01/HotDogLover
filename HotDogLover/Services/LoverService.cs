using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotDogLover.Models;

namespace HotDogLover.Services
{
    public class LoverService
    {
        private static List<Lover> profiles;
        private static DogService hotDogService;
        static LoverService()
        {
            reload();
        }

        public List<Lover> ListAll()
        {
            return profiles;
        }
        public Lover Get(int id)
        {
            Lover foundProfile = new Lover();
            foreach (Lover profile in profiles)
            {
                if (profile.LoverID == id)
                {
                    foundProfile = profile;
                }
            }
            return foundProfile;
        }
        public void Add(Lover profile)
        {
            if (profile == null)
            {
                return;
            }

            profiles.Add(profile);
        }

        public void AddDog(Lover profile, Dog dog)
        {
            Lover p = Get(profile.LoverID);
            p.DogList.Add(dog);

        }
        public void Remove(Lover profile)
        {
            if (profile == null)
            {
                return;
            }

            Lover profileToRemove = null;
            foreach (Lover p in profiles)
            {
                if (p.LoverID == profile.LoverID)
                {
                    profileToRemove = p;
                }
            }

            if (profileToRemove != null)
            {
                profiles.Remove(profileToRemove);
            }
        }
        public void Update(Lover profile)
        {
            Lover profileToUpdate = Get(profile.LoverID);

            profileToUpdate.Name = profile.Name;
            profileToUpdate.Image = profile.Image;
            profileToUpdate.Biography = profile.Biography;

            Remove(profile);
            Add(profileToUpdate);
        }
        public static void reload()
        {
            hotDogService = new DogService();
            profiles = new List<Lover>();

            List<Dog> myFavs = new List<Dog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(2));
            myFavs.Add(hotDogService.Get(3));

            Lover p1 = new Lover()
            {
                Name = "Oliver Paxton",
                Biography = "I own a hotdog joint. You should come try my dogs.",
                Image = "http://images.search.yahoo.com/images/view;_ylt=AwrB8o9IMRNVHXEAPsmJzbkF;_ylu=X3oDMTIyYTgxYTN2BHNlYwNzcgRzbGsDaW1nBG9pZANmZjA5MzJkNmQ1MmMzMDgwOGQxNTZkMzFjMjY5NDllYQRncG9zAzIEaXQDYmluZw--?.origin=&back=http%3A%2F%2Fimages.search.yahoo.com%2Fyhs%2Fsearch%3Fp%3Darrrow%2Boliver%26n%3D60%26ei%3DUTF-8%26y%3DSearch%26type%3Ddsites0301%26fr%3Dyhs-iry-fullyhosted_003%26fr2%3Dsb-top-images.search.yahoo.com%26hsimp%3Dyhs-fullyhosted_003%26hspart%3Diry%26tab%3Dorganic%26ri%3D2&w=720&h=960&imgurl=3.bp.blogspot.com%2F-hpt3IZA4rn8%2FUHaP5Dc3sKI%2FAAAAAAAAHwg%2FmeEKlJL07yM%2Fs1600%2FOliver-Queen-Promo-Pictures-arrow-cw-31448834-720-960.jpg&rurl=http%3A%2F%2Fmindy-tv.blogspot.com%2F2012%2F10%2Farrow-desert-island-face-off.html&size=68.7KB&name=%3Cb%3EARROW%3C%2Fb%3E%3A+A+Desert-Island+Face-Off&p=arrow+oliver&oid=ff0932d6d52c30808d156d31c26949ea&fr2=sb-top-images.search.yahoo.com&fr=yhs-iry-fullyhosted_003&rw=arrow+oliver&tt=%3Cb%3EARROW%3C%2Fb%3E%3A+A+Desert-Island+Face-Off&b=0&ni=96&no=2&ts=&tab=organic&sigr=126u3d9i9&sigb=16kijpnc4&sigi=1428d734l&sigt=1161f00t3&sign=1161f00t3&.crumb=7JVRFEpNd4B&fr=yhs-iry-fullyhosted_003&fr2=sb-top-images.search.yahoo.com&hsimp=yhs-fullyhosted_003&hspart=iry&type=dsites0301",
                LoverID = 1,
                FavoriteHotDog = hotDogService.Get(1),
                DogList = myFavs
            };
            profiles.Add(p1);

            myFavs = new List<Dog>();
            myFavs.Add(hotDogService.Get(1));
            myFavs.Add(hotDogService.Get(2));


        }

    }
}