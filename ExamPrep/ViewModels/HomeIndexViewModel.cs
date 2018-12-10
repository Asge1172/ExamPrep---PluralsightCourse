using System;
using System.Collections.Generic;
using ExamPrep.Models;

namespace ExamPrep.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
