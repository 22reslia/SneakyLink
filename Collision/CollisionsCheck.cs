using SneakyLink.Blocks;
using SneakyLink.Enemies;
using SneakyLink.Items;
using SneakyLink.Player;
using SneakyLink.Scene;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class CollisionsCheck
    {
        public static void collisionCheck(Game1 game)
        {
            //collision check for enemy
            foreach (IEnemy enemy in game.enemies)
            {
                CollisionType side1 = CollisionDetector.CheckCollision(game.link.collisionBox, enemy.CollisionBox);
                //Debug.Print(game.link.stateMachine.currentState.ToString());
                if (game.link.stateMachine.currentState == PlayerState.playerAttacking)
                {
                    CollisionType side2 = CollisionDetector.CheckCollision(enemy.CollisionBox, game.link.stateMachine.sword.collisionBox);
                    EnemyPlayerHandler.HandleCollision(enemy, side2);
                }
                PlayerEnemyHandler.HandleCollision(game.link, side1);
            }

            //collision check for room item
            List<IItem> itemPicked = new List<IItem>();
            foreach (IItem item in game.itemList)
            {
                CollisionType side = CollisionDetector.CheckCollision(game.link.collisionBox, item.CollisionBox);
                if (side != CollisionType.None)
                {
                    itemPicked.Add(item);
                }
            }
            foreach (IItem item in itemPicked)
            {
                PlayerItemHandler.HandleCollision(game.link, item, game);
            }

            //collision detect check for room element
            for (int x = 0; x < game.room.blockList.Count; x++)
            {
                if (game.blocks[x].CollisionBox != null)
                {
                    CollisionType side3 = CollisionDetector.CheckCollision(game.link.collisionBox, game.blocks[x].CollisionBox);
                    if (side3 != CollisionType.None)
                    {
                        PlayerBlockHandler.HandleCollision(game.link, side3, game.blocks[x].CollisionBox);
                    }
                    foreach (IEnemy enemy in game.enemies)
                    {
                        CollisionType side4 = CollisionDetector.CheckCollision(enemy.CollisionBox, game.blocks[x].CollisionBox);
                        if (side4 != CollisionType.None)
                        {
                            EnemyBlockHandler.HandleCollision(enemy, side4, game.blocks[x].CollisionBox);
                        }
                    }
                }
            }
            for (int x = 0; x < game.boundaryCollisionBox.Count; x++)
            {
                game.link.collisionBox.side = CollisionDetector.CheckCollision(game.link.collisionBox, game.boundaryCollisionBox[x]);
                if (game.link.collisionBox.side != CollisionType.None)
                {
                    PlayerBlockHandler.HandleCollision(game.link, game.link.collisionBox.side, game.boundaryCollisionBox[x]);
                }
                foreach (IEnemy enemy in game.enemies)
                {
                    enemy.CollisionBox.side = CollisionDetector.CheckCollision(enemy.CollisionBox, game.boundaryCollisionBox[x]);
                    if (enemy.CollisionBox.side != CollisionType.None)
                    {
                        EnemyBlockHandler.HandleCollision(enemy, enemy.CollisionBox.side, game.boundaryCollisionBox[x]);
                    }
                }
            }
            for (int x = 0; x < game.doors.Count; x++)
            {
                game.link.collisionBox.side = CollisionDetector.CheckCollision(game.link.collisionBox, game.doors[x].CollisionBox);
                if (game.link.collisionBox.side != CollisionType.None)
                {
                    if (game.doors[x].NextRoomFilePath != "")
                    {
                        //Debug.Print(game.link.playerPosition.ToString());
                        PlayerDoorHandler.HandleCollision(game.link, game.link.collisionBox.side, game.doors[x].NextRoomFilePath, game.doors[x].NextLinkPosition, game);
                    }
                    else
                    {
                        //Debug.Print(game.link.playerPosition.ToString());
                        PlayerBlockHandler.HandleCollision(game.link, game.link.collisionBox.side, game.doors[x].CollisionBox);
                    }
                }
                foreach (IEnemy enemy in game.enemies)
                {
                    enemy.CollisionBox.side = CollisionDetector.CheckCollision(enemy.CollisionBox, game.doors[x].CollisionBox);
                    if (enemy.CollisionBox.side != CollisionType.None)
                    {
                        EnemyBlockHandler.HandleCollision(enemy, enemy.CollisionBox.side, game.doors[x].CollisionBox);
                    }
                }
            }
        }
    }
}
