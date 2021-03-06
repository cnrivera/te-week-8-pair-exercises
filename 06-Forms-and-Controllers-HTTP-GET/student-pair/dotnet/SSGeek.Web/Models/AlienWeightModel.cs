﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        [Display(Name = "Choose a planet: ")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth weight: ")]
        public double NumberToConvert { get; set; }

        public double GetConvertedValue()
        {
            Dictionary<string, double> convertWeights = new Dictionary<string, double>()
            {
                { "Mercury", 0.37},
                { "Venus", 0.90},
                { "Mars", 0.38 },
                { "Jupiter", 2.65 },
                { "Saturn", 1.13 },
                { "Uranus", 1.09 },
                { "Neptune", 1.43 },
               
            };

            double convertedValue = NumberToConvert * convertWeights[Planet];

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