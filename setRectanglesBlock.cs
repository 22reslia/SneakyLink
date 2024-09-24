using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class setRectanglesBlock
    {
        private Rectangle[] blockSourceRectangles = new Rectangle[15];

        private static setRectanglesBlock instance = new setRectanglesBlock();
        public static setRectanglesBlock Instance
        {
            get
            {
                return instance;
            }
        }
        public Rectangle[] LoadBlock()
        {
            blockSourceRectangles[0] = new Rectangle(984, 11, 16, 16);
            blockSourceRectangles[1] = new Rectangle(1001, 11, 16, 16);
            blockSourceRectangles[2] = new Rectangle(1018, 11, 16, 16);
            blockSourceRectangles[3] = new Rectangle(1035, 11, 16, 16);
            blockSourceRectangles[4] = new Rectangle(984, 28, 16, 16);
            blockSourceRectangles[5] = new Rectangle(1001, 28, 16, 16);
            blockSourceRectangles[6] = new Rectangle(1018, 28, 16, 16);
            blockSourceRectangles[7] = new Rectangle(1035, 28, 16, 16);
            blockSourceRectangles[8] = new Rectangle(984, 45, 16, 16);
            blockSourceRectangles[9] = new Rectangle(1001, 45, 16, 16);
            blockSourceRectangles[10] = new Rectangle(815, 11, 32, 32);
            blockSourceRectangles[11] = new Rectangle(848, 11, 32, 32);
            blockSourceRectangles[12] = new Rectangle(881, 11, 32, 32);
            blockSourceRectangles[13] = new Rectangle(914, 11, 32, 32);
            blockSourceRectangles[14] = new Rectangle(947, 11, 32, 32);

            return blockSourceRectangles;
        }
    }
}
