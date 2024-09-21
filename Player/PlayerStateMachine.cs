using System;
using System.Data;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    public enum PlayerState {LeftNormal, RightNormal, BackwardNormal, ForwardNormal};
    public PlayerState currentState = PlayerState.ForwardNormal;
    private PlayerState previousState;

    //Constructor to initialize previousState
    public PlayerStateMachine()
    {
        previousState = currentState;
    }

    //creates an ISprite object for each different enum
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

    //checks for state change
    public bool PlayerSpriteStateChange()
    {   
        bool StateChange = false;
        if (currentState != previousState)
        {
            StateChange = true;
        }
        return StateChange;
    }

    //draws the sprite
    public void Draw(SpriteBatch spriteBatch, ISprite playerSprite, int x, int y)
        {
            playerSprite.Draw(spriteBatch, x, y);
        }
}