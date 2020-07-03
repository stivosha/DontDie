using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Don_t_Die.Enums;
using Don_t_Die.Models;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.GameObjects.Items.Weapons;
using Don_t_Die.Models.Items;
using Don_t_Die.Models.Levels;
using Don_t_Die.Views;
using Don_t_Die.Views.Animation;
using Don_t_Die.Views.Camera;
using Don_t_Die.Views.Sprites;

namespace Don_t_Die.Controllers
{
    class GameController : IController
    {
        private IView View { get; set; }
        public IModel Model { get; set; }
        private Image[] LightsImages { get; set; }
        private Size resultMove;
        public Camera Camera { get; set; }
        public int currentFrame = 0;

        public GameController(IView view, IModel model)
        {
            LightsImages = new Image[9];
            for(var i = 0; i < 9; i++)
                LightsImages[i] = Image.FromFile("Textures/LightsBlocks/light_" + i.ToString() + ".png");
            resultMove = Size.Empty;
            View = view;
            Model = model;
            Camera = new Camera(0, 0);
            Camera.FollowForEntity(Model.Scene.Player);
            View.Controller = this;
            Model.Controller = this;
            var timer = new Timer {Interval = 100};
            timer.Tick += Update;
            timer.Start();
        }
        
        public void AddEvent(Keys key, bool down)
        {
            if (key == Keys.Space && down)
                Model.Entities.Add(Model.Scene.Player.Attack(new Sword()));

            if (key == Keys.E && down)
                Model.Scene.Player.LookingAtInventory = !Model.Scene.Player.LookingAtInventory;
            
            if (!Config.KeysStates.ContainsKey(key))
                return;
            if (down)
            {
                if (!Config.KeysStates[key].Item2)
                {
                    resultMove += Config.KeysStates[key].Item1;
                    Config.KeysStates[key] = Tuple.Create(Config.KeysStates[key].Item1, true);
                }
            }
            else
            {
                if (Config.KeysStates[key].Item2)
                {
                    resultMove -= Config.KeysStates[key].Item1;
                    Config.KeysStates[key] = Tuple.Create(Config.KeysStates[key].Item1, false);
                }

                if (resultMove == new Size(0,0))
                {
                    GetState();
                    return;
                }
            }
            Model.MovePlayer(resultMove);
        }

        public void Update(object sender, EventArgs e)
        {
            currentFrame += 1;
            if (currentFrame > 256)
                currentFrame = 0;
            /*var data = new List<Sprite>();
            var a = GetCellsCoordInRadius(Model.Scene.Player.Collider.X, Model.Scene.Player.Collider.Y, 32, 32);
            foreach (var coord in a)
            {
                data.Add(new Sprite {
                    X = coord.Item1 * 32,
                    Y = coord.Item2 * 32,
                    Image = Textures.BlockTextures[Model.Scene.Level.Grid[coord.Item1, coord.Item2, 1].BlockId] });
            }
            var data1 = new List<Sprite>();
            //var midlEl = data[data.Count / 2];
            /*foreach (var el in data)
            {
                data1.Add(new Sprite {X = el.X, Y = el.Y, Image = LightsImages[8 - Model.DayTime.CurrentLightLevel]});
            }
            var data2 = UpdateLightGrid(Model.Scene.Level, a, 8 - Model.DayTime.CurrentLightLevel);
            //var playerCoord = Model.Scene.Player;
            data.AddRange(AnimationManager.CalcCurrentSprites(Model.Entities, currentFrame));
            data.AddRange(data1);
            data.AddRange(data2);*/
            var data = new List<Sprite>();
            var chunks = Model.Scene.World.GetCloseChunks(Model.Scene.Player.Collider.X - 32 * 8, Model.Scene.Player.Collider.Y - 32 * 8);
            Model.Update(chunks);
            foreach (var chunk in chunks.Values)
                data.AddRange(DrawChunk(chunk));
            var data1 = new List<Sprite>();
            foreach (var el in data)
                data1.Add(new Sprite { X = el.X, Y = el.Y, Image = LightsImages[8 - Model.DayTime.CurrentLightLevel] });
            data.AddRange(AnimationManager.CalcCurrentSprites(Model.Entities, currentFrame));
            data.AddRange(data1);
            if (Model.Scene.Player.LookingAtInventory)
                data.Add(CalcInventory(Model.Scene.Player));
            View.Update(data);
        }
        private List<Sprite> DrawChunk(Chunk chunk)
        {
            var sprites = new List<Sprite>();
            for (var i = 0; i < Config.CHUNK_SIZE; i++)
            for (var j = 0; j < Config.CHUNK_SIZE; j++)
                sprites.Add(new Sprite
                {
                    X = chunk.X * Config.CHUNK_SIZE * Config.BLOCK_SIZE + i * Config.BLOCK_SIZE,
                    Y = chunk.Y * Config.CHUNK_SIZE * Config.BLOCK_SIZE + j * Config.BLOCK_SIZE,
                    Image = Textures.BlockTextures[chunk.Blocks[i, j].BlockId]
                });
            return sprites;
        }

        private Sprite CalcInventory(Player player)
        {
            var startPos = new Point(8, 84);
            var bitmap = new Bitmap(Textures.GuiTextures[GameObjectsId.Inventory]);
            var graphics = Graphics.FromImage(bitmap);
            for (var i = 0; i < player.Inventory.GetLength(0); i++)
            for (var j = 0; j < player.Inventory.GetLength(1); j++)
                if(player.Inventory[i, j] != null)
                    graphics.DrawImage(Textures.TexturesForInventory[player.Inventory[i, j].Id], 
                        startPos.X + i * 18, 
                        startPos.Y + j * 18 + (j / 3) * 4 );
            return new Sprite
            {
                X = player.Collider.X - Textures.GuiTextures[GameObjectsId.Inventory].Width / 2,
                Y = player.Collider.Y - Textures.GuiTextures[GameObjectsId.Inventory].Height / 2,
                Image = bitmap
            };
        }

        private void GetState()
        {
            Model.Scene.Player.State = Config.StandByDirection[Model.Scene.Player.State];
        }

        //private List<Sprite> UpdateLightGrid(ILevel level, List<Tuple<int, int>> closeCells, int currentLight)
        //{
        //    var sprites = new List<Sprite>();
        //    int size = (int)Math.Sqrt(closeCells.Count);
        //    var lightCells = new int[size, size];
           
        //    for (var i = 0; i < size; i++)
        //        for (var j = 0; j < size; j++)
        //            if (lightCells[i, j] == 0)
        //                lightCells[i, j] = currentLight;
            
        //    for (var i = 0; i < size; i++)
        //        for (var j = 0; j < size; j++)
        //            if (level.Grid[closeCells[i * size + j].Item1, closeCells[i * size + j].Item2, 1].IsSourceOfLight)
        //                LightManager.CalcLights(lightCells, i, j, 8);
            
        //    for (var i = 0; i < size; i++)
        //        for (var j = 0; j < size; j++)
        //            sprites.Add(new Sprite
        //            {
        //                X = i * 32 + closeCells[0].Item1 * 32,
        //                Y = j * 32 + closeCells[0].Item2 * 32,
        //                Image = LightsImages[lightCells[i, j]]
        //            });
        //    return sprites;
        //}
    }
}
