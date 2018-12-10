using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPrep.Models;

namespace ExamPrep.ViewModels
{
    public class RestaurantEditModel
    {
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
