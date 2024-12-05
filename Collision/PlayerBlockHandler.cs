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
        public static void HandleCollision(Game1 game, CollisionType side, CollisionBox targetBlock)
        {
            //sand will not prevent moving but slow down player
            if (targetBlock.type == CollisionObjectType.Sand)
            {
                game.link.velocity = 1;
                if (!game.link.isV && !game.link.hasBluepotion)
                {
                    game.link.currentHealth--;
                    game.link.isV = true;
                }
            }
            else if (targetBlock.type == CollisionObjectType.Stair)
            {
                //clear the old objects
                game.gameState = GameState.RoomTransmission;
                game.oldRoom = game.room;
                game.nextRoomFilePath = "BossRoom";
            }
            else if (targetBlock.type == CollisionObjectType.Box)
            {
                switch (side)
                {
                    case CollisionType.None:
                        game.link.isBlockedLeft = false;
                        game.link.isBlockedRight = false;
                        game.link.isBlockedTop = false;
                        game.link.isBlockedBottom = false;
                        break;
                    case CollisionType.Left:
                        game.link.isBlockedLeft = true;
                        break;
                    case CollisionType.Right:
                        game.link.isBlockedRight = true;
                        break;
                    case CollisionType.Top:
                        game.link.isBlockedTop = true;
                        break;
                    case CollisionType.Bottom:
                        game.link.isBlockedBottom = true;
                        break;
                }
                if (game.link.keyNum > 0)
                {
                    game.link.keyNum--;
                    game.link.maxHealth += 5;
                }
            }
            else
            {
                switch (side)
                {
                    case CollisionType.None:
                        game.link.isBlockedLeft = false;
                        game.link.isBlockedRight = false;
                        game.link.isBlockedTop = false;
                        game.link.isBlockedBottom = false;
                        break;
                    case CollisionType.Left:
                        game.link.isBlockedLeft = true;
                        break;
                    case CollisionType.Right:
                        game.link.isBlockedRight = true;
                        break;
                    case CollisionType.Top:
                        game.link.isBlockedTop = true;
                        break;
                    case CollisionType.Bottom:
                        game.link.isBlockedBottom = true;
                        break;
                }
            }
        }
    }
}
