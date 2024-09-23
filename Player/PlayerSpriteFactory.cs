using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;
public class PlayerSpriteFactory
    {
        private Texture2D linkSpriteSheet;
        private Texture2D linkDamagedSpriteSheet;



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
            linkDamagedSpriteSheet = content.Load<Texture2D>("Link Damage Sprites");

        }

        //moving sprites
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

        //idle sprites
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

        //wooden sword attacking sprites
        public ISprite CreateLinkWoodenAttackRightSprite()
        {
            return new LinkWoodenSwordRight(linkSpriteSheet);
        }
        public ISprite CreateLinkWoodenAttackLeftSprite()
        {
            return new LinkWoodenSwordLeft(linkSpriteSheet);
        }
        public ISprite CreateLinkWoodenAttackForwardSprite()
        {
            return new LinkWoodenSwordForward(linkSpriteSheet);
        }
        public ISprite CreateLinkWoodenAttackBackwardSprite()
        {
            return new LinkWoodenSwordTop(linkSpriteSheet);
        }

        //taking damage sprites
        
        public ISprite CreateLinkDamagedRightSprite()
        {
            return new DamagedLinkRight(linkDamagedSpriteSheet);
        }
        public ISprite CreateLinkDamagedLeftSprite()
        {
            return new DamagedLinkLeft(linkDamagedSpriteSheet);
        }
        public ISprite CreateLinkDamagedForwardSprite()
        {
            return new DamagedLinkForward(linkDamagedSpriteSheet);
        }
        public ISprite CreateLinkDamagedBackwardSprite()
        {
            return new DamagedLinkBack(linkDamagedSpriteSheet);
        }

    }