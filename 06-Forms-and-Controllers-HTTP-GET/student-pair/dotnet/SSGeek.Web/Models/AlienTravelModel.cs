using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class AlienTravelModel
    {
        [Display(Name = "Choose a planet: ")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth age: ")]
        public double TravelerAge { get; set; }

        [Display(Name = "Choose a mode of transport: ")]
        public string TransportMode {get; set;}

        public static List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };

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

        public double GetTravelTime()
        {

            Dictionary<string, double> convertSpeed = new Dictionary<string, double>()
            {
                { "walking", 3},
                { "car", 100 },
                { "bullet train", 200 },
                { "boeing 747", 570 },
                { "concorde", 1350 }

            };

            Dictionary<string, double> averageDistance = new Dictionary<string, double>()
            {
                { "Mercury", 56974146 },
                { "Venus", 25724767 },
                { "Mars", 48678219 },
                { "Jupiter", 390674710 },
                { "Saturn", 792248270 },
                { "Uranus", 1692662530 },
                { "Neptune", 2703959960 },

            };

            double HoursInAYear = 365 * 24;
            double totalTravelHours = averageDistance[Planet] / convertSpeed[TransportMode];
            double totalTravelYears = Math.Round(totalTravelHours / HoursInAYear, 2);
            
            return totalTravelYears;


        }

        public double ArrivalAge(double totalTravelYears)
        {
            double travelerArrivalAge = Math.Round(TravelerAge + totalTravelYears, 2);
            return travelerArrivalAge;

        }


    }
}
