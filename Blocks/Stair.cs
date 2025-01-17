﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class Stair : IBlock
    {
        private ISprite stairSprite;
        private int x, y;
        private CollisionBox collisionBox;
        public CollisionBox CollisionBox { get => collisionBox; set => collisionBox = value; }
        public Stair(int positionX, int positionY)
        {
            stairSprite = new StairSprite();
            x = positionX;
            y = positionY;
            collisionBox = new CollisionBox(CollisionObjectType.Stair, 40, 40, x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            stairSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
    }
}
