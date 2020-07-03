using System;
using System.Collections.Generic;
using System.Drawing;
using Don_t_Die.Controllers;
using Don_t_Die.Models.Animals;
using Don_t_Die.Models.Entities.Monsters;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Levels;
using Don_t_Die.Models.Time;

namespace Don_t_Die.Models
{
    class GameModel : IModel
    {
        public IController Controller { get; set; }
        public Scene Scene { get; set; }
        public List<IEntity> Entities { get; set; }
        public DayTime DayTime { get; set; }
        public GameModel()
        {
            Scene = new Scene(new LevelManager(1024).GetLevelByNumber(1));
            DayTime = new DayTime();
            Entities = new List<IEntity>
            {
                Scene.Player
            };

            var owner = new Shepherdess(400, 400);
            foreach(var animal in Scene.Animals)
            {
                (animal as Cow).Owner = owner;
                Entities.Add(animal);
            }
            Entities.Add(owner);
        }

        public void Update(Dictionary<Tuple<int, int>, Chunk> chunks)
        {
            DayTime.Update();
            var objectsNeedRemove = new List<IEntity>();
            
            foreach (var entity in Entities)
                if (entity != null)
                {
                    entity.Update(chunks);
                    if (!entity.IsAlive)
                        objectsNeedRemove.Add(entity);
                }

            foreach (var objectNeedRemove in objectsNeedRemove)
                Entities.Remove(objectNeedRemove);
            Entities.RemoveAll(x => x == null);

            for (var i = 0; i < Entities.Count - 1; i++)
                for (var j = i + 1; j < Entities.Count; j++)
                    if (i != j && Entities[i] != null && Entities[j] != null && Entities[i].Collider.CollideWith(Entities[j].Collider))
                    {
                        Entities[i].ConflictWith(Entities[j]);
                        Entities[j].ConflictWith(Entities[i]);
                    }
        }

        public void MovePlayer(Size resultMove)
        {
            Scene.Player.State = Config.PlayerPossibleDirection[resultMove];
        }
    }
}
