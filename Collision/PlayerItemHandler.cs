
using SneakyLink.Items;
using SneakyLink.Player;


namespace SneakyLink.Collision
{
    public class PlayerItemHandler
    {
        public static void HandleCollision(Link link, IItem item, Game1 game)
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
                    link.coinNum++;
                    break;
            }
        }
    }
}
