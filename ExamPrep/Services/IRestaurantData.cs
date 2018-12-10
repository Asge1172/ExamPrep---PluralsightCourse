using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPrep.Models;

namespace ExamPrep.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
    }
}
