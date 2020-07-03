

using System.Collections.Generic;
using System.Drawing;

namespace Don_t_Die.Enums
{
    public static class Textures
    {
        public static Dictionary<GameObjectsId, Image> TexturesForInventory = new Dictionary<GameObjectsId, Image>
        {
            [GameObjectsId.Apple] = Image.FromFile("Textures/Foods/apple_16x16.png"),
            [GameObjectsId.GoldApple] = Image.FromFile("Textures/Foods/apple_golden_16x16.png"),
            [GameObjectsId.Bread] = Image.FromFile("Textures/Foods/bread_16x16.png"),
            [GameObjectsId.Carrot] = Image.FromFile("Textures/Foods/carrot_16x16.png"),
            [GameObjectsId.GoldCarrot] = Image.FromFile("Textures/Foods/carrot_golden_16x16.png")
        };

        public static Dictionary<GameObjectsId, Image> BlockTextures = new Dictionary<GameObjectsId, Image>
        {
            [GameObjectsId.GrassBlock] = Image.FromFile("Textures/Blocks/grass_32x32.jpg"),
            [GameObjectsId.GlowStoneBlock] = Image.FromFile("Textures/Blocks/glowstone_32x32.png"),
            [GameObjectsId.SeaBlock] = Image.FromFile("Textures/Blocks/seablock_32x32.png"),
            [GameObjectsId.SandBlock] = Image.FromFile("Textures/Blocks/sand_32x32.png"),
            [GameObjectsId.TropicsBlock] = Image.FromFile("Textures/Blocks/grass_32x32.jpg") //FIX!!!!
        };

        public static Dictionary<GameObjectsId, Image> EntityTextures = new Dictionary<GameObjectsId, Image>
        {
            [GameObjectsId.Player] = Image.FromFile("Textures/player.png"),
            [GameObjectsId.Cow] = Image.FromFile("Textures/Animals/cow.png")
        };

        public static Dictionary<GameObjectsId, Image> GuiTextures = new Dictionary<GameObjectsId, Image>
        {
            [GameObjectsId.Inventory] = Image.FromFile("Textures/Gui/Inventory.png")
        };
    }
}
