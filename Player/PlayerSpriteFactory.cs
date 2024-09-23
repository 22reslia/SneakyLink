using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;
public class PlayerSpriteFactory
    {
        private Texture2D linkSpriteSheet;
        private Texture2D linkDamagedSpriteSheetBlue;
        private Texture2D linkDamagedSpriteSheetBlueandWhite;
        private Texture2D linkDamagedSpriteSheetRedandBlack;



        private static PlayerSpriteFactory instance = new PlayerSpriteFactory();

        public static PlayerSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private PlayerSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("Link Sprite Sheet");
            linkDamagedSpriteSheetBlue = content.Load<Texture2D>("Link Sprite Sheet Blue");
            linkDamagedSpriteSheetBlueandWhite = content.Load<Texture2D>("Link Sprite Sheet Blue and White");
            linkDamagedSpriteSheetRedandBlack = content.Load<Texture2D>("Link Sprite Sheet Red and Black");

        }

        public ISprite CreateLinkRightSprite()
        {
            return new LinkRight(linkSpriteSheet);
        }
        public ISprite CreateLinkLeftSprite()
        {
            return new LinkLeft(linkSpriteSheet);
        }
        public ISprite CreateLinkForwardSprite()
        {
            return new LinkForward(linkSpriteSheet);
        }
        public ISprite CreateLinkBackwardSprite()
        {
            return new LinkBack(linkSpriteSheet);
        }
        public ISprite CreateLinkIdleRightSprite()
        {
            return new LinkRightIdle(linkSpriteSheet);
        }
        public ISprite CreateLinkIdleLeftSprite()
        {
            return new LinkLeftIdle(linkSpriteSheet);
        }
        public ISprite CreateLinkIdleForwardSprite()
        {
            return new LinkForwardIdle(linkSpriteSheet);
        }
        public ISprite CreateLinkIdleBackwardSprite()
        {
            return new LinkBackIdle(linkSpriteSheet);
        }

    }