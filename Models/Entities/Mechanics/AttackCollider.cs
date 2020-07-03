using System;
using System.Collections.Generic;
using Don_t_Die.Enums;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Geometry;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Levels;

namespace Don_t_Die.Models.Mechanics
{
    public class AttackCollider : IEntity
    {
        public IEntity Sender { get; set; }
        public GameObjectsId Id { get; set; }
        public States State { get; set; }
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public Collider Collider { get; set; }
        public IItem[,] Inventory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AttackCollider(int x, int y, int w, int h, IEntity entity, int lifeTime)
        {
            Collider = new Collider(x, y, w, h);
            Sender = entity;
            LifeTime = lifeTime;
            IsAlive = true;
            Id = GameObjectsId.SimpleAttack;
        }
        
        public void ConflictWith(IEntity entity)
        {
            if (entity != Sender)
                entity.IsAlive = false;
        }

        public void Update(Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            LifeTime -= 1;
            if (LifeTime < 0)
                IsAlive = false;
        }

        public void PutInInventory(IItem item)
        {

        }
    }
}
