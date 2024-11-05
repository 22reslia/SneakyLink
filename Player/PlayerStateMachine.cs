using System;
using System.Data;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SneakyLink.Player;

public class PlayerStateMachine
{
    public PlayerState currentState = PlayerState.playerIdle;
    public PlayerDirection currentDirection = PlayerDirection.playerDown;
    private PlayerState previousState;
    private PlayerDirection previousDirection;
    private ISprite currentSprite;
    public Sword sword;
    private Link link;
    private bool isMoving = false;

    //Constructor to initialize previousState
    public PlayerStateMachine(Vector2 initialPosition, Link link)
    {
        previousState = currentState;
        previousDirection = currentDirection;

        //intializes the forward sprite as the default sprite
        currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleForwardSprite();
        this.link = link;
    }

    //creates an ISprite object for each different enum
    public ISprite GetCurrentMovingSprite()
    {
        switch (currentDirection)
        {   
            //cases for animated sprites
            case PlayerDirection.playerLeft:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkLeftSprite();
                break;
            case PlayerDirection.playerRight:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkRightSprite();
                break;
            case PlayerDirection.playerUp:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkBackwardSprite();
                break;
            case PlayerDirection.playerDown:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkForwardSprite();
                break;
        }
        return currentSprite;
    }

    public ISprite GetCurrentIdleSprite()
    {   
        switch (currentDirection)
        {

            //cases for idle sprites
            case PlayerDirection.playerLeft:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleLeftSprite();
                break;
            case PlayerDirection.playerRight:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleRightSprite();
                break;
            case PlayerDirection.playerUp:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleBackwardSprite();
                break;
            case PlayerDirection.playerDown:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkIdleForwardSprite();
                break;
        }
        return currentSprite;
    }

    public ISprite GetCurrentWoodenAttackingSprite()
    {   
        switch (currentDirection)
        {

            //cases for idle sprites
            case PlayerDirection.playerLeft:
                sword = new Sword((int)link.playerPosition.X - 24, (int)link.playerPosition.Y + (38 - 32) / 2);
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkWoodenAttackLeftSprite();
                break;
            case PlayerDirection.playerRight:
                sword = new Sword((int)link.playerPosition.X + 64, (int)link.playerPosition.Y + (38 - 32) / 2);
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkWoodenAttackRightSprite();
                break;
            case PlayerDirection.playerUp:
                sword = new Sword((int)link.playerPosition.X + (38 - 24) / 2, (int)link.playerPosition.Y - 32);
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkWoodenAttackBackwardSprite();
                break;
            case PlayerDirection.playerDown:
                sword = new Sword((int)link.playerPosition.X + (38 - 24) / 2, (int)link.playerPosition.Y + 64);
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkWoodenAttackForwardSprite();
                break;
        }
        return currentSprite;
    }

    public ISprite GetCurrentDamagedSprite()
    {   
        switch (currentDirection)
        {

            //cases for idle sprites
            case PlayerDirection.playerLeft:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedLeftSprite();
                break;
            case PlayerDirection.playerRight:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedRightSprite();
                break;
            case PlayerDirection.playerUp:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedBackwardSprite();
                break;
            case PlayerDirection.playerDown:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkDamagedForwardSprite();
                break;
        }
        return currentSprite;
    }

     public ISprite GetCurrentUseItemSprite()
    {   
        switch (currentDirection)
        {

            //cases for idle sprites
            case PlayerDirection.playerLeft:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkUseItemLeftSprite();
                break;
            case PlayerDirection.playerRight:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkUseItemRightSprite();
                break;
            case PlayerDirection.playerUp:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkUseItemNorthSprite();
                break;
            case PlayerDirection.playerDown:
                currentSprite = PlayerSpriteFactory.Instance.CreateLinkUseItemSouthSprite();
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

    //checks for directional change
    public bool PlayerSpriteDirectionChange()
    {
        bool directionChange = false;
        if (currentDirection != previousDirection)
        {
            previousDirection = currentDirection;
            directionChange = true;
        }
        return directionChange;
    }

    //Link Position State
    public bool LinkPositionIdle()
    {   
        KeyboardState keyboardState = Keyboard.GetState();

        if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.Left))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        return isMoving;
    }

    //draws the sprite
    public void Draw(SpriteBatch spriteBatch, ISprite playerSprite, int x, int y)
        {
            playerSprite.Draw(spriteBatch, x, y);
        }

    public ISprite Update(GameTime gameTime)
    {
        // float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        // float timer = 0f;
        // float stopTime = 5f;
        
         if (PlayerSpriteStateChange() || PlayerSpriteDirectionChange())
        {
            switch (currentState)
            {
                case PlayerState.playerMoving:
                    currentSprite = GetCurrentMovingSprite();
                    break;
                case PlayerState.playerIdle:
                    currentSprite = GetCurrentIdleSprite();
                    break;
                case PlayerState.playerAttacking:
                    currentSprite = GetCurrentWoodenAttackingSprite();
                    break;
                case PlayerState.playerDamaged:
                    currentSprite = GetCurrentDamagedSprite();
                    break;
                case PlayerState.playerUseItem:
                    currentSprite = GetCurrentUseItemSprite();
                    break;
            }
        }

        return currentSprite;
    }
}