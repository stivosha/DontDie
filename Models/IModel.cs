using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Controllers;
using Don_t_Die.Enums;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.Levels;
using Don_t_Die.Models.Time;

namespace Don_t_Die.Models
{
    public interface IModel
    {
        IController Controller { get; set; }
        Scene Scene { get; set; }
        List<IEntity> Entities { get; set; }
        DayTime DayTime { get; set; }
        void Update(Dictionary<Tuple<int, int>, Chunk> chunks);
        void MovePlayer(Size direction);
    }
}
