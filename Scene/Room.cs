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
        private ISprite block;
        private ISprite door;

        public Room(Game1 game, string filePath) {
            this.filePath = filePath;
            sceneManage = new SceneManage(filePath, scene);
            LoadLevelTextures(game.Content);
        }

        public void LoadLevelTextures(ContentManager content)
        {
            scene = content.Load<Texture2D>("Blocks");
            background = new BackgroundSprite(scene);
            levelData = sceneManage.LoadLevel(filePath);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch, 80, 20);
            //draw door part
            for (int x = 0; x < 4; x++)
            {
                DrawDoor(levelData[0, x], spriteBatch, x);
            }
            //draw block part
            for (int y = 1; y < levelData.GetLength(0); y++)
            {
                for (int x = 0; x < levelData.GetLength(1); x++)
                {
                    DrawBlock(levelData[y, x], spriteBatch, x, y);
                }
            }
        }

        public void DrawBlock(string blockID, SpriteBatch spriteBatch, int col, int row)
        {
            Boolean isBlock = true;
            switch (blockID)
            {
                case "ground":
                    block = new BlueFloorSprite();
                    break;
                case "sand":
                    block = new BlueSandSprite();
                    break;
                case "block":
                    block = new SquareBlockSprite();
                    break;
                case "statue1":
                    block = new Statue1Sprite();
                    break;
                case "statue2":
                    block = new Statue2Sprite();
                    break;
                case "void":
                    block = new VoidSprite();
                    break;
                case "blueGap":
                    block = new BlueGapSprite();
                    break;
                case "stair":
                    block = new StairSprite();
                    break;
                default:
                    isBlock = false;
                    break;
            }

            if (isBlock)
            {
                block.Draw(spriteBatch, 160 + col * 40, 100 + (row-1) * 40);
            }
        }

        public void DrawDoor(string doorID, SpriteBatch spriteBatch, int row)
        {
            int positionX = 0;
            int positionY = 0;

            door = new Doors(doorID);

            switch (row)
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
            door.Draw(spriteBatch, positionX, positionY);
        }
    }
}
