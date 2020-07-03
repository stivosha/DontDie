using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Don_t_Die.Models;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Views.Camera;

namespace Don_t_Die.Controllers
{
    public interface IController
    {
        Camera Camera { get; set; }
        IModel Model { get; set; }
        void AddEvent(Keys key, bool down);
        void Update(object sender, EventArgs e);
    }
}
