using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using SneakyLink.Enemies;
using System.Collections.Generic;
using System.IO;
using System;
using SneakyLink.Collision;
using SneakyLink.Items;
using SneakyLink.Projectiles;

namespace SneakyLink.Scene
{
    public class Room : IScene
    {
        private Texture2D scene;
        private ISprite background;
        private SceneManage sceneManage;
        private string filePath;
        private string[,] levelData;
        public List<IBlock> blockList;
        public List<Doors> doorList;
        public List<IEnemy> enemyList;
        public List<IItem> itemList;

        public Room(Game1 game, string filePath)
        {
            this.filePath = filePath;
            sceneManage = new SceneManage(filePath, scene);
            blockList = new List<IBlock>();
            doorList = new List<Doors>();
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            LoadLevelTextures(game.Content);
            //set collision box for the background
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 205, 80, 160, 20));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 205, 80, 445, 20));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 205, 80, 160, 380));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 205, 80, 445, 380));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 80, 120, 80, 80));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 80, 120, 640, 80));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 80, 120, 80, 260));
            game.boundaryCollisionBox.Add(new CollisionBox(CollisionObjectType.Block, 80, 120, 640, 260));
        }

        public void LoadLevelTextures(ContentManager content)
        {
            scene = content.Load<Texture2D>("Blocks");
            background = new BackgroundSprite(scene);
            levelData = sceneManage.LoadLevel(filePath);
            //store the door information
            for (int x = 0; x < 8; x+=2)
            {
                int positionX = 0;
                int positionY = 0;
                switch (x)
                {
                    case 0:
                        positionX = 360;
                        positionY = 20;
                        break;
                    case 2:
                        positionX = 80;
                        positionY = 200;
                        break;
                    case 4:
                        positionX = 640;
                        positionY = 200;
                        break;
                    case 6:
                        positionX = 360;
                        positionY = 380;
                        break;
                }
                doorList.Add(new Doors(levelData[0, x], positionX, positionY, levelData[0, x+1]));
            }
            //store the block information
            for (int y = 1; y < 8; y++)
            {
                for (int x = 0; x < levelData.GetLength(1); x++)
                {
                    int positionX = 160 + x * 40;
                    int positionY = 100 + (y - 1) * 40;
                    switch (levelData[y, x])
                    {
                        case "ground":
                            blockList.Add(new Ground(positionX, positionY));
                            break;
                        case "sand":
                            blockList.Add(new Sand(positionX, positionY));
                            break;
                        case "block":
                            blockList.Add(new Block(positionX, positionY));
                            break;
                        case "statue1":
                            blockList.Add(new Statue1(positionX, positionY));
                            break;
                        case "statue2":
                            blockList.Add(new Statue2(positionX, positionY));
                            break;
                        case "void":
                            blockList.Add(new VoidSpace(positionX, positionY));
                            break;
                        case "blueGap":
                            blockList.Add(new BlueGap(positionX, positionY));
                            break;
                        case "stair":
                            blockList.Add(new Stair(positionX, positionY));
                            break;
                    }
                }
            }

            //store enemies and items information
            for (int y = 8; y < 15; y++)
            {
                for (int x = 0; x < levelData.GetLength(1); x++)
                {
                    int positionX = 160 + x * 40;
                    int positionY = 100 + (y - 8) * 40;
                    switch (levelData[y, x])
                    {
                        case "gel":
                            enemyList.Add(new Gel(positionX, positionY));
                            break;
                        case "zol":
                            enemyList.Add(new Zol(positionX, positionY));
                            break;
                        case "goriya":
                            enemyList.Add(new Goriya(positionX, positionY));
                            break;
                        case "keese":
                            enemyList.Add(new Keese(positionX, positionY));
                            break;
                        case "stalfos":
                            enemyList.Add(new Stalfos(positionX, positionY));
                            break;
                        case "map":
                            itemList.Add(new MapObject(positionX + 12, positionY + 5));
                            break;
                        case "rupee":
                            itemList.Add(new RupeeObject(positionX + 12, positionY + 5));
                            break;
                        case "bomb":
                            itemList.Add(new BombObject(positionX + 12, positionY + 5));
                            break;
                        case "bluepotion":
                            itemList.Add(new BluePotion(positionX + 12, positionY + 5));
                            break;
                        case "redpotion":
                            itemList.Add(new RedPotion(positionX + 12, positionY + 5));
                            break;
                        case "heartcontainer":
                            itemList.Add(new HeartContainer(positionX + 12, positionY + 5));
                            break;
                        case "pushableBlock":
                            itemList.Add(new KeyObject(positionX + 12, positionY + 5));
                            itemList.Add(new PushableBlock(positionX, positionY));
                            break;
                        case "empty":
                            break;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, 80, 20);
            //draw door part
            for (int x = 0; x < doorList.Count; x++)
            {
                doorList[x].Draw(spriteBatch);
            }
            //draw block part
            for (int x = 0; x < blockList.Count; x++)
            {
                blockList[x].Draw(spriteBatch);
            }
        }
    }
}
