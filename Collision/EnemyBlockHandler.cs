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
        public static void HandleCollision(IEnemy enemy, CollisionType side)
        {
            //Debug.Print(side.ToString());
            switch (side)
            {
                case CollisionType.None:
                    enemy.isBlockedL = false;
                    enemy.isBlockedR = false;
                    enemy.isBlockedT = false;
                    enemy.isBlockedB = false;
                    break;
                case CollisionType.Left:
                    enemy.isBlockedL = true;
                    break;
                case CollisionType.Right:
                    enemy.isBlockedR = true;
                    break;
                case CollisionType.Top:
                    enemy.isBlockedT = true;
                    break;
                case CollisionType.Bottom:
                    enemy.isBlockedB = true;
                    break;
            }
        }
    }
}
