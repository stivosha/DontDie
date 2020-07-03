using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Die.Models.Levels
{
    class LevelManager
    {
        public int Size { get; set; }
        
        public LevelManager(int size)
        {
            Size = size;
        }

        public ILevel GetLevelByNumber(int number)
        {
            switch (number)
            {
                case 1:
                    return new Level1(Size);
            }
            return new Level1(Size);
        }
    }
}
