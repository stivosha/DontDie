using Don_t_Die.Models.GameObjects;

namespace Don_t_Die.Models.Monsters
{
    public interface IMonster : IEntity
    {
        int HP { get; set; }
        int Damage { get; set; }
        int Speed { get; set; }
        IEntity Target { get; set; }
        void Attack();
        void AgrToEntity(IEntity entity);
    }
}
