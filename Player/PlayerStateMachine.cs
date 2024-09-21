using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    private enum PlayerState {LeftNormal, RightNormal, BackwardNormal, ForwardNormal};
    private PlayerState currentState = PlayerState.ForwardNormal;

    public ISprite GetCurrentSprite()
    {
        ISprite currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
        if(currentState == PlayerState.LeftNormal)
        {
            currentSprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
        }
        else if(currentState == PlayerState.RightNormal)
        {
            currentSprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
        }
        else if(currentState == PlayerState.BackwardNormal)
        {
            currentSprite = PlayerSpriteFactory.Instance.CreateLinkBackwardSprite();
        }
        else if(currentState == PlayerState.ForwardNormal)
        {
            currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
        }

        return currentSprite;
    }
    public void Draw(SpriteBatch spriteBatch, ISprite playerSprite, int x, int y)
        {
            playerSprite.Draw(spriteBatch, x, y);
        }
}