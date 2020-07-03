using Don_t_Die.Models.GameObjects;

namespace Don_t_Die.Views.Camera
{
    public class Camera
    {
        private int x;
        private int y;
        public int X
        {
            get
            {
                if (followFor != null)
                    return followFor.Collider.X;
                return x;
            }
            set { x = value; }
        }

        public int Y 
        {
            get
            {
                if (followFor != null)
                    return followFor.Collider.Y;
                return y;
            }
            set { y = value; }
        }

        private IEntity followFor;

        public Camera(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void FollowForEntity(IEntity entity)
        {
            followFor = entity;
        }
    }
}
