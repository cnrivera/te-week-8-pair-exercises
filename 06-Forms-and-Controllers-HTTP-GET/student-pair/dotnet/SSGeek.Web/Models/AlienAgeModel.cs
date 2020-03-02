using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {

        [Display(Name = "Choose a planet: ")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth age: ")]
        public double EarthAge { get; set; }

        public double GetConvertedValue()
        {
            Dictionary<string, double> convertAge = new Dictionary<string, double>()
            {
                { "Mercury", 87.96 },
                { "Venus", 224.68 },
                { "Mars", 686.98 },
                { "Jupiter", 11.862 },
                { "Saturn", 29.456 },
                { "Uranus", 84.07 },
                { "Neptune", 164.81 },
               
            };

            double convertedValue = Math.Round(EarthAge / convertAge[Planet], 2);

            return convertedValue;


        }

        public static List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury" },
            new SelectListItem() { Text = "Venus" },
            new SelectListItem() { Text = "Mars" },
            new SelectListItem() { Text = "Jupiter" },
            new SelectListItem() { Text = "Saturn" },
            new SelectListItem() { Text = "Neptune" },
            new SelectListItem() { Text = "Uranus" }
        };
    }
}
