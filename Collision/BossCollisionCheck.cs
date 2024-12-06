using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Blocks;
using SneakyLink.Boss;
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
            //boss and player collision check
            CollisionType side1 = CollisionDetector.CheckCollision(game.link.CollisionBox, game.boss.collisionBox);
            if (game.link.StateMachine.currentState == PlayerState.playerAttacking)
            {
                CollisionType side2 = CollisionDetector.CheckCollision(game.boss.CollisionBox, game.link.StateMachine.sword.collisionBox);
                BossPlayerHandler.HandleCollision(game.boss, side2, game.link.Damage);
            }
            PlayerEnemyHandler.HandleCollision(game.link, side1, playerSounds);

            //boss projectile collision check
            foreach (BossProjectile fireBall in game.boss.projectile)
            {
                CollisionType sideProjectile = CollisionDetector.CheckCollision(game.link.CollisionBox, fireBall.CollisionBox);
                PlayerEnemyHandler.HandleCollision(game.link, sideProjectile, playerSounds);
            }

            // Collision check for bombs and boss
            foreach (var bomb in game.projectileList.OfType<LinkBomb>().ToList()) // Use ToList to avoid modifying the collection during iteration
            {
                    CollisionType bombBossSide = CollisionDetector.CheckCollision(bomb.CollisionBox, game.boss.CollisionBox);
                    if (bombBossSide != CollisionType.None)
                    {
                        BombCollisionHandler.HandleCollision(bomb, game.boss, game);
                    }
            }
        }
    }
}
