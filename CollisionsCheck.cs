using SneakyLink.Blocks;
using SneakyLink.Collision;
using SneakyLink.Enemies;
using SneakyLink.Player;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public class CollisionsCheck
    {
        public static void collisionCheck(Game1 game)
        {
            CollisionType side1 = CollisionDetector.CheckCollision(game.link.collisionBox, game.gel.collisionBox);
            CollisionType side2 = CollisionDetector.CheckCollision(game.gel.CollisionBox, game.link.collisionBox);
            PlayerEnemyHandler.HandleCollision(game.link, side1);
            EnemyPlayerHandler.HandleCollision(game.gel, side2);

            //collision detect check for room element
            for (int x = 0; x < game.room.blockList.Count; x++)
            {
                if (game.blocks[x].CollisionBox != null)
                {
                    CollisionType side3 = CollisionDetector.CheckCollision(game.link.collisionBox, game.blocks[x].CollisionBox);
                    CollisionType side4 = CollisionDetector.CheckCollision(game.gel.CollisionBox, game.blocks[x].CollisionBox);
                    if (side3 != CollisionType.None)
                    {
                        PlayerBlockHandler.HandleCollision(game.link, side3);
                    }
                    if (side4 != CollisionType.None)
                    {
                        EnemyBlockHandler.HandleCollision(game.gel, side4);
                    }
                }
            }
            for (int x = 0; x < game.boundaryCollisionBox.Count; x++)
            {
                game.link.collisionBox.side = CollisionDetector.CheckCollision(game.link.collisionBox, game.boundaryCollisionBox[x]);
                game.gel.CollisionBox.side = CollisionDetector.CheckCollision(game.gel.CollisionBox, game.boundaryCollisionBox[x]);
                if (game.link.collisionBox.side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(game.link, game.link.collisionBox.side);
                }
                if (game.gel.CollisionBox.side != CollisionType.None)
                {
                    EnemyBlockHandler.HandleCollision(game.gel, game.gel.CollisionBox.side);
                }
            }
            for (int x = 0; x < game.doors.Count; x++)
            {
                game.link.collisionBox.side = CollisionDetector.CheckCollision(game.link.collisionBox, game.doors[x].CollisionBox);
                game.gel.CollisionBox.side = CollisionDetector.CheckCollision(game.gel.CollisionBox, game.doors[x].CollisionBox);
                if (game.link.collisionBox.side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(game.link, game.link.collisionBox.side);
                }
                if (game.gel.CollisionBox.side != CollisionType.None)
                {
                    EnemyBlockHandler.HandleCollision(game.gel, game.gel.CollisionBox.side);
                }
            }
        }
    }
}
