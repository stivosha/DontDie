using System.Drawing;
namespace Don_t_Die.Views.Sprites
{
    public static class SpriteSheet
    {
        public static Image CropImage(Image image, int x, int y, int width, int height)
        {
            var bitmap = new Bitmap(image);
            return bitmap.Clone(new Rectangle(x, y, width, height), bitmap.PixelFormat);
        }
    }
}
