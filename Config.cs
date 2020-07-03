using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Don_t_Die.Enums;
using Don_t_Die.Models.Blocks;

namespace Don_t_Die
{
    public static class Config
    {
        public static readonly List<List<Tuple<int, int>>> Result = new List<List<Tuple<int, int>>>()
            {
            new List<Tuple<int,int>>()//1
                {
                    Tuple.Create(-2, 7),
                    Tuple.Create(-1, 7),
                    Tuple.Create(0, 7),
                    Tuple.Create(1, 7),
                    Tuple.Create(2, 7),

                    Tuple.Create(-2, -7),
                    Tuple.Create(-1, -7),
                    Tuple.Create(0, -7),
                    Tuple.Create(1, -7),
                    Tuple.Create(2, -7),

                    Tuple.Create(7, -2),
                    Tuple.Create(7, -1),
                    Tuple.Create(7, 0),
                    Tuple.Create(7, 1),
                    Tuple.Create(7, 2),

                    Tuple.Create(-7, -2),
                    Tuple.Create(-7, -1),
                    Tuple.Create(-7, 0),
                    Tuple.Create(-7, 1),
                    Tuple.Create(-7, 2),

                    Tuple.Create(-4, 6),
                    Tuple.Create(-3, 6),
                    Tuple.Create(3, 6),
                    Tuple.Create(4, 6),

                    Tuple.Create(6, -4),
                    Tuple.Create(6, -3),
                    Tuple.Create(6, 3),
                    Tuple.Create(6, 4),

                    Tuple.Create(-6, -4),
                    Tuple.Create(-6, -3),
                    Tuple.Create(-6, 3),
                    Tuple.Create(-6, 4),

                    Tuple.Create(-4, -6),
                    Tuple.Create(-3, -6),
                    Tuple.Create(3, -6),
                    Tuple.Create(4, -6),

                    Tuple.Create(5, 5),
                    Tuple.Create(5, -5),
                    Tuple.Create(-5, -5),
                    Tuple.Create(-5, 5),
                },
                new List<Tuple<int,int>>()//2
                {
                    Tuple.Create(-2, 6),
                    Tuple.Create(-1, 6),
                    Tuple.Create(0, 6),
                    Tuple.Create(1, 6),
                    Tuple.Create(2, 6),

                    Tuple.Create(-2, -6),
                    Tuple.Create(-1, -6),
                    Tuple.Create(0, -6),
                    Tuple.Create(1, -6),
                    Tuple.Create(2, -6),

                    Tuple.Create(6, -2),
                    Tuple.Create(6, -1),
                    Tuple.Create(6, 0),
                    Tuple.Create(6, 1),
                    Tuple.Create(6, 2),

                    Tuple.Create(-6, -2),
                    Tuple.Create(-6, -1),
                    Tuple.Create(-6, 0),
                    Tuple.Create(-6, 1),
                    Tuple.Create(-6, 2),

                    Tuple.Create(-4, 5),
                    Tuple.Create(-3, 5),
                    Tuple.Create(-2, 5),
                    Tuple.Create(2, 5),
                    Tuple.Create(3, 5),
                    Tuple.Create(4, 5),

                    Tuple.Create(5, -4),
                    Tuple.Create(5, -3),
                    Tuple.Create(5, -2),
                    Tuple.Create(5, 2),
                    Tuple.Create(5, 3),
                    Tuple.Create(5, 4),

                    Tuple.Create(-5, -4),
                    Tuple.Create(-5, -3),
                    Tuple.Create(-5, -2),
                    Tuple.Create(-5, 2),
                    Tuple.Create(-5, 3),
                    Tuple.Create(-5, 4),

                    Tuple.Create(-4, -5),
                    Tuple.Create(-3, -5),
                    Tuple.Create(-2, -5),
                    Tuple.Create(2, -5),
                    Tuple.Create(3, -5),
                    Tuple.Create(4, -5),

                    Tuple.Create(4, 4),
                    Tuple.Create(4, -4),
                    Tuple.Create(-4, -4),
                    Tuple.Create(-4, 4),
                },
                new List<Tuple<int,int>>()//3
                {
                    Tuple.Create(-1, -5),
                    Tuple.Create(0, -5),
                    Tuple.Create(1, -5),

                    Tuple.Create(5, -1),
                    Tuple.Create(5, 0),
                    Tuple.Create(5, 1),

                    Tuple.Create(-1, 5),
                    Tuple.Create(0, 5),
                    Tuple.Create(1, 5),

                    Tuple.Create(-5, -1),
                    Tuple.Create(-5, 0),
                    Tuple.Create(-5, 1),

                    Tuple.Create(-2, -2),
                    Tuple.Create(2, 2),
                    Tuple.Create(2, -2),
                    Tuple.Create(-2, 2),

                    Tuple.Create(-2, -4),
                    Tuple.Create(-3, -4),
                    Tuple.Create(-4, -3),
                    Tuple.Create(-4, -2),

                    Tuple.Create(-2, 4),
                    Tuple.Create(-3, 4),
                    Tuple.Create(-4, 3),
                    Tuple.Create(-4, 2),

                    Tuple.Create(2, -4),
                    Tuple.Create(3, -4),
                    Tuple.Create(4, -3),
                    Tuple.Create(4, -2),

                    Tuple.Create(2, 4),
                    Tuple.Create(3, 4),
                    Tuple.Create(4, 3),
                    Tuple.Create(4, 2),

                    Tuple.Create(4, -2),
                    Tuple.Create(4, -3),
                    Tuple.Create(3, -4),
                    Tuple.Create(2, -4)
                },
                new List<Tuple<int,int>>()//4
                {
                    Tuple.Create(-1, -4),
                    Tuple.Create(0, -4),
                    Tuple.Create(1, -4),
                    Tuple.Create(4, -1),
                    Tuple.Create(4, 0),
                    Tuple.Create(4, 1),
                    Tuple.Create(-1, 4),
                    Tuple.Create(0, 4),
                    Tuple.Create(1, 4),
                    Tuple.Create(-4, -1),
                    Tuple.Create(-4, 0),
                    Tuple.Create(-4, 1),
                    Tuple.Create(-3, -3),
                    Tuple.Create(3, 3),
                    Tuple.Create(3, -3),
                    Tuple.Create(-3, 3),
                    Tuple.Create(-3, -2),
                    Tuple.Create(-2, -3),
                    Tuple.Create(3, 2),
                    Tuple.Create(2, 3),
                    Tuple.Create(-2, 3),
                    Tuple.Create(-3, 2),
                    Tuple.Create(2, -3),
                    Tuple.Create(3, -2)
                },
                new List<Tuple<int,int>>()//5
                {
                    Tuple.Create(-1, -3),
                    Tuple.Create(0, -3),

                    Tuple.Create(1, -3),
                    Tuple.Create(3, -1),
                    Tuple.Create(3, 0),

                    Tuple.Create(3, 1),
                    Tuple.Create(-1, 3),
                    Tuple.Create(0, 3),

                    Tuple.Create(1, 3),
                    Tuple.Create(-3, -1),
                    Tuple.Create(-3, 0),
                    Tuple.Create(-3, 1),

                    Tuple.Create(-2, -2),
                    Tuple.Create(2, 2),
                    Tuple.Create(2, -2),
                    Tuple.Create(-2, 2)

                },
                new List<Tuple<int,int>>()//6
                {
                    Tuple.Create(-1, -2),
                    Tuple.Create(0, -2),
                    Tuple.Create(1, -2),
                    Tuple.Create(2, -1),

                    Tuple.Create(2, 0),
                    Tuple.Create(2, 1),
                    Tuple.Create(-1, 2),
                    Tuple.Create(0, 2),

                    Tuple.Create(1, 2),
                    Tuple.Create(-2, -1),
                    Tuple.Create(-2, 0),
                    Tuple.Create(-2, 1)
                },
                new List<Tuple<int,int>>()//7
                {
                    Tuple.Create(-1, -1),
                    Tuple.Create(0, -1),
                    Tuple.Create(1, -1),
                    Tuple.Create(-1, 0),
                    Tuple.Create(1, 0),
                    Tuple.Create(-1, 1),
                    Tuple.Create(0, 1),
                    Tuple.Create(1, 1)
                },
                new List<Tuple<int,int>>()//8
                {
                    Tuple.Create(0, 0)
                }
            };

        public static readonly Dictionary<GameObjectsId, Block> IdToBlock = new Dictionary<GameObjectsId, Block>
        {
            [GameObjectsId.GrassBlock] = new Block(GameObjectsId.GrassBlock, -1, false, true),
            [GameObjectsId.SeaBlock] = new Block(GameObjectsId.SeaBlock, -1, false, false),
            [GameObjectsId.SandBlock] = new Block(GameObjectsId.SandBlock, -1, false, true),
            [GameObjectsId.TropicsBlock] = new Block(GameObjectsId.TropicsBlock, -1, false, true),

            [GameObjectsId.GlowStoneBlock] = new Block(GameObjectsId.TropicsBlock, 8, true, false)
        };

        public static readonly Dictionary<Keys, Tuple<Size, bool>> KeysStates = new Dictionary<Keys, Tuple<Size, bool>>
        {
            [Keys.A] = Tuple.Create(new Size(-1, 0), false),
            [Keys.D] = Tuple.Create(new Size(1, 0), false),
            [Keys.W] = Tuple.Create(new Size(0, -1), false),
            [Keys.S] = Tuple.Create(new Size(0, 1), false)
        };

        public static readonly Commands[] CommandArray = new Commands[]
        {
            Commands.StandUp,
            Commands.MoveLeft,
            Commands.MoveRight,
            Commands.MoveUp,
            Commands.MoveDown,
            Commands.StandDown,
            Commands.StandLeft,
            Commands.StandDown
        };

        public static readonly Dictionary<Commands, States> Command = new Dictionary<Commands, States>
        {
            [Commands.MoveLeft] = States.MoveLeft,
            [Commands.MoveDown] = States.MoveDown,
            [Commands.MoveRight] = States.MoveRight,
            [Commands.MoveUp] = States.MoveUp,
            [Commands.MoveDownLeft] = States.MoveDownLeft,
            [Commands.MoveDownRight] = States.MoveDownRight,
            [Commands.MoveUpLeft] = States.MoveUpLeft,
            [Commands.MoveUpRight] = States.MoveUpRight,
            [Commands.MoveLeft] = States.MoveLeft,
            [Commands.StandDown] = States.StandDown,
            [Commands.StandUp] = States.StandUp,
            [Commands.StandRight] = States.StandRight,
            [Commands.StandLeft] = States.StandLeft
        };

        public static readonly Dictionary<States, Tuple<int, int>> StatesToTuple = new Dictionary<States, Tuple<int, int>>
        {
            [Enums.States.StandUp] = Tuple.Create(0, 0),
            [Enums.States.StandLeft] = Tuple.Create(0, 0),
            [Enums.States.StandRight] = Tuple.Create(0, 0),
            [Enums.States.StandDown] = Tuple.Create(0, 0),
            [Enums.States.MoveUp] = Tuple.Create(0, -1),
            [Enums.States.MoveDown] = Tuple.Create(0, 1),
            [Enums.States.MoveLeft] = Tuple.Create(-1, 0),
            [Enums.States.MoveRight] = Tuple.Create(1, 0),
            [Enums.States.MoveUpLeft] = Tuple.Create(-1, -1),
            [Enums.States.MoveUpRight] = Tuple.Create(1, -1),
            [Enums.States.MoveDownLeft] = Tuple.Create(-1, 1),
            [Enums.States.MoveDownRight] = Tuple.Create(1, 1),
        };

        public readonly static Dictionary<Size, States> PlayerPossibleDirection = new Dictionary<Size, States>
        {
            [new Size(0, 0)] = States.StandUp,
            [new Size(0, 0)] = States.StandDown,
            [new Size(0, 0)] = States.StandLeft,
            [new Size(0, 0)] = States.StandRight,
            [new Size(1, 0)] = States.MoveRight,
            [new Size(-1, 0)] = States.MoveLeft,
            [new Size(0, 1)] = States.MoveDown,
            [new Size(0, -1)] = States.MoveUp,
            [new Size(-1, -1)] = States.MoveUpLeft,
            [new Size(-1, 1)] = States.MoveDownLeft,
            [new Size(1, -1)] = States.MoveUpRight,
            [new Size(1, 1)] = States.MoveDownRight
        };

        public readonly static Dictionary<States, States> StandByDirection = new Dictionary<States, States>
        {
            [States.MoveUp] = States.StandUp,
            [States.MoveDown] = States.StandDown,
            [States.MoveRight] = States.StandRight,
            [States.MoveLeft] = States.StandLeft,
            [States.MoveDownLeft] = States.StandUpLeft,
            [States.MoveDownRight] = States.StandDownLeft,
            [States.MoveUpLeft] = States.StandUpRight,
            [States.MoveUpRight] = States.StandDownRight,
        };

        public static Random random = new Random();
       
        public static int CHUNK_SIZE = 16;
        
        public static int BLOCK_SIZE = 32;
    }
}
