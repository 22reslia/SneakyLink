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
                pushableBlock.CheckPush(link.CollisionBox);
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
                        link.BombNum++;
                        break;
                    case RupeeObject:
                        sounds.PlayGetRupee();
                        link.CoinNum++;
                        break;
                    case KeyObject:
                        sounds.PlayGetRupee();
                        link.KeyNum++;
                        break;
                    case HeartContainer:
                        link.MaxHealth++;
                        link.CurrentHealth++;
                        break;
                    case RedPotion: 
                        link.HasRedPotion = true;
                        break;
                    case BluePotion:
                        link.HasBluePotion = true;
                        break;

                }
            }
        }
    }
}