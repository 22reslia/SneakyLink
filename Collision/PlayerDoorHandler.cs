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
            switch (side)
            {
                case CollisionType.None:
                    link.IsBlockedLeft = false;
                    link.IsBlockedRight = false;
                    link.IsBlockedTop = false;
                    link.IsBlockedBottom = false;
                    break;
                case CollisionType.Left:
                    link.IsBlockedLeft = true;
                    break;
                case CollisionType.Right:
                    link.IsBlockedRight = true;
                    break;
                case CollisionType.Top:
                    link.IsBlockedTop = true;
                    break;
                case CollisionType.Bottom:
                    link.IsBlockedBottom = true;
                    break;
            }
            //clear the old objects
            game.gameState = GameState.RoomTransmission;
            game.oldRoom = game.room;

            game.nextRoomFilePath = nextDoorFilePath;
            game.link.PlayerPosition = nextLinkPosition;
        }
    }
}
