using SneakyLink;
using SneakyLink.Player;
using System.Diagnostics;

public class GameExit : ICommand {

    private Game1 _game; //Reference to Game1

    //Constructor that takes in Exit
    public GameExit(Game1 exit){
        
        _game = exit;
    }

    public void Execute () {

        _game.Exit();
    }
    
}

//Moves Link to the right and changes link's sprite directionally
public class MoveRight : ICommand
{
    private Link link;

    public MoveRight(Link player){
        link = player;
    }

    public void Execute () 
    {
        link.stateMachine.currentDirection = PlayerDirection.playerRight;
        if (link.isMovable)
        {
            link.stateMachine.currentState = PlayerState.playerMoving;
            if (!link.isBlockedRight)
            {
                link.playerPosition.X += link.velocity;
            }
        }
    }
}

//Moves Link to the left and changes link's sprite directionally
public class MoveLeft : ICommand
{
    private Link link;

    public MoveLeft(Link player)
    {
        link = player;
    }

    public void Execute () 
    {
        link.stateMachine.currentDirection = PlayerDirection.playerLeft;
        if (link.isMovable)
        {
            link.stateMachine.currentState = PlayerState.playerMoving;
            if (!link.isBlockedLeft)
            {
                link.playerPosition.X -= link.velocity;
            }
        }
    }
}

//Moves link up and changes link's sprite directionally
public class MoveUp : ICommand
{
    private Link link;

    public MoveUp(Link player)
    {
        link = player;
    }

    public void Execute ()
    {   
        link.stateMachine.currentDirection = PlayerDirection.playerUp;
        if (link.isMovable)
        {
            link.stateMachine.currentState = PlayerState.playerMoving;
            if (!link.isBlockedTop)
            {
                link.playerPosition.Y -= link.velocity;
            }
        }
    }
}

//Moves link down and changes link's sprite directionally
public class MoveDown : ICommand
{
    private Link link;

    public MoveDown(Link player)
    {
        link = player;
    }

    public void Execute () 
    {   
        link.stateMachine.currentDirection = PlayerDirection.playerDown;
        if (link.isMovable)
        {
            link.stateMachine.currentState = PlayerState.playerMoving;
            if (!link.isBlockedBottom)
            {
                link.playerPosition.Y += link.velocity;
            }
        }
    }
}

// link wooden sword attack command
public class WoodenAttack : ICommand
{
    private Link link;
    private PlayerSounds playerSounds;
    public WoodenAttack(Link player, PlayerSounds sounds)
    {
        link = player;
        playerSounds = sounds;
    }

    public void Execute () 
    {   
        link.stateMachine.currentState = PlayerState.playerAttacking;

        playerSounds.PlayLinkSwordSlash();
    }
}

public class DamagePlayer : ICommand
{
    private Link link;

    public DamagePlayer(Link player)
    {
        link = player;
    }

    public void Execute () 
    {   
        link.stateMachine.currentState = PlayerState.playerDamaged;
    }
}
public class UseItem : ICommand
{
    private Link link;

    public UseItem(Link player)
    {
        link = player;
    }

    public void Execute () 
    {
        if (link.bombNum > 0)
        {
            link.bombNum--;
            link.stateMachine.currentState = PlayerState.playerUseItem;
        }
        
    }
    
}
public class DrinkRedpotion : ICommand
{
    private Link link;

    public DrinkRedpotion(Link player)
    {
        link = player;
    }

    public void Execute()
    {
        if (link.hasRedpotion && link.coinNum >= 1)
        {
            link.coinNum--;
            link.isDrinkingRedpotion = true;
        }

    }

}

    public class MuteCommand : ICommand
    {
        private Game1 _game;

        public MuteCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            _game.isMuted = !_game.isMuted;

            // Mute player sounds
            if (_game.playerSounds != null)
            {
                _game.playerSounds.SetMute(_game.isMuted);
            }

            // Mute item sounds
            if (_game.itemSounds != null)
            {
                _game.itemSounds.SetMute(_game.isMuted);
            }

            // Mute title music
            if (_game.titleScene != null)
            {
                _game.MuteTitleMusic(_game.isMuted);
            }

            Debug.WriteLine($"Game mute toggled: {(_game.isMuted ? "Muted" : "Unmuted")}");
        }
    }
    public class GoToBossRoomCommand : ICommand
    {
        private Game1 _game;

        public GoToBossRoomCommand(Game1 game)
        {
            _game = game;
        }

        public void Execute()
        {
            // Check if the boss room exists
            if (_game.roomList.ContainsKey("BossRoom"))
            {
                // Transition to the boss room
                _game.oldRoom = _game.room;
                _game.room = _game.roomList["BossRoom"];
                _game.enemies = _game.room.enemyList;
                _game.itemList = _game.room.itemList;
                _game.projectileList.Clear();

                // Update player position (adjust coordinates as needed)
                _game.link.playerPosition = new Microsoft.Xna.Framework.Vector2(200, 200);

                // Set the game state to gameplay if needed
                _game.gameState = GameState.GamePlay;

                // Log for debugging
                System.Diagnostics.Debug.WriteLine("Transitioned to the Boss Room");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Boss Room not found in roomList!");
            }
        }
    }

