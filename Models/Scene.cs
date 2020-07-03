using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Models.Animals;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Levels;

namespace Don_t_Die.Models
{
    public class Scene
    {
        public Player Player { get; set; }
        public List<IAnimals> Animals { get; set; }
        public World World { get; set; }
        
        public Scene(ILevel level)
        {
            //Level = level;
            World = new World("new world", 20);
            Player = new Player(0, 0, 1);
            Animals = new List<IAnimals>
            {
                new Cow(20, 20),
                new Cow(40, 20),
                new Cow(20, 40),
                new Cow(50, 30),
                new Cow(-20, -20)
            };
        }
    }
}
