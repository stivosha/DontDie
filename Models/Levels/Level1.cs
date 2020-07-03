using Don_t_Die.Models.Blocks;

namespace Don_t_Die.Models.Levels
{
    class Level1 : ILevel
    {
        public Block[,,] Grid { get; set; }
        
        public Level1(int size)
        {
            /*Grid = new Block[size, size, 2];
            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                    Grid[i, j, 1] = new GrassBlock();
            Grid[60, 60, 1] = new GlowStoneBlock();
            Grid[63, 63, 1] = new GlowStoneBlock();*/
        }
    }
}
