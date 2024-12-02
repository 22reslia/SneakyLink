using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Items;
using SneakyLink.Player;
using SneakyLink.Projectiles;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class BossCollisionCheck
    {
        public static void collisionCheck(Game1 game)
        {
            PlayerSounds playerSounds = game.playerSounds;
            CollisionType side1 = CollisionDetector.CheckCollision(game.link.collisionBox, game.boss.collisionBox);
            PlayerEnemyHandler.HandleCollision(game.link, side1, playerSounds);
        }
    }
}
