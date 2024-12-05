using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;

namespace SneakyLink.Enemies
{
    public interface IEnemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int mHealth { get; set; }
        public int cHealth { get; set; }
        public bool isBlockedL { get; set; }
        public bool isBlockedR { get; set; }
        public bool isBlockedT { get; set; }
        public bool isBlockedB { get; set; }
        public bool IsV { get; set; }
        public CollisionBox CollisionBox { get; set; }

        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}