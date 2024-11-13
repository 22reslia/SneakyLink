using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SneakyLink.Projectiles;

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
    private IProjectile currentProjectile;

    public PlayerItem currentItem = PlayerItem.None;

    private bool isAttacking = false;

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

    public void Attack(Vector2 linkPosition)
{
        Vector2 projectilePosition = linkPosition;
        Vector2 projectileVelocity = Vector2.Zero;

        // Select projectile type based on current item
        switch (currentItem)
        {
            case PlayerItem.Bow:
                currentProjectile = new LinkArrow((int)projectilePosition.X, (int)projectilePosition.Y);
                Console.WriteLine("current projectile" + currentProjectile);
                break;
            case PlayerItem.Fireball:
                currentProjectile = new LinkFire((int)projectilePosition.X, (int)projectilePosition.Y);
                break;

            default:
                currentProjectile = new LinkBomb((int)projectilePosition.X, (int)projectilePosition.Y);
                break;
            
        }

        // Set position and velocity based on Link's direction
        switch (currentDirection)
        {
            case PlayerDirection.playerLeft:
                projectilePosition += new Vector2(-20, 0);
                projectileVelocity = new Vector2(-5, 0);
                break;
            case PlayerDirection.playerRight:
                projectilePosition += new Vector2(20, 0);
                projectileVelocity = new Vector2(5, 0);
                break;
            case PlayerDirection.playerUp:
                projectilePosition += new Vector2(0, -20);
                projectileVelocity = new Vector2(0, -5);
                break;
            case PlayerDirection.playerDown:
                projectilePosition += new Vector2(0, 20);
                projectileVelocity = new Vector2(0, 5);
                break;
        }

        // Set position and shoot the projectile
        currentProjectile.Position = projectilePosition;
        currentProjectile.Shoot(projectileVelocity.X, projectileVelocity.Y);
        
        // Display the "use item" sprite
        currentSprite = GetCurrentUseItemSprite();
        isAttacking = true;
    

    // Update the projectile's movement and check for its end state
    if (currentProjectile != null)
    {
        //if (currentProjectile.HasCollided || currentProjectile.IsOutOfBounds())
        if (currentProjectile.HasCollided)
        {
            currentProjectile = null; // Remove projectile if it hits something or goes out of bounds
            isAttacking = false;
            ResetToIdleOrMovingSprite(); // Reset Link's sprite after attack is done
        }
    }
}

// Helper method to reset Link's sprite to idle or moving after using an item
private void ResetToIdleOrMovingSprite()
{
    switch (currentState)
    {
        case PlayerState.playerIdle:
            currentSprite = GetCurrentIdleSprite();
            break;
        case PlayerState.playerMoving:
            currentSprite = GetCurrentMovingSprite();
            break;
    }
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
            if (currentProjectile != null)
            {
                currentProjectile.Draw(spriteBatch);
            }
            playerSprite.Draw(spriteBatch, x, y);
        }

    public ISprite Update(GameTime gameTime)
    {
        // float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        // float timer = 0f;
        // float stopTime = 5f;
        if (currentProjectile != null)
        {
            currentProjectile.Update();
        }
        
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
                    Attack(link.playerPosition);
                    break;
            }
        }

        return currentSprite;
    }
}