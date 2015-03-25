using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotDogLover.Models
{
    public class Dog
    {
        public int HotdogID { get; set; }
        public string Name { get; set; }
        public DateTime LastAte { get; set; }
        public int Rating { get; set; }

    }
}