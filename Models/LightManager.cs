using System;
using System.Collections.Generic;
using System.Linq;
using Don_t_Die.Models.Items;

namespace Don_t_Die.Models
{
    static class LightManager
    {
        #region
        
        #endregion
        public static void CalcLights(int[,] grid, int x, int y, int levelLight)
        {
            for (var i = 0; i < Config.Result.Count; i++)
            {
                foreach (var e in Config.Result[i])
                {
                    var value = 8 - i;
                    if(grid[x + e.Item1, y + e.Item2] >= value)
                        grid[x + e.Item1, y + e.Item2] = value;
                }
            }
        }
    }
}
