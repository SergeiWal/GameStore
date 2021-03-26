using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore
{
    [Serializable]
    class Game
    {
        public string FullName { get; set; }
        public string SmallName { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public SystemRequirements SystemRequirements { get; set; }

        public Game() { }
        public Game(string fullName, string smallName, Genre genre, double rating, decimal price, string description, SystemRequirements systemRequirements)
        {
            FullName = fullName;
            SmallName = smallName;
            Genre = genre;
            Rating = rating;
            Price = price;
            Description = description;
            SystemRequirements = systemRequirements;
        }

        
    }
}
