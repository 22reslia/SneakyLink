using SneakyLink.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public interface ICollisionHandler
    {
        void HandleCollision(Link link, ICollision other, CollisionType collisionType);
    }
}
