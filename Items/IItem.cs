using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink.Items
{
    public interface IItem
    {
        public CollisionBox CollisionBox { get; set; }

        public void Draw(SpriteBatch spriteBatch);

        public void Update();
    }
}
