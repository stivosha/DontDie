using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Enums;
using Don_t_Die.Models.Items;

namespace Don_t_Die.Models.GameObjects.Items.Weapons
{
    abstract class Weapon : IItem
    {
        public GameObjectsId Id { get; set; }
        public ItemType Type { get; }

        protected Weapon()
        {
            Type = ItemType.Weapon;
        }
    }
}
