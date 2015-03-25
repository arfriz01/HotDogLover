using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Models
{
    public class Lover
    {
        public int LoverID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Biography { get; set; }
        public string Image { get; set; }
        public Dog FavoriteDog { get; set; }
        public List<Dog> DogList { get; set; }
    }
}