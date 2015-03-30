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
                HotdogID = 1,
                Name = "Cheese Filled Dog",
                LastPlaceAte = "Tony's",
                LastAte = new DateTime(),
                Rating = 5
            };
            hDogs.Add(dog1);
           
            Dog dog2 = new Dog()
            {
                HotdogID = 2,
                Name = "Chilli Cheese Dog",
                LastPlaceAte = "Ollie's Trollie",
                LastAte = new DateTime(),
                Rating = 4
            };
            hDogs.Add(dog2);

            Dog dog3 = new Dog()
            {
                HotdogID = 3,
                Name = "Sour Dog",
                LastPlaceAte = "Dog City",
                LastAte = new DateTime(),
                Rating = 2
            };
            hDogs.Add(dog3);
        }

        public List<Dog> listAll(){
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