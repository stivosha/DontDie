using System;
using System.Collections.Generic;
using Don_t_Die.Algorithm.PerlinNoise;
using Don_t_Die.Enums;

namespace Don_t_Die.Models.Levels
{
    public class ChunkManager
    {
        private int seed = 20;
        private float sizeOfBiom = 0.05f;
        private float levelOfHumidity = 0.002f;
        private string path;
        private Dictionary<Tuple<int, int>, Chunk> ChunkInRAM;

        public ChunkManager(string path)
        {
            ChunkInRAM = new Dictionary<Tuple<int, int>, Chunk>();
            this.path = path;
        }

        public Dictionary<Tuple<int, int>, Chunk> CalcCloseChunks(int x, int y, int radius)
        {
            Dictionary<Tuple<int, int>, Chunk> result = new Dictionary<Tuple<int, int>, Chunk>();
            for (var i = -radius / 2; i < radius / 2 + 1; i++)
            for (var j = -radius / 2; j < radius / 2 + 1; j++)
                result[Tuple.Create(x + i, y + j)] = GetChunk(x + i, y + j);
            return result;
        }

        public Chunk GetChunk(int x, int y)
        {
            if (ChunkInRAM.ContainsKey(Tuple.Create(x, y)))
                return ChunkInRAM[Tuple.Create(x, y)];
            //
            ChunkInRAM[Tuple.Create(x, y)] = CreateNewChunk(x, y);
            return ChunkInRAM[Tuple.Create(x, y)];
        }

        private Chunk CreateNewChunk(int x, int y)
        {
            var chunk = new Chunk(x, y);
            for (var i = 0; i < Config.CHUNK_SIZE; i++)
            for (var j = 0; j < Config.CHUNK_SIZE; j++)
                chunk.PutBlock(i, j, SelectBlock(
                    x * Config.CHUNK_SIZE + i,
                    y * Config.CHUNK_SIZE + j));
            return chunk;
        }

        private GameObjectsId SelectBlock(int blockPosX, int blockPosY)
        {
            var elevation = PerlinNoise.PerlinNoise_2D(blockPosX * sizeOfBiom, blockPosY * sizeOfBiom, seed);
            var humidity = PerlinNoise.PerlinNoise_2D(blockPosX * levelOfHumidity, blockPosY * levelOfHumidity, seed * 10);
            if (elevation < 40)
                return GameObjectsId.SeaBlock;
            if (elevation < 50)
                return GameObjectsId.SandBlock;
            if (humidity > 100)
                return GameObjectsId.TropicsBlock;
            if (humidity < 30)
                return GameObjectsId.SandBlock;
            return GameObjectsId.GrassBlock;
        }
    }
}
