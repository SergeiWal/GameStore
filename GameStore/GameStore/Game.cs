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
        public string Developer { get; set; }
        public string Image { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public SystemRequirements SystemRequirements { get; set; }

        public Game() { }

        public override bool Equals(object obj)
        {
            if (obj is Game)
            {
                Game game = (Game)obj;
                if (game.FullName == this.FullName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashCode = 1565895131;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            hashCode = hashCode * -1521134295 + EqualityComparer<SystemRequirements>.Default.GetHashCode(SystemRequirements);
            return hashCode;
        }
    }
}
