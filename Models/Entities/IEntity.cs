using System;
using System.Collections.Generic;
using Don_t_Die.Enums;
using Don_t_Die.Models.Geometry;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Levels;

namespace Don_t_Die.Models.GameObjects
{
    public interface IEntity
    {
        GameObjectsId Id { get; set; }
        States State { get; set; } 
        bool IsAlive { get; set; }
        int LifeTime { get; set; }
        IItem[,] Inventory { get; set; }
        Collider Collider { get; set; }
        void ConflictWith(IEntity entity);
        void Update(Dictionary<Tuple<int, int>, Chunk> chunks);
        void PutInInventory(IItem item);
    }
}
