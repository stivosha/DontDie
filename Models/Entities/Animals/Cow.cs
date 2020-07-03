using System;
using System.Collections.Generic;
using Don_t_Die.Enums;
using Don_t_Die.Models.Entities.Animals;
using Don_t_Die.Models.Entities.Monsters;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Geometry;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Items.Food;
using Don_t_Die.Models.Levels;
using Don_t_Die.Models.Mechanics;

namespace Don_t_Die.Models.Animals
{
    class Cow : IAnimals
    {
        public bool IsAlive { get; set; }
        public int LifeTime { get; set; }
        public Collider Collider { get; set; }
        public GameObjectsId Id { get; set; }
        public States State { get; set; }
        public IItem[,] Inventory { get; set; }
        public IEntity Owner { get; set; }
        public int HP { get; set; }
        public int Speed { get; set; }
        private Command currentCommand;
        private readonly int commandLifeTime = 30;

        public Cow(int x, int y)
        {
            IsAlive = true;
            Id = GameObjectsId.Cow;
            State = States.StandDown;
            currentCommand = CreateNewCommand();
            Collider = new Collider(x, y, 32,32);
            HP = 8;
            Speed = 2;
        }

        public void Move()
        {
            Collider.X += Config.StatesToTuple[State].Item1 * Speed;
            Collider.Y += Config.StatesToTuple[State].Item2 * Speed;
        }

        public void NeutralBehavior()
        {
            if (currentCommand.Lifetime < 0)
                currentCommand = CreateNewCommand();
            currentCommand.Execute();
            Move();
        }


        public void ConflictWith(IEntity entity)
        {
            if (entity is AttackCollider)
                Die(entity);
        }

        public void Update(Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            NeutralBehavior();
        }

        private Command CreateNewCommand()
        {
            var num = Config.random.Next(0, 8);
            return new Command(Config.CommandArray[num], commandLifeTime, this);
        }

        public void Die(IEntity entity)
        {
            IsAlive = false;
            (entity as AttackCollider).Sender.PutInInventory(new Apple());
            if (Owner != null)
                (Owner as Shepherdess).AgrToEntity((entity as AttackCollider).Sender);
        }

        public void PutInInventory(IItem item)
        {
            
        }
    }
}
