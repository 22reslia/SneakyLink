using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class setRectanglesItem
    {
        private Rectangle[] compass = new Rectangle[1];
        private Rectangle[] map = new Rectangle[1];
        private Rectangle[] key = new Rectangle[1];
        private Rectangle[] heartContainer = new Rectangle[1];
        private Rectangle[] triforcePiece = new Rectangle[2];
        private Rectangle[] woodenBoomerang = new Rectangle[1];
        private Rectangle[] bow = new Rectangle[1];
        private Rectangle[] heart = new Rectangle[2];
        private Rectangle[] rupee = new Rectangle[2];
        private Rectangle[] arrow = new Rectangle[1];
        private Rectangle[] bomb = new Rectangle[1];
        private Rectangle[] fairy = new Rectangle[2];
        private Rectangle[] clock = new Rectangle[1];

        private static setRectanglesItem instance = new setRectanglesItem();
        public static setRectanglesItem Instance
        {
            get
            {
                return instance;
            }
        }

        public setRectanglesItem()
        {
            compass[0] = new Rectangle(258, 1, 11, 12);
            map[0] = new Rectangle(88, 0, 8, 16);
            key[0] = new Rectangle(240, 0, 8, 16);
            heartContainer[0] = new Rectangle(25, 1, 13, 13);
            triforcePiece[0] = new Rectangle(275, 3, 10, 10);
            triforcePiece[1] = new Rectangle(275, 19, 10, 10);
            woodenBoomerang[0] = new Rectangle(129, 3, 5, 8);
            bow[0] = new Rectangle(144, 0, 8, 16);
            heart[0] = new Rectangle(0, 0, 7, 8);
            heart[1] = new Rectangle(0, 8, 7, 8);
            rupee[0] = new Rectangle(72, 0, 8, 16);
            rupee[1] = new Rectangle(72, 16, 8, 16);
            arrow[0] = new Rectangle(154, 0, 5, 16);
            bomb[0] = new Rectangle(136, 0, 8, 14);
            fairy[0] = new Rectangle(40, 0, 8, 17);
            fairy[1] = new Rectangle(48, 0, 8, 17);
            clock[0] = new Rectangle(58, 0, 11, 16);
        }

        public Rectangle[] Compass()
        {
            return compass;
        }
        public Rectangle[] Map()
        {
            return map;
        }
        public Rectangle[] Key()
        {
            return key;
        }
        public Rectangle[] HeartContainer()
        {
            return heartContainer;
        }
        public Rectangle[] TriforcePiece()
        {
            return triforcePiece;
        }
        public Rectangle[] WoodenBoomerang()
        {
            return woodenBoomerang;
        }
        public Rectangle[] Bow()
        {
            return bow;
        }
        public Rectangle[] Heart()
        {
            return heart;
        }
        public Rectangle[] Rupee()
        {
            return rupee;
        }
        public Rectangle[] Arrow()
        {
            return arrow;
        }
        public Rectangle[] Bomb()
        {
            return bomb;
        }
        public Rectangle[] Fairy()
        {
            return fairy;
        }
        public Rectangle[] Clock()
        {
            return clock;
        }
    }
}
