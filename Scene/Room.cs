using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using SneakyLink.Enemies;
using System.Collections.Generic;
using System.IO;
using System;

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
        public List<IBlock> doorList;

        public Room(Game1 game, string filePath) {
            this.filePath = filePath;
            sceneManage = new SceneManage(filePath, scene);
            blockList = game.blocks;
            doorList = game.doors;
            LoadLevelTextures(game.Content);
        }

        public void LoadLevelTextures(ContentManager content)
        {
            scene = content.Load<Texture2D>("Blocks");
            background = new BackgroundSprite(scene);
            levelData = sceneManage.LoadLevel(filePath);
            //store the door information
            for (int x = 0; x < 4; x++)
            {
                int positionX = 0;
                int positionY = 0;
                switch (x)
                {
                    case 0:
                        positionX = 360;
                        positionY = 20;
                        break;
                    case 1:
                        positionX = 80;
                        positionY = 200;
                        break;
                    case 2:
                        positionX = 640;
                        positionY = 200;
                        break;
                    case 3:
                        positionX = 360;
                        positionY = 380;
                        break;
                }
                doorList.Add(new Doors(levelData[0, x], positionX, positionY));
            }
            //store the block information
            for (int y = 1; y < levelData.GetLength(0); y++)
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
