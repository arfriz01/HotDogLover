using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotDogLover.Models
{
    public class Dog
    {
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]
        public int HotdogID { get; set; }

         [DisplayName("Last Ate")]
        [Required(ErrorMessage = "Last Ate is required")]
        public string Name { get; set; }

         [DataType(DataType.Date)]
         [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastAte { get; set; }

        [Range(1, 5,
            ErrorMessage = "Rate it!")]
        public int Rating { get; set; }
        

        
    }
}
