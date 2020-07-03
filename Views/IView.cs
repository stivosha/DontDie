using System.Collections.Generic;
using Don_t_Die.Controllers;
using Don_t_Die.Views.Sprites;

namespace Don_t_Die.Views
{
    interface IView
    {
        IController Controller { get; set; }
        void Update(List<Sprite> gameSprites);
    }
}
