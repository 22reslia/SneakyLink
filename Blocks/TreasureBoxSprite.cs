using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Blocks
{
    public class TreasureBoxSprite : ISprite
    {
        Texture2D image;
        Rectangle sourceRectangle;

        public TreasureBoxSprite()
        {
            image = BlockSpriteFactory.Instance.GetTreasureBox();
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            sourceRectangle = new Rectangle(0, 0, 254, 254);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(image, new Rectangle(x, y, 40, 40), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
