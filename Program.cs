using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Don_t_Die.Controllers;
using Don_t_Die.Models;
using Don_t_Die.Models.Levels;
using Don_t_Die.Views;

namespace Don_t_Die
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new GameForm() { WindowState = FormWindowState.Maximized };
            var game = new GameModel();
            var controller = new GameController(view, game);
            Application.Run(view);
        }
    }
}
