using Microsoft.Xna.Framework;
using SneakyLink.Items;
using SneakyLink.Player;
using System.Diagnostics;


namespace SneakyLink.Collision
{
    public class PlayerItemHandler
    {
        public static void HandleCollision(Link link, IItem item, Game1 game, ItemSounds sounds)
        {
            if (item is PushableBlock pushableBlock)
            {
                pushableBlock.CheckPush(link.collisionBox);
                pushableBlock.Push();
            }
            else
            {
                game.itemList.Remove(item);
                switch (item)
                {
                    case MapObject:
                        game.mapPicked = true;
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
                        link.hasRedpotion = true;
                        break;
                    case BluePotion:
                        link.hasBluepotion = true;
                        break;

                }
            }
        }
    }
}