using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Don_t_Die.Controllers;
using Don_t_Die.Views.Sprites;
using Timer = System.Windows.Forms.Timer;

namespace Don_t_Die.Views
{
    public partial class GameForm : Form, IView
    {
        public IController Controller { get; set; }

        private List<Sprite> sprites;
        
        public GameForm()
        {
            var timer = new Timer();
            DoubleBuffered = true;
            InitializeComponent();
        }
        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, true);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, false);
        }

        private void HandleKey(Keys key, bool down)
        {
            Controller.AddEvent(key, down);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (sprites != null)
            {
                e.Graphics.TranslateTransform(-Controller.Camera.X + ClientRectangle.Width / 2, 
                    -Controller.Camera.Y + ClientRectangle.Height / 2); //FIX ME
                foreach (var sprite in sprites)
                    e.Graphics.DrawImage(sprite.Image, sprite.X, sprite.Y);
                
            }
            Text = Controller.Camera.X + @":" + Controller.Camera.Y + @":" + Controller.Model.DayTime.CurrentTimeOfDay;
        }

        void IView.Update(List<Sprite> gameSprites)
        {
            sprites = gameSprites;
            Invalidate();
            Update();
        }
    }
}
