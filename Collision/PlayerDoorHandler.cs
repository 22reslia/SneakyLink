using Microsoft.Xna.Framework.Input;
using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Player;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class PlayerDoorHandler
    {
        public static void HandleCollision(Link link, CollisionType side, String nextDoorFilePath, Vector2 nextLinkPosition, Game1 game)
        {
            //Debug.Print(side.ToString());
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
            //clear the old objects
            game.blocks.Clear();
            game.doors.Clear();
            game.enemies.Clear();
            game.room = new Room(game, nextDoorFilePath);
            game.link.playerPosition = nextLinkPosition;
        }
    }
}
