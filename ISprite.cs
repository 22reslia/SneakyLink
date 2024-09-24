using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakyLink
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, int x, int y);
    }
}
