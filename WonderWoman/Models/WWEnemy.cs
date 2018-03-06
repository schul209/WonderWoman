using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WonderWoman.Models
{
    public class WWEnemy
    {
            [Required(ErrorMessage = "A unique ID must be entered.")]
            public int Id { get; set; }

            [Required]
            [Display(Name = "Enemy Name")]
            public string Name { get; set; }
            public string Comic { get; set; }
            public int Number { get; set; }
            public string Year { get; set; }


        
    }
}