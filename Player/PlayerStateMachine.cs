using System;
using System.Data;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    public enum PlayerState {LeftNormal, RightNormal, BackwardNormal, ForwardNormal};
    public PlayerState currentState = PlayerState.ForwardNormal;
    private PlayerState previousState;
    private ISprite currentSprite;

    //Constructor to initialize previousState
    public PlayerStateMachine()
    {
        previousState = currentState;

        //intializes the forward sprite as the default sprite
        currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
    }

    //creates an ISprite object for each different enum
    public ISprite GetCurrentSprite()
    {
        switch (currentState)
        {
            case PlayerState.LeftNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
                break;
            case PlayerState.RightNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
                break;
            case PlayerState.BackwardNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkBackwardSprite();
                break;
            case PlayerState.ForwardNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
                break;
        }
        return currentSprite;
    }

    //checks for state change
    public bool PlayerSpriteStateChange()
    {
        bool stateChange = false;
        if (currentState != previousState)
        {
            previousState = currentState;
            stateChange = true;
        }
        return stateChange;
    }


    //draws the sprite
    public void Draw(SpriteBatch spriteBatch, ISprite playerSprite, int x, int y)
        {
            playerSprite.Draw(spriteBatch, x, y);
        }

    public ISprite Update()
    {
        if(PlayerSpriteStateChange())
        {
            currentSprite = GetCurrentSprite();
        }
        return currentSprite;
    }
}