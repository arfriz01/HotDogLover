using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotDogLover.Models;

namespace HotDogLover.Services
{
    public class DogService
    {
        private static List<Dog> hotDogs;
        static DogService() {
            hDogs = new List<Dog>();
            Dog dog1 = new Dog()
            {
                HotDogID = 1,
                HotDogName = "Cheese Filled Dog",
                LastPlaceAte = "Tony's",
                LastTimeAte = new DateTime(),
                Rating = 5
            };
            hDogs.Add(dog1);
           
            Dog dog2 = new Dog()
            {
                HotDogID = 2,
                HotDogName = "Chilli Cheese Dog",
                LastPlaceAte = "Ollie's Trollie",
                LastTimeAte = new DateTime(),
                Rating = 4
            };
            hDogs.Add(dog2);

            Dog dog3 = new Dog()
            {
                HotDogID = 3,
                HotDogName = "Sour Dog",
                LastPlaceAte = "Dog City",
                LastTimeAte = new DateTime(),
                Rating = 2
            };
            hDogs.Add(dog3);
        }

        public List<HotDog> listAll(){
            return hDogs;
        }
        public Dog Get(int id) 
        {Dog selectedDog = new Dog();
            foreach (Dog h in hDogs) {
                if (hotdog.HotdogID == id) {
                    selectedDog = h;
                }
            }
            return selectedDog;
        }
        public void Add(Dog h) {
            hDogs.Add(h);
        }
        public void Remove(Dog h) {
            hDogs.Remove(h);
        }
    }
    }
}