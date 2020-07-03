using Don_t_Die.Models.Blocks;

namespace Don_t_Die.Models.Levels
{
    public interface ILevel
    {
        Block[,,] Grid { get; set; }
    }
}
