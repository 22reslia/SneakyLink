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
    public class EnemyBlockHandler
    {
        public static void HandleCollision(Gel enemy, CollisionType side)
        {
            //Debug.Print(side.ToString());
            switch (side)
            {
                case CollisionType.None:
                    enemy.isBlockedLeft = false;
                    enemy.isBlockedRight = false;
                    enemy.isBlockedTop = false;
                    enemy.isBlockedBottom = false;
                    break;
                case CollisionType.Left:
                    enemy.isBlockedLeft = true;
                    break;
                case CollisionType.Right:
                    enemy.isBlockedRight = true;
                    break;
                case CollisionType.Top:
                    enemy.isBlockedTop = true;
                    break;
                case CollisionType.Bottom:
                    enemy.isBlockedBottom = true;
                    break;
            }
        }
    }
}
