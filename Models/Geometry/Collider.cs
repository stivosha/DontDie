
namespace Don_t_Die.Models.Geometry
{
    public class Collider
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Collider(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        public bool CollideWith(Collider collider)
        {
            if (collider.X < X + Width && X < collider.X + collider.Width && collider.Y < Y + Height)
                return Y < collider.Y + collider.Height;
            return false;
        }

    }
}
