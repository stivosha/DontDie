using System;
using System.Collections.Generic;
using Don_t_Die.Enums;
using Don_t_Die.Models.Geometry;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Items.Food;
using Don_t_Die.Models.Levels;
using Don_t_Die.Models.Mechanics;

namespace Don_t_Die.Models.GameObjects
{
    public class Player : IEntity
    {
        public int Z { get; set; }
        public int Speed { get; set; }
        public GameObjectsId Id { get; set; }
        public States State { get; set; }
        public int Satiety { get; set; }
        public readonly int BlockSize = 32;
        public IItem[,] Inventory { get; set; }
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public Collider Collider { get; set; }
        public bool LookingAtInventory { get; set; }
        private Dictionary<Tuple<int, int>, Chunk> closeChunks; 
        public Player(int x, int y, int z)
        {
            Z = z;
            Speed = 10;
            State = States.StandDown;
            Collider = new Collider(x, y,16,16);
            IsAlive = true;
            Id = GameObjectsId.Player;
            LookingAtInventory = false;
            Inventory = new IItem[9, 4];
            Inventory[3, 3] = new Apple();
            closeChunks = new Dictionary<Tuple<int, int>, Chunk>();
        }

        public void Move()
        {
            Collider.X += Config.StatesToTuple[State].Item1;
            Collider.Y += Config.StatesToTuple[State].Item2;
        }

        public void MoveBack()
        {
            Collider.X -= Config.StatesToTuple[State].Item1;
            Collider.Y -= Config.StatesToTuple[State].Item2;
        }

        public void PutInInventory(IItem item)
        {
            for (var i = 0; i < Inventory.GetLength(1); i++)
                for (var j = 0; j < Inventory.GetLength(0); j++)
                    if (Inventory[j, i] == null)
                    {
                        Inventory[j, i] = item;
                        return;
                    }
        }

        public void Eat(IItem item)
        {
            if (item.Type != ItemType.Food)
                return;
            Satiety += ((Food)item).Satiety;
        }

        public void Use(IItem item)
        {
            if (item.Type != ItemType.Tool)
                return;
        }

        public AttackCollider Attack(IItem item)
        {
            if (item.Type != ItemType.Weapon)
                return null;
            switch (State)
            {
                case States.StandRight:
                    return new AttackCollider(Collider.X + Collider.Width, Collider.Y, Collider.Width, Collider.Height, this, 1);
                case States.StandLeft:
                    return new AttackCollider(Collider.X - Collider.Width, Collider.Y, Collider.Width, Collider.Height, this, 1);
                case States.StandUp:
                    return new AttackCollider(Collider.X, Collider.Y - Collider.Height, Collider.Width, Collider.Height, this, 1);
                case States.StandDown:
                    return new AttackCollider(Collider.X, Collider.Y + Collider.Height, Collider.Width, Collider.Height, this, 1);
            }
            return null;
        }

        public GameObjectsId CraftItem(string craft) =>
            Crafts.CraftsItem.ContainsKey(craft) ? Crafts.CraftsItem[craft] : GameObjectsId.Apple;

        public void ConflictWith(IEntity entity)
        {

        }

        public void Update(Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            UpdateCurrentChunks(ToChunkCoord(Collider.X),
                                ToChunkCoord(Collider.Y),
                                chunks);
            for (var i = 0; i < Speed; i++)
            {
                Move();
                if (!OurPositionCorrect())
                {
                    MoveBack();
                    return;
                }
            }
        }

        private bool OurPositionCorrect()
        {
            return CanMoveThrough(Collider.X, Collider.Y, closeChunks[Tuple.Create(ToChunkCoord(Collider.X), ToChunkCoord(Collider.Y))]) 
                   && CanMoveThrough(Collider.X + Collider.Width, Collider.Y, closeChunks[Tuple.Create(ToChunkCoord(Collider.X + Collider.Width), ToChunkCoord(Collider.Y))])
                   && CanMoveThrough(Collider.X, Collider.Y + Collider.Height, closeChunks[Tuple.Create(ToChunkCoord(Collider.X), ToChunkCoord(Collider.Y + Collider.Height))])
                   && CanMoveThrough(Collider.X + Collider.Width, Collider.Y + Collider.Height, closeChunks[Tuple.Create(ToChunkCoord(Collider.X + Collider.Width), ToChunkCoord(Collider.Y + Collider.Height))]);
        }

        private bool CanMoveThrough(int x, int y, Chunk chunk)
        {
            x = (x - chunk.X * Config.CHUNK_SIZE * Config.BLOCK_SIZE) / Config.BLOCK_SIZE;
            y = (y - chunk.Y * Config.CHUNK_SIZE * Config.BLOCK_SIZE) / Config.BLOCK_SIZE;
            if (x == 16)
                x = 15;
            if (y == 16)
                y = 15;
            return chunk.Blocks[x, y].CanMoveThrough;
        }

        private void UpdateCurrentChunks(int x, int y, Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            closeChunks.Clear();
            for (var i = -1; i <= 1; i++)
                for (var j = -1; j <= 1; j++)
                    if (chunks.ContainsKey(Tuple.Create(x + i, y + j)))
                        closeChunks[Tuple.Create(x + i, y + j)] = chunks[Tuple.Create(x + i, y + j)];
        }

        private int ToChunkCoord(int num)
        {
            if (num < 0)
                num -= Config.CHUNK_SIZE * Config.BLOCK_SIZE;
            return num / Config.CHUNK_SIZE / Config.BLOCK_SIZE;
        }
    }
}
