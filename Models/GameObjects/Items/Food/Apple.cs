using Don_t_Die.Enums;

namespace Don_t_Die.Models.Items.Food
{
    class Apple : Food
    {
        public Apple()
        {
            Satiety = 10;
            Id = GameObjectsId.Apple;
        }
    }
}
