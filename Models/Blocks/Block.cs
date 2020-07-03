using Don_t_Die.Enums;

namespace Don_t_Die.Models.Blocks
{
    public class Block
    {
        public GameObjectsId BlockId { get;}
        public int LevelLight { get;}
        public bool IsSourceOfLight { get;}
        public bool CanMoveThrough { get; }

        public Block(GameObjectsId id, int levelLight, bool isSourceOfLight, bool canMoveThrough )
        {
            BlockId = id;
            LevelLight = levelLight;
            IsSourceOfLight = isSourceOfLight;
            CanMoveThrough = canMoveThrough;
        }
        public Block Clone() 
            => new Block(BlockId, LevelLight, IsSourceOfLight, CanMoveThrough);
    }
}
