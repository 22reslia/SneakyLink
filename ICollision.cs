using Microsoft.Xna.Framework;

namespace SneakyLink
{
    public enum CollisionType { None, Left, Right, Top, Bottom }
    public enum CollisionObjectType { Player, Enemy, Block };

    public interface ICollision
    {
        Rectangle CollisionBox { get; }
        CollisionObjectType ObjectType { get; }
        void OnCollision(ICollision other, CollisionType collisionType);
    }
}
