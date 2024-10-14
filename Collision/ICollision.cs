using Microsoft.Xna.Framework;

namespace SneakyLink.Collision
{
    public enum CollisionType { None, Left, Right, Top, Bottom }
    public enum CollisionObjectType { Player, Enemy, Block, Interactive };

    public interface ICollision
    {
        CollisionObjectType ObjectType { get; }
        void OnCollision(ICollision other, CollisionType collisionType);
    }
}
