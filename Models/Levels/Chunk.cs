using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Enums;
using Don_t_Die.Models.Blocks;

namespace Don_t_Die.Models.Levels
{
    public class Chunk
    {
        public Block[,] Blocks { get; }
        public int X { get; }
        public int Y { get; }

        public Chunk(int x, int y)
        {
            Blocks = new Block[Config.CHUNK_SIZE, Config.CHUNK_SIZE];
            X = x;
            Y = y;
        }

        public void PutBlock(int x, int y, GameObjectsId id)
        {
            Blocks[x, y] = Config.IdToBlock[id].Clone();
        }
    }
}
