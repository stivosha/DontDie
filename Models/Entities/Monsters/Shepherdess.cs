using Don_t_Die.Enums;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Geometry;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Drawing;
using Don_t_Die.Models.Levels;

namespace Don_t_Die.Models.Entities.Monsters
{
    class Shepherdess : IMonster
    {
        public int HP { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public GameObjectsId Id { get; set; }
        public States State { get; set; }
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public IItem[,] Inventory { get; set; }
        public Collider Collider { get; set; }
        public IEntity Target { get; set; }

        public Shepherdess(int x, int y)
        {
            Id = GameObjectsId.Skeleton;
            Collider = new Collider(x, y, 32, 32);
            IsAlive = true;
            State = States.StandDown;
            Speed = 5;
            HP = 100000;
            Damage = 1000;
        }

        public void Move()
        {
            Collider.X += Config.StatesToTuple[State].Item1 * Speed;
            Collider.Y += Config.StatesToTuple[State].Item2 * Speed;
        }
        public void AgrToEntity(IEntity entity)
        {
            Target = entity;
        }

        public void Attack()
        {
            
        }

        public void ConflictWith(IEntity entity)
        {
            if (entity.Id == GameObjectsId.Player)
            {
                entity.IsAlive = false;
                State = States.StandDown;
                Target = null;
            }
        }

        public void PutInInventory(IItem item)
        {
            
        }

        public void Update(Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            Move();
            if (Target is null)
                return;
            var dx = NormalizedValue(-Collider.X + Target.Collider.X);
            var dy = NormalizedValue(-Collider.Y + Target.Collider.Y);
            State = Config.PlayerPossibleDirection[new Size(dx, dy)];
        }

        private int NormalizedValue(int num)
        {
            return num == 0
                ? 0 
                : num / Math.Abs(num);
        }
    }
}
