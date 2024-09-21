using System;
using System.Data;
using Microsoft.Xna.Framework.Graphics;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    public enum PlayerState {LeftMoving, RightMoving, BackwardMoving, ForwardMoving, LeftIdle, RightIdle, BackwardIdle, ForwardIdle};
    public PlayerState currentState = PlayerState.ForwardIdle;
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
            //cases for animated sprites
            case PlayerState.LeftMoving:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
                break;
            case PlayerState.RightMoving:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
                break;
            case PlayerState.BackwardMoving:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkBackwardSprite();
                break;
            case PlayerState.ForwardMoving:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
                break;

            //cases for idle sprites
            case PlayerState.LeftIdle:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleLeftSprite();
                break;
            case PlayerState.RightIdle:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleRightSprite();
                break;
            case PlayerState.BackwardIdle:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleBackwardSprite();
                break;
            case PlayerState.ForwardIdle:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleForwardSprite();
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