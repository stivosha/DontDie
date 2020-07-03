using Don_t_Die.Enums;
using Don_t_Die.Models.Animals;
using Don_t_Die.Models.Items;

namespace Don_t_Die.Models.Entities.Animals
{
    public class Command
    {
        public Commands CurrentCommand;
        public int Lifetime { get; set; }
        public IAnimals Animal;

        public Command(Commands command, int lifeTime, IAnimals animal)
        {
            CurrentCommand = command;
            Lifetime = lifeTime;
            Animal = animal;
        }

        public void Execute()
        {
            Lifetime--;
            Animal.State = Config.Command[CurrentCommand];
        }
    }
}
