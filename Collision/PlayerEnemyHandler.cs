using Microsoft.Xna.Framework.Input;
using SneakyLink.Enemies;
using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Collision
{
    public class PlayerEnemyHandler
    {
        private ISprite currentSprite;
        public void HandleCollision(Link link, ICollision other, CollisionType collisionType)
        {
            switch (collisionType)
            {
                case CollisionType.None:
                    break;
                case CollisionType.Left:
                    currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedLeftSprite();
                    break;
                case CollisionType.Right:
                    currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedRightSprite();
                    break;
                case CollisionType.Top:
                    currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedBackwardSprite();
                    break;
                case CollisionType.Bottom:
                    currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedForwardSprite();
                    break;
            }
        }
    }
}
