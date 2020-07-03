using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Die.Models.Levels
{
    public class World
    {
        private ChunkManager chunkManager;
        private Dictionary<Tuple<int, int>, Chunk> chunks;
        public World(string name, int seed)
        {
            /*if(String.IsNullOrEmpty(name))
                return;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "Worlds", name);
            if(Directory.Exists(path))
                Load();
            else
                Create(path, seed);*/
            chunkManager = new ChunkManager("anime");
        }

        public Dictionary<Tuple<int, int>, Chunk> GetCloseChunks(int x, int y) 
            => chunkManager.CalcCloseChunks(
                x / Config.CHUNK_SIZE / Config.BLOCK_SIZE, 
                y / Config.CHUNK_SIZE / Config.BLOCK_SIZE, 3);
        

        private void Load()
        {
            //
        }

        private void Create(string path, int seed)
        {
            Directory.CreateDirectory(path);
            chunkManager = new ChunkManager(path);
            chunks = new Dictionary<Tuple<int, int>, Chunk>();
            chunks[Tuple.Create(0, 0)] = chunkManager.GetChunk(0,0);
            for (var i = -1; i < 2; i++)
            for (var j = -1; j < 2; j++)
                chunks[Tuple.Create(i, j)] = chunkManager.GetChunk(i, j);
        }
    }
}
