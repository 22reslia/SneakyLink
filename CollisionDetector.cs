using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class CollisionDetector
    {
        public static CollisionType CheckCollision(ICollision obj1, ICollision obj2)
        {
            Rectangle rect1 = obj1.CollisionBox;
            Rectangle rect2 = obj2.CollisionBox;

            if (!rect1.Intersects(rect2))
                return CollisionType.None;

            Rectangle intersection = Rectangle.Intersect(rect1, rect2);

            if (intersection.Width >= intersection.Height)
            {
                if (rect1.Top < rect2.Top)
                    return CollisionType.Top;
                else
                    return CollisionType.Bottom;
            }
            else
            {
                if (rect1.Left < rect2.Left)
                    return CollisionType.Left;
                else
                    return CollisionType.Right;
            }
        }
    }
}
