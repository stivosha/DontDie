using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Don_t_Die.Enums;

namespace Don_t_Die.Models.Items
{
    public interface IItem
    {
        GameObjectsId Id { get; set; }
        ItemType Type { get;}
    }
}


