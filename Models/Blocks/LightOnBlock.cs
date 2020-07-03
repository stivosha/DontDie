using Don_t_Die.Enums;

namespace Don_t_Die.Models.Blocks
{
    class LightOnBlock
    {
        public int LevelLight { get; set; }
        public TypeOfShadow Type { get; set; }
        public Direction ShadowDirection { get; set; }
        public LightOnBlock()
        {
            ShadowDirection = Direction.Up;
        }
    }
}
