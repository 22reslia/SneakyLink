using Microsoft.Xna.Framework;
using SneakyLink.Items;
using SneakyLink.Player;
using System.Diagnostics;


namespace SneakyLink.Collision
{
    public class PlayerItemHandler
    {
        public static void HandleCollision(Link link, IItem item, CollisionType side, Game1 game, ItemSounds sounds)
        {
            if (item is PushableBlock pushableBlock)
            {
                switch (side)
                {
                    case CollisionType.None:
                        pushableBlock.isPushedRight = false;
                        pushableBlock.isPushedLeft = false;
                        pushableBlock.isPushedUp = false;
                        pushableBlock.isPushedDown = false;
                        break;
                    case CollisionType.Left:
                        pushableBlock.isPushedLeft = true;
                        break;
                    case CollisionType.Right:
                        pushableBlock.isPushedRight = true;
                        break;
                    case CollisionType.Top:
                        pushableBlock.isPushedUp = true;
                        break;
                    case CollisionType.Bottom:
                        pushableBlock.isPushedDown = true;
                        break;
                }
                pushableBlock.Push(link.playerPosition);
            }
            else
            {
                game.itemList.Remove(item);
                switch (item)
                {
                    case MapObject:
                        break;
                    case BombObject:
                        link.bombNum++;
                        break;
                    case RupeeObject:
                        sounds.PlayGetRupee();
                        link.coinNum++;
                        break;
                    case KeyObject:
                        sounds.PlayGetRupee();
                        link.keyNum++;
                        break;
                    case HeartContainer:
                        link.maxHealth++;
                        break;
                    case RedPotion: 
                        link.currentHealth++;
                        break;
                    case BluePotion:
                        break;

                }
            }
        }
    }
}