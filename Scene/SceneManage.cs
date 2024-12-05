using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using System.IO;
using System;
using System.Diagnostics;

namespace SneakyLink.Scene
{
    public class SceneManage
    {
        private Texture2D scene;
        public SceneManage(string filePath, Texture2D scene)
        {
            this.scene = scene;
        }
        public string[,] LoadLevel(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[1].Split(',').Length;

            string[,] levelData = new string[rows, cols];
            //load doors
            string[] doorValues = lines[0].Split(',');
            for (int x = 0; x < doorValues.Length; x++)
            {
                levelData[0, x] = doorValues[x];
            }
            //load blocks and enemies and items
            for (int y = 1; y < rows; y++)
            {
                string[] values = lines[y].Split(',');
                for (int x = 0; x < cols; x++)
                {
                    levelData[y, x] = values[x];
                }
            }

            return levelData;
        }
    }
}
