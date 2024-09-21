using System;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    public enum PlayerState {LeftNormal, RightNormal, BackwardNormal, ForwardNormal};
    public PlayerState currentState = PlayerState.ForwardNormal;
    private PlayerState previousState;
    private ISprite currentSprite;
    private float idleTimer = 0f;  // Timer to track inactivity
    private float idleDelay = 0.1f;  // 0.1 seconds delay before switching to idle

    //Constructor to initialize previousState
    public PlayerStateMachine()
    {
        previousState = currentState;

        //intializes the forward sprite as the default sprite
        currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleForwardSprite();
    }

    //creates an ISprite object for each different enum
    public ISprite GetCurrentMovingSprite()
    {
        switch (currentState)
        {   
            //cases for animated sprites
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

    public ISprite GetCurrentIdleSprite()
    {   
        switch (currentState)
        {

            //cases for idle sprites
            case PlayerState.LeftNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleLeftSprite();
                break;
            case PlayerState.RightNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleRightSprite();
                break;
            case PlayerState.BackwardNormal:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleBackwardSprite();
                break;
            case PlayerState.ForwardNormal:
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

    public ISprite Update(GameTime gameTime)
    {   
        KeyboardState keyState = Keyboard.GetState();
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        
        if(idleDelay < deltaTime && PlayerSpriteStateChange())
        {
            currentSprite = GetCurrentMovingSprite();
        }
        else if (idleDelay < deltaTime)
        {
            currentSprite = GetCurrentIdleSprite();
            deltaTime = 0f;
        }
        return currentSprite;
    }
}