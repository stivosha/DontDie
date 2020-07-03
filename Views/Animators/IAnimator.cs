using System.Collections.Generic;
using System.Drawing;
using Don_t_Die.Enums;

namespace Don_t_Die.Views.Animation
{
    public interface IAnimator
    {
        Dictionary<States, Image[]> Animation { get; set; }
    }
}
