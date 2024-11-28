
using SneakyLink.Items;
using SneakyLink.Player;


namespace SneakyLink.Collision
{
    public class PlayerItemHandler
    {
        public static void HandleCollision(Link link, IItem item, Game1 game, ItemSounds sounds)
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
            }
        }
    }
}
