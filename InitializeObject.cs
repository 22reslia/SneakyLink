using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class InitializeObject : ICommand
    {
        Game1 game;
        public InitializeObject(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {   
            game.link.playerPosition.X = 100;
            game.link.playerPosition.Y = 100;
            game.link.stateMachine.currentDirection = Player.PlayerDirection.playerDown;
            game.link.stateMachine.currentState = Player.PlayerState.playerIdle;
            //load enemy part
            IEnemy Keese = new Enemies.Keese();
            IEnemy Zol = new Enemies.Zol();
            IEnemy Aquamentus = new Enemies.Aquamentus();
            IEnemy Gel = new Enemies.Gel();
            IEnemy Goriya = new Enemies.Goriya();
            IEnemy Stalfos = new Enemies.Stalfos();
            game.enemyList = new List<IEnemy>();
            game.enemyList.Add(Keese);
            game.enemyList.Add(Zol);
            game.enemyList.Add(Aquamentus);
            game.enemyList.Add(Gel);
            game.enemyList.Add(Goriya);
            game.enemyList.Add(Stalfos);
            game.currentEnemy = game.enemyList[0];

            ISprite Statue1 = new Blocks.Statue1Sprite();
            ISprite Statue2 = new Blocks.Statue2Sprite();
            ISprite SquareBlock = new Blocks.SquareBlockSprite();
            ISprite BlueGap = new Blocks.BlueGapSprite();
            ISprite Stair = new Blocks.StairSprite();
            ISprite WhiteBrick = new Blocks.WhiteBrickSprite();
            ISprite Ladder = new Blocks.LadderSprite();
            ISprite BlueFloor = new Blocks.BlueFloorSprite();
            ISprite BlueSand = new Blocks.BlueSandSprite();
            ISprite Void = new Blocks.VoidSprite();
            ISprite Wall = new Blocks.WallSprite();
            ISprite OpenDoor = new Blocks.OpenDoorSprite();
            ISprite BombedWallOpening = new Blocks.BombedWallOpeningSprite();
            ISprite KeyholeLockedDoor = new Blocks.KeyholeLockedDoorSprite();
            ISprite DiamondSymbolLockedDoor = new Blocks.DiamondSymbolLockedDoorSprite();
            game.blockList = new List<ISprite>();
            game.blockList.Add(Statue1);
            game.blockList.Add(Statue2);
            game.blockList.Add(SquareBlock);
            game.blockList.Add(BlueGap);
            game.blockList.Add(Stair);
            game.blockList.Add(WhiteBrick);
            game.blockList.Add(Ladder);
            game.blockList.Add(BlueFloor);
            game.blockList.Add(BlueSand);
            game.blockList.Add(Void);
            game.blockList.Add(Wall);
            game.blockList.Add(OpenDoor);
            game.blockList.Add(BombedWallOpening);
            game.blockList.Add(KeyholeLockedDoor);
            game.blockList.Add(DiamondSymbolLockedDoor);
            game.currentBlock = game.blockList[0];

            ISprite Compass = new Items.CompassSprite();
            ISprite Map = new Items.MapSprite();
            ISprite Key = new Items.KeySprite();
            ISprite HeartContainer = new Items.HeartContainerSprite();
            ISprite TriforcePiece = new Items.TriforcePieceSprite();
            ISprite WoodenBoomerang = new Items.WoodenBoomerangSprite();
            ISprite Bow = new Items.BowSprite();
            ISprite Heart = new Items.HeartSprite();
            ISprite Rupee = new Items.RupeeSprite();
            ISprite Arrow = new Items.ArrowSprite();
            ISprite Bomb = new Items.BombSprite();
            ISprite Fairy = new Items.FairySprite();
            ISprite Clock = new Items.ClockSprite();
            game.itemList = new List<ISprite>();
            game.itemList.Add(Compass);
            game.itemList.Add(Map);
            game.itemList.Add(Key);
            game.itemList.Add(HeartContainer);
            game.itemList.Add(TriforcePiece);
            game.itemList.Add(WoodenBoomerang);
            game.itemList.Add(Bow);
            game.itemList.Add(Heart);
            game.itemList.Add(Rupee);
            game.itemList.Add(Arrow);
            game.itemList.Add(Bomb);
            game.itemList.Add(Fairy);
            game.itemList.Add(Clock);
            game.currentItem = game.itemList[0];
        }
    }
}
