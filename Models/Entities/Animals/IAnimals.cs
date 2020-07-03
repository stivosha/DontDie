using Don_t_Die.Models.GameObjects;

namespace Don_t_Die.Models.Animals
{
    public interface IAnimals : IEntity
    {
        int HP { get; set; }
        int Speed { get; set; }
        void NeutralBehavior();
        void Move();
    }
}
