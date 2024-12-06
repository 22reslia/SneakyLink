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
                game.link.Velocity = 1;
                if (!game.link.IsV && !game.link.HasBluePotion)
                {
                    game.link.CurrentHealth--;
                    game.link.IsV = true;
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
                        game.link.IsBlockedLeft = false;
                        game.link.IsBlockedRight = false;
                        game.link.IsBlockedTop = false;
                        game.link.IsBlockedBottom = false;
                        break;
                    case CollisionType.Left:
                        game.link.IsBlockedLeft = true;
                        break;
                    case CollisionType.Right:
                        game.link.IsBlockedRight = true;
                        break;
                    case CollisionType.Top:
                        game.link.IsBlockedTop = true;
                        break;
                    case CollisionType.Bottom:
                        game.link.IsBlockedBottom = true;
                        break;
                }
                if (game.link.KeyNum > 0)
                {
                    game.link.KeyNum--;
                    game.link.MaxHealth += 5;
                }
            }
            else
            {
                switch (side)
                {
                    case CollisionType.None:
                        game.link.IsBlockedLeft = false;
                        game.link.IsBlockedRight = false;
                        game.link.IsBlockedTop = false;
                        game.link.IsBlockedBottom = false;
                        break;
                    case CollisionType.Left:
                        game.link.IsBlockedLeft = true;
                        break;
                    case CollisionType.Right:
                        game.link.IsBlockedRight = true;
                        break;
                    case CollisionType.Top:
                        game.link.IsBlockedTop = true;
                        break;
                    case CollisionType.Bottom:
                        game.link.IsBlockedBottom = true;
                        break;
                }
            }
        }
    }
}
