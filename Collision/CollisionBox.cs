namespace SneakyLink.Collision
{
    public class CollisionBox : ICollision
    {
        public CollisionType side;
        public CollisionObjectType type;
        public int width, height;
        public int x, y;
        public CollisionBox(CollisionObjectType type, int width, int height, int x, int y)
        {
            this.type = type;
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }
        public CollisionObjectType ObjectType => type;
    }
}