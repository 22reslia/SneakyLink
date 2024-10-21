using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink
{
    public interface IEnemy
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public bool isBlockedL { get; set; }
        public bool isBlockedR { get; set; }
        public bool isBlockedT { get; set; }
        public bool isBlockedB { get; set; }

        public CollisionBox CollisionBox { get; set; }

        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}