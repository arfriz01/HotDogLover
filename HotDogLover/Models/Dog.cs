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
        public int HotdogID { get; set; }
        public string Name { get; set; }
        public DateTime LastAte { get; set; }
        public int Rating { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Name")]

        [DisplayName("Last Ate")]
        [Required(ErrorMessage = "Last Ate is required")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        [Range(1, 5,
            ErrorMessage = "Rate it!")]
    }
}
