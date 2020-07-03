using Don_t_Die.Enums;

namespace Don_t_Die.Models.Items.Food
{
    abstract class Food : IItem
    {
        public GameObjectsId Id { get; set; }
        public ItemType Type { get;}
        public int Satiety { get; set; }
        protected Food()
        {
            Type = ItemType.Food;
        }
    }
}
