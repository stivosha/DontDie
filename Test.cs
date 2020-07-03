using Don_t_Die.Enums;
using Don_t_Die.Models;
using Don_t_Die.Models.Animals;
using Don_t_Die.Models.Blocks;
using Don_t_Die.Models.Entities.Monsters;
using Don_t_Die.Models.GameObjects;
using Don_t_Die.Models.GameObjects.Items.Weapons;
using Don_t_Die.Models.Items.Food;
using Don_t_Die.Models.Levels;
using Don_t_Die.Models.Mechanics;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Don_t_Die
{
	[TestFixture]
	public class Don_t_Die_Should
	{
		private IEntity Entity { get; set; }


		[Test]
		public void Test_MovePlayer()
		{
			var player = new Player(10, 10, 1)
			{
				State = States.MoveDown
			};
			player.Move();
			Assert.AreEqual(10, player.Collider.X);
			Assert.AreEqual(11, player.Collider.Y);

			player.State = States.MoveLeft;
			player.Move();

			Assert.AreEqual(9, player.Collider.X);
			Assert.AreEqual(11, player.Collider.Y);

			player.State = States.MoveRight;
			player.Move();
			Assert.AreEqual(10, player.Collider.X);
			Assert.AreEqual(11, player.Collider.Y);

			player.State = States.MoveDownLeft;
			player.Move();
			Assert.AreEqual(9, player.Collider.X);
			Assert.AreEqual(12, player.Collider.Y);

			player.State = States.MoveUpRight;
			player.Move();
			Assert.AreEqual(10, player.Collider.X);
			Assert.AreEqual(11, player.Collider.Y);

			player.State = States.MoveDownRight;
			player.Move();
			Assert.AreEqual(11, player.Collider.X);
			Assert.AreEqual(12, player.Collider.Y);
		}

		[Test]
		public void Test_PutInInvetroty()
		{
			var apple = new Apple();
			var player = new Player(10, 10, 1);
			player.PutInInventory(apple);
			Assert.AreEqual(36, player.Inventory.Length);
			Assert.AreEqual(apple, player.Inventory[0, 0]);
		}

		[Test]
		public void Test_EatFood()
		{
			var player = new Player(10, 10, 1);
			var apple = new Apple();
			player.Eat(apple);
			Assert.AreEqual(apple.Satiety, player.Satiety);
		}

		[Test]
		public void Test_PlayerAttack()
		{
			var player = new Player(10, 10, 1);
			var apple = new Apple();
			Assert.IsNull(player.Attack(apple));
			var sword = new Sword();
			Assert.NotNull(player.Attack(sword));
		}

		[Test]
		public void Test_PlayerCraft()
		{
			var player = new Player(10, 10, 1);
			var craftItem = player.CraftItem("022012010");
			Assert.AreEqual(GameObjectsId.Axe, craftItem);
		}

		[Test]
		public void Test_SkeletonMove()
		{
			var skeleton = new Shepherdess(10, 10)
			{
				State = States.MoveDown
			};
			skeleton.Move();
			Assert.AreEqual(10, skeleton.Collider.X);
			Assert.AreEqual(10 + skeleton.Speed, skeleton.Collider.Y);

			skeleton.State = States.MoveLeft;
			skeleton.Move();

			Assert.AreEqual(10 - skeleton.Speed, skeleton.Collider.X);
			Assert.AreEqual(10 + skeleton.Speed, skeleton.Collider.Y);

			skeleton.State = States.MoveRight;
			skeleton.Move();
			Assert.AreEqual(10, skeleton.Collider.X);
			Assert.AreEqual(10 + skeleton.Speed, skeleton.Collider.Y);

			skeleton.State = States.MoveDownLeft;
			skeleton.Move();
			Assert.AreEqual(10 - skeleton.Speed, skeleton.Collider.X);
			Assert.AreEqual(10 + 2 * skeleton.Speed, skeleton.Collider.Y);

			skeleton.State = States.MoveUpRight;
			skeleton.Move();
			Assert.AreEqual(10, skeleton.Collider.X);
			Assert.AreEqual(10 + skeleton.Speed, skeleton.Collider.Y);

			skeleton.State = States.MoveDownRight;
			skeleton.Move();
			Assert.AreEqual(10 + skeleton.Speed, skeleton.Collider.X);
			Assert.AreEqual(10 + 2 * skeleton.Speed, skeleton.Collider.Y);
		}

		[Test]
		public void Test_Skeleton_ConflictWith()
		{
			var skeleton = new Shepherdess(10, 10);
			var player = new Player(9, 9, 1);
			skeleton.ConflictWith(player);
			Assert.AreEqual(false, player.IsAlive);
			Assert.IsNull(skeleton.Target);
		}

		[Test]
		public void Test_NormalizedVector()
		{

		}

		[Test]
		public void Test_Skeleton_ArgToEntity()
		{
			var skeleton = new Shepherdess(10, 10);
			var player = new Player(9, 9, 1);
			skeleton.AgrToEntity(player);
			Assert.AreEqual(player, skeleton.Target);
		}

		[Test]
		public void Test_CreateNewLevel()
		{
			Assert.IsNotNull(new World("new world", 20));
		}

		[Test]
		public void Test_CountItemsCreateNewWorld()
		{
			var world = new World("new world", 0);
			Assert.AreEqual(49, world.GetCloseChunks(0, 0).Count);
		}

		[Test]
		public void Test_CowDead()
		{
			var cow = new Cow(100, 100);
			Entity = new AttackCollider(110, 110, 32, 32, cow, 10);
			cow.ConflictWith(Entity);
			Assert.AreEqual(false, cow.IsAlive);
		}

		[Test]
		public void Test_CowMove()
		{
			var cow = new Cow(100, 100)
			{
				State = Enums.States.MoveDown
			};
			cow.Move();
			Assert.AreEqual(100, cow.Collider.X);
			Assert.AreEqual(102, cow.Collider.Y);
		}

		[Test]
		public void Test_CowState()
		{
			var cow = new Cow(100, 100)
			{
				State = Enums.States.StandDown
			};
			cow.Move();
			Assert.AreEqual(100, cow.Collider.X);
			Assert.AreEqual(100, cow.Collider.Y);
		}

		[Test]
		public void Test_LightManager()
		{
			var grid = new int[32, 32];
			for (var i = 0; i < 32; i++)
				for (var j = 0; j < 32; j++)
					grid[i, j] = 8;

			LightManager.CalcLights(grid, 10, 10, 1);
			Assert.AreEqual(2, grid[9, 9]);
			Assert.AreEqual(4, grid[8, 8]);
			Assert.AreEqual(5, grid[7, 8]);
			Assert.AreEqual(8, grid[3, 3]);
		}

		[Test]
		public void Test_NearestDrawing()
		{
			var blocksInRadius = GetCellsCoordInRadius(10, 10, 2, 32);
			var oneBlockUnderPlayer = GetCellsCoordInRadius(10, 10, 0, 32);
			var noBlocks = GetCellsCoordInRadius(10, 10, -1, 32);
			Assert.AreEqual(0, noBlocks.Count);
			Assert.AreEqual(1, oneBlockUnderPlayer.Count);
			Assert.AreEqual(9, blocksInRadius.Count);
		}

		private List<Tuple<int, int>> GetCellsCoordInRadius(int x, int y, int radius, int sizeBlock)
		{
			var grid = new Block[12, 12, 2];
			var result = new List<Tuple<int, int>>();
			x /= sizeBlock;
			y /= sizeBlock;
			for (var i = x - radius; i <= x + radius; i++)
				for (var j = y - radius; j <= y + radius; j++)
					if (IsInBounds(i, j,
							grid.GetLength(0),
							grid.GetLength(1)))
						result.Add(Tuple.Create(i, j));
			return result;
		}
		private static bool IsInBounds(int x, int y, int sizeX, int sizeY)
			=> x >= 0
			&& y >= 0
			&& x <= sizeX
			&& y <= sizeY;
	}
}