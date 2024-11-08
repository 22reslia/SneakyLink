using Microsoft.Xna.Framework.Input;
using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class PlayerBlockHandler
    {
        public static void HandleCollision(Link link, CollisionType side, CollisionBox targetBlock)
        {
            //Debug.Print(side.ToString());
            //sand will not prevent moving but slow down player
            if (targetBlock.type == CollisionObjectType.Sand)
            {
                link.velocity = 1;
            }
            else
            {
                link.velocity = 3;
                switch (side)
                {
                    case CollisionType.None:
                        link.isBlockedLeft = false;
                        link.isBlockedRight = false;
                        link.isBlockedTop = false;
                        link.isBlockedBottom = false;
                        break;
                    case CollisionType.Left:
                        link.isBlockedLeft = true;
                        break;
                    case CollisionType.Right:
                        link.isBlockedRight = true;
                        break;
                    case CollisionType.Top:
                        link.isBlockedTop = true;
                        break;
                    case CollisionType.Bottom:
                        link.isBlockedBottom = true;
                        break;
                }
            }
        }
    }
}
