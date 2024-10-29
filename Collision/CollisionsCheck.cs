using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Player;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class CollisionsCheck
    {
        public static void collisionCheck(Game1 game)
        {
            foreach (IEnemy enemy in game.enemies)
            {
                CollisionType side1 = CollisionDetector.CheckCollision(game.link.linkCB, enemy.CollisionBox);
                CollisionType side2 = CollisionDetector.CheckCollision(enemy.CollisionBox, game.link.linkCB);
                PlayerEnemyHandler.HandleCollision(game.link, side1);
                EnemyPlayerHandler.HandleCollision(enemy, side2);
            }

            //collision detect check for room element
            for (int x = 0; x < game.room.blockList.Count; x++)
            {
                if (game.blocks[x].CollisionBox != null)
                {
                    CollisionType side3 = CollisionDetector.CheckCollision(game.link.linkCB, game.blocks[x].CollisionBox);
                    if (side3 != CollisionType.None)
                    {
                        PlayerBlockHandler.HandleCollision(game.link, side3);
                    }
                    foreach (IEnemy enemy in game.enemies)
                    {
                        CollisionType side4 = CollisionDetector.CheckCollision(enemy.CollisionBox, game.blocks[x].CollisionBox);
                        if (side4 != CollisionType.None)
                        {
                            EnemyBlockHandler.HandleCollision(enemy, side4);
                        }
                    }
                }
            }
            for (int x = 0; x < game.boundaryCollisionBox.Count; x++)
            {
                game.link.linkCB.side = CollisionDetector.CheckCollision(game.link.linkCB, game.boundaryCollisionBox[x]);
                if (game.link.linkCB.side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(game.link, game.link.linkCB.side);
                }
                foreach (IEnemy enemy in game.enemies)
                {
                    enemy.CollisionBox.side = CollisionDetector.CheckCollision(enemy.CollisionBox, game.boundaryCollisionBox[x]);
                    if (enemy.CollisionBox.side != CollisionType.None)
                    {
                        EnemyBlockHandler.HandleCollision(enemy, enemy.CollisionBox.side);
                    }
                }
            }
            for (int x = 0; x < game.doors.Count; x++)
            {
                game.link.linkCB.side = CollisionDetector.CheckCollision(game.link.linkCB, game.doors[x].CollisionBox);
                if (game.link.linkCB.side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(game.link, game.link.linkCB.side);
                }
                foreach (IEnemy enemy in game.enemies)
                {
                    enemy.CollisionBox.side = CollisionDetector.CheckCollision(enemy.CollisionBox, game.doors[x].CollisionBox);
                    if (enemy.CollisionBox.side != CollisionType.None)
                    {
                        EnemyBlockHandler.HandleCollision(enemy, enemy.CollisionBox.side);
                    }
                }
            }
        }
    }
}
