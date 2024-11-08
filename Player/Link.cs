using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SneakyLink.Collision;
using SneakyLink.Enemies;

namespace SneakyLink.Player;
public class Link
{
    public Vector2 playerPosition;
    public PlayerStateMachine stateMachine;
    public CollisionBox collisionBox;
    public ISprite playerSprite;
    public int velocity;
    float timer = 0f;
    float stopTime = 1f;

    //states for collision
    public bool isBlockedTop;
    public bool isBlockedBottom;
    public bool isBlockedLeft;
    public bool isBlockedRight;

    //hp
    public bool isV;
    public bool isMovable;
    public int maxHealth;
    public int currentHealth;

    private int vCounter;
    private int mCounter;

    //link collective items info
    public int coinNum;
    public int keyNum;
    public int bombNum;

    //creats a player with basic stats
    public Link()
    {
        maxHealth = 16;
        currentHealth = maxHealth;
        isV = false;
        isMovable = true;

        velocity = 3;
        playerPosition.X = 100;
        playerPosition.Y = 100;

        isBlockedTop = false;
        isBlockedBottom = false;
        isBlockedLeft = false;
        isBlockedRight = false;

        vCounter = 0;
        mCounter = 0;
        //creates a state machine and gets the current sprite based on directional movement
        stateMachine = new PlayerStateMachine(playerPosition, this);
        collisionBox = new CollisionBox(CollisionObjectType.Player, 38, 38, (int)playerPosition.X, (int)playerPosition.Y);

        coinNum = 0;
        keyNum = 0;
        bombNum = 1;
    }

    public void SetSprite()
    {
        playerSprite = stateMachine.GetCurrentIdleSprite();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (playerSprite != null)
        {
            stateMachine.Draw(spriteBatch, playerSprite, (int)playerPosition.X, (int)playerPosition.Y);
        }
    }

    public void Update(GameTime gameTime)
    {
        //updates the sprite based off the change of state
        playerSprite = stateMachine.Update(gameTime);
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //!stateMachine.LinkPositionIdle() && stateMachine.currentState != PlayerState.playerDamaged ||
        if (timer >= stopTime)
        {
            stateMachine.currentState = PlayerState.playerIdle;
            timer = 0f;
        }
        else
        {
            timer += deltaTime;
        }

        collisionBox.x = (int)playerPosition.X;
        collisionBox.y = (int)playerPosition.Y;

        if (this.collisionBox.side == CollisionType.None)
        {
            isBlockedTop = false;
            isBlockedBottom = false;
            isBlockedLeft = false;
            isBlockedRight = false;
        }

        //update isV
        if (isV)
        {
            vCounter++;
            if (vCounter == 60)
            {
                isV = false;
                vCounter = 0;
            }
        }

        //update isMovable
        if (this.collisionBox.side == CollisionType.None)
        {
            mCounter++;
            if (mCounter == 50)
            {
                isMovable = true;
                mCounter = 0;
            }
        }

        //update link's speed
        velocity = 3;

        //calls the ISprite update for given sprite
        playerSprite.Update();
    }
}