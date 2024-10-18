using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class CollisionDetector
    {
        public static CollisionType CheckCollision(CollisionBox obj1, CollisionBox obj2)
        {
            Rectangle rect1 = new Rectangle(obj1.x, obj1.y, obj1.width, obj1.height);
            Rectangle rect2 = new Rectangle(obj2.x, obj2.y, obj2.width, obj2.height);

            if (!rect1.Intersects(rect2))
            {
                return CollisionType.None;
            }
            else
            {
                Rectangle intersection = Rectangle.Intersect(rect1, rect2);

                if (intersection.Width >= intersection.Height)
                {
                    if (rect1.Top < rect2.Top)
                    {
                        Debug.WriteLine("Collision Bottom Detected.");
                        return CollisionType.Bottom;
                    }
                    else
                    {
                        Debug.WriteLine("Collision Top Detected.");
                        return CollisionType.Top;
                    }
                }
                else
                {
                    if (rect1.Left < rect2.Left)
                    {
                        Debug.WriteLine("Collision Right Detected.");
                        return CollisionType.Right;
                    }
                    else
                    {
                        Debug.WriteLine("Collision Left Detected.");
                        return CollisionType.Left;
                    }
                }
            }
        }
    }
}
