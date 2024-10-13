﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Blocks
{
    public class BlueGap : IBlock, ICollision
    {
        private ISprite blueGapSprite;
        private int x, y;
        private int width = 40, height = 40;
        public Rectangle CollisionBox => new Rectangle(x, y, width, height);
        public CollisionObjectType ObjectType => CollisionObjectType.Block;
        public BlueGap(int positionX, int positionY)
        {
            blueGapSprite = new BlueGapSprite();
            x = positionX;
            y = positionY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blueGapSprite.Draw(spriteBatch, x, y);
        }

        public void Update()
        {

        }
        public void OnCollision(ICollision other, CollisionType collisionType)
        {
            
        }
    }
}